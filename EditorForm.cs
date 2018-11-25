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
using static Caravel.Core.Physics.Cv_GamePhysics;

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

        public string CurrentMaterial
        {
            get; private set;
        }

        public bool CanSelectEntities
        {
            get
            {
                return !m_EntityContextMenu.Visible;
            }
        }

        public string EditorDirectory
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
        private Dictionary<string, Cv_PhysicsMaterial> m_PhysicsMaterials;
        private List<string> m_PhysicsMaterialList;

        private ContextMenuStrip m_AssetContextMenu;
        private ContextMenuStrip m_EntityContextMenu;
        private ContextMenuStrip m_EntityTypesContextMenu;
        private ContextMenuStrip m_MaterialsContextMenu;

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

            ((ToolStripDropDownMenu)entityTypeToolStripMenuItem.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)entityTypeToolStripMenuItem.DropDown).ShowCheckMargin = false;

            ((ToolStripDropDownMenu)materialsToolStripMenuItem.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)materialsToolStripMenuItem.DropDown).ShowCheckMargin = false;

            /**
             * Initialize member variables
             */
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new CaravelMenuColorTable());
            editorToolStrip.Renderer = new ToolStripProfessionalRenderer(new CaravelMenuColorTable());
            m_EntityXmlNodes = new Dictionary<Cv_EntityID, XmlElement>();
            m_EntityTreeNodes = new Dictionary<Cv_EntityID, TreeNode>();
            m_ResourceBundles = new Dictionary<string, string>();
            m_EntityTypes = new Dictionary<string, string>();
            m_EntityTypeItems = new Dictionary<string, EntityTypeItem>();
            m_EntityTypeXmlNodes = new Dictionary<string, XmlElement>();
            m_OriginalEntityTypeXmlNodes = new Dictionary<string, XmlElement>();
            m_OriginalEntityTypeNodesDoc = new XmlDocument();
            m_EntityTypesList = new List<EntityTypeItem>();
            m_PhysicsMaterials = new Dictionary<string, Cv_PhysicsMaterial>();
            m_PhysicsMaterialList = new List<string>();
            editorWindow.EditorForm = this;

            materialEditorControl.Visible = false;
            materialEditorControl.PhysicsMaterials = m_PhysicsMaterials;

            /**
             * Set initial button states
             */
            createEntityToolStripMenuItem.Enabled = false;
            createEntityAsChildToolStripMenuItem.Enabled = false;
            removeEntityToolStripMenuItem.Enabled = false;
            renameEntityToolStripMenuItem.Enabled = false;
            makeEntityIntoTypeToolStripMenuItem.Enabled = false;
            exportAssetsToolStripMenuItem.Enabled = false;
            saveSceneToolStripMenuItem.Enabled = false;
            createTypeToolStripMenuItem.Enabled = false;
            removeTypeToolStripMenuItem.Enabled = false;
            addNewMaterialToolStripMenuItem.Enabled = false;
            removeMaterialToolStripMenuItem.Enabled = false;
            editSceneToolStripMenuItem.Enabled = false;

            /**
             * Create asset view right click context menu
             */
            m_AssetContextMenu = new ContextMenuStrip();
            m_AssetContextMenu.ShowImageMargin = false;
            m_AssetContextMenu.ShowCheckMargin = false;
            m_AssetContextMenu.Renderer = new ToolStripProfessionalRenderer(new CaravelMenuColorTable());
            var openItem = m_AssetContextMenu.Items.Add("Open");
            openItem.ForeColor = System.Drawing.SystemColors.Control;
            openItem.Click += new EventHandler(assetsTreeView_Open);
            var deleteItem = m_AssetContextMenu.Items.Add("Delete");
            deleteItem.ForeColor = System.Drawing.SystemColors.Control;
            deleteItem.Click += new EventHandler(assetsTreeView_Delete);

            /**
             * Create scene entities view right click context menu
             */
            m_EntityContextMenu = new ContextMenuStrip();
            m_EntityContextMenu.ShowImageMargin = false;
            m_EntityContextMenu.ShowCheckMargin = false;
            m_EntityContextMenu.Renderer = new ToolStripProfessionalRenderer(new CaravelMenuColorTable());
            var createEntityItem = m_EntityContextMenu.Items.Add("Create");
            createEntityItem.ForeColor = System.Drawing.SystemColors.Control;
            createEntityItem.Click += new EventHandler(createEntityToolStripMenuItem_Click);
            var createAsChildItem = m_EntityContextMenu.Items.Add("Create As Child");
            createAsChildItem.ForeColor = System.Drawing.SystemColors.Control;
            createAsChildItem.Click += new EventHandler(createEntityAsChildToolStripMenuItem_Click);
            var removeEntityItem = m_EntityContextMenu.Items.Add("Remove");
            removeEntityItem.ForeColor = System.Drawing.SystemColors.Control;
            removeEntityItem.Click += new EventHandler(removeEntityToolStripMenuItem_Click);
            var makeIntoTypeItem = m_EntityContextMenu.Items.Add("Make Into Type");
            makeIntoTypeItem.ForeColor = System.Drawing.SystemColors.Control;
            makeIntoTypeItem.Click += new EventHandler(makeEntityIntoTypeToolStripMenuItem_Click);
            var renameEntityItem = m_EntityContextMenu.Items.Add("Rename");
            renameEntityItem.ForeColor = System.Drawing.SystemColors.Control;
            renameEntityItem.Click += new EventHandler(renameEntityToolStripMenuItem_Click);

            /**
             * Create entity types view right click context menu
             */
            m_EntityTypesContextMenu = new ContextMenuStrip();
            m_EntityTypesContextMenu.ShowImageMargin = false;
            m_EntityTypesContextMenu.ShowCheckMargin = false;
            m_EntityTypesContextMenu.Renderer = new ToolStripProfessionalRenderer(new CaravelMenuColorTable());
            var createEntityTypeItem = m_EntityTypesContextMenu.Items.Add("Create New");
            createEntityTypeItem.ForeColor = System.Drawing.SystemColors.Control;
            createEntityTypeItem.Enabled = false;
            var removeEntityTypeItem = m_EntityTypesContextMenu.Items.Add("Remove");
            removeEntityTypeItem.ForeColor = System.Drawing.SystemColors.Control;
            removeEntityTypeItem.Click += new EventHandler(removeTypeToolStripMenuItem_Click);

            /**
             * Create materials view right click context menu
             */
            m_MaterialsContextMenu = new ContextMenuStrip();
            m_MaterialsContextMenu.ShowImageMargin = false;
            m_MaterialsContextMenu.ShowCheckMargin = false;
            m_MaterialsContextMenu.Renderer = new ToolStripProfessionalRenderer(new CaravelMenuColorTable());
            var createMaterialItem = m_MaterialsContextMenu.Items.Add("Create New");
            createMaterialItem.ForeColor = System.Drawing.SystemColors.Control;
            createMaterialItem.Click += new EventHandler(addNewMaterialToolStripMenuItem_Click);
            var removeMaterialItem = m_MaterialsContextMenu.Items.Add("Remove");
            removeMaterialItem.ForeColor = System.Drawing.SystemColors.Control;
            removeMaterialItem.Click += new EventHandler(removeMaterialToolStripMenuItem_Click);

            EditorDirectory = Directory.GetCurrentDirectory();
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

        public void InitializeTools()
        {
            cameraToolOptions.Initialize(editorWindow.EditorApp);
            transformToolOptions1.Initialize(editorWindow.EditorApp);
        }

        public void UpdateTools()
        {
            cameraToolOptions.RefreshInfo();
        }

        public void InitializeComponentEditor()
        {
            m_EntityComponentEditor = new EntityComponentEditor(sceneSplitContainer.Panel2, this, editorWindow.EditorApp);
            m_TypeComponentEditor = new EntityComponentEditor(entityTypesSplitContainer.Panel2, this, editorWindow.EditorApp);
        }

        public void InitializeMaterialsEditor()
        {
            materialEditorControl.EditorApp = editorWindow.EditorApp;
        }

        public void LoadComponentDefinitions()
        {
            m_EntityComponentEditor.Initialize();
            m_TypeComponentEditor.Initialize();
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
                var e = editorWindow.EditorApp.Logic.GetEntity(n);
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

            saveSceneToolStripMenuItem.Enabled = true;
            createEntityToolStripMenuItem.Enabled = true;
            editSceneToolStripMenuItem.Enabled = true;
            //createTypeToolStripMenuItem.Enabled = true;
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
                sceneEntitiesTreeView.SelectedNode = m_EntityTreeNodes[CurrentEntity];

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
                sceneEntitiesTreeView.SelectedNode = null;

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

        public void SetSelectedMaterial(string material)
        {
            if (material != null && material != "")
            {
                CurrentMaterial = material;
                materialEditorControl.SetMaterial(CurrentMaterial);

                if (this.editorTabs.SelectedTab == this.materialsTab)
                {
                    materialEditorControl.Visible = true;
                }

                removeMaterialToolStripMenuItem.Enabled = true;
            }
            else
            {
                CurrentMaterial = "";
                materialsListBox.SelectedIndex = -1;
                materialEditorControl.SetMaterial("");
                materialEditorControl.Visible = false;

                removeMaterialToolStripMenuItem.Enabled = false;
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
        
        public void InitializePhysicsMaterials()
        {
            m_PhysicsMaterialList.Clear();
            m_PhysicsMaterials.Clear();

            m_PhysicsMaterialList.AddRange(editorWindow.EditorApp.EditorLogic.PhysicsMaterials);

            foreach (var m in m_PhysicsMaterialList)
            {
                m_PhysicsMaterials.Add(m, editorWindow.EditorApp.EditorLogic.GetMaterial(m));
            }
            
            materialsListBox.DataSource = m_PhysicsMaterialList;
            materialsListBox.Refresh();
        }

        public void InitializeEntityTypes()
        {
            m_EntityTypesList.Clear();
            m_EntityTypeItems.Clear();
            m_EntityTypes.Clear();
            m_EntityTypeXmlNodes.Clear();
            m_OriginalEntityTypeXmlNodes.Clear();

            var resourceBundleDirectory = Path.Combine(CurrentProjectDirectory, Path.GetFileNameWithoutExtension(CurrentResourceBundle));
            var entityTypesDirectory = Path.Combine(resourceBundleDirectory, "entity_types");
            var stack = new Stack<EntityTypeItem>();
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
                    modifyXml.SetAttribute("visible", e.Value.Visible.ToString());

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

                        editorWindow.EditorApp.Logic.RemoveComponent(e.Key, componentName);
                    }

                    editorWindow.EditorApp.Logic.ModifyEntity(e.Key, modifyXml.ChildNodes);

                    m_EntityXmlNodes[e.Key] = editorWindow.EditorApp.Logic.GetEntityXML(e.Key);
                }
            }

            m_OriginalEntityTypeXmlNodes[typePath] = (XmlElement) m_OriginalEntityTypeNodesDoc.ImportNode(newTypeXml, true);
        }

        public void RepositionToolBox()
        {
            editorToolStrip.Location = new Point(editorWindow.Location.X + 10,
                                                    editorWindow.Location.Y + 10);
        }

        private void entityTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = sceneEntitiesTreeView.SelectedNode;
            if (node != null)
            {
                var entity = editorWindow.EditorApp.Logic.GetEntity(node.Name);

                if (entity.ID != CurrentEntity)
                {
                    SetSelectedEntity(entity.ID);
                }
            }
        }

        private void entityTypeListBox_AfterSelect(object sender, EventArgs e)
        {
            if (entityTypesListBox.SelectedIndex != -1)
            {
                if (CurrentEntityType != (string) entityTypesListBox.SelectedValue)
                {
                    SetSelectedEntityType((string) entityTypesListBox.SelectedValue);
                }
            }
        }

        private void materialsListBox_AfterSelect(object sender, EventArgs e)
        {
            if (materialsListBox.SelectedIndex != -1)
            {
                if (CurrentMaterial != (string) materialsListBox.SelectedValue)
                {
                    SetSelectedMaterial((string) materialsListBox.SelectedValue);
                }
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
                toolStripProjectLabel.Text = ProjectName;
                statusStrip1.Refresh();

                var bundles = root.SelectSingleNode("//ResourceBundles");
                CurrentProjectDirectory = Path.GetDirectoryName(dialog.FileName);

                foreach (XmlElement element in bundles.ChildNodes)
                {
                    var bundleId = element.Attributes["name"].Value;
                    var bundleFile = element.Attributes["file"].Value;
                    editorWindow.EditorApp.EditorLoadResourceBundle(bundleId, CurrentProjectDirectory, bundleFile, editorWindow.Editor.services);
                    m_ResourceBundles.Add(bundleFile, bundleId);
                }

                var materials = root.SelectSingleNode("//Materials");

                if (materials != null)
                {
                    editorWindow.EditorApp.EditorReadMaterials(CurrentProjectDirectory);
                    addNewMaterialToolStripMenuItem.Enabled = true;
                }

                var strings = root.SelectSingleNode("//Strings");

                if (strings != null)
                {
                    editorWindow.EditorApp.EditorReadStrings(CurrentProjectDirectory);
                }

                editorWindow.EditorApp.EForm = this;

                loadSceneToolStripMenuItem.Enabled = true;
                newSceneToolStripMenuItem.Enabled = true;

                InitializePhysicsMaterials();
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
                    toolStripSceneLabel.Text = CurrentSceneFile;
                    editorWindow.EditorApp.EWindow = editorWindow;
                    editorWindow.EditorApp.CurrentScene = CurrentSceneFile;
                    editorWindow.EditorApp.CurrentResourceBundle = m_ResourceBundles[resourceBundle];
                    editorWindow.EditorApp.Logic.ChangeState(Cv_GameState.LoadingScene);

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

        private void assetsTreeView_Open(object sender, EventArgs e)
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

        private void assetsTreeView_Delete(object sender, EventArgs e)
        {
            TreeNode node = assetsTreeView.SelectedNode;
            if (node != null && node.Nodes.Count == 0)
            {
                string file = node.Tag.ToString();
                if (File.Exists(file))
                {
                    if (assetsTreeView.SelectedNode.Parent != null)
                    {
                        File.Delete(file);
                        assetsTreeView.SelectedNode.Parent.Nodes.Remove(assetsTreeView.SelectedNode);
                        editorWindow.EditorApp.ResourceManager.RefreshResourceBundle(m_ResourceBundles[CurrentResourceBundle]);
                        m_AssetContextMenu.Hide();
                    }
                }
            }
        }

        private void assetsTreeView_RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Select the clicked node
                assetsTreeView.SelectedNode = assetsTreeView.GetNodeAt(e.X, e.Y);

                if (assetsTreeView.SelectedNode != null)
                {
                    if (assetsTreeView.SelectedNode.Parent == null)
                    {
                        m_AssetContextMenu.Items[1].Enabled = false; //Disable delete button
                    }
                    else
                    {
                        m_AssetContextMenu.Items[1].Enabled = true;
                    }

                    m_AssetContextMenu.Show(assetsTreeView, e.Location);
                }
            }
        }

        private void entityTreeView_RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && CurrentSceneFile != null && CurrentSceneFile != "")
            {
                // Select the clicked node
                var newNode = sceneEntitiesTreeView.GetNodeAt(e.X, e.Y);

                if (newNode != null)
                {
                    SetSelectedEntity(editorWindow.EditorApp.Logic.GetEntity(newNode.Name).ID);

                    foreach (ToolStripItem item in m_EntityContextMenu.Items)
                    {
                        item.Enabled = true;
                    }

                    m_EntityContextMenu.Show(sceneEntitiesTreeView, e.Location);
                }
            }
        }

        private void entityTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            var entity = editorWindow.EditorApp.Logic.GetEntity(e.Node.Name);
            if (entity != null)
            {
                entity.Visible = e.Node.Checked;

                m_EntityXmlNodes[entity.ID].SetAttribute("visible", e.Node.Checked.ToString());
            }
        }

        private void editorWindow_RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && CurrentSceneFile != null && CurrentSceneFile != "")
            {
                foreach (ToolStripItem item in m_EntityContextMenu.Items)
                {
                    item.Enabled = true;
                }

                if (CurrentEntity == Cv_EntityID.INVALID_ENTITY)
                {
                    foreach (ToolStripItem item in m_EntityContextMenu.Items)
                    {
                        if (item.Text != "Create")
                        {
                            item.Enabled = false;
                        }
                    }
                }

                m_EntityContextMenu.Show(editorWindow, e.Location);
            }
        }

        private void entityTypesListBox_RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && CurrentSceneFile != null && CurrentSceneFile != "")
            {
                // Select the clicked node
                var newItem = entityTypesListBox.IndexFromPoint(e.Location);

                if (newItem != ListBox.NoMatches)
                {
                    entityTypesListBox.SelectedIndex = newItem;

                    m_EntityTypesContextMenu.Show(entityTypesListBox, e.Location);
                }
            }
        }

        private void materialsListBox_RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && CurrentProjectDirectory != null && CurrentProjectDirectory != "")
            {
                // Select the clicked node
                var newItem = materialsListBox.IndexFromPoint(e.Location);

                if (newItem != ListBox.NoMatches)
                {
                    materialsListBox.SelectedIndex = newItem;

                    m_MaterialsContextMenu.Show(materialsListBox, e.Location);
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


        private void viewClickAreasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editorWindow.EditorApp.EditorLogic.EditorView.DebugDrawClickableAreas = !editorWindow.EditorApp.EditorLogic.EditorView.DebugDrawClickableAreas;

            if (editorWindow.EditorApp.EditorLogic.EditorView.DebugDrawClickableAreas)
            {
                viewClickAreasToolStripMenuItem.Checked = true;
            }
            else
            {
                viewClickAreasToolStripMenuItem.Checked = false;
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
                        entity = editorWindow.EditorApp.Logic.CreateEntity(form.GetEntityType(), form.GetEntityName(), m_ResourceBundles[CurrentResourceBundle]);
                    }
                    else
                    {
                        entity = editorWindow.EditorApp.Logic.CreateEmptyEntity(form.GetEntityName(), m_ResourceBundles[CurrentResourceBundle]);
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
                        entity = editorWindow.EditorApp.Logic.CreateEntity(form.GetEntityType(), form.GetEntityName(), m_ResourceBundles[CurrentResourceBundle], true, CurrentEntity);
                    }
                    else
                    {
                        entity = editorWindow.EditorApp.Logic.CreateEmptyEntity(form.GetEntityName(), m_ResourceBundles[CurrentResourceBundle], true, CurrentEntity);
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
            editorWindow.EditorApp.Logic.AddComponent(CurrentEntity, component);
            var newXml = editorWindow.EditorApp.Logic.GetEntityXML(CurrentEntity);

            if (newXml != null)
            {
                m_EntityXmlNodes[CurrentEntity] = newXml;
                m_EntityComponentEditor.ShowEntityComponents(newXml);
            }
        }

        public void RemoveComponentFromEntity(string componentName)
        {
            editorWindow.EditorApp.Logic.RemoveComponent(CurrentEntity, componentName);
            UpdateEntityXml();
        }

        public void UpdateEntityXml()
        {
            var newXml = editorWindow.EditorApp.Logic.GetEntityXML(CurrentEntity);

            if (newXml != null)
            {
                m_EntityXmlNodes[CurrentEntity] = newXml;
                m_EntityComponentEditor.ShowEntityComponents(newXml);
            }
        }

        public void AddNewEntityToEditor(Cv_Entity e, bool addParented)
        {
            TreeNode node = new TreeNode();
            node.Name = e.EntityName;
            node.Text = e.EntityName + " (" + e.EntityType + ")";
            node.Checked = e.Visible;

            XmlElement entityXml = e.ToXML();
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
                var e = editorWindow.EditorApp.Logic.GetEntity(n);
                listEntities.Add(e);
            }

            foreach (var e in listEntities)
            {
                if (e.ID != eId && e.Parent == eId)
                {
                    RemoveEntityFromEditor(e.ID);
                }
            }

            editorWindow.EditorApp.Logic.DestroyEntity(eId);
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
                    m_OriginalEntityTypeXmlNodes.Add(typeItem.Resource, (XmlElement) m_OriginalEntityTypeNodesDoc.ImportNode(entityTypeNode, true));

                    entityTypesListBox.DataSource = null;
                    entityTypesListBox.DataSource = m_EntityTypesList;

                    editorWindow.EditorApp.ResourceManager.RefreshResourceBundle(m_ResourceBundles[CurrentResourceBundle]);
                    editorWindow.EditorApp.Logic.ChangeType(CurrentEntity, form.GetTypeName(), form.GetFileName().Replace("\\", "/"));

                    var entity = editorWindow.EditorApp.Logic.GetEntity(CurrentEntity);
                    var entityTreeNode = m_EntityTreeNodes[CurrentEntity];

                    entityTreeNode.Name = entity.EntityName;
                    entityTreeNode.Text = entity.EntityName + " (" + entity.EntityType + ")";

                    m_EntityXmlNodes[entity.ID] = entity.ToXML();
                    m_EntityComponentEditor.ShowEntityComponents(m_EntityXmlNodes[entity.ID]);
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
                    editorWindow.EditorApp.Logic.ChangeType(entity.ID, "Unknown", "");

                    m_EntityXmlNodes[entity.ID] = entity.ToXML();

                    var entityTreeNode = m_EntityTreeNodes[CurrentEntity];
                    entityTreeNode.Name = entity.EntityName;
                    entityTreeNode.Text = entity.EntityName + " (" + entity.EntityType + ")";
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
            else
            {
                materialEditorControl.Visible = false;
            }
        }

        private void editorTabs_Selected(Object sender, TabControlEventArgs e)
        {
            if (e.TabPage == this.sceneTab && CurrentEntity != Cv_EntityID.INVALID_ENTITY)
            {
                m_EntityComponentEditor.ShowEntityComponents(m_EntityXmlNodes[CurrentEntity]);
            }
            else if (e.TabPage == this.entityTypesTab && CurrentEntityType != null && CurrentEntityType != "")
            {
                m_TypeComponentEditor.ShowEntityComponents(m_EntityTypeXmlNodes[CurrentEntityType]);
            }
            else if (CurrentMaterial != null && CurrentMaterial != "")
            {
                materialEditorControl.Visible = true;
            }
        }

        private void newSceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> bundleList = new List<string>();

            foreach (var bundle in m_ResourceBundles.Keys)
            {
                bundleList.Add(bundle);
            }

            using (var form = new AddSceneForm(CurrentProjectDirectory, bundleList.ToArray()))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    XmlDocument doc = new XmlDocument();

                    var sceneNode = doc.CreateElement("Scene");
                    sceneNode.SetAttribute("vWidth", form.GetWidth());
                    sceneNode.SetAttribute("vHeight", form.GetHeight());

                    var scriptNode = doc.CreateElement("Script");
                    scriptNode.SetAttribute("preLoad", form.GetPreLoadScript());
                    scriptNode.SetAttribute("postLoad", form.GetPostLoadScript());

                    doc.AppendChild(sceneNode);
                    sceneNode.AppendChild(scriptNode);

                    XmlWriterSettings oSettings = new XmlWriterSettings();
                    oSettings.Indent = true;
                    oSettings.OmitXmlDeclaration = true;
                    oSettings.Encoding = Encoding.UTF8;
                    oSettings.ConformanceLevel = ConformanceLevel.Auto;

                    string sceneLocation = form.GetFile();

                    using (XmlWriter writer = XmlWriter.Create(sceneLocation, oSettings))
                    {
                        doc.WriteContentTo(writer);
                    }

                    if (CurrentResourceBundle != null && CurrentResourceBundle != "")
                    {
                        InitializeAssets();
                    }

                    editorWindow.EditorApp.ResourceManager.RefreshResourceBundle(m_ResourceBundles[form.GetSceneResourceBundle()]);

                }
                else
                {
                    return;
                }
            }
        }

        private void renameEntityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> entityNamesList = new List<string>();

            foreach (var name in editorWindow.EditorApp.EditorLogic.EntityNamesMap.Keys)
            {
                entityNamesList.Add(name);
            }

            var entity = editorWindow.EditorApp.Logic.GetEntity(CurrentEntity);

            using (var form = new RenameEntityForm(entity.EntityName, entityNamesList.ToArray()))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    var newName = form.GetNewName();

                    editorWindow.EditorApp.Logic.ChangeName(CurrentEntity, newName);
                    var entityTreeNode = m_EntityTreeNodes[CurrentEntity];

                    entityTreeNode.Name = entity.EntityName;
                    entityTreeNode.Text = entity.EntityName + " (" + entity.EntityType + ")";

                    XmlElement entityXml = entity.ToXML();
                    if (entityXml != null)
                    {
                        m_EntityXmlNodes[entity.ID] = entityXml;
                    }
                }
            }
        }

        private void addNewMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> materialList = new List<string>();

            foreach (var material in m_PhysicsMaterials.Keys)
            {
                materialList.Add(material);
            }

            using (var form = new AddMaterialForm(materialList.ToArray()))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    m_PhysicsMaterials.Add(form.GetMaterialName(), form.GetMaterial());
                    m_PhysicsMaterialList.Add(form.GetMaterialName());

                    materialEditorControl.SaveMaterials();

                    materialsListBox.DataSource = null;
                    materialsListBox.DataSource = m_PhysicsMaterialList;
                    materialsListBox.Refresh();
                }
                else
                {
                    return;
                }
            }
        }

        private void removeMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_PhysicsMaterials.Remove(CurrentMaterial);
            m_PhysicsMaterialList.Remove(CurrentMaterial);

            SetSelectedMaterial("");

            materialEditorControl.SaveMaterials();

            materialsListBox.DataSource = null;
            materialsListBox.DataSource = m_PhysicsMaterialList;
            materialsListBox.Refresh();
        }

        private void saveSceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();

            var sceneNode = doc.CreateElement("Scene");
            sceneNode.SetAttribute("vWidth", editorWindow.EditorApp.EditorLogic.EditorView.SceneVirtualWidth.ToString());
            sceneNode.SetAttribute("vHeight", editorWindow.EditorApp.EditorLogic.EditorView.SceneVirtualHeight.ToString());

            doc.AppendChild(sceneNode);
            var entitiesNode = doc.CreateElement("StaticEntities");
            sceneNode.AppendChild(entitiesNode);
            
            foreach (TreeNode node in sceneEntitiesTreeView.Nodes)
            {
                var xmlDiff = GetEntityXmlDiff(node.Name, doc);
                var childXmlNodes = GetChildEntitiesXmlNodeDiffs(node.Name, doc);

                foreach (var childNode in childXmlNodes)
                {
                    xmlDiff.AppendChild(childNode);
                }

                entitiesNode.AppendChild(xmlDiff);
            }

            var scriptNode = doc.CreateElement("Script");
            scriptNode.SetAttribute("preLoad", editorWindow.EditorApp.EditorLogic.CurrentScenePreLoadScript);
            scriptNode.SetAttribute("postLoad", editorWindow.EditorApp.EditorLogic.CurrentScenePostLoadScript);
            sceneNode.AppendChild(scriptNode);

            XmlWriterSettings oSettings = new XmlWriterSettings();
            oSettings.Indent = true;
            oSettings.OmitXmlDeclaration = true;
            oSettings.Encoding = Encoding.UTF8;
            oSettings.ConformanceLevel = ConformanceLevel.Auto;

            string resourceBundleFullPath = Path.Combine(CurrentProjectDirectory, Path.GetFileNameWithoutExtension(CurrentResourceBundle));
            string sceneLocation = Path.Combine(resourceBundleFullPath, CurrentSceneFile);

            using (XmlWriter writer = XmlWriter.Create(sceneLocation, oSettings))
            {
                doc.WriteContentTo(writer);
            }
        }


        private void editSceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new EditSceneSettingsForm(CurrentProjectDirectory,
                                                            CurrentResourceBundle,
                                                            editorWindow.EditorApp.EditorLogic.EditorView.SceneVirtualWidth,
                                                            editorWindow.EditorApp.EditorLogic.EditorView.SceneVirtualHeight,
                                                            editorWindow.EditorApp.EditorLogic.CurrentScenePreLoadScript,
                                                            editorWindow.EditorApp.EditorLogic.CurrentScenePostLoadScript))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    editorWindow.EditorApp.EditorLogic.EditorView.SceneVirtualWidth = form.GetWidth();
                    editorWindow.EditorApp.EditorLogic.EditorView.SceneVirtualHeight = form.GetHeight();
                    editorWindow.EditorApp.EditorLogic.CurrentScenePreLoadScript = form.GetPreLoadScript();
                    editorWindow.EditorApp.EditorLogic.CurrentScenePostLoadScript = form.GetPostLoadScript();
                }
                else
                {
                    return;
                }
            }
        }

        private XmlElement GetEntityXmlDiff(string entityName, XmlDocument doc)
        {
            var entity = editorWindow.EditorApp.Logic.GetEntity(entityName);

            XmlElement typeXml;

            if (entity.EntityTypeResource == "")
            {
                typeXml = doc.CreateElement("EntityType");
            }
            else
            {
                typeXml = m_EntityTypeXmlNodes[entity.EntityTypeResource];
            }

            var diffBetweenType = EditorUtils.GetDifference(typeXml, m_EntityXmlNodes[entity.ID]);

            var entityXml = doc.CreateElement("Entity");
            entityXml.SetAttribute("name", entity.EntityName);
            entityXml.SetAttribute("type", entity.EntityTypeResource);
            entityXml.SetAttribute("visible", entity.Visible.ToString());

            if (diffBetweenType == null)
            {
                return entityXml;
            }

            var changedComponents = diffBetweenType.SelectNodes("*/Node-Changed/*");

            foreach (XmlNode component in changedComponents)
            {
                var componentNode = doc.CreateElement(component.Name);
                var changedElements = component.SelectNodes("Node-Changed");

                foreach (XmlNode element in changedElements)
                {
                    var newElement = m_EntityXmlNodes[entity.ID].SelectSingleNode(element.Attributes["xpath"].Value);

                    var importedElement = doc.ImportNode(newElement, true);
                    componentNode.AppendChild(importedElement);
                }

                entityXml.AppendChild(componentNode);
            }

            var addedComponents = diffBetweenType.SelectNodes("*/Node-Added");

            foreach (XmlNode component in addedComponents)
            {
                var componentNode = m_EntityXmlNodes[entity.ID].SelectSingleNode(component.Attributes["xpath"].Value);
                var importedComponent = doc.ImportNode(componentNode, true);

                entityXml.AppendChild(importedComponent);
            }
                
            return entityXml;
        }

        private List<XmlElement> GetChildEntitiesXmlNodeDiffs(string name, XmlDocument doc)
        {
            var entity = editorWindow.EditorApp.Logic.GetEntity(name);
            var entityTreeNode = m_EntityTreeNodes[entity.ID];
            var childList = new List<XmlElement>();

            foreach (TreeNode node in entityTreeNode.Nodes)
            {
                var entityXmlDiff = GetEntityXmlDiff(node.Name, doc);
                var childXmlNodes = GetChildEntitiesXmlNodeDiffs(node.Name, doc);

                foreach (var childNode in childXmlNodes)
                {
                    entityXmlDiff.AppendChild(childNode);
                }

                childList.Add(entityXmlDiff);
            }

            return childList;
        }

        private void toolStripButton_Clicked(object sender, MouseEventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            if (button == null) throw new InvalidCastException();
            foreach (ToolStripItem item in button.Owner.Items)
            {
                if (item is ToolStripButton)
                {
                    ((ToolStripButton)item).Checked = (item == button);
                }
            }

            if (button == editorToolsGrabButton)
            {
                editorWindow.EditorApp.Mode = EditorApp.EditorMode.TRANSFORM;
            }
            else if (button == editorToolsCameraButton)
            {
                editorWindow.EditorApp.Mode = EditorApp.EditorMode.CAMERA;
            }
            else
            {
                editorWindow.EditorApp.Mode = EditorApp.EditorMode.CREATE;
            }
        }
    }
}
