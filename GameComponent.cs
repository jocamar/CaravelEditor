using Caravel.Core.Entity;
using System;
using System.Collections.Generic;
using System.Xml;

namespace CaravelEditor
{
    class GameComponent : Cv_EntityComponent
    {
        public string ComponentName;
        private Dictionary<string, Tuple<string, List<Tuple<string, string>>>> m_FieldValues;

        public void Init(string compName)
        {
            ComponentName = compName;
            m_FieldValues = new Dictionary<string, Tuple<string, List<Tuple<string, string>>>>();

            XmlNode compInfo;
            if (!EntityComponentEditor.ComponentsByName.TryGetValue(compName, out compInfo))
            {
                return;
            }

            var componentElements = compInfo.ChildNodes;

            foreach (XmlElement element in componentElements)
            {
                var name = element.Attributes["name"].Value;
                var type = element.Attributes["type"].Value;
                var fieldNames = new string[] { };

                if (element.Attributes["fieldNames"] != null)
                {
                    fieldNames = element.Attributes["fieldNames"].Value.Split(',');
                }

                var comboBoxOptions = new string[] { };

                if (element.Attributes["options"] != null)
                {
                    fieldNames = element.Attributes["options"].Value.Split(',');
                }

                var fieldList = new List<Tuple<string, string>>();

                if (type == "rgba")
                {
                    var r = new Tuple<string, string>("r", "255");
                    fieldList.Add(r);
                    var g = new Tuple<string, string>("g", "255");
                    fieldList.Add(g);
                    var b = new Tuple<string, string>("b", "255");
                    fieldList.Add(b);
                    var a = new Tuple<string, string>("a", "255");
                    fieldList.Add(a);
                }
                else
                {
                    foreach (var field in fieldNames)
                    {
                        Tuple<string, string> fieldItem = null;
                        if (type == "float")
                        {
                            fieldItem = new Tuple<string, string>(field, "0.0");
                        }
                        else if (type == "int")
                        {
                            fieldItem = new Tuple<string, string>(field, "0");
                        }
                        else if (type == "boolean")
                        {
                            fieldItem = new Tuple<string, string>(field, "False");
                        }
                        else if (type == "file" || type == "string")
                        {
                            fieldItem = new Tuple<string, string>(field, "");
                        }
                        else if (type == "comboBox")
                        {
                            fieldItem = new Tuple<string, string>(field, comboBoxOptions[0]);
                        }
                        else
                        {
                            fieldItem = new Tuple<string, string>(field, "");
                        }

                        fieldList.Add(fieldItem);
                    }
                }

                var compElementInfo = new Tuple<string, List<Tuple<string, string>>>(type, fieldList);
                m_FieldValues[name] = compElementInfo;
            }
        }
        
        public override bool VInitialize(XmlElement componentData)
        {
            XmlNode compInfo;
            if (!EntityComponentEditor.ComponentsByName.TryGetValue(componentData.Name, out compInfo))
            {
                return false;
            }

            var componentElements = compInfo.ChildNodes;

            foreach (XmlElement element in componentElements)
            {
                var name = element.Attributes["name"].Value;
                var type = element.Attributes["type"].Value;
                var fieldNames = new string[] { };

                var initializationNode = componentData.SelectSingleNode(name);

                if (initializationNode == null)
                {
                    continue;
                }

                if (element.Attributes["fieldNames"] != null)
                {
                    fieldNames = element.Attributes["fieldNames"].Value.Split(',');
                }

                var fieldList = new List<Tuple<string, string>>();

                if (type == "rgba")
                {
                    var r = new Tuple<string, string>("r", initializationNode.Attributes["r"].Value);
                    fieldList.Add(r);
                    var g = new Tuple<string, string>("g", initializationNode.Attributes["g"].Value);
                    fieldList.Add(g);
                    var b = new Tuple<string, string>("b", initializationNode.Attributes["b"].Value);
                    fieldList.Add(b);
                    var a = new Tuple<string, string>("a", "255");
                    if (initializationNode.Attributes["a"] != null)
                    {
                        a = new Tuple<string, string>("a", initializationNode.Attributes["a"].Value);
                    }
                    fieldList.Add(a);
                }
                else
                {
                    foreach (var field in fieldNames)
                    {
                        var fieldItem = new Tuple<string, string>(field, initializationNode.Attributes[field].Value);
                        fieldList.Add(fieldItem);
                    }
                }

                var compElementInfo = new Tuple<string, List<Tuple<string, string>>>(type, fieldList);
                m_FieldValues[name] = compElementInfo;
            }

            return true;
        }

        public override void VOnChanged()
        {
        }

        public override void VOnDestroy()
        {
        }

        public override bool VPostInitialize()
        {
            return true;
        }

        public override void VPostLoad()
        {
        }

        public override XmlElement VToXML()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement baseElement = doc.CreateElement(ComponentName);

            foreach (var element in m_FieldValues)
            {
                XmlElement elementNode = doc.CreateElement(element.Key);

                foreach (var field in element.Value.Item2)
                {
                    elementNode.SetAttribute(field.Item1, field.Item2);
                }

                baseElement.AppendChild(elementNode);
            }

            return baseElement;
        }

        protected override void VOnUpdate(float elapsedTime)
        {
        }
    }
}
