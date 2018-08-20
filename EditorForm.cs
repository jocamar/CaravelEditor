using Caravel.Core.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static Caravel.Core.Cv_GameLogic;
using static Caravel.Core.Entity.Cv_Entity;

namespace CaravelEditor
{
    public partial class EditorForm : Form
    {
        public string CurrentSceneFile
        {
            get; private set;
        }

        public string CurrentProjectDirectory
        {
            get; private set;
        }

        public string ProjectName
        {
            get; private set;
        }

        public string CurrentResourceBundle
        {
            get; private set;
        }

        public Cv_EntityID CurrentEntity
        {
            get; private set;
        }

        public string CurrentEntityType
        {
            get; private set;
        }

        private Dictionary<string, string> m_ResourceBundles;
        private Dictionary<Cv_EntityID, XmlElement> m_EntityXmlNodes;
        private Dictionary<Cv_EntityID, TreeNode> m_EntityTreeNodes;
        private Dictionary<string, EntityTypeItem> m_EntityTypeItems;
        private Dictionary<string, string> m_EntityTypes;
        private Dictionary<string, XmlElement> m_EntityTypeXmlNodes;
        private Dictionary<string, XmlElement> m_OriginalEntityTypeXmlNodes;
        private EntityComponentEditor m_EntityComponentEditor;
        private EntityComponentEditor m_TypeComponentEditor;
        private XmlDocument m_OriginalEntityTypeNodesDoc;
        private List<EntityTypeItem> m_EntityTypesList;

        public EditorForm()
        {
            InitializeComponent();

            ((ToolStripDropDownMenu)projectToolStripMenuItem.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)projectToolStripMenuItem.DropDown).ShowCheckMargin = false;

            ((ToolStripDropDownMenu)entityToolStripMenuItem.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)entityToolStripMenuItem.DropDown).ShowCheckMargin = false;

