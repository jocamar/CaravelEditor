using System.Windows.Forms;

namespace CaravelEditor
{
    partial class EditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAssetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCollisionShapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewBoundingBoxesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCamerasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewBoundingCirclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEntityTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewMaterialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeMaterialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createEntityAsChildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeEntityIntoTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorTabs = new Dotnetrix.Controls.TabControlEX();
            this.sceneTab = new System.Windows.Forms.TabPage();
            this.sceneSplitContainer = new System.Windows.Forms.SplitContainer();
            this.sceneEntitiesTreeView = new System.Windows.Forms.TreeView();
            this.entityTypesTab = new System.Windows.Forms.TabPage();
            this.entityTypesSplitContainer = new System.Windows.Forms.SplitContainer();
            this.entityTypesListBox = new System.Windows.Forms.ListBox();
            this.materialsTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.assetsTreeView = new System.Windows.Forms.TreeView();
            this.AssetsLabelPanel = new System.Windows.Forms.Panel();
            this.AssetsLabel = new System.Windows.Forms.Label();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.editorWindow = new CaravelEditor.EditorWindow();
            this.controlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBundleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeBundleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.editorTabs.SuspendLayout();
            this.sceneTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sceneSplitContainer)).BeginInit();
            this.sceneSplitContainer.Panel1.SuspendLayout();
            this.sceneSplitContainer.SuspendLayout();
            this.entityTypesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entityTypesSplitContainer)).BeginInit();
            this.entityTypesSplitContainer.Panel1.SuspendLayout();
            this.entityTypesSplitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.AssetsLabelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 698);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1280, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(128, 17);
            this.toolStripStatusLabel1.Text = "Open a project to start.";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.editToolStripMenuItem,
            this.entityToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1280, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.newSceneToolStripMenuItem,
            this.loadSceneToolStripMenuItem,
            this.saveSceneToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exportAssetsToolStripMenuItem,
            this.newBundleToolStripMenuItem,
            this.removeBundleToolStripMenuItem});
            this.projectToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.newProjectToolStripMenuItem.Enabled = false;
            this.newProjectToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.newProjectToolStripMenuItem.Text = "New Project";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.openToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.openToolStripMenuItem.Text = "Open Project";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // newSceneToolStripMenuItem
            // 
            this.newSceneToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.newSceneToolStripMenuItem.Enabled = false;
            this.newSceneToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.newSceneToolStripMenuItem.Name = "newSceneToolStripMenuItem";
            this.newSceneToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.newSceneToolStripMenuItem.Text = "New Scene";
            // 
            // loadSceneToolStripMenuItem
            // 
            this.loadSceneToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loadSceneToolStripMenuItem.Enabled = false;
            this.loadSceneToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.loadSceneToolStripMenuItem.Name = "loadSceneToolStripMenuItem";
            this.loadSceneToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.loadSceneToolStripMenuItem.Text = "Load Scene";
            this.loadSceneToolStripMenuItem.Click += new System.EventHandler(this.loadSceneToolStripMenuItem_Click);
            // 
            // saveSceneToolStripMenuItem
            // 
            this.saveSceneToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.saveSceneToolStripMenuItem.Enabled = false;
            this.saveSceneToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.saveSceneToolStripMenuItem.Name = "saveSceneToolStripMenuItem";
            this.saveSceneToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.saveSceneToolStripMenuItem.Text = "Save Scene";
            // 
            // exportAssetsToolStripMenuItem
            // 
            this.exportAssetsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.exportAssetsToolStripMenuItem.Enabled = false;
            this.exportAssetsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.exportAssetsToolStripMenuItem.Name = "exportAssetsToolStripMenuItem";
            this.exportAssetsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.exportAssetsToolStripMenuItem.Text = "Export Assets";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewCollisionShapesToolStripMenuItem,
            this.viewBoundingBoxesToolStripMenuItem,
            this.viewCamerasToolStripMenuItem,
            this.viewBoundingCirclesToolStripMenuItem});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // viewCollisionShapesToolStripMenuItem
            // 
            this.viewCollisionShapesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.viewCollisionShapesToolStripMenuItem.Checked = true;
            this.viewCollisionShapesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewCollisionShapesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.viewCollisionShapesToolStripMenuItem.Name = "viewCollisionShapesToolStripMenuItem";
            this.viewCollisionShapesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.viewCollisionShapesToolStripMenuItem.Text = "View Collision Shapes";
            this.viewCollisionShapesToolStripMenuItem.Click += new System.EventHandler(this.viewCollisionShapesToolStripMenuItem_Click);
            // 
            // viewBoundingBoxesToolStripMenuItem
            // 
            this.viewBoundingBoxesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.viewBoundingBoxesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.viewBoundingBoxesToolStripMenuItem.Name = "viewBoundingBoxesToolStripMenuItem";
            this.viewBoundingBoxesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.viewBoundingBoxesToolStripMenuItem.Text = "View Bounding Boxes";
            this.viewBoundingBoxesToolStripMenuItem.Click += new System.EventHandler(this.viewBoundingBoxesToolStripMenuItem_Click);
            // 
            // viewCamerasToolStripMenuItem
            // 
            this.viewCamerasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.viewCamerasToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.viewCamerasToolStripMenuItem.Name = "viewCamerasToolStripMenuItem";
            this.viewCamerasToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.viewCamerasToolStripMenuItem.Text = "View Cameras";
            this.viewCamerasToolStripMenuItem.Click += new System.EventHandler(this.viewCamerasToolStripMenuItem_Click);
            // 
            // viewBoundingCirclesToolStripMenuItem
            // 
            this.viewBoundingCirclesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.viewBoundingCirclesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.viewBoundingCirclesToolStripMenuItem.Name = "viewBoundingCirclesToolStripMenuItem";
            this.viewBoundingCirclesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.viewBoundingCirclesToolStripMenuItem.Text = "View Bounding Circles";
            this.viewBoundingCirclesToolStripMenuItem.Click += new System.EventHandler(this.viewBoundingCirclesToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEntityTypeToolStripMenuItem,
            this.materialsToolStripMenuItem,
            this.controlsToolStripMenuItem});
            this.editToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addEntityTypeToolStripMenuItem
            // 
            this.addEntityTypeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addEntityTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createTypeToolStripMenuItem,
            this.removeTypeToolStripMenuItem});
            this.addEntityTypeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.addEntityTypeToolStripMenuItem.Name = "addEntityTypeToolStripMenuItem";
            this.addEntityTypeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addEntityTypeToolStripMenuItem.Text = "Entity Types";
            // 
            // createTypeToolStripMenuItem
            // 
            this.createTypeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.createTypeToolStripMenuItem.Enabled = false;
            this.createTypeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.createTypeToolStripMenuItem.Name = "createTypeToolStripMenuItem";
            this.createTypeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.createTypeToolStripMenuItem.Text = "Create New";
            // 
            // removeTypeToolStripMenuItem
            // 
            this.removeTypeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.removeTypeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.removeTypeToolStripMenuItem.Name = "removeTypeToolStripMenuItem";
            this.removeTypeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeTypeToolStripMenuItem.Text = "Remove";
            this.removeTypeToolStripMenuItem.Click += new System.EventHandler(this.removeTypeToolStripMenuItem_Click);
            // 
            // materialsToolStripMenuItem
            // 
            this.materialsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.materialsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewMaterialToolStripMenuItem,
            this.removeMaterialToolStripMenuItem});
            this.materialsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.materialsToolStripMenuItem.Name = "materialsToolStripMenuItem";
            this.materialsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.materialsToolStripMenuItem.Text = "Materials";
            // 
            // addNewMaterialToolStripMenuItem
            // 
            this.addNewMaterialToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addNewMaterialToolStripMenuItem.Enabled = false;
            this.addNewMaterialToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.addNewMaterialToolStripMenuItem.Name = "addNewMaterialToolStripMenuItem";
            this.addNewMaterialToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addNewMaterialToolStripMenuItem.Text = "Add New";
            // 
            // removeMaterialToolStripMenuItem
            // 
            this.removeMaterialToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.removeMaterialToolStripMenuItem.Enabled = false;
            this.removeMaterialToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.removeMaterialToolStripMenuItem.Name = "removeMaterialToolStripMenuItem";
            this.removeMaterialToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeMaterialToolStripMenuItem.Text = "Remove";
            // 
            // entityToolStripMenuItem
            // 
            this.entityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createEntityToolStripMenuItem,
            this.createEntityAsChildToolStripMenuItem,
            this.removeEntityToolStripMenuItem,
            this.makeEntityIntoTypeToolStripMenuItem,
            this.renameEntityToolStripMenuItem});
            this.entityToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.entityToolStripMenuItem.Name = "entityToolStripMenuItem";
            this.entityToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.entityToolStripMenuItem.Text = "Entity";
            // 
            // createEntityToolStripMenuItem
            // 
            this.createEntityToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.createEntityToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.createEntityToolStripMenuItem.Name = "createEntityToolStripMenuItem";
            this.createEntityToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.createEntityToolStripMenuItem.Text = "Create";
            this.createEntityToolStripMenuItem.Click += new System.EventHandler(this.createEntityToolStripMenuItem_Click);
            // 
            // createEntityAsChildToolStripMenuItem
            // 
            this.createEntityAsChildToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.createEntityAsChildToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.createEntityAsChildToolStripMenuItem.Name = "createEntityAsChildToolStripMenuItem";
            this.createEntityAsChildToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.createEntityAsChildToolStripMenuItem.Text = "Create As Child";
            this.createEntityAsChildToolStripMenuItem.Click += new System.EventHandler(this.createEntityAsChildToolStripMenuItem_Click);
            // 
            // removeEntityToolStripMenuItem
            // 
            this.removeEntityToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.removeEntityToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.removeEntityToolStripMenuItem.Name = "removeEntityToolStripMenuItem";
            this.removeEntityToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.removeEntityToolStripMenuItem.Text = "Remove";
            this.removeEntityToolStripMenuItem.Click += new System.EventHandler(this.removeEntityToolStripMenuItem_Click);
            // 
            // makeEntityIntoTypeToolStripMenuItem
            // 
            this.makeEntityIntoTypeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.makeEntityIntoTypeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.makeEntityIntoTypeToolStripMenuItem.Name = "makeEntityIntoTypeToolStripMenuItem";
            this.makeEntityIntoTypeToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.makeEntityIntoTypeToolStripMenuItem.Text = "Make Into Type";
            this.makeEntityIntoTypeToolStripMenuItem.Click += new System.EventHandler(this.makeEntityIntoTypeToolStripMenuItem_Click);
            // 
            // renameEntityToolStripMenuItem
            // 
            this.renameEntityToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.renameEntityToolStripMenuItem.Enabled = false;
            this.renameEntityToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.renameEntityToolStripMenuItem.Name = "renameEntityToolStripMenuItem";
            this.renameEntityToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.renameEntityToolStripMenuItem.Text = "Rename";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Enabled = false;
            this.helpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // editorTabs
            // 
            this.editorTabs.Appearance = Dotnetrix.Controls.TabAppearanceEX.FlatTab;
            this.editorTabs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.editorTabs.Controls.Add(this.sceneTab);
            this.editorTabs.Controls.Add(this.entityTypesTab);
            this.editorTabs.Controls.Add(this.materialsTab);
            this.editorTabs.Dock = System.Windows.Forms.DockStyle.Right;
            this.editorTabs.FlatBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.editorTabs.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.editorTabs.HotColor = System.Drawing.SystemColors.ControlDarkDark;
            this.editorTabs.Location = new System.Drawing.Point(895, 24);
            this.editorTabs.Margin = new System.Windows.Forms.Padding(0);
            this.editorTabs.Name = "editorTabs";
            this.editorTabs.Padding = new System.Drawing.Point(0, 0);
            this.editorTabs.SelectedIndex = 0;
            this.editorTabs.SelectedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.editorTabs.Size = new System.Drawing.Size(385, 674);
            this.editorTabs.TabColor = System.Drawing.SystemColors.ControlDarkDark;
            this.editorTabs.TabIndex = 6;
            this.editorTabs.UseVisualStyles = false;
            this.editorTabs.Deselecting += new TabControlCancelEventHandler(editorTabs_Deselecting);
            this.editorTabs.Selected += new TabControlEventHandler(editorTabs_Selected);
            // 
            // sceneTab
            // 
            this.sceneTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.sceneTab.Controls.Add(this.sceneSplitContainer);
            this.sceneTab.ForeColor = System.Drawing.SystemColors.Control;
            this.sceneTab.Location = new System.Drawing.Point(4, 25);
            this.sceneTab.Name = "sceneTab";
            this.sceneTab.Padding = new System.Windows.Forms.Padding(3);
            this.sceneTab.Size = new System.Drawing.Size(377, 645);
            this.sceneTab.TabIndex = 0;
            this.sceneTab.Text = "Scene";
            // 
            // sceneSplitContainer
            // 
            this.sceneSplitContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.sceneSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sceneSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.sceneSplitContainer.Name = "sceneSplitContainer";
            this.sceneSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sceneSplitContainer.Panel1
            // 
            this.sceneSplitContainer.Panel1.Controls.Add(this.sceneEntitiesTreeView);
            // 
            // sceneSplitContainer.Panel2
            // 
            this.sceneSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.sceneSplitContainer.Panel2.ForeColor = System.Drawing.SystemColors.Control;
            this.sceneSplitContainer.Size = new System.Drawing.Size(371, 639);
            this.sceneSplitContainer.SplitterDistance = 206;
            this.sceneSplitContainer.TabIndex = 1;
            // 
            // sceneEntitiesTreeView
            // 
            this.sceneEntitiesTreeView.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.sceneEntitiesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sceneEntitiesTreeView.ForeColor = System.Drawing.SystemColors.Control;
            this.sceneEntitiesTreeView.Location = new System.Drawing.Point(0, 0);
            this.sceneEntitiesTreeView.Name = "sceneEntitiesTreeView";
            this.sceneEntitiesTreeView.Size = new System.Drawing.Size(371, 206);
            this.sceneEntitiesTreeView.TabIndex = 0;
            this.sceneEntitiesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.entityTreeView_AfterSelect);
            // 
            // entityTypesTab
            // 
            this.entityTypesTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.entityTypesTab.Controls.Add(this.entityTypesSplitContainer);
            this.entityTypesTab.ForeColor = System.Drawing.SystemColors.Control;
            this.entityTypesTab.Location = new System.Drawing.Point(4, 25);
            this.entityTypesTab.Name = "entityTypesTab";
            this.entityTypesTab.Padding = new System.Windows.Forms.Padding(3);
            this.entityTypesTab.Size = new System.Drawing.Size(377, 645);
            this.entityTypesTab.TabIndex = 1;
            this.entityTypesTab.Text = "Entity Types";
            // 
            // entityTypesSplitContainer
            // 
            this.entityTypesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entityTypesSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.entityTypesSplitContainer.Name = "entityTypesSplitContainer";
            this.entityTypesSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // entityTypesSplitContainer.Panel1
            // 
            this.entityTypesSplitContainer.Panel1.Controls.Add(this.entityTypesListBox);
            // 
            // entityTypesSplitContainer.Panel2
            // 
            this.entityTypesSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.entityTypesSplitContainer.Size = new System.Drawing.Size(371, 639);
            this.entityTypesSplitContainer.SplitterDistance = 207;
            this.entityTypesSplitContainer.TabIndex = 0;
            // 
            // entityTypesListBox
            // 
            this.entityTypesListBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.entityTypesListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.entityTypesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entityTypesListBox.ForeColor = System.Drawing.SystemColors.Control;
            this.entityTypesListBox.FormattingEnabled = true;
            this.entityTypesListBox.Location = new System.Drawing.Point(0, 0);
            this.entityTypesListBox.Name = "entityTypesListBox";
            this.entityTypesListBox.Size = new System.Drawing.Size(371, 207);
            this.entityTypesListBox.TabIndex = 0;
            this.entityTypesListBox.SelectedIndexChanged += new System.EventHandler(this.entityTypeListBox_AfterSelect);
            // 
            // materialsTab
            // 
            this.materialsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.materialsTab.ForeColor = System.Drawing.SystemColors.Control;
            this.materialsTab.Location = new System.Drawing.Point(4, 25);
            this.materialsTab.Name = "materialsTab";
            this.materialsTab.Padding = new System.Windows.Forms.Padding(3);
            this.materialsTab.Size = new System.Drawing.Size(377, 645);
            this.materialsTab.TabIndex = 2;
            this.materialsTab.Text = "Materials";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.assetsTreeView);
            this.panel1.Controls.Add(this.AssetsLabelPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 674);
            this.panel1.TabIndex = 7;
            // 
            // assetsTreeView
            // 
            this.assetsTreeView.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.assetsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assetsTreeView.ForeColor = System.Drawing.SystemColors.Control;
            this.assetsTreeView.Location = new System.Drawing.Point(0, 22);
            this.assetsTreeView.Name = "assetsTreeView";
            this.assetsTreeView.Size = new System.Drawing.Size(178, 652);
            this.assetsTreeView.TabIndex = 1;
            this.assetsTreeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.assetsTreeView_DoubleClick);
            // 
            // AssetsLabelPanel
            // 
            this.AssetsLabelPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.AssetsLabelPanel.Controls.Add(this.AssetsLabel);
            this.AssetsLabelPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AssetsLabelPanel.Location = new System.Drawing.Point(0, 0);
            this.AssetsLabelPanel.Name = "AssetsLabelPanel";
            this.AssetsLabelPanel.Size = new System.Drawing.Size(178, 22);
            this.AssetsLabelPanel.TabIndex = 0;
            // 
            // AssetsLabel
            // 
            this.AssetsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.AssetsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetsLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.AssetsLabel.Location = new System.Drawing.Point(0, 0);
            this.AssetsLabel.Name = "AssetsLabel";
            this.AssetsLabel.Size = new System.Drawing.Size(178, 22);
            this.AssetsLabel.TabIndex = 0;
            this.AssetsLabel.Text = "Assets";
            this.AssetsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(154, 6);
            // 
            // editorWindow
            // 
            this.editorWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorWindow.EditorForm = null;
            this.editorWindow.Location = new System.Drawing.Point(178, 24);
            this.editorWindow.Name = "editorWindow";
            this.editorWindow.Size = new System.Drawing.Size(717, 674);
            this.editorWindow.TabIndex = 8;
            this.editorWindow.Text = "editorWindow";
            // 
            // controlsToolStripMenuItem
            // 
            this.controlsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.controlsToolStripMenuItem.Enabled = false;
            this.controlsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.controlsToolStripMenuItem.Name = "controlsToolStripMenuItem";
            this.controlsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.controlsToolStripMenuItem.Text = "Controls";
            // 
            // newBundleToolStripMenuItem
            // 
            this.newBundleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.newBundleToolStripMenuItem.Enabled = false;
            this.newBundleToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.newBundleToolStripMenuItem.Name = "newBundleToolStripMenuItem";
            this.newBundleToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.newBundleToolStripMenuItem.Text = "New Bundle";
            // 
            // removeBundleToolStripMenuItem
            // 
            this.removeBundleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.removeBundleToolStripMenuItem.Enabled = false;
            this.removeBundleToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.removeBundleToolStripMenuItem.Name = "removeBundleToolStripMenuItem";
            this.removeBundleToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.removeBundleToolStripMenuItem.Text = "Remove Bundle";
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.editorWindow);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.editorTabs);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EditorForm";
            this.Text = "Caravel Editor";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.editorTabs.ResumeLayout(false);
            this.sceneTab.ResumeLayout(false);
            this.sceneSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sceneSplitContainer)).EndInit();
            this.sceneSplitContainer.ResumeLayout(false);
            this.entityTypesTab.ResumeLayout(false);
            this.entityTypesSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.entityTypesSplitContainer)).EndInit();
            this.entityTypesSplitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.AssetsLabelPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSceneToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private Dotnetrix.Controls.TabControlEX editorTabs;
        private System.Windows.Forms.TabPage sceneTab;
        private System.Windows.Forms.TabPage entityTypesTab;
        private System.Windows.Forms.TabPage materialsTab;
        private System.Windows.Forms.SplitContainer sceneSplitContainer;
        private System.Windows.Forms.TreeView sceneEntitiesTreeView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView assetsTreeView;
        private System.Windows.Forms.Panel AssetsLabelPanel;
        private System.Windows.Forms.Label AssetsLabel;
        private EditorWindow editorWindow;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCollisionShapesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewBoundingBoxesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCamerasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewBoundingCirclesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEntityTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewMaterialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeMaterialToolStripMenuItem;
        private ToolStripMenuItem entityToolStripMenuItem;
        private SplitContainer entityTypesSplitContainer;
        private ListBox entityTypesListBox;
        private ToolStripMenuItem saveSceneToolStripMenuItem;
        private ToolStripMenuItem exportAssetsToolStripMenuItem;
        private ToolStripMenuItem createEntityToolStripMenuItem;
        private ToolStripMenuItem createEntityAsChildToolStripMenuItem;
        private ToolStripMenuItem removeEntityToolStripMenuItem;
        private ToolStripMenuItem makeEntityIntoTypeToolStripMenuItem;
        private ToolStripMenuItem renameEntityToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem newProjectToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem newSceneToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem newBundleToolStripMenuItem;
        private ToolStripMenuItem removeBundleToolStripMenuItem;
        private ToolStripMenuItem controlsToolStripMenuItem;
    }
}

