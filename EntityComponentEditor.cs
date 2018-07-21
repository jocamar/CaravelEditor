using Caravel.Editor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace CaravelEditor
{
    public class EntityComponentEditor
    {
        private Dictionary<string, XmlNode> m_ComponentsByName;
        private XmlDocument m_SelectedEntityComponents;
        private XmlNode m_EntityXml;

        private const int m_iLabelColumnWidth = 160;
        private const int m_iElementLabelWidth = 100;
        private const int m_iLeftPaddingTitles = 20;
        private const int m_iLeftPaddingElements = 40;
        private int m_iLineSpacing;
        private Panel m_Panel;
        private EditorForm m_EditorForm;
        private EditorApp m_EditorApp;

        public EntityComponentEditor(Panel panel, EditorForm eForm, EditorApp editorApp)
        {
            m_ComponentsByName = new Dictionary<string, XmlNode>();

            m_EditorForm = eForm;
            m_EditorApp = editorApp;
            m_Panel = panel;
            m_iLineSpacing = m_Panel.Font.Height * 2;
        }

        public void Initialize()
        {
            m_ComponentsByName.Clear();
            XmlDocument componentsXML = new XmlDocument();
            var fullPath = Path.Combine(m_EditorForm.CurrentProjectDirectory, "Editor/components.xml");
            componentsXML.Load(fullPath);

            XmlElement root = componentsXML.DocumentElement;
            XmlNodeList components = root.SelectNodes("child::*");
            foreach (XmlNode component in components)
            {
                m_ComponentsByName[component.Attributes["name"].Value] = component;
            }
        }
        
        public void ShowEntityComponents(XmlNode entityXml)
        {
            m_EntityXml = entityXml;

            m_SelectedEntityComponents = new XmlDocument();
            XmlNode editorComponents = m_SelectedEntityComponents.CreateElement("Entity");
            m_SelectedEntityComponents.AppendChild(editorComponents);

            m_Panel.Controls.Clear();

            // Enables vertical scroll, disables horizontal scroll
            m_Panel.HorizontalScroll.Maximum = 0;
            m_Panel.AutoScroll = false;
            m_Panel.VerticalScroll.Visible = false;
            m_Panel.AutoScroll = true;

            XmlNodeList entityValueComponents = m_EntityXml.SelectNodes("child::*");
            int lineNum = 0;
            foreach (XmlNode entityValueComponent in entityValueComponents)
            {
                // [mrmike] - if you crash right here you have a component that you've never defined in Editor\components.xml
                XmlNode sourceEditorComponent = m_ComponentsByName[entityValueComponent.Name];
                XmlDocument ownerDoc = editorComponents.OwnerDocument;
                XmlNode editorComponent = ownerDoc.ImportNode(sourceEditorComponent, true);
                editorComponents.AppendChild(editorComponent);
                lineNum = AddComponentUI(entityValueComponent, editorComponent, lineNum);
            }
        }
        
        private XmlNode FindEditorElementFromXPath(string xpath)
        {
            XmlNode root = m_SelectedEntityComponents.FirstChild;
            XmlNodeList nodeList = root.SelectNodes(xpath);
            return nodeList[0];
        }
        
        private XmlNode FindEntityElementFromXPath(string xpath)
        {
            XmlNodeList nodeList = m_EntityXml.OwnerDocument.DocumentElement.SelectNodes(xpath);
            return nodeList[0];
        }

        public int AddComponentUI(XmlNode entityComponentValues, XmlNode editorComponentValues, int lineNum)
        {
            string componentName = entityComponentValues.Name;
            try
            {
                AddElementLabel("     " + componentName, lineNum, 0, m_Panel.Width, System.Drawing.SystemColors.ControlDark);
                ++lineNum;
                int elementNum = 0;

                foreach (XmlNode inputField in editorComponentValues)
                {
                    // FUTURE WORK - We should check for Comment style nodes here and ignore them. 
                    //               Putting comments in XML breaks this code!

                    string xpath = EditorUtils.GetXPathToNode(inputField);
                    string elementName = inputField.Attributes["name"].Value;
                    string elementType = inputField.Attributes["type"].Value;

                    XmlNode entityValues = entityComponentValues.ChildNodes[elementNum];

                    AddElementLabel(elementName, lineNum, m_iLeftPaddingElements, m_iElementLabelWidth);

                    switch (elementType)
                    {
                        case "int":
                        case "float":
                            string format = (elementType == "int") ? "0" : "0.000";
                            lineNum = AddNum(entityValues, xpath, format, lineNum);
                            ++lineNum;
                            break;

                        case "rgba":
                            lineNum = AddRGBA(entityValues, xpath, lineNum);
                            ++lineNum;
                            break;

                        case "file":
                            lineNum = AddFileElement(entityValues, xpath, lineNum);
                            ++lineNum;
                            break;

                        case "cameraProperties":
                            lineNum = AddCameraProperties(entityValues, xpath, lineNum);
                            ++lineNum;
                            break;

                        case "animationProperties":
                            lineNum = AddAnimationProperties(entityValues, xpath, lineNum);
                            ++lineNum;
                            break;
                            
                        case "physicsMaterial":
                            var physMaterials = m_EditorApp.EditorLogic.PhysicsMaterials;
                            lineNum = AddCombobox(entityValues, xpath, physMaterials, lineNum, 100);
                            break;

                        case "physicsProperties":
                            lineNum = AddPhysicsProperties(entityValues, xpath, lineNum);
                            ++lineNum;
                            break;

                        case "bodyProperties":
                            lineNum = AddBodyProperties(entityValues, xpath, lineNum);
                            ++lineNum;
                            break;

                        case "physicsShapes":
                            lineNum = AddPhysicsShapes(entityValues, xpath, lineNum);
                            ++lineNum;
                            break;

                        case "boolean":
                            List<string> options = new List<string>(new string[] { "false", "true" });
                            lineNum = AddCombobox(entityValues, xpath, options, lineNum, 60);
                            break;

                        case "comboBox":
                            lineNum = AddCombobox(entityValues, xpath, null, lineNum, 100);
                            break;

                        default:
                            lineNum = AddElementLabel(elementName + ": " + elementType + " (unknown!)", lineNum, m_iLeftPaddingElements, m_iElementLabelWidth);
                            ++lineNum;
                            break;
                    }

                    ++elementNum;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error in ComponentName " + componentName + "\n" + e.ToString());
            }

            return lineNum;
        }


        public int AddFileElement(XmlNode entityValues, string elementName, int lineNum)
        {
            const int boxWidth = 100;
            const int horizSpacing = 20;

            XmlNode fieldsElement = FindEditorElementFromXPath(elementName);
            string fieldNames = fieldsElement.Attributes["fieldNames"].Value;
            string[] fields = fieldNames.Split(',');

            foreach (var field in fields)
            {
                TextBox textBox = new TextBox();
                Point location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements, lineNum * m_iLineSpacing);
                textBox.Name = elementName + "/@" + field;
                textBox.Location = location;
                textBox.Text = entityValues.Attributes[field].Value;
                textBox.TextChanged += new EventHandler(FileElementChanged);
                textBox.ReadOnly = true;
                m_Panel.Controls.Add(textBox);

                Button button = new Button();
                location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements + boxWidth + horizSpacing, lineNum * m_iLineSpacing);
                button.Name = elementName + "/@" + field + "Button";
                button.Text = "Browse...";
                button.Location = location;
                button.MouseClick += new MouseEventHandler(SelectFile);
                m_Panel.Controls.Add(button);
            }

            return lineNum;
        }
        
        private void FileElementChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string xPath = textBox.Name;
            string newValue = textBox.Text;

            XmlDocument xmlDoc = new XmlDocument();
            XmlElement xmlEntity = xmlDoc.CreateElement("Entity");
            xmlDoc.AppendChild(xmlEntity);

            XmlAttribute xmlEntityId = xmlDoc.CreateAttribute("id");
            xmlEntityId.InnerText = m_EditorForm.CurrentEntity.ToString();
            xmlEntity.Attributes.Append(xmlEntityId);

            XmlNode elementNode = FindEntityElementFromXPath(xPath);
            XmlNode componentNode;

            if (elementNode.ParentNode == null)
            {
                XmlAttribute attribute = (XmlAttribute)elementNode;
                componentNode = attribute.OwnerElement.ParentNode;
                elementNode = attribute.OwnerElement;

                attribute.Value = newValue;
            }
            else
            {
                componentNode = elementNode.ParentNode;
                elementNode.InnerText = newValue;
            }

            string componentName = componentNode.Name;
            string elementName = elementNode.Name;

            XmlElement xmlComponent = xmlDoc.CreateElement(componentName);
            xmlEntity.AppendChild(xmlComponent);

            XmlNode newElementNode = xmlDoc.ImportNode(elementNode, true);
            xmlComponent.AppendChild(newElementNode);

            m_EditorApp.EditorLogic.ModifyEntity(m_EditorForm.CurrentEntity, xmlEntity.ChildNodes);
        }
        
        private void SelectFile(object sender, MouseEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            Button button = (Button)sender;
            string buttonDesc = "Button";
            string textBoxElementName = button.Name.Substring(0, button.Name.Length - buttonDesc.Length);
            string elementName = textBoxElementName.Substring(0, textBoxElementName.LastIndexOf("/"));
            string resourceBundleFullPath = Path.Combine(m_EditorForm.CurrentProjectDirectory, Path.GetFileNameWithoutExtension(m_EditorForm.CurrentResourceBundle));

            XmlNode fileElement = FindEditorElementFromXPath(elementName);

            openFile.Filter = fileElement.Attributes["extensions"].Value;
            openFile.ShowDialog();
            if (openFile.FileNames.Length > 0)
            {
                try
                {
                    string fileName = openFile.FileNames[0];
                    if (fileName.StartsWith(resourceBundleFullPath))
                    {
                        TextBox textBox = (TextBox)m_Panel.Controls[textBoxElementName];
                        textBox.Text = fileName.Substring(resourceBundleFullPath.Length + 1);
                    }
                    else
                    {
                        MessageBox.Show("Error - This file isn't a part of the required resource bundle (it must be in " + resourceBundleFullPath + ").");
                    }
                }
                catch
                {
                    MessageBox.Show("ElementName is incorrect in SelectFile");
                }
            }
        }

        public int AddElementLabel(string labelText, int lineNum, int padding, int width, Color? color = null)
        {
            Label label = new Label();
            Point location = new Point(padding, lineNum * m_iLineSpacing);
            label.Location = location;
            //                label.Height = m_Panel.Font.Height;
            label.Width = width;
            label.Text = labelText;
            label.TextAlign = ContentAlignment.MiddleLeft;

            if (color != null)
            {
                label.BackColor = color.Value;
            }

            m_Panel.Controls.Add(label);

            return lineNum;
        }


        protected int AddNum(XmlNode entityValues, string xpath, string format, int lineNum)
        {
            const int boxWidth = 40;
            const int charWidth = 7;
            const int horizSpacing = 10;

            XmlNode fieldsElement = FindEditorElementFromXPath(xpath);
            string fieldNames = fieldsElement.Attributes["fieldNames"].Value;
            string[] fields = fieldNames.Split(',');

            string[] editorFields = fieldsElement.Attributes["editorNames"].Value.Split(',');

            var currLoc = m_iElementLabelWidth + m_iLeftPaddingElements;

            for (var i = 0; i < fields.Length; i++)
            {
                var field = fields[i];
                var editorName = editorFields[i] + ":";

                AddElementLabel(editorName, lineNum, currLoc , charWidth * (editorName.Length+1));
                currLoc += charWidth * editorName.Length;

                TextBox textBox = new TextBox();
                Point location = new Point(currLoc, lineNum * m_iLineSpacing);
                currLoc += horizSpacing + boxWidth;
                textBox.Name = xpath + "/@" + field;

                float entityValue = Convert.ToSingle(entityValues.Attributes[field].Value, CultureInfo.InvariantCulture);
                textBox.Text = entityValue.ToString();
                textBox.Location = location;
                textBox.TextAlign = HorizontalAlignment.Right;
                textBox.Leave += new EventHandler(NumElementChanged);
                textBox.KeyDown += new KeyEventHandler(TextBoxOnKeyDown);

                textBox.Width = boxWidth;
                m_Panel.Controls.Add(textBox);
            }

            return lineNum;
        }

        private void TextBoxOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NumElementChanged(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void NumElementChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox textBox = (TextBox)sender;
                string xPath = textBox.Name;
                string newValue = textBox.Text;

                XmlDocument xmlDoc = new XmlDocument();
                XmlElement xmlEntity = xmlDoc.CreateElement("Entity");
                xmlDoc.AppendChild(xmlEntity);

                XmlAttribute xmlEntityId = xmlDoc.CreateAttribute("id");
                xmlEntityId.InnerText = m_EditorForm.CurrentEntity.ToString();
                xmlEntity.Attributes.Append(xmlEntityId);

                XmlNode elementNode;
                XmlNode node = FindEntityElementFromXPath(xPath);
                if (node.ParentNode == null)
                {
                    XmlAttribute attribute = (XmlAttribute)node;
                    elementNode = attribute.OwnerElement;

                    attribute.Value = newValue;
                }
                else
                {
                    elementNode = node;
                    elementNode.InnerText = newValue;
                }

                XmlNode componentNode = elementNode.ParentNode;

                string componentName = componentNode.Name;
                string elementName = elementNode.Name;

                XmlElement xmlComponent = xmlDoc.CreateElement(componentName);
                xmlEntity.AppendChild(xmlComponent);

                XmlNode newElementNode = xmlDoc.ImportNode(elementNode, true);
                xmlComponent.AppendChild(newElementNode);

                m_EditorApp.EditorLogic.ModifyEntity(m_EditorForm.CurrentEntity, xmlEntity.ChildNodes);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public int AddCombobox(XmlNode entityValues, string elementName, List<string> values, int lineNum, int width)
        {
            XmlNode fieldsElement = FindEditorElementFromXPath(elementName);
            string fieldNames = fieldsElement.Attributes["fieldNames"].Value;
            string[] fields = fieldNames.Split(',');

            string[] options;
            if (values == null)
            {
                options = fieldsElement.Attributes["options"].Value.Split(',');
            }
            else
            {
                options = values.ToArray();
            }

            foreach (var field in fields)
            {
                ComboBox comboBox = new ComboBox();
                Point location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements, lineNum * m_iLineSpacing);
                comboBox.Name = elementName + "/@" + field;
                comboBox.Location = location;
                comboBox.Width = width;

                foreach (string s in options)
                {
                    comboBox.Items.Add(s);
                }

                comboBox.SelectedIndex = comboBox.FindStringExact(entityValues.Attributes[field].Value);
                comboBox.SelectedIndexChanged += new EventHandler(ComboBoxElementChanged);
                m_Panel.Controls.Add(comboBox);
                lineNum++;
            }

            return lineNum;
        }

        private void ComboBoxElementChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox comboBox = (ComboBox)sender;
                string xPath = comboBox.Name;
                string newValue = comboBox.Text;

                XmlDocument xmlDoc = new XmlDocument();
                XmlElement xmlEntity = xmlDoc.CreateElement("Entity");
                xmlDoc.AppendChild(xmlEntity);

                XmlAttribute xmlEntityId = xmlDoc.CreateAttribute("id");
                xmlEntityId.InnerText = m_EditorForm.CurrentEntity.ToString();
                xmlEntity.Attributes.Append(xmlEntityId);

                XmlNode elementNode;
                XmlNode node = FindEntityElementFromXPath(xPath);
                if (node.ParentNode == null)
                {
                    XmlAttribute attribute = (XmlAttribute)node;
                    elementNode = attribute.OwnerElement;

                    attribute.Value = newValue;
                }
                else
                {
                    elementNode = node;
                    elementNode.InnerText = newValue;
                }

                XmlNode componentNode = elementNode.ParentNode;

                string componentName = componentNode.Name;
                string elementName = elementNode.Name;

                XmlElement xmlComponent = xmlDoc.CreateElement(componentName);
                xmlEntity.AppendChild(xmlComponent);

                XmlNode newElementNode = xmlDoc.ImportNode(elementNode, true);

                xmlComponent.AppendChild(newElementNode);

                m_EditorApp.EditorLogic.ModifyEntity(m_EditorForm.CurrentEntity, xmlEntity.ChildNodes);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public int AddRGBA(XmlNode entityValues, string elementName, int lineNum)
        {
            const int boxWidth = 40;
            const int horizSpacing = 20;

            TextBox textBox = new TextBox();
            Point location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements, lineNum * m_iLineSpacing);
            textBox.Name = elementName;
            textBox.Location = location;
            textBox.Width = boxWidth;
            textBox.Text = " ";

            var r = Convert.ToInt32(entityValues.Attributes["r"].Value);
            var g = Convert.ToInt32(entityValues.Attributes["g"].Value);
            var b = Convert.ToInt32(entityValues.Attributes["b"].Value);
            // FUTURE WORK - We need a text box to enter Alpha values 
            var a = Convert.ToInt32(entityValues.Attributes["a"].Value);

            textBox.BackColor = Color.FromArgb(255, (int)(r), (int)(g), (int)(b));
            textBox.TextChanged += new EventHandler(RGBAElementTextChanged);
            textBox.BackColorChanged += new EventHandler(RGBAElementChanged);
            m_Panel.Controls.Add(textBox);

            Button button = new Button();
            location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements + boxWidth + horizSpacing, lineNum * m_iLineSpacing);
            button.Name = elementName + "Button";
            button.Text = "Choose...";
            button.Location = location;
            button.MouseClick += new MouseEventHandler(SelectRGBA);
            m_Panel.Controls.Add(button);

            return lineNum;
        }


        private void RGBAElementTextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = "";
        }

        private void RGBAElementChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string xPath = textBox.Name;
            string newValue = textBox.Text;

            XmlDocument xmlDoc = new XmlDocument();
            XmlElement xmlEntity = xmlDoc.CreateElement("Entity");
            xmlDoc.AppendChild(xmlEntity);

            XmlAttribute xmlEntityId = xmlDoc.CreateAttribute("id");
            xmlEntityId.InnerText = m_EditorForm.CurrentEntity.ToString();
            xmlEntity.Attributes.Append(xmlEntityId);

            XmlNode elementNode = FindEntityElementFromXPath(xPath);
            XmlNode componentNode = elementNode.ParentNode;

            string componentName = componentNode.Name;
            string elementName = elementNode.Name;

            XmlElement xmlComponent = xmlDoc.CreateElement(componentName);
            xmlEntity.AppendChild(xmlComponent);

            XmlElement xmlElementName = xmlDoc.CreateElement(elementName);
            xmlComponent.AppendChild(xmlElementName);

            string format = "{0:0.00}";
            XmlAttribute rAttribute = xmlDoc.CreateAttribute("r");
            float r = Convert.ToSingle(textBox.BackColor.R);
            rAttribute.Value = String.Format(format, r.ToString());
            xmlElementName.Attributes.Append(rAttribute);

            XmlAttribute gAttribute = xmlDoc.CreateAttribute("g");
            float g = Convert.ToSingle(textBox.BackColor.G);
            gAttribute.Value = String.Format(format, g.ToString());
            xmlElementName.Attributes.Append(gAttribute);

            XmlAttribute bAttribute = xmlDoc.CreateAttribute("b");
            float b = Convert.ToSingle(textBox.BackColor.B);
            bAttribute.Value = String.Format(format, b.ToString());
            xmlElementName.Attributes.Append(bAttribute);

            XmlAttribute aAttribute = xmlDoc.CreateAttribute("a");
            float a = Convert.ToSingle(textBox.BackColor.A);
            aAttribute.Value = String.Format(format, a.ToString());
            xmlElementName.Attributes.Append(aAttribute);

            m_EditorApp.EditorLogic.ModifyEntity(m_EditorForm.CurrentEntity, xmlEntity.ChildNodes);
        }

        private void SelectRGBA(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            string buttonDesc = "Button";
            string textBoxElementName = button.Name.Substring(0, button.Name.Length - buttonDesc.Length);
            TextBox textBox = (TextBox)m_Panel.Controls[textBoxElementName];

            AlphaColorDialog MyDialog = new AlphaColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = textBox.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                textBox.BackColor = Color.FromArgb(255, MyDialog.Color.R, MyDialog.Color.G, MyDialog.Color.B);
            }
        }

        public int AddCameraProperties(XmlNode entityValues, string elementName, int lineNum)
        {
            const int boxWidth = 60;
            const int zoomLabelWidth = 60;
            const int isDefaultLabelWidth = 60;

            AddElementLabel("Zoom:", lineNum, m_iElementLabelWidth + m_iLeftPaddingElements, zoomLabelWidth);
            
            TextBox textBox = new TextBox();
            Point location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements + zoomLabelWidth, lineNum * m_iLineSpacing);
            textBox.Name = elementName + "/@zoom";

            float entityValue = Convert.ToSingle(entityValues.Attributes["zoom"].Value, CultureInfo.InvariantCulture);
            textBox.Text = entityValue.ToString();
            textBox.Location = location;
            textBox.TextAlign = HorizontalAlignment.Right;
            textBox.Leave += new EventHandler(NumElementChanged);
            textBox.KeyDown += new KeyEventHandler(TextBoxOnKeyDown);

            textBox.Width = boxWidth;
            m_Panel.Controls.Add(textBox);

            AddElementLabel("IsDefault:", lineNum+1, m_iElementLabelWidth + m_iLeftPaddingElements, isDefaultLabelWidth);

            List<string> options = new List<string> { "true", "false" };

            ComboBox comboBox = new ComboBox();
            location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements + isDefaultLabelWidth, (lineNum+1) * m_iLineSpacing);
            comboBox.Name = elementName + "/@defaultCamera";
            comboBox.Location = location;
            comboBox.Width = 60;

            foreach (string s in options)
            {
                comboBox.Items.Add(s);
            }

            comboBox.SelectedIndex = comboBox.FindStringExact(entityValues.Attributes["defaultCamera"].Value);
            comboBox.SelectedIndexChanged += new EventHandler(ComboBoxElementChanged);

            m_Panel.Controls.Add(comboBox);

            return lineNum + 1;
        }

        public int AddAnimationProperties(XmlNode entityValues, string elementName, int lineNum)
        {
            const int boxWidth = 35;
            const int shortLabelWidth = 45;
            const int labelWidth = 60;
            const int largeLabelWidth = 100;
            const int horizSpacing = 10;

            // ------------- Frame X ------------------------
            AddElementLabel("FX:", lineNum, m_iElementLabelWidth + m_iLeftPaddingElements, shortLabelWidth);

            TextBox textBox = new TextBox();
            Point location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements + shortLabelWidth, lineNum * m_iLineSpacing);
            textBox.Name = elementName + "/@fx";

            int frameValue = Convert.ToInt32(entityValues.Attributes["fx"].Value);
            textBox.Text = frameValue.ToString();
            textBox.Location = location;
            textBox.TextAlign = HorizontalAlignment.Right;
            textBox.Leave += new EventHandler(NumElementChanged);
            textBox.KeyDown += new KeyEventHandler(TextBoxOnKeyDown);

            textBox.Width = boxWidth;
            m_Panel.Controls.Add(textBox);

            // ------------- Frame Y ----------------------
            AddElementLabel("FY:", lineNum, m_iElementLabelWidth + m_iLeftPaddingElements + boxWidth + shortLabelWidth + horizSpacing, shortLabelWidth);

            textBox = new TextBox();
            location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements + (shortLabelWidth * 2) + boxWidth + horizSpacing, lineNum * m_iLineSpacing);
            textBox.Name = elementName + "/@fy";

            frameValue = Convert.ToInt32(entityValues.Attributes["fy"].Value);
            textBox.Text = frameValue.ToString();
            textBox.Location = location;
            textBox.TextAlign = HorizontalAlignment.Right;
            textBox.Leave += new EventHandler(NumElementChanged);
            textBox.KeyDown += new KeyEventHandler(TextBoxOnKeyDown);

            textBox.Width = boxWidth;
            m_Panel.Controls.Add(textBox);

            // New Line ----------------
            lineNum++;

            // ----------------- Looping --------------------
            AddElementLabel("Looping:", lineNum, m_iElementLabelWidth + m_iLeftPaddingElements, labelWidth);

            List<string> options = new List<string> { "true", "false" };

            ComboBox comboBox = new ComboBox();
            location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements + labelWidth, lineNum * m_iLineSpacing);
            comboBox.Name = elementName + "/@loop";
            comboBox.Location = location;
            comboBox.Width = 60;

            foreach (string s in options)
            {
                comboBox.Items.Add(s);
            }

            comboBox.SelectedIndex = comboBox.FindStringExact(entityValues.Attributes["loop"].Value);
            comboBox.SelectedIndexChanged += new EventHandler(ComboBoxElementChanged);

            m_Panel.Controls.Add(comboBox);

            // -------------------- SubAnimations ---------------------
            var subAnimations = entityValues.SelectNodes("//SubAnimation");

            if (subAnimations.Count > 0)
            {
                lineNum++;

                // ----------------- Default Anim --------------------
                AddElementLabel("Default Animation:", lineNum, m_iElementLabelWidth + m_iLeftPaddingElements, largeLabelWidth);

                options = new List<string>();

                foreach (XmlElement subAnim in subAnimations)
                {
                    options.Add(subAnim.Attributes["id"].Value);
                }

                comboBox = new ComboBox();
                location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements + largeLabelWidth, lineNum * m_iLineSpacing);
                comboBox.Name = elementName + "/@defaultAnim";
                comboBox.Location = location;
                comboBox.Width = 100;

                foreach (string s in options)
                {
                    comboBox.Items.Add(s);
                }

                comboBox.SelectedIndex = comboBox.FindStringExact(entityValues.Attributes["defaultAnim"].Value);
                comboBox.SelectedIndexChanged += new EventHandler(ComboBoxElementChanged);

                m_Panel.Controls.Add(comboBox);
            }

            for (var i = 0; i < subAnimations.Count; i++)
            {
                lineNum++;
                AddElementLabel(subAnimations[i].Attributes["id"].Value, lineNum, m_iElementLabelWidth + m_iLeftPaddingElements, largeLabelWidth);

                Button button = new Button();
                location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements + largeLabelWidth + horizSpacing, lineNum * m_iLineSpacing);
                button.Name = elementName + "/SubAnimation[" + (i+1) + "]Button";
                button.Text = "Remove";
                button.Location = location;
                //button.MouseClick += new MouseEventHandler(SelectRGBA);
                m_Panel.Controls.Add(button);

                lineNum++;

                // ------------- Start Frame ------------------------
                AddElementLabel("Start:", lineNum, m_iElementLabelWidth + (int)(m_iLeftPaddingElements*1.5f), shortLabelWidth);

                textBox = new TextBox();
                location = new Point(m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 1.5f) + shortLabelWidth, lineNum * m_iLineSpacing);
                textBox.Name = elementName + "/SubAnimation[" + (i+1) +"]/@startFrame";

                frameValue = Convert.ToInt32(subAnimations[i].Attributes["startFrame"].Value);
                textBox.Text = frameValue.ToString();
                textBox.Location = location;
                textBox.TextAlign = HorizontalAlignment.Right;
                textBox.Leave += new EventHandler(NumElementChanged);
                textBox.KeyDown += new KeyEventHandler(TextBoxOnKeyDown);

                textBox.Width = boxWidth;
                m_Panel.Controls.Add(textBox);

                // ------------- End Frame ----------------------
                AddElementLabel("End:", lineNum, m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 1.5f) + boxWidth + shortLabelWidth + horizSpacing, shortLabelWidth);

                textBox = new TextBox();
                location = new Point(m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 1.5f) + (shortLabelWidth * 2) + boxWidth + horizSpacing, lineNum * m_iLineSpacing);
                textBox.Name = elementName + "/SubAnimation[" + (i + 1) + "]/@endFrame";

                frameValue = Convert.ToInt32(subAnimations[i].Attributes["endFrame"].Value);
                textBox.Text = frameValue.ToString();
                textBox.Location = location;
                textBox.TextAlign = HorizontalAlignment.Right;
                textBox.Leave += new EventHandler(NumElementChanged);
                textBox.KeyDown += new KeyEventHandler(TextBoxOnKeyDown);

                textBox.Width = boxWidth;
                m_Panel.Controls.Add(textBox);

                lineNum++;

                // ------------- Speed ------------------------
                AddElementLabel("Speed:", lineNum, m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 1.5f), shortLabelWidth);

                textBox = new TextBox();
                location = new Point(m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 1.5f) + shortLabelWidth, lineNum * m_iLineSpacing);
                textBox.Name = elementName + "/SubAnimation[" + (i + 1) + "]/@speed";

                var speedValue = Convert.ToInt32(subAnimations[i].Attributes["speed"].Value);
                textBox.Text = speedValue.ToString();
                textBox.Location = location;
                textBox.TextAlign = HorizontalAlignment.Right;
                textBox.Leave += new EventHandler(NumElementChanged);
                textBox.KeyDown += new KeyEventHandler(TextBoxOnKeyDown);

                textBox.Width = boxWidth;
                m_Panel.Controls.Add(textBox);

            }

            lineNum++;

            Button addButton = new Button();
            location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements, lineNum * m_iLineSpacing);
            addButton.Name = elementName + "/SubAnimation_AddButton";
            addButton.Text = "Add Animation";
            addButton.Location = location;
            addButton.Width = largeLabelWidth;
            //button.MouseClick += new MouseEventHandler(SelectRGBA);
            m_Panel.Controls.Add(addButton);

            return lineNum;
        }

        public int AddPhysicsProperties(XmlNode entityValues, string elementName, int lineNum)
        {
            const int largeLabelWidth = 100;
            const int boxWidth = 40;
            AddElementLabel("UseEntityRotation:", lineNum, m_iElementLabelWidth + m_iLeftPaddingElements, largeLabelWidth);

            List<string> options = new List<string> { "true", "false" };

            ComboBox comboBox = new ComboBox();
            var location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements + largeLabelWidth, lineNum * m_iLineSpacing);
            comboBox.Name = elementName + "/@fixedRotation";
            comboBox.Location = location;
            comboBox.Width = 60;

            foreach (string s in options)
            {
                comboBox.Items.Add(s);
            }

            comboBox.SelectedIndex = comboBox.FindStringExact(entityValues.Attributes["fixedRotation"].Value);
            comboBox.SelectedIndexChanged += new EventHandler(ComboBoxElementChanged);

            m_Panel.Controls.Add(comboBox);

            lineNum++;

            AddElementLabel("Gravity Scale:", lineNum, m_iElementLabelWidth + m_iLeftPaddingElements, largeLabelWidth);

            TextBox textBox = new TextBox();
            location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements + largeLabelWidth, lineNum * m_iLineSpacing);
            textBox.Name = elementName + "/@gravityScale";

            float entityValue = Convert.ToSingle(entityValues.Attributes["gravityScale"].Value, CultureInfo.InvariantCulture);
            textBox.Text = entityValue.ToString();
            textBox.Location = location;
            textBox.TextAlign = HorizontalAlignment.Right;
            textBox.Leave += new EventHandler(NumElementChanged);
            textBox.KeyDown += new KeyEventHandler(TextBoxOnKeyDown);

            textBox.Width = boxWidth;
            m_Panel.Controls.Add(textBox);

            lineNum++;

            AddElementLabel("Max Velocity:", lineNum, m_iElementLabelWidth + m_iLeftPaddingElements, largeLabelWidth);

            textBox = new TextBox();
            location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements + largeLabelWidth, lineNum * m_iLineSpacing);
            textBox.Name = elementName + "/@maxVelocity";

            entityValue = Convert.ToSingle(entityValues.Attributes["maxVelocity"].Value, CultureInfo.InvariantCulture);
            textBox.Text = entityValue.ToString();
            textBox.Location = location;
            textBox.TextAlign = HorizontalAlignment.Right;
            textBox.Leave += new EventHandler(NumElementChanged);
            textBox.KeyDown += new KeyEventHandler(TextBoxOnKeyDown);

            textBox.Width = boxWidth;
            m_Panel.Controls.Add(textBox);

            lineNum++;

            AddElementLabel("Max Ang Velocity:", lineNum, m_iElementLabelWidth + m_iLeftPaddingElements, largeLabelWidth);

            textBox = new TextBox();
            location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements + largeLabelWidth, lineNum * m_iLineSpacing);
            textBox.Name = elementName + "/@maxAngVelocity";

            entityValue = Convert.ToSingle(entityValues.Attributes["maxAngVelocity"].Value, CultureInfo.InvariantCulture);
            textBox.Text = entityValue.ToString();
            textBox.Location = location;
            textBox.TextAlign = HorizontalAlignment.Right;
            textBox.Leave += new EventHandler(NumElementChanged);
            textBox.KeyDown += new KeyEventHandler(TextBoxOnKeyDown);

            textBox.Width = boxWidth;
            m_Panel.Controls.Add(textBox);

            return lineNum;
        }

        public int AddBodyProperties(XmlNode entityValues, string elementName, int lineNum)
        {
            const int largeLabelWidth = 100;
            const int largeLargeLabelWidth = 120;
            const int boxWidth = 40;
            AddElementLabel("Linear Damping:", lineNum, m_iElementLabelWidth + m_iLeftPaddingElements, largeLabelWidth);

            TextBox textBox = new TextBox();
            var location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements + largeLabelWidth, lineNum * m_iLineSpacing);
            textBox.Name = elementName + "/@linearDamping";

            float entityValue = Convert.ToSingle(entityValues.Attributes["linearDamping"].Value, CultureInfo.InvariantCulture);
            textBox.Text = entityValue.ToString();
            textBox.Location = location;
            textBox.TextAlign = HorizontalAlignment.Right;
            textBox.Leave += new EventHandler(NumElementChanged);
            textBox.KeyDown += new KeyEventHandler(TextBoxOnKeyDown);

            textBox.Width = boxWidth;
            m_Panel.Controls.Add(textBox);

            lineNum++;

            AddElementLabel("Angular Damping:", lineNum, m_iElementLabelWidth + m_iLeftPaddingElements, largeLabelWidth);

            textBox = new TextBox();
            location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements + largeLabelWidth, lineNum * m_iLineSpacing);
            textBox.Name = elementName + "/@angularDamping";

            entityValue = Convert.ToSingle(entityValues.Attributes["angularDamping"].Value, CultureInfo.InvariantCulture);
            textBox.Text = entityValue.ToString();
            textBox.Location = location;
            textBox.TextAlign = HorizontalAlignment.Right;
            textBox.Leave += new EventHandler(NumElementChanged);
            textBox.KeyDown += new KeyEventHandler(TextBoxOnKeyDown);

            textBox.Width = boxWidth;
            m_Panel.Controls.Add(textBox);

            lineNum++;

            AddElementLabel("Body Type:", lineNum, m_iElementLabelWidth + m_iLeftPaddingElements, largeLabelWidth);

            List<string> options = new List<string> { "dynamic", "static", "kinematic" };

            ComboBox comboBox = new ComboBox();
            location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements + largeLabelWidth, lineNum * m_iLineSpacing);
            comboBox.Name = elementName + "/@type";
            comboBox.Location = location;
            comboBox.Width = 80;

            foreach (string s in options)
            {
                comboBox.Items.Add(s);
            }

            comboBox.SelectedIndex = comboBox.FindStringExact(entityValues.Attributes["type"].Value);
            comboBox.SelectedIndexChanged += new EventHandler(ComboBoxElementChanged);

            m_Panel.Controls.Add(comboBox);

            lineNum++;

            AddElementLabel("Follow Entity Rotation:", lineNum, m_iElementLabelWidth + m_iLeftPaddingElements, largeLargeLabelWidth);

            options = new List<string> { "false", "true" };

            comboBox = new ComboBox();
            location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements + largeLargeLabelWidth, lineNum * m_iLineSpacing);
            comboBox.Name = elementName + "/@followEntityRotation";
            comboBox.Location = location;
            comboBox.Width = 60;

            foreach (string s in options)
            {
                comboBox.Items.Add(s);
            }

            comboBox.SelectedIndex = comboBox.FindStringExact(entityValues.Attributes["followEntityRotation"].Value);
            comboBox.SelectedIndexChanged += new EventHandler(ComboBoxElementChanged);

            m_Panel.Controls.Add(comboBox);


            return lineNum;
        }

        public int AddPhysicsShapes(XmlNode entityValues, string elementName, int lineNum)
        {
            var boxShapes = entityValues.SelectNodes("//Box");

            for (var i = 0; i < boxShapes.Count; i++)
            {
                var shapePath = elementName + "/Box[" + (i + 1) + "]";
                lineNum = AddBoxShape(boxShapes[i], shapePath, lineNum);
            }

            var circleShapes = entityValues.SelectNodes("//Circle");

            for (var i = 0; i < circleShapes.Count; i++)
            {
                var shapePath = elementName + "/Circle[" + (i + 1) + "]";
                lineNum = AddCircleShape(circleShapes[i], shapePath, lineNum);
            }

            var triggerShapes = entityValues.SelectNodes("//Trigger");

            for (var i = 0; i < triggerShapes.Count; i++)
            {
                var shapePath = elementName + "/Trigger[" + (i + 1) + "]";
                lineNum = AddTriggerShape(triggerShapes[i], shapePath, lineNum);
            }

            var polygonShapes = entityValues.SelectNodes("//Polygon");

            for (var i = 0; i < polygonShapes.Count; i++)
            {
                var shapePath = elementName + "/Polygon[" + (i + 1) + "]";
                lineNum = AddPolygonShape(polygonShapes[i], shapePath, lineNum);
            }


            return lineNum;
        }

        public int AddCollisionCategories(XmlNode entityValues, string elementName, int lineNum, int loc)
        {
            const int labelWidth = 100;
            const int smallLabelWidth = 60;
            const int horizSpacing = 10;
            const int comboBoxWidth = 40;

            AddElementLabel("Collision Categories", lineNum, loc, labelWidth);
            var collisionCategories = entityValues.SelectNodes("//CollisionCategory");

            loc += (int)(m_iLeftPaddingElements * 0.5);
            for (var i = 0; i < collisionCategories.Count; i++)
            {
                lineNum++;
                AddElementLabel("Category", lineNum, loc, smallLabelWidth);

                ComboBox comboBox = new ComboBox();
                var location = new Point(loc + smallLabelWidth, lineNum * m_iLineSpacing);
                comboBox.Name = elementName + "/CollisionCategory[" + (i+1) + "]/@id";
                comboBox.Location = location;
                comboBox.Width = comboBoxWidth;
                //comboBox.SelectedIndexChanged += some handler

                for (var j = 0; j < 32; j++)
                {
                    comboBox.Items.Add(j.ToString());
                }

                comboBox.SelectedIndex = comboBox.FindStringExact(collisionCategories[i].Attributes["id"].Value);

                m_Panel.Controls.Add(comboBox);

                Button removeButton = new Button();
                location = new Point(loc + smallLabelWidth + comboBoxWidth + horizSpacing, lineNum * m_iLineSpacing);
                removeButton.Name = elementName + "/CollisionCategory[" + (i+1) + "]Button";
                removeButton.Text = "Remove";
                removeButton.Location = location;
                removeButton.Width = smallLabelWidth;
                //button.MouseClick += new MouseEventHandler(SelectRGBA);
                m_Panel.Controls.Add(removeButton);
            }

            lineNum++;

            Button addButton = new Button();
            var buttonLocation = new Point(loc, lineNum * m_iLineSpacing);
            addButton.Name = elementName + "/CollisionCategory_AddButton";
            addButton.Text = "Add Category";
            addButton.Location = buttonLocation;
            addButton.Width = labelWidth;
            //button.MouseClick += new MouseEventHandler(SelectRGBA);
            m_Panel.Controls.Add(addButton);

            return lineNum;
        }

        public int AddCollidesWith(XmlNode entityValues, string elementName, int lineNum, int loc)
        {
            const int labelWidth = 100;
            const int smallLabelWidth = 60;
            const int comboBoxWidth = 40;
            const int largeComboBoxWidth = 80;

            AddElementLabel("Collides With", lineNum, loc, labelWidth);
            var collisionCategories = entityValues.SelectNodes("//CollidesWith");

            loc += (int)(m_iLeftPaddingElements * 0.5);
            for (var i = 0; i < collisionCategories.Count; i++)
            {
                lineNum++;
                AddElementLabel("Category", lineNum, loc, smallLabelWidth);

                ComboBox comboBox = new ComboBox();
                var location = new Point(loc + smallLabelWidth, lineNum * m_iLineSpacing);
                comboBox.Name = elementName + "/CollidesWith[" + (i + 1) + "]/@id";
                comboBox.Location = location;
                comboBox.Width = comboBoxWidth;

                for (var j = 0; j < 32; j++)
                {
                    comboBox.Items.Add(j.ToString());
                }

                comboBox.SelectedIndex = comboBox.FindStringExact(collisionCategories[i].Attributes["id"].Value);
                comboBox.SelectedIndexChanged += new EventHandler(ComboBoxElementChanged);

                m_Panel.Controls.Add(comboBox);

                lineNum++;
                AddElementLabel("Direction", lineNum, loc, smallLabelWidth);

                comboBox = new ComboBox();
                location = new Point(loc + smallLabelWidth, lineNum * m_iLineSpacing);
                comboBox.Name = elementName + "/CollidesWith[" + (i + 1) + "]/@directions";
                comboBox.Location = location;
                comboBox.Width = largeComboBoxWidth;

                var options = new string[] { "All",
                                            "Left",
                                            "Right",
                                            "Top",
                                            "Bottom",
                                            "LeftRight",
                                            "LeftTop",
                                            "LeftBottom",
                                            "RightTop",
                                            "RightBottom",
                                            "TopBottom",
                                            "LeftRightTop",
                                            "LeftRightBottom",
                                            "LeftTopBottom",
                                            "RightTopBottom" };
                foreach (var o in options)
                {
                    comboBox.Items.Add(o);
                }

                comboBox.SelectedIndex = comboBox.FindStringExact(collisionCategories[i].Attributes["directions"].Value);
                comboBox.SelectedIndexChanged += new EventHandler(ComboBoxElementChanged);

                m_Panel.Controls.Add(comboBox);

                lineNum++;

                Button removeButton = new Button();
                location = new Point(loc, lineNum * m_iLineSpacing);
                removeButton.Name = elementName + "/CollidesWith[" + (i + 1) + "]Button";
                removeButton.Text = "Remove";
                removeButton.Location = location;
                removeButton.Width = smallLabelWidth;
                //button.MouseClick += new MouseEventHandler(SelectRGBA);
                m_Panel.Controls.Add(removeButton);
            }

            lineNum++;

            Button addButton = new Button();
            var buttonLocation = new Point(loc, lineNum * m_iLineSpacing);
            addButton.Name = elementName + "/CollidesWith_AddButton";
            addButton.Text = "Add Category";
            addButton.Location = buttonLocation;
            addButton.Width = labelWidth;
            //button.MouseClick += new MouseEventHandler(SelectRGBA);
            m_Panel.Controls.Add(addButton);

            return lineNum;
        }

        public int AddBoxShape(XmlNode entityValues, string elementName, int lineNum)
        {
            const int labelWidth = 50;
            const int charWidth = 7;
            const int horizSpacing = 10;
            const int boxWidth = 40;

            AddElementLabel("Box", lineNum, m_iElementLabelWidth + m_iLeftPaddingElements, labelWidth);

            lineNum = AddCommonShapeElements(entityValues, elementName, lineNum);

            // ------------------ New Line -----------------------------
            var currLoc = m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 1.5f);
            lineNum++;
            // ----------------------------------------------------------

            AddElementLabel("Size", lineNum, currLoc, labelWidth);
            currLoc += labelWidth;

            AddElementLabel("X:", lineNum, currLoc, charWidth * 3);
            currLoc += charWidth * 3;

            var textBox = new TextBox();
            var location = new Point(currLoc, lineNum * m_iLineSpacing);
            currLoc += boxWidth + horizSpacing;
            textBox.Name = elementName + "/@dimensionsX";

            var entityValue = Convert.ToInt32(entityValues.Attributes["dimensionsX"].Value);
            textBox.Text = entityValue.ToString();
            textBox.Location = location;
            textBox.TextAlign = HorizontalAlignment.Right;
            textBox.Leave += new EventHandler(NumElementChanged);
            textBox.KeyDown += new KeyEventHandler(TextBoxOnKeyDown);

            textBox.Width = boxWidth;
            m_Panel.Controls.Add(textBox);

            AddElementLabel("Y:", lineNum, currLoc, charWidth * 3);
            currLoc += charWidth * 3;

            textBox = new TextBox();
            location = new Point(currLoc, lineNum * m_iLineSpacing);
            textBox.Name = elementName + "/@dimensionsY";

            entityValue = Convert.ToInt32(entityValues.Attributes["dimensionsY"].Value);
            textBox.Text = entityValue.ToString();
            textBox.Location = location;
            textBox.TextAlign = HorizontalAlignment.Right;
            textBox.Leave += new EventHandler(NumElementChanged);
            textBox.KeyDown += new KeyEventHandler(TextBoxOnKeyDown);

            textBox.Width = boxWidth;
            m_Panel.Controls.Add(textBox);

            // ------------------ New Line -----------------------------
            currLoc = m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 1.5f);
            lineNum++;
            // ----------------------------------------------------------

            lineNum = AddCollisionCategories(entityValues, elementName, lineNum, currLoc);

            // ------------------ New Line -----------------------------
            currLoc = m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 1.5f);
            lineNum++;
            // ----------------------------------------------------------

            lineNum = AddCollidesWith(entityValues, elementName, lineNum, currLoc);

            return lineNum;
        }

        public int AddCircleShape(XmlNode entityValues, string elementName, int lineNum)
        {
            const int labelWidth = 50;
            const int charWidth = 7;
            const int horizSpacing = 10;
            const int boxWidth = 40;

            AddElementLabel("Circle", lineNum, m_iElementLabelWidth + m_iLeftPaddingElements, labelWidth);

            lineNum = AddCommonShapeElements(entityValues, elementName, lineNum);

            // ------------------ New Line -----------------------------
            var currLoc = m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 1.5f);
            lineNum++;
            // ----------------------------------------------------------

            AddElementLabel("Radius", lineNum, currLoc, charWidth * 7);
            currLoc += charWidth * 7;

            var textBox = new TextBox();
            var location = new Point(currLoc, lineNum * m_iLineSpacing);
            currLoc += boxWidth + horizSpacing;
            textBox.Name = elementName + "/@radius";

            var entityValue = Convert.ToInt32(entityValues.Attributes["radius"].Value);
            textBox.Text = entityValue.ToString();
            textBox.Location = location;
            textBox.TextAlign = HorizontalAlignment.Right;
            textBox.Leave += new EventHandler(NumElementChanged);
            textBox.KeyDown += new KeyEventHandler(TextBoxOnKeyDown);

            textBox.Width = boxWidth;
            m_Panel.Controls.Add(textBox);

            // ------------------ New Line -----------------------------
            currLoc = m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 1.5f);
            lineNum++;
            // ----------------------------------------------------------

            lineNum = AddCollisionCategories(entityValues, elementName, lineNum, currLoc);

            // ------------------ New Line -----------------------------
            currLoc = m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 1.5f);
            lineNum++;
            // ----------------------------------------------------------

            lineNum = AddCollidesWith(entityValues, elementName, lineNum, currLoc);

            return lineNum;
        }

        public int AddPolygonShape(XmlNode entityValues, string elementName, int lineNum)
        {
            const int labelWidth = 50;
            const int charWidth = 7;
            const int horizSpacing = 10;
            const int boxWidth = 40;

            AddElementLabel("Polygon", lineNum, m_iElementLabelWidth + m_iLeftPaddingElements, labelWidth);

            lineNum = AddCommonShapeElements(entityValues, elementName, lineNum);

            var points = entityValues.SelectNodes("//Point");

            var currLoc = 0;

            for (var i = 0; i < points.Count; i++)
            {
                // ------------------ New Line -----------------------------
                currLoc = m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 1.5f);
                lineNum++;
                // ----------------------------------------------------------

                AddElementLabel("Point" + i, lineNum, currLoc, charWidth * 7);
                currLoc += charWidth * 7;

                AddElementLabel("X:", lineNum, currLoc, charWidth * 3);
                currLoc += charWidth * 3;

                var textBox = new TextBox();
                var location = new Point(currLoc, lineNum * m_iLineSpacing);
                currLoc += boxWidth + horizSpacing;
                textBox.Name = elementName + "/Point[" + (i+1) + "]/@x";

                var entityValue = Convert.ToInt32(points[i].Attributes["x"].Value);
                textBox.Text = entityValue.ToString();
                textBox.Location = location;
                textBox.TextAlign = HorizontalAlignment.Right;
                textBox.Leave += new EventHandler(NumElementChanged);
                textBox.KeyDown += new KeyEventHandler(TextBoxOnKeyDown);

                textBox.Width = boxWidth;
                m_Panel.Controls.Add(textBox);

                AddElementLabel("Y:", lineNum, currLoc, charWidth * 3);
                currLoc += charWidth * 3;

                textBox = new TextBox();
                location = new Point(currLoc, lineNum * m_iLineSpacing);
                textBox.Name = elementName + "/Point[" + (i + 1) + "]/@y";

                entityValue = Convert.ToInt32(points[i].Attributes["y"].Value);
                textBox.Text = entityValue.ToString();
                textBox.Location = location;
                textBox.TextAlign = HorizontalAlignment.Right;
                textBox.Leave += new EventHandler(NumElementChanged);
                textBox.KeyDown += new KeyEventHandler(TextBoxOnKeyDown);

                textBox.Width = boxWidth;
                m_Panel.Controls.Add(textBox);

                // ------------------ New Line -----------------------------
                currLoc = m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 2f);
                lineNum++;
                // ----------------------------------------------------------

                Button removeButton = new Button();
                location = new Point(currLoc, lineNum * m_iLineSpacing);
                removeButton.Name = elementName + "/Point[" + (i + 1) + "]Button";
                removeButton.Text = "Remove";
                removeButton.Location = location;
                removeButton.Width = 60;
                //button.MouseClick += new MouseEventHandler(SelectRGBA);
                m_Panel.Controls.Add(removeButton);
            }

            // ------------------ New Line -----------------------------
            currLoc = m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 1.5f);
            lineNum++;
            // ----------------------------------------------------------

            Button addButton = new Button();
            var buttonLocation = new Point(currLoc, lineNum * m_iLineSpacing);
            addButton.Name = elementName + "/Point_AddButton";
            addButton.Text = "Add Point";
            addButton.Location = buttonLocation;
            addButton.Width = 100;
            //button.MouseClick += new MouseEventHandler(SelectRGBA);
            m_Panel.Controls.Add(addButton);

            // ------------------ New Line -----------------------------
            currLoc = m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 1.5f);
            lineNum++;
            // ----------------------------------------------------------

            lineNum = AddCollisionCategories(entityValues, elementName, lineNum, currLoc);

            // ------------------ New Line -----------------------------
            currLoc = m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 1.5f);
            lineNum++;
            // ----------------------------------------------------------

            lineNum = AddCollidesWith(entityValues, elementName, lineNum, currLoc);

            return lineNum;
        }

        public int AddTriggerShape(XmlNode entityValues, string elementName, int lineNum)
        {
            const int labelWidth = 50;
            const int charWidth = 7;
            const int horizSpacing = 10;
            const int boxWidth = 40;

            AddElementLabel("Trigger", lineNum, m_iElementLabelWidth + m_iLeftPaddingElements, labelWidth);

            lineNum = AddCommonShapeElements(entityValues, elementName, lineNum);

            // ------------------ New Line -----------------------------
            var currLoc = m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 1.5f);
            lineNum++;
            // ----------------------------------------------------------

            AddElementLabel("Size", lineNum, currLoc, charWidth * 5);
            currLoc += charWidth * 5;

            var textBox = new TextBox();
            var location = new Point(currLoc, lineNum * m_iLineSpacing);
            currLoc += boxWidth + horizSpacing;
            textBox.Name = elementName + "/@dimensions";

            var entityValue = Convert.ToInt32(entityValues.Attributes["dimensions"].Value);
            textBox.Text = entityValue.ToString();
            textBox.Location = location;
            textBox.TextAlign = HorizontalAlignment.Right;
            textBox.Leave += new EventHandler(NumElementChanged);
            textBox.KeyDown += new KeyEventHandler(TextBoxOnKeyDown);

            textBox.Width = boxWidth;
            m_Panel.Controls.Add(textBox);

            // ------------------ New Line -----------------------------
            currLoc = m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 1.5f);
            lineNum++;
            // ----------------------------------------------------------

            lineNum = AddCollisionCategories(entityValues, elementName, lineNum, currLoc);

            // ------------------ New Line -----------------------------
            currLoc = m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 1.5f);
            lineNum++;
            // ----------------------------------------------------------

            lineNum = AddCollidesWith(entityValues, elementName, lineNum, currLoc);

            return lineNum;
        }

        private int AddCommonShapeElements(XmlNode entityValues, string elementName, int lineNum)
        {
            const int labelWidth = 50;
            const int charWidth = 7;
            const int horizSpacing = 10;
            const int boxWidth = 40;

            Button button = new Button();
            var location = new Point(m_iElementLabelWidth + m_iLeftPaddingElements + labelWidth + horizSpacing, lineNum * m_iLineSpacing);
            button.Name = elementName + "Button";
            button.Text = "Remove";
            button.Location = location;
            //button.MouseClick += new MouseEventHandler(SelectRGBA);
            m_Panel.Controls.Add(button);

            // ------------------ New Line -----------------------------
            lineNum++;
            var currLoc = m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 1.5f);
            // ----------------------------------------------------------

            AddElementLabel("Origin", lineNum, currLoc, labelWidth);
            currLoc += labelWidth;

            AddElementLabel("X:", lineNum, currLoc, charWidth * 3);
            currLoc += charWidth * 3;

            TextBox textBox = new TextBox();
            location = new Point(currLoc, lineNum * m_iLineSpacing);
            currLoc += boxWidth + horizSpacing;
            textBox.Name = elementName + "/@anchorX";

            var entityValue = Convert.ToInt32(entityValues.Attributes["anchorX"].Value);
            textBox.Text = entityValue.ToString();
            textBox.Location = location;
            textBox.TextAlign = HorizontalAlignment.Right;
            textBox.Leave += new EventHandler(NumElementChanged);
            textBox.KeyDown += new KeyEventHandler(TextBoxOnKeyDown);

            textBox.Width = boxWidth;
            m_Panel.Controls.Add(textBox);

            AddElementLabel("Y:", lineNum, currLoc, charWidth * 3);
            currLoc += charWidth * 3;

            textBox = new TextBox();
            location = new Point(currLoc, lineNum * m_iLineSpacing);
            textBox.Name = elementName + "/@anchorY";

            entityValue = Convert.ToInt32(entityValues.Attributes["anchorY"].Value);
            textBox.Text = entityValue.ToString();
            textBox.Location = location;
            textBox.TextAlign = HorizontalAlignment.Right;
            textBox.Leave += new EventHandler(NumElementChanged);
            textBox.KeyDown += new KeyEventHandler(TextBoxOnKeyDown);

            textBox.Width = boxWidth;
            m_Panel.Controls.Add(textBox);

            // ------------------ New Line -------------------------------
            currLoc = m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 1.5f);
            lineNum++;
            // ----------------------------------------------------------

            AddElementLabel("IsBullet", lineNum, currLoc, labelWidth);
            currLoc += labelWidth;

            List<string> options = new List<string> { "false", "true" };

            ComboBox comboBox = new ComboBox();
            location = new Point(currLoc, lineNum * m_iLineSpacing);
            comboBox.Name = elementName + "/@isBullet";
            comboBox.Location = location;
            comboBox.Width = 60;

            foreach (string s in options)
            {
                comboBox.Items.Add(s);
            }

            comboBox.SelectedIndex = comboBox.FindStringExact(entityValues.Attributes["isBullet"].Value);
            comboBox.SelectedIndexChanged += new EventHandler(ComboBoxElementChanged);

            m_Panel.Controls.Add(comboBox);

            // ------------------ New Line -----------------------------
            currLoc = m_iElementLabelWidth + (int)(m_iLeftPaddingElements * 1.5f);
            lineNum++;
            // ----------------------------------------------------------

            var physMaterials = m_EditorApp.EditorLogic.PhysicsMaterials;
            AddElementLabel("Material", lineNum, currLoc, labelWidth);
            currLoc += labelWidth;

            comboBox = new ComboBox();
            location = new Point(currLoc, lineNum * m_iLineSpacing);
            comboBox.Name = elementName + "/@material";
            comboBox.Location = location;
            comboBox.Width = 80;

            foreach (string s in physMaterials)
            {
                comboBox.Items.Add(s);
            }

            comboBox.SelectedIndex = comboBox.FindStringExact(entityValues.Attributes["material"].Value);
            comboBox.SelectedIndexChanged += new EventHandler(ComboBoxElementChanged);

            m_Panel.Controls.Add(comboBox);

            return lineNum;
        }
    };
}