            ((ToolStripDropDownMenu)editToolStripMenuItem.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)editToolStripMenuItem.DropDown).ShowCheckMargin = false;

            ((ToolStripDropDownMenu)helpToolStripMenuItem.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)helpToolStripMenuItem.DropDown).ShowCheckMargin = false;

            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new CaravelMenuColorTable());
            m_EntityXmlNodes = new Dictionary<Cv_EntityID, XmlElement>();
            m_EntityTreeNodes = new Dictionary<Cv_EntityID, TreeNode>();
            m_ResourceBundles = new Dictionary<string, string>();
            m_EntityTypes = new Dictionary<string, string>();
            m_EntityTypeItems = new Dictionary<string, EntityTypeItem>();
            m_EntityTypeXmlNodes = new Dictionary<string, XmlElement>();
            m_OriginalEntityTypeXmlNodes = new Dictionary<string, XmlElement>();
            m_OriginalEntityTypeNodesDoc = new XmlDocument();
            m_EntityTypesList = new List<EntityTypeItem>();
            editorWindow.EditorForm = this;

            createEntityToolStripMenuItem.Enabled = false;
            createEntityAsChildToolStripMenuItem.Enabled = false;
            removeEntityToolStripMenuItem.Enabled = false;
            renameEntityToolStripMenuItem.Enabled = false;
            makeEntityIntoTypeToolStripMenuItem.Enabled = false;
            exportAssetsToolStripMenuItem.Enabled = false;
            saveSceneToolStripMenuItem.Enabled = false;
            addEntityTypeToolStripMenuItem.Enabled = false;
            removeTypeToolStripMenuItem.Enabled = false;
        }

        public bool TypeHasComponent(string type, string component)
        {
            if (m_EntityTypeXmlNodes.ContainsKey(type))
            {
                var typeXmlNode = m_EntityTypeXmlNodes[type];

                if (typeXmlNode.SelectNodes(component).Count > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool EntityHasComponent(Cv_EntityID entity, string component)
        {
            if (m_EntityXmlNodes.ContainsKey(entity))
            {
                var entityXmlNode = m_EntityXmlNodes[entity];

                if (entityXmlNode.SelectNodes(component).Count > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public string GetResourceBundle(string filepath)
        {
            string resourceBundle = null;
            string resourceBundleFullPath = "";
            foreach (var f in m_ResourceBundles.Keys)
            {
                resourceBundleFullPath = Path.Combine(CurrentProjectDirectory, Path.GetFileNameWithoutExtension(f));

                if (EditorUtils.IsSubPathOf(filepath, resourceBundleFullPath))
                {
                    resourceBundle = f;
                    break;
                }
            }

            return resourceBundle;
        }

        public void InitializeComponentEditor()
        {
            m_EntityComponentEditor = new EntityComponentEditor(sceneSplitContainer.Panel2, this, editorWindow.EditorApp);
            m_TypeComponentEditor = new EntityComponentEditor(entityTypesSplitContainer.Panel2, this, editorWindow.EditorApp);
        }

        public void InitializeSceneEntitiess()
        {
            sceneEntitiesTreeView.Nodes.Clear();
            m_EntityTreeNodes.Clear();
            m_EntityXmlNodes.Clear();
            CurrentEntity = Cv_EntityID.INVALID_ENTITY;

            var entityNames = editorWindow.EditorApp.EditorLogic.EntityNamesMap.Keys;

            var listEntities = new List<Cv_Entity>();
            foreach (var n in entityNames)
            {
                var e = editorWindow.EditorApp.EditorLogic.GetEntity(n);
                listEntities.Add(e);
            }
            
            var parentedEntities = new List<Cv_Entity>();

            // Add each entity as its own node in the treeview.
            foreach (var e in listEntities)
            {
                if (e.EntityName == "_editorCamera")
                {
                    continue;
                }

                if (e.Parent != Cv_EntityID.INVALID_ENTITY)
                {
                    parentedEntities.Add(e);
                }

                AddNewEntityToEditor(e, false);
            }

            foreach (var parentedEntity in parentedEntities)
            {
                m_EntityTreeNodes[parentedEntity.Parent].Nodes.Add(m_EntityTreeNodes[parentedEntity.ID]);
            }

            m_EntityComponentEditor.Initialize();
            m_TypeComponentEditor.Initialize();

            saveSceneToolStripMenuItem.Enabled = true;
            createEntityToolStripMenuItem.Enabled = true;
            addEntityTypeToolStripMenuItem.Enabled = true;
        }

        public void SetSelectedEntity(Cv_EntityID entityId)
        {
            if (CurrentEntity != Cv_EntityID.INVALID_ENTITY && m_EntityTreeNodes.ContainsKey(CurrentEntity))
            {
                m_EntityTreeNodes[CurrentEntity].BackColor = System.Drawing.SystemColors.ControlDarkDark;
                m_EntityTreeNodes[CurrentEntity].ForeColor = System.Drawing.SystemColors.Control;
            }

            if (entityId != Cv_EntityID.INVALID_ENTITY)
            {
                CurrentEntity = entityId; // Game starts Entity Ids at 1

                m_EntityTreeNodes[CurrentEntity].BackColor = System.Drawing.SystemColors.ControlDark;
                m_EntityTreeNodes[CurrentEntity].ForeColor = Color.White;

                editorWindow.EditorApp.EditorLogic.EditorView.EditorSelectedEntity = entityId;

                if (this.editorTabs.SelectedTab == this.sceneTab)
                {
                    m_EntityComponentEditor.ShowEntityComponents(m_EntityXmlNodes[CurrentEntity]);
                }

                createEntityAsChildToolStripMenuItem.Enabled = true;
                makeEntityIntoTypeToolStripMenuItem.Enabled = true;
                removeEntityToolStripMenuItem.Enabled = true;
                renameEntityToolStripMenuItem.Enabled = true;
            }
            else
            {
                CurrentEntity = Cv_EntityID.INVALID_ENTITY;
                editorWindow.EditorApp.EditorLogic.EditorView.EditorSelectedEntity = Cv_EntityID.INVALID_ENTITY;
                m_EntityComponentEditor.ShowEntityComponents(null);

                createEntityAsChildToolStripMenuItem.Enabled = false;
                makeEntityIntoTypeToolStripMenuItem.Enabled = false;
                removeEntityToolStripMenuItem.Enabled = false;
                renameEntityToolStripMenuItem.Enabled = false;
            }
        }

        public void SetSelectedEntityType(string typeResource)
        {
            if (typeResource != null)
            {
                CurrentEntityType = typeResource;
                
                if (this.editorTabs.SelectedTab == this.entityTypesTab)
                {
                    m_TypeComponentEditor.ShowEntityComponents(m_EntityTypeXmlNodes[typeResource]);
                }

                removeTypeToolStripMenuItem.Enabled = true;
            }
            else
            {
                CurrentEntityType = "";
                entityTypesListBox.SelectedIndex = -1;

                m_TypeComponentEditor.ShowEntityComponents(null);

                removeTypeToolStripMenuItem.Enabled = false;
            }
        }

        public struct EntityTypeItem
        {
            public string Type { get; set; }
            public string Resource { get; set; }

            public override string ToString()
            {
                return Type;
            }
        }

        public void InitializeAssets()
        {
            assetsTreeView.Nodes.Clear();

            var resourceBundleDirectory = Path.Combine(CurrentProjectDirectory, Path.GetFileNameWithoutExtension(CurrentResourceBundle));
            var stack = new Stack<TreeNode>();
            var rootDirectory = new DirectoryInfo(resourceBundleDirectory);
            var node = new TreeNode(rootDirectory.Name) { Tag = rootDirectory };
            stack.Push(node);

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                var directoryInfo = (DirectoryInfo)currentNode.Tag;
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    FileAttributes attributes = File.GetAttributes(directory.FullName);
                    if ((attributes & FileAttributes.Hidden) == 0)
                    {
                        var childDirectoryNode = new TreeNode(directory.Name);
                        childDirectoryNode.Tag = directory;
                        currentNode.Nodes.Add(childDirectoryNode);
                        stack.Push(childDirectoryNode);
                    }
                }

                foreach (var file in directoryInfo.GetFiles())
                {
                    FileAttributes attributes = File.GetAttributes(file.FullName);
                    if ((attributes & FileAttributes.Hidden) == 0)
                    {
                        var childNode = new TreeNode(file.Name);
                        childNode.Tag = file.FullName;
                        currentNode.Nodes.Add(childNode);
                    }
                }
            }

            assetsTreeView.Nodes.Add(node);
        }

        public void InitializeEntityTypes()
        {
            m_EntityTypesList.Clear();
            m_EntityTypeItems.Clear();
            m_EntityTypes.Clear();
            m_EntityTypeXmlNodes.Clear();
            m_OriginalEntityTypeXmlNodes.Clear();
            //entityTypesListBox.Items.Clear();

            var resourceBundleDirectory = Path.Combine(CurrentProjectDirectory, Path.GetFileNameWithoutExtension(CurrentResourceBundle));
            var entityTypesDirectory = Path.Combine(resourceBundleDirectory, "entity_types");
            var stack = new Stack<EntityTypeItem>();
            //var rootDirectory = new DirectoryInfo(entityTypesDirectory);
            var node = new EntityTypeItem { Type = Path.GetDirectoryName(entityTypesDirectory), Resource = entityTypesDirectory };
            stack.Push(node);

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                var directoryInfo = new DirectoryInfo(currentNode.Resource);

                if (directoryInfo.Exists)
                {
                    foreach (var directory in directoryInfo.GetDirectories())
                    {
                        FileAttributes attributes = File.GetAttributes(directory.FullName);
                        if ((attributes & FileAttributes.Hidden) == 0)
                        {
                            var childDirectoryNode = new EntityTypeItem { Type = directory.Name, Resource = directory.FullName };
                            stack.Push(childDirectoryNode);
                        }
                    }

                    foreach (var file in directoryInfo.GetFiles())
                    {
                        FileAttributes attributes = File.GetAttributes(file.FullName);
                        if ((attributes & FileAttributes.Hidden) == 0 && file.Extension == ".cve")
                        {
                            var xmlDoc = new XmlDocument();
                            xmlDoc.Load(file.FullName);
                            var xmlNode = xmlDoc.DocumentElement;

                            var childNode = new EntityTypeItem { Type = xmlNode.Attributes["type"].Value, Resource = file.FullName.Replace(resourceBundleDirectory + Path.DirectorySeparatorChar, "") };
                            childNode.Resource = childNode.Resource.Replace("\\", "/");
                            m_EntityTypesList.Add(childNode);
                            m_EntityTypeItems.Add(childNode.Resource, childNode);
                            m_EntityTypes.Add(childNode.Resource, file.FullName);
                            m_EntityTypeXmlNodes.Add(childNode.Resource, xmlNode);
                            var origCopy = (XmlElement)m_OriginalEntityTypeNodesDoc.ImportNode(xmlNode, true);
                            m_OriginalEntityTypeXmlNodes.Add(childNode.Resource, origCopy);
                        }
                    }
                }
            }

            entityTypesListBox.DisplayMember = "Type";
            entityTypesListBox.ValueMember = "Resource";
            entityTypesListBox.DataSource = m_EntityTypesList;
            entityTypesListBox.Refresh();
        }

        public void SyncEntitiesWithType(string type)
        {
            var typePath = type.Replace("\\", "/");
            var newTypeXml = m_EntityTypeXmlNodes[typePath];
            var oldTypeXml = m_OriginalEntityTypeXmlNodes[typePath];

            var diffBetweenType = EditorUtils.GetDifference(oldTypeXml, newTypeXml);

            if (diffBetweenType == null)
            {
                return;
            }
            
            foreach (var e in editorWindow.EditorApp.EditorLogic.EntitiesMap)
            {
                if (e.Value.EntityTypeResource == typePath)
                {
                    var entityDiff = EditorUtils.GetDifference(oldTypeXml, m_EntityXmlNodes[e.Value.ID]);

                    var modifyXml = m_EntityXmlNodes[e.Value.ID].OwnerDocument.CreateElement("Entity");
                    modifyXml.SetAttribute("name", e.Value.EntityName);
                    modifyXml.SetAttribute("type", e.Value.EntityType);

                    var changedComponents = diffBetweenType.SelectNodes("*/Node-Changed/*");

                    foreach (XmlNode component in changedComponents)
                    {
                        var componentNode = modifyXml.OwnerDocument.CreateElement(component.Name);
                        var changedElements = component.SelectNodes("Node-Changed");

                        foreach (XmlNode element in changedElements)
                        {
                            if (entityDiff != null)
                            {
                                var xpath = "//" + component.Name + "/*[@name='" + element.Attributes["name"].Value + "']";
                                var entityDiffNode = entityDiff.SelectSingleNode(xpath);
                                if (entityDiffNode != null)
                                {
                                    continue;
                                }
                            }

                            var newElement = newTypeXml.SelectSingleNode(element.Attributes["xpath"].Value.Substring(1));

                            var importedElement = modifyXml.OwnerDocument.ImportNode(newElement, true);
                            componentNode.AppendChild(importedElement);
                        }

                        modifyXml.AppendChild(componentNode);
                    }

                    var addedComponents = diffBetweenType.SelectNodes("*/Node-Added");

                    foreach (XmlNode component in addedComponents)
                    {
                        var componentNode = newTypeXml.SelectSingleNode(component.Attributes["xpath"].Value);
                        var importedComponent = modifyXml.OwnerDocument.ImportNode(componentNode, true);

                        modifyXml.AppendChild(importedComponent);
                    }

                    var removedComponents = diffBetweenType.SelectNodes("*/Node-Removed");

                    foreach (XmlNode component in removedComponents)
                    {
                        var componentName = component.Attributes["name"].Value;

                        if (entityDiff != null)
                        {
                            var xpath = "//" + componentName;
                            var entityDiffNode = entityDiff.SelectSingleNode(xpath);
                            if (entityDiffNode != null)
                            {
                                continue;
                            }
                        }

                        editorWindow.EditorApp.EditorLogic.RemoveComponent(e.Key, componentName);
                    }

                    editorWindow.EditorApp.EditorLogic.ModifyEntity(e.Key, modifyXml.ChildNodes);

                    m_EntityXmlNodes[e.Key] = editorWindow.EditorApp.EditorLogic.GetEntityXML(e.Key);
                }
            }

            m_OriginalEntityTypeXmlNodes[typePath] = (XmlElement) m_OriginalEntityTypeNodesDoc.ImportNode(newTypeXml, true);
        }

        private void entityTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = sceneEntitiesTreeView.SelectedNode;
            if (node != null)
            {
                SetSelectedEntity(editorWindow.EditorApp.EditorLogic.GetEntity(node.Name).ID);
            }
        }

        private void entityTypeListBox_AfterSelect(object sender, EventArgs e)
        {
            if (entityTypesListBox.SelectedIndex != -1)
            {
                SetSelectedEntityType((string) entityTypesListBox.SelectedValue);
            }
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            dialog.Filter = "Caravel Project files (*.cvp)|*.cvp";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var doc = new XmlDocument();
                doc.Load(dialog.FileName);
                var root = doc.FirstChild;

                ProjectName = root.Attributes["name"].Value;
                toolStripStatusLabel1.Text = ProjectName;
                statusStrip1.Refresh();

                var bundles = root.SelectSingleNode("//ResourceBundles");
                CurrentProjectDirectory = Path.GetDirectoryName(dialog.FileName);

                foreach (XmlElement element in bundles.ChildNodes)
                {
                    var bundleId = element.Attributes["name"].Value;
                    var bundleFile = element.Attributes["file"].Value;
                    editorWindow.EditorApp.EditorLoadResourceBundle(bundleId, CurrentProjectDirectory, bundleFile);
                    m_ResourceBundles.Add(bundleFile, bundleId);
                }

                var materials = root.SelectSingleNode("//Materials");

                if (materials != null)
                {
                    editorWindow.EditorApp.EditorReadMaterials(CurrentProjectDirectory);
                }
                
                loadSceneToolStripMenuItem.Enabled = true;
            }
        }

        private void loadSceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.InitialDirectory = CurrentProjectDirectory;
            dialog.Filter = "Caravel Scene files (*.cvs)|*.cvs";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CurrentSceneFile = dialog.FileName;

                string resourceBundle = GetResourceBundle(dialog.FileName);

                if (resourceBundle == null)
                {
                    string message = "Scene does not belong to any resource bundles in the current project.";
                    string caption = "Error When Loading Scene";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);
                    CurrentSceneFile = null;
                }
                else
                {
                    string resourceBundleFullPath = Path.Combine(CurrentProjectDirectory, Path.GetFileNameWithoutExtension(resourceBundle));
                    CurrentResourceBundle = resourceBundle;
                    CurrentSceneFile = CurrentSceneFile.Replace(resourceBundleFullPath + Path.DirectorySeparatorChar, "");
                    editorWindow.EditorApp.EWindow = editorWindow;
                    editorWindow.EditorApp.CurrentScene = CurrentSceneFile;
                    editorWindow.EditorApp.CurrentResourceBundle = m_ResourceBundles[resourceBundle];
                    editorWindow.EditorApp.EForm = this;
                    editorWindow.EditorApp.EditorLogic.ChangeState(Cv_GameState.LoadingScene);

                    SetSelectedEntity(Cv_EntityID.INVALID_ENTITY);
                }
            }
        }

        private void assetsTreeView_DoubleClick(object sender, MouseEventArgs e)
        {
            TreeNode node = assetsTreeView.SelectedNode;
            if (node != null && node.Nodes.Count == 0)
            {
                string file = node.Tag.ToString();
                if (File.Exists(file))
                {
                    Process.Start(file);
                }
            }
        }

        private void viewCollisionShapesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editorWindow.EditorApp.EditorLogic.EditorView.DebugDrawPhysicsShapes = !editorWindow.EditorApp.EditorLogic.EditorView.DebugDrawPhysicsShapes;

            if (editorWindow.EditorApp.EditorLogic.EditorView.DebugDrawPhysicsShapes)
            {
                viewCollisionShapesToolStripMenuItem.Checked = true;
            }
            else
            {
                viewCollisionShapesToolStripMenuItem.Checked = false;
            }
        }

        private void viewBoundingBoxesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editorWindow.EditorApp.EditorLogic.EditorView.DebugDrawPhysicsBoundingBoxes = !editorWindow.EditorApp.EditorLogic.EditorView.DebugDrawPhysicsBoundingBoxes;

            if (editorWindow.EditorApp.EditorLogic.EditorView.DebugDrawPhysicsBoundingBoxes)
            {
                viewBoundingBoxesToolStripMenuItem.Checked = true;
            }
            else
            {
                viewBoundingBoxesToolStripMenuItem.Checked = false;
            }
        }

        private void viewCamerasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editorWindow.EditorApp.EditorLogic.EditorView.DebugDrawCameras = !editorWindow.EditorApp.EditorLogic.EditorView.DebugDrawCameras;

            if (editorWindow.EditorApp.EditorLogic.EditorView.DebugDrawCameras)
            {
                viewCamerasToolStripMenuItem.Checked = true;
            }
            else
            {
                viewCamerasToolStripMenuItem.Checked = false;
            }
        }

        private void viewBoundingCirclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editorWindow.EditorApp.EditorLogic.EditorView.DebugDrawRadius = !editorWindow.EditorApp.EditorLogic.EditorView.DebugDrawRadius;

            if (editorWindow.EditorApp.EditorLogic.EditorView.DebugDrawRadius)
            {
                viewBoundingCirclesToolStripMenuItem.Checked = true;
            }
            else
            {
                viewBoundingCirclesToolStripMenuItem.Checked = false;
            }
        }

        private void createEntityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<EntityTypeItem> typeList = new List<EntityTypeItem>();
            typeList.AddRange(m_EntityTypeItems.Values);

            var namesList = editorWindow.EditorApp.EditorLogic.EntityNamesMap.Keys;

            var namesArray = new List<string>(namesList).ToArray();

            using (var form = new AddEntityForm(typeList, namesArray))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Cv_Entity entity = null;
                    if (form.TypeWasSelected())
                    {
                        entity = editorWindow.EditorApp.EditorLogic.CreateEntity(form.GetEntityType(), form.GetEntityName(), m_ResourceBundles[CurrentResourceBundle]);
                    }
                    else
                    {
                        entity = editorWindow.EditorApp.EditorLogic.CreateEmptyEntity(form.GetEntityName(), m_ResourceBundles[CurrentResourceBundle]);
                    }


                    if (entity != null)
                    {
                        AddNewEntityToEditor(entity, true);
                        SetSelectedEntity(entity.ID);
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void createEntityAsChildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<EntityTypeItem> typeList = new List<EntityTypeItem>();
            typeList.AddRange(m_EntityTypeItems.Values);

            var namesList = editorWindow.EditorApp.EditorLogic.EntityNamesMap.Keys;

            var namesArray = new List<string>(namesList).ToArray();

            using (var form = new AddEntityForm(typeList, namesArray))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Cv_Entity entity = null;
                    if (form.TypeWasSelected())
                    {
                        entity = editorWindow.EditorApp.EditorLogic.CreateEntity(form.GetEntityType(), form.GetEntityName(), m_ResourceBundles[CurrentResourceBundle], CurrentEntity);
                    }
                    else
                    {
                        entity = editorWindow.EditorApp.EditorLogic.CreateEmptyEntity(form.GetEntityName(), m_ResourceBundles[CurrentResourceBundle], CurrentEntity);
                    }


                    if (entity != null)
                    {
                        AddNewEntityToEditor(entity, true);
                        SetSelectedEntity(entity.ID);
                    }
                }
                else
                {
                    return;
                }
            }
        }

        public void AddNewComponentToEntity(Cv_EntityComponent component)
        {
            editorWindow.EditorApp.EditorLogic.AddComponent(CurrentEntity, component);
            var newXml = editorWindow.EditorApp.EditorLogic.GetEntityXML(CurrentEntity);

            if (newXml != null)
            {
                m_EntityXmlNodes[CurrentEntity] = newXml;
                m_EntityComponentEditor.ShowEntityComponents(newXml);
            }
        }

        public void RemoveComponentFromEntity(string componentName)
        {
            editorWindow.EditorApp.EditorLogic.RemoveComponent(CurrentEntity, componentName);
            var newXml = editorWindow.EditorApp.EditorLogic.GetEntityXML(CurrentEntity);

            if (newXml != null)
            {
                m_EntityXmlNodes[CurrentEntity] = newXml;
                m_EntityComponentEditor.ShowEntityComponents(newXml);
            }
        }

        private void AddNewEntityToEditor(Cv_Entity e, bool addParented)
        {
            TreeNode node = new TreeNode();
            node.Name = e.EntityName;
            node.Text = e.EntityName + " (" + e.EntityType + ")";

            XmlElement entityXml = editorWindow.EditorApp.EditorLogic.GetEntityXML(e.ID);
            if (entityXml != null)
            {
                m_EntityXmlNodes.Add(e.ID, entityXml);
            }

            if (e.Parent != Cv_EntityID.INVALID_ENTITY)
            {
                m_EntityTreeNodes.Add(e.ID, node);
                if (addParented)
                {
                    m_EntityTreeNodes[e.Parent].Nodes.Add(m_EntityTreeNodes[e.ID]);
                }
            }
            else
            {
                sceneEntitiesTreeView.Nodes.Add(node);
                m_EntityTreeNodes.Add(e.ID, node);
            }
        }

        private void RemoveEntityFromEditor(Cv_EntityID eId)
        {
            var node = m_EntityTreeNodes[eId];
            node.Remove();
            m_EntityTreeNodes.Remove(eId);

            m_EntityXmlNodes.Remove(eId);

            var entityNames = editorWindow.EditorApp.EditorLogic.EntityNamesMap.Keys;
            var listEntities = new List<Cv_Entity>();
            foreach (var n in entityNames)
            {
                var e = editorWindow.EditorApp.EditorLogic.GetEntity(n);
                listEntities.Add(e);
            }

            foreach (var e in listEntities)
            {
                if (e.ID != eId && e.Parent == eId)
                {
                    RemoveEntityFromEditor(e.ID);
                }
            }

            editorWindow.EditorApp.EditorLogic.DestroyEntity(eId);
        }

        private void removeEntityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentEntity != Cv_EntityID.INVALID_ENTITY)
            {
                RemoveEntityFromEditor(CurrentEntity);
                SetSelectedEntity(Cv_EntityID.INVALID_ENTITY);
            }
        }

        private void makeEntityIntoTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> typeList = new List<string>();

            foreach (var type in m_EntityTypeItems.Values)
            {
                typeList.Add(type.Type);
            }

            var entityXml = m_EntityXmlNodes[CurrentEntity];

            using (var form = new MakeIntoTypeForm(CurrentResourceBundle, CurrentProjectDirectory, typeList.ToArray()))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    XmlDocument doc = new XmlDocument();

                    var entityTypeNode = doc.CreateElement("EntityType");
                    entityTypeNode.SetAttribute("type", form.GetTypeName());
                    entityTypeNode.SetAttribute("resource", form.GetFileName());
                    
                    foreach (XmlNode componentNode in entityXml.ChildNodes)
                    {
                        var importedComponent = doc.ImportNode(componentNode, true);
                        entityTypeNode.AppendChild(importedComponent);
                    }

                    doc.AppendChild(entityTypeNode);

                    XmlWriterSettings oSettings = new XmlWriterSettings();
                    oSettings.Indent = true;
                    oSettings.OmitXmlDeclaration = true;
                    oSettings.Encoding = Encoding.UTF8;
                    oSettings.ConformanceLevel = ConformanceLevel.Auto;

                    string entityTypeLocation = Path.Combine(CurrentProjectDirectory, Path.GetFileNameWithoutExtension(CurrentResourceBundle));
                    entityTypeLocation = Path.Combine(entityTypeLocation, form.GetFileName());

                    using (XmlWriter writer = XmlWriter.Create(entityTypeLocation, oSettings))
                    {
                        doc.WriteContentTo(writer);
                    }

                    InitializeAssets();

                    var typeItem = new EntityTypeItem { Type = entityTypeNode.Attributes["type"].Value, Resource = entityTypeNode.Attributes["resource"].Value };
                    typeItem.Resource = typeItem.Resource.Replace("\\", "/");
                    m_EntityTypesList.Add(typeItem);
                    m_EntityTypeItems.Add(typeItem.Resource, typeItem);
                    m_EntityTypes.Add(typeItem.Resource, entityTypeLocation);
                    m_EntityTypeXmlNodes.Add(typeItem.Resource, entityTypeNode);

                    entityTypesListBox.DataSource = null;
                    entityTypesListBox.DataSource = m_EntityTypesList;

                    editorWindow.EditorApp.ResourceManager.RefreshResourceBundle(m_ResourceBundles[CurrentResourceBundle]);
                    editorWindow.EditorApp.EditorLogic.ChangeType(CurrentEntity, form.GetTypeName(), form.GetFileName());

                }
                else
                {
                    return;
                }
            }
        }

        private void removeTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Delete(m_EntityTypes[CurrentEntityType]);

            InitializeAssets();

            foreach (var entity in editorWindow.EditorApp.EditorLogic.EntityNamesMap.Values)
            {
                if (entity.EntityType == m_EntityTypeItems[CurrentEntityType].Type)
                {
                    editorWindow.EditorApp.EditorLogic.ChangeType(entity.ID, "Unknown", "");

                    m_EntityXmlNodes[entity.ID].SetAttribute("type", "");
                }
            }

            m_EntityTypesList.RemoveAll(t => t.Resource == CurrentEntityType);
            m_EntityTypeItems.Remove(CurrentEntityType);
            m_EntityTypes.Remove(CurrentEntityType);
            m_EntityTypeXmlNodes.Remove(CurrentEntityType);
            m_OriginalEntityTypeXmlNodes.Remove(CurrentEntityType);

            entityTypesListBox.DataSource = null;
            entityTypesListBox.DataSource = m_EntityTypesList;

            SetSelectedEntity(CurrentEntity);
        }

        private void editorTabs_Deselecting(Object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == this.sceneTab)
            {
                m_EntityComponentEditor.ShowEntityComponents(null);
            }
            else if (e.TabPage == this.entityTypesTab)
            {
                m_TypeComponentEditor.ShowEntityComponents(null);
            }
        }

        private void editorTabs_Selected(Object sender, TabControlEventArgs e)
        {
            if (e.TabPage == this.sceneTab && CurrentEntity != Cv_EntityID.INVALID_ENTITY)
            {
                m_EntityComponentEditor.ShowEntityComponents(m_EntityXmlNodes[CurrentEntity]);
            }
            else if (e.TabPage == this.entityTypesTab && CurrentEntityType != "")
            {
                m_TypeComponentEditor.ShowEntityComponents(m_EntityTypeXmlNodes[CurrentEntityType]);
            }
        }
    }
}
