using Caravel.Core.Entity;
using Caravel.Editor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

        private Dictionary<string, string> m_ResourceBundles;
        private Dictionary<Cv_EntityID, XmlElement> m_EntityXmlNodes;
        private Dictionary<Cv_EntityID, TreeNode> m_EntityTreeNodes;
        private EntityComponentEditor m_ComponentEditor;

        public EditorForm()
        {
            InitializeComponent();
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new CaravelMenuColorTable());
            m_EntityXmlNodes = new Dictionary<Cv_EntityID, XmlElement>();
            m_EntityTreeNodes = new Dictionary<Cv_EntityID, TreeNode>();
            m_ResourceBundles = new Dictionary<string, string>();
            editorWindow.EditorForm = this;
        }

        public void InitializeComponentEditor()
        {
            m_ComponentEditor = new EntityComponentEditor(sceneSplitContainer.Panel2, this, editorWindow.EditorApp);
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

                TreeNode node = new TreeNode();
                node.Name = e.EntityName;
                node.Text = e.EntityName;

                XmlElement entityXml = editorWindow.EditorApp.EditorLogic.GetEntityXML(e.ID);
                if (entityXml != null)
                {
                    m_EntityXmlNodes.Add(e.ID, entityXml);
                }

                if (e.Parent != Cv_EntityID.INVALID_ENTITY)
                {
                    parentedEntities.Add(e);
                    m_EntityTreeNodes.Add(e.ID, node);
                }
                else
                {
                    sceneEntitiesTreeView.Nodes.Add(node);
                    m_EntityTreeNodes.Add(e.ID, node);
                }
            }

            foreach (var parentedEntity in parentedEntities)
            {
                m_EntityTreeNodes[parentedEntity.Parent].Nodes.Add(m_EntityTreeNodes[parentedEntity.ID]);
            }

            m_ComponentEditor.Initialize();
        }

        public void SetSelectedEntity(Cv_EntityID entityId)
        {
            if (entityId != Cv_EntityID.INVALID_ENTITY)
            {
                if (CurrentEntity != Cv_EntityID.INVALID_ENTITY)
                {
                    m_EntityTreeNodes[CurrentEntity].BackColor = System.Drawing.SystemColors.ControlDarkDark;
                    m_EntityTreeNodes[CurrentEntity].ForeColor = System.Drawing.SystemColors.Control;
                }

                CurrentEntity = entityId; // Game starts Entity Ids at 1

                m_EntityTreeNodes[CurrentEntity].BackColor = System.Drawing.SystemColors.ControlDark;
                m_EntityTreeNodes[CurrentEntity].ForeColor = Color.White;

                editorWindow.EditorApp.EditorLogic.EditorView.EditorSelectedEntity = entityId;

                m_ComponentEditor.ShowEntityComponents(m_EntityXmlNodes[CurrentEntity]);
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

        private void entityTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = sceneEntitiesTreeView.SelectedNode;
            if (node != null)
            {
                SetSelectedEntity(editorWindow.EditorApp.EditorLogic.GetEntity(node.Name).ID);
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

                string resourceBundle = null;
                string resourceBundleFullPath = "";
                foreach (var f in m_ResourceBundles.Keys)
                {
                    resourceBundleFullPath = Path.Combine(CurrentProjectDirectory, Path.GetFileNameWithoutExtension(f));

                    if (EditorUtils.IsSubPathOf(dialog.FileName, resourceBundleFullPath))
                    {
                        resourceBundle = f;
                        break;
                    }
                }

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
                    CurrentResourceBundle = resourceBundle;
                    CurrentSceneFile = CurrentSceneFile.Replace(resourceBundleFullPath + Path.DirectorySeparatorChar, "");
                    editorWindow.EditorApp.EWindow = editorWindow;
                    editorWindow.EditorApp.CurrentScene = CurrentSceneFile;
                    editorWindow.EditorApp.CurrentResourceBundle = m_ResourceBundles[resourceBundle];
                    editorWindow.EditorApp.EForm = this;
                    editorWindow.EditorApp.EditorLogic.ChangeState(Cv_GameState.LoadingGameEnvironment);
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
    }
}
