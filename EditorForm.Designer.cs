﻿using System.Windows.Forms;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProjectLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSceneLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportAssetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBundleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeBundleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCollisionShapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewBoundingBoxesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCamerasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewBoundingCirclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewClickAreasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entityTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewMaterialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeMaterialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createEntityAsChildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeEntityIntoTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSceneAsChildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorTabs = new Dotnetrix.Controls.TabControlEX();
            this.sceneTab = new System.Windows.Forms.TabPage();
            this.sceneSplitContainer = new System.Windows.Forms.SplitContainer();
            this.sceneEntitiesTreeView = new System.Windows.Forms.TreeView();
            this.entityTypesTab = new System.Windows.Forms.TabPage();
            this.entityTypesSplitContainer = new System.Windows.Forms.SplitContainer();
            this.entityTypesListBox = new System.Windows.Forms.ListBox();
            this.materialsTab = new System.Windows.Forms.TabPage();
            this.materialsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.materialsListBox = new System.Windows.Forms.ListBox();
            this.materialEditorControl = new CaravelEditor.MaterialEditorControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.assetsTreeView = new System.Windows.Forms.TreeView();
            this.assetPreviewPanel = new System.Windows.Forms.Panel();
            this.assetsPictureBox = new System.Windows.Forms.PictureBox();
            this.AssetsLabelPanel = new System.Windows.Forms.Panel();
            this.assetsRefreshButton = new System.Windows.Forms.Button();
            this.AssetsLabel = new System.Windows.Forms.Label();
            this.editorToolStrip = new System.Windows.Forms.ToolStrip();
            this.editorToolsGrabButton = new System.Windows.Forms.ToolStripButton();
            this.editorToolsCameraButton = new System.Windows.Forms.ToolStripButton();
            this.editorToolsPaintbrushButton = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.playButton = new System.Windows.Forms.Button();
            this.cameraToolOptions = new CaravelEditor.CameraToolOptions();
            this.transformToolOptions1 = new CaravelEditor.TransformToolOptions();
            this.terminalPanel = new System.Windows.Forms.Panel();
            this.outputLabel = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.editorWindow = new CaravelEditor.EditorWindow();
            this.startupPage = new CaravelEditor.StartupPage();
            this.assetInfo = new CaravelEditor.AssetInfo();
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
            this.materialsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialsSplitContainer)).BeginInit();
            this.materialsSplitContainer.Panel1.SuspendLayout();
            this.materialsSplitContainer.Panel2.SuspendLayout();
            this.materialsSplitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.assetPreviewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assetsPictureBox)).BeginInit();
            this.AssetsLabelPanel.SuspendLayout();
            this.editorToolStrip.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.terminalPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProjectLabel,
            this.toolStripSceneLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 971);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1894, 38);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProjectLabel
            // 
            this.toolStripProjectLabel.AutoSize = false;
            this.toolStripProjectLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripProjectLabel.Name = "toolStripProjectLabel";
            this.toolStripProjectLabel.Size = new System.Drawing.Size(178, 33);
            this.toolStripProjectLabel.Text = "Open a project to start.";
            // 
            // toolStripSceneLabel
            // 
            this.toolStripSceneLabel.AutoSize = false;
            this.toolStripSceneLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripSceneLabel.Margin = new System.Windows.Forms.Padding(0, 3, 385, 2);
            this.toolStripSceneLabel.Name = "toolStripSceneLabel";
            this.toolStripSceneLabel.Size = new System.Drawing.Size(2015, 17);
            this.toolStripSceneLabel.Spring = true;
            this.toolStripSceneLabel.Text = "No Scene Loaded.";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.editToolStripMenuItem,
            this.entityToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1894, 44);
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
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(100, 36);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.newProjectToolStripMenuItem.Enabled = false;
            this.newProjectToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(282, 38);
            this.newProjectToolStripMenuItem.Text = "New Project";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.openToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(282, 38);
            this.openToolStripMenuItem.Text = "Open Project";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(279, 6);
            // 
            // newSceneToolStripMenuItem
            // 
            this.newSceneToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.newSceneToolStripMenuItem.Enabled = false;
            this.newSceneToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.newSceneToolStripMenuItem.Name = "newSceneToolStripMenuItem";
            this.newSceneToolStripMenuItem.Size = new System.Drawing.Size(282, 38);
            this.newSceneToolStripMenuItem.Text = "New Scene";
            this.newSceneToolStripMenuItem.Click += new System.EventHandler(this.newSceneToolStripMenuItem_Click);
            // 
            // loadSceneToolStripMenuItem
            // 
            this.loadSceneToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loadSceneToolStripMenuItem.Enabled = false;
            this.loadSceneToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.loadSceneToolStripMenuItem.Name = "loadSceneToolStripMenuItem";
            this.loadSceneToolStripMenuItem.Size = new System.Drawing.Size(282, 38);
            this.loadSceneToolStripMenuItem.Text = "Load Scene";
            this.loadSceneToolStripMenuItem.Click += new System.EventHandler(this.loadSceneToolStripMenuItem_Click);
            // 
            // saveSceneToolStripMenuItem
            // 
            this.saveSceneToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.saveSceneToolStripMenuItem.Enabled = false;
            this.saveSceneToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.saveSceneToolStripMenuItem.Name = "saveSceneToolStripMenuItem";
            this.saveSceneToolStripMenuItem.Size = new System.Drawing.Size(282, 38);
            this.saveSceneToolStripMenuItem.Text = "Save Scene";
            this.saveSceneToolStripMenuItem.Click += new System.EventHandler(this.saveSceneToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(279, 6);
            // 
            // exportAssetsToolStripMenuItem
            // 
            this.exportAssetsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.exportAssetsToolStripMenuItem.Enabled = false;
            this.exportAssetsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.exportAssetsToolStripMenuItem.Name = "exportAssetsToolStripMenuItem";
            this.exportAssetsToolStripMenuItem.Size = new System.Drawing.Size(282, 38);
            this.exportAssetsToolStripMenuItem.Text = "Export Assets";
            // 
            // newBundleToolStripMenuItem
            // 
            this.newBundleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.newBundleToolStripMenuItem.Enabled = false;
            this.newBundleToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.newBundleToolStripMenuItem.Name = "newBundleToolStripMenuItem";
            this.newBundleToolStripMenuItem.Size = new System.Drawing.Size(282, 38);
            this.newBundleToolStripMenuItem.Text = "New Bundle";
            // 
            // removeBundleToolStripMenuItem
            // 
            this.removeBundleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.removeBundleToolStripMenuItem.Enabled = false;
            this.removeBundleToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.removeBundleToolStripMenuItem.Name = "removeBundleToolStripMenuItem";
            this.removeBundleToolStripMenuItem.Size = new System.Drawing.Size(282, 38);
            this.removeBundleToolStripMenuItem.Text = "Remove Bundle";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewCollisionShapesToolStripMenuItem,
            this.viewBoundingBoxesToolStripMenuItem,
            this.viewCamerasToolStripMenuItem,
            this.viewBoundingCirclesToolStripMenuItem,
            this.viewClickAreasToolStripMenuItem});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(78, 36);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // viewCollisionShapesToolStripMenuItem
            // 
            this.viewCollisionShapesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.viewCollisionShapesToolStripMenuItem.Checked = true;
            this.viewCollisionShapesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewCollisionShapesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.viewCollisionShapesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewCollisionShapesToolStripMenuItem.Name = "viewCollisionShapesToolStripMenuItem";
            this.viewCollisionShapesToolStripMenuItem.Size = new System.Drawing.Size(352, 38);
            this.viewCollisionShapesToolStripMenuItem.Text = "View Collision Shapes";
            this.viewCollisionShapesToolStripMenuItem.Click += new System.EventHandler(this.viewCollisionShapesToolStripMenuItem_Click);
            // 
            // viewBoundingBoxesToolStripMenuItem
            // 
            this.viewBoundingBoxesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.viewBoundingBoxesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.viewBoundingBoxesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewBoundingBoxesToolStripMenuItem.Name = "viewBoundingBoxesToolStripMenuItem";
            this.viewBoundingBoxesToolStripMenuItem.Size = new System.Drawing.Size(352, 38);
            this.viewBoundingBoxesToolStripMenuItem.Text = "View Bounding Boxes";
            this.viewBoundingBoxesToolStripMenuItem.Click += new System.EventHandler(this.viewBoundingBoxesToolStripMenuItem_Click);
            // 
            // viewCamerasToolStripMenuItem
            // 
            this.viewCamerasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.viewCamerasToolStripMenuItem.Checked = true;
            this.viewCamerasToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewCamerasToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.viewCamerasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewCamerasToolStripMenuItem.Name = "viewCamerasToolStripMenuItem";
            this.viewCamerasToolStripMenuItem.Size = new System.Drawing.Size(352, 38);
            this.viewCamerasToolStripMenuItem.Text = "View Cameras";
            this.viewCamerasToolStripMenuItem.Click += new System.EventHandler(this.viewCamerasToolStripMenuItem_Click);
            // 
            // viewBoundingCirclesToolStripMenuItem
            // 
            this.viewBoundingCirclesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.viewBoundingCirclesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.viewBoundingCirclesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewBoundingCirclesToolStripMenuItem.Name = "viewBoundingCirclesToolStripMenuItem";
            this.viewBoundingCirclesToolStripMenuItem.Size = new System.Drawing.Size(352, 38);
            this.viewBoundingCirclesToolStripMenuItem.Text = "View Bounding Circles";
            this.viewBoundingCirclesToolStripMenuItem.Click += new System.EventHandler(this.viewBoundingCirclesToolStripMenuItem_Click);
            // 
            // viewClickAreasToolStripMenuItem
            // 
            this.viewClickAreasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.viewClickAreasToolStripMenuItem.Checked = true;
            this.viewClickAreasToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewClickAreasToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.viewClickAreasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewClickAreasToolStripMenuItem.Name = "viewClickAreasToolStripMenuItem";
            this.viewClickAreasToolStripMenuItem.Size = new System.Drawing.Size(352, 38);
            this.viewClickAreasToolStripMenuItem.Text = "View Click Areas";
            this.viewClickAreasToolStripMenuItem.Click += new System.EventHandler(this.viewClickAreasToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entityTypeToolStripMenuItem,
            this.materialsToolStripMenuItem,
            this.controlsToolStripMenuItem,
            this.editSceneToolStripMenuItem});
            this.editToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(67, 36);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // entityTypeToolStripMenuItem
            // 
            this.entityTypeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.entityTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createTypeToolStripMenuItem,
            this.removeTypeToolStripMenuItem});
            this.entityTypeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.entityTypeToolStripMenuItem.Name = "entityTypeToolStripMenuItem";
            this.entityTypeToolStripMenuItem.Size = new System.Drawing.Size(242, 38);
            this.entityTypeToolStripMenuItem.Text = "Entity Types";
            // 
            // createTypeToolStripMenuItem
            // 
            this.createTypeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.createTypeToolStripMenuItem.Enabled = false;
            this.createTypeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.createTypeToolStripMenuItem.Name = "createTypeToolStripMenuItem";
            this.createTypeToolStripMenuItem.Size = new System.Drawing.Size(238, 38);
            this.createTypeToolStripMenuItem.Text = "Create New";
            // 
            // removeTypeToolStripMenuItem
            // 
            this.removeTypeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.removeTypeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.removeTypeToolStripMenuItem.Name = "removeTypeToolStripMenuItem";
            this.removeTypeToolStripMenuItem.Size = new System.Drawing.Size(238, 38);
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
            this.materialsToolStripMenuItem.Size = new System.Drawing.Size(242, 38);
            this.materialsToolStripMenuItem.Text = "Materials";
            // 
            // addNewMaterialToolStripMenuItem
            // 
            this.addNewMaterialToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addNewMaterialToolStripMenuItem.Enabled = false;
            this.addNewMaterialToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.addNewMaterialToolStripMenuItem.Name = "addNewMaterialToolStripMenuItem";
            this.addNewMaterialToolStripMenuItem.Size = new System.Drawing.Size(238, 38);
            this.addNewMaterialToolStripMenuItem.Text = "Create New";
            this.addNewMaterialToolStripMenuItem.Click += new System.EventHandler(this.addNewMaterialToolStripMenuItem_Click);
            // 
            // removeMaterialToolStripMenuItem
            // 
            this.removeMaterialToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.removeMaterialToolStripMenuItem.Enabled = false;
            this.removeMaterialToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.removeMaterialToolStripMenuItem.Name = "removeMaterialToolStripMenuItem";
            this.removeMaterialToolStripMenuItem.Size = new System.Drawing.Size(238, 38);
            this.removeMaterialToolStripMenuItem.Text = "Remove";
            this.removeMaterialToolStripMenuItem.Click += new System.EventHandler(this.removeMaterialToolStripMenuItem_Click);
            // 
            // controlsToolStripMenuItem
            // 
            this.controlsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.controlsToolStripMenuItem.Enabled = false;
            this.controlsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.controlsToolStripMenuItem.Name = "controlsToolStripMenuItem";
            this.controlsToolStripMenuItem.Size = new System.Drawing.Size(242, 38);
            this.controlsToolStripMenuItem.Text = "Controls";
            // 
            // editSceneToolStripMenuItem
            // 
            this.editSceneToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editSceneToolStripMenuItem.Enabled = false;
            this.editSceneToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.editSceneToolStripMenuItem.Name = "editSceneToolStripMenuItem";
            this.editSceneToolStripMenuItem.Size = new System.Drawing.Size(242, 38);
            this.editSceneToolStripMenuItem.Text = "Scene";
            this.editSceneToolStripMenuItem.Click += new System.EventHandler(this.editSceneToolStripMenuItem_Click);
            // 
            // entityToolStripMenuItem
            // 
            this.entityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createEntityToolStripMenuItem,
            this.createEntityAsChildToolStripMenuItem,
            this.removeEntityToolStripMenuItem,
            this.makeEntityIntoTypeToolStripMenuItem,
            this.renameEntityToolStripMenuItem,
            this.addSceneAsChildToolStripMenuItem,
            this.exportAsSceneToolStripMenuItem});
            this.entityToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.entityToolStripMenuItem.Name = "entityToolStripMenuItem";
            this.entityToolStripMenuItem.Size = new System.Drawing.Size(87, 36);
            this.entityToolStripMenuItem.Text = "Entity";
            // 
            // createEntityToolStripMenuItem
            // 
            this.createEntityToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.createEntityToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.createEntityToolStripMenuItem.Name = "createEntityToolStripMenuItem";
            this.createEntityToolStripMenuItem.Size = new System.Drawing.Size(322, 38);
            this.createEntityToolStripMenuItem.Text = "Create";
            this.createEntityToolStripMenuItem.Click += new System.EventHandler(this.createEntityToolStripMenuItem_Click);
            // 
            // createEntityAsChildToolStripMenuItem
            // 
            this.createEntityAsChildToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.createEntityAsChildToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.createEntityAsChildToolStripMenuItem.Name = "createEntityAsChildToolStripMenuItem";
            this.createEntityAsChildToolStripMenuItem.Size = new System.Drawing.Size(322, 38);
            this.createEntityAsChildToolStripMenuItem.Text = "Create As Child";
            this.createEntityAsChildToolStripMenuItem.Click += new System.EventHandler(this.createEntityAsChildToolStripMenuItem_Click);
            // 
            // removeEntityToolStripMenuItem
            // 
            this.removeEntityToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.removeEntityToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.removeEntityToolStripMenuItem.Name = "removeEntityToolStripMenuItem";
            this.removeEntityToolStripMenuItem.Size = new System.Drawing.Size(322, 38);
            this.removeEntityToolStripMenuItem.Text = "Remove";
            this.removeEntityToolStripMenuItem.Click += new System.EventHandler(this.removeEntityToolStripMenuItem_Click);
            // 
            // makeEntityIntoTypeToolStripMenuItem
            // 
            this.makeEntityIntoTypeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.makeEntityIntoTypeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.makeEntityIntoTypeToolStripMenuItem.Name = "makeEntityIntoTypeToolStripMenuItem";
            this.makeEntityIntoTypeToolStripMenuItem.Size = new System.Drawing.Size(322, 38);
            this.makeEntityIntoTypeToolStripMenuItem.Text = "Make Into Type";
            this.makeEntityIntoTypeToolStripMenuItem.Click += new System.EventHandler(this.makeEntityIntoTypeToolStripMenuItem_Click);
            // 
            // renameEntityToolStripMenuItem
            // 
            this.renameEntityToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.renameEntityToolStripMenuItem.Enabled = false;
            this.renameEntityToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.renameEntityToolStripMenuItem.Name = "renameEntityToolStripMenuItem";
            this.renameEntityToolStripMenuItem.Size = new System.Drawing.Size(322, 38);
            this.renameEntityToolStripMenuItem.Text = "Rename";
            this.renameEntityToolStripMenuItem.Click += new System.EventHandler(this.renameEntityToolStripMenuItem_Click);
            // 
            // addSceneAsChildToolStripMenuItem
            // 
            this.addSceneAsChildToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addSceneAsChildToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.addSceneAsChildToolStripMenuItem.Name = "addSceneAsChildToolStripMenuItem";
            this.addSceneAsChildToolStripMenuItem.Size = new System.Drawing.Size(322, 38);
            this.addSceneAsChildToolStripMenuItem.Text = "Add Scene As Child";
            this.addSceneAsChildToolStripMenuItem.Click += new System.EventHandler(this.AddSceneAsChildToolStripMenuItem_Click);
            // 
            // exportAsSceneToolStripMenuItem
            // 
            this.exportAsSceneToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.exportAsSceneToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.exportAsSceneToolStripMenuItem.Name = "exportAsSceneToolStripMenuItem";
            this.exportAsSceneToolStripMenuItem.Size = new System.Drawing.Size(322, 38);
            this.exportAsSceneToolStripMenuItem.Text = "Export As Scene";
            this.exportAsSceneToolStripMenuItem.Click += new System.EventHandler(this.ExportAsSceneToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Enabled = false;
            this.helpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(77, 36);
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
            this.editorTabs.Location = new System.Drawing.Point(1124, 44);
            this.editorTabs.Margin = new System.Windows.Forms.Padding(0);
            this.editorTabs.MinimumSize = new System.Drawing.Size(770, 0);
            this.editorTabs.Name = "editorTabs";
            this.editorTabs.Padding = new System.Drawing.Point(0, 0);
            this.editorTabs.SelectedIndex = 0;
            this.editorTabs.SelectedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.editorTabs.Size = new System.Drawing.Size(770, 927);
            this.editorTabs.TabColor = System.Drawing.SystemColors.ControlDarkDark;
            this.editorTabs.TabIndex = 6;
            this.editorTabs.UseVisualStyles = false;
            this.editorTabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.editorTabs_Selected);
            this.editorTabs.Deselecting += new System.Windows.Forms.TabControlCancelEventHandler(this.editorTabs_Deselecting);
            // 
            // sceneTab
            // 
            this.sceneTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.sceneTab.Controls.Add(this.sceneSplitContainer);
            this.sceneTab.ForeColor = System.Drawing.SystemColors.Control;
            this.sceneTab.Location = new System.Drawing.Point(8, 38);
            this.sceneTab.Margin = new System.Windows.Forms.Padding(6);
            this.sceneTab.Name = "sceneTab";
            this.sceneTab.Padding = new System.Windows.Forms.Padding(6);
            this.sceneTab.Size = new System.Drawing.Size(754, 881);
            this.sceneTab.TabIndex = 0;
            this.sceneTab.Text = "Scene";
            // 
            // sceneSplitContainer
            // 
            this.sceneSplitContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.sceneSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sceneSplitContainer.Location = new System.Drawing.Point(6, 6);
            this.sceneSplitContainer.Margin = new System.Windows.Forms.Padding(6);
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
            this.sceneSplitContainer.Size = new System.Drawing.Size(742, 869);
            this.sceneSplitContainer.SplitterDistance = 274;
            this.sceneSplitContainer.SplitterWidth = 8;
            this.sceneSplitContainer.TabIndex = 1;
            // 
            // sceneEntitiesTreeView
            // 
            this.sceneEntitiesTreeView.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.sceneEntitiesTreeView.CheckBoxes = true;
            this.sceneEntitiesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sceneEntitiesTreeView.ForeColor = System.Drawing.SystemColors.Control;
            this.sceneEntitiesTreeView.Location = new System.Drawing.Point(0, 0);
            this.sceneEntitiesTreeView.Margin = new System.Windows.Forms.Padding(6);
            this.sceneEntitiesTreeView.Name = "sceneEntitiesTreeView";
            this.sceneEntitiesTreeView.Size = new System.Drawing.Size(742, 274);
            this.sceneEntitiesTreeView.TabIndex = 0;
            this.sceneEntitiesTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.entityTreeView_AfterCheck);
            this.sceneEntitiesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.entityTreeView_AfterSelect);
            this.sceneEntitiesTreeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.entityTreeView_RightClick);
            // 
            // entityTypesTab
            // 
            this.entityTypesTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.entityTypesTab.Controls.Add(this.entityTypesSplitContainer);
            this.entityTypesTab.ForeColor = System.Drawing.SystemColors.Control;
            this.entityTypesTab.Location = new System.Drawing.Point(8, 38);
            this.entityTypesTab.Margin = new System.Windows.Forms.Padding(6);
            this.entityTypesTab.Name = "entityTypesTab";
            this.entityTypesTab.Padding = new System.Windows.Forms.Padding(6);
            this.entityTypesTab.Size = new System.Drawing.Size(754, 881);
            this.entityTypesTab.TabIndex = 1;
            this.entityTypesTab.Text = "Entity Types";
            // 
            // entityTypesSplitContainer
            // 
            this.entityTypesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entityTypesSplitContainer.Location = new System.Drawing.Point(6, 6);
            this.entityTypesSplitContainer.Margin = new System.Windows.Forms.Padding(6);
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
            this.entityTypesSplitContainer.Size = new System.Drawing.Size(742, 869);
            this.entityTypesSplitContainer.SplitterDistance = 275;
            this.entityTypesSplitContainer.SplitterWidth = 8;
            this.entityTypesSplitContainer.TabIndex = 0;
            // 
            // entityTypesListBox
            // 
            this.entityTypesListBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.entityTypesListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.entityTypesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entityTypesListBox.ForeColor = System.Drawing.SystemColors.Control;
            this.entityTypesListBox.FormattingEnabled = true;
            this.entityTypesListBox.ItemHeight = 25;
            this.entityTypesListBox.Location = new System.Drawing.Point(0, 0);
            this.entityTypesListBox.Margin = new System.Windows.Forms.Padding(6);
            this.entityTypesListBox.Name = "entityTypesListBox";
            this.entityTypesListBox.Size = new System.Drawing.Size(742, 275);
            this.entityTypesListBox.TabIndex = 0;
            this.entityTypesListBox.SelectedIndexChanged += new System.EventHandler(this.entityTypeListBox_AfterSelect);
            this.entityTypesListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.entityTypesListBox_RightClick);
            // 
            // materialsTab
            // 
            this.materialsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.materialsTab.Controls.Add(this.materialsSplitContainer);
            this.materialsTab.ForeColor = System.Drawing.SystemColors.Control;
            this.materialsTab.Location = new System.Drawing.Point(8, 38);
            this.materialsTab.Margin = new System.Windows.Forms.Padding(6);
            this.materialsTab.Name = "materialsTab";
            this.materialsTab.Padding = new System.Windows.Forms.Padding(6);
            this.materialsTab.Size = new System.Drawing.Size(754, 881);
            this.materialsTab.TabIndex = 2;
            this.materialsTab.Text = "Materials";
            // 
            // materialsSplitContainer
            // 
            this.materialsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialsSplitContainer.Location = new System.Drawing.Point(6, 6);
            this.materialsSplitContainer.Margin = new System.Windows.Forms.Padding(6);
            this.materialsSplitContainer.Name = "materialsSplitContainer";
            this.materialsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // materialsSplitContainer.Panel1
            // 
            this.materialsSplitContainer.Panel1.Controls.Add(this.materialsListBox);
            // 
            // materialsSplitContainer.Panel2
            // 
            this.materialsSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.materialsSplitContainer.Panel2.Controls.Add(this.materialEditorControl);
            this.materialsSplitContainer.Size = new System.Drawing.Size(742, 869);
            this.materialsSplitContainer.SplitterDistance = 271;
            this.materialsSplitContainer.SplitterWidth = 8;
            this.materialsSplitContainer.TabIndex = 1;
            // 
            // materialsListBox
            // 
            this.materialsListBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.materialsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialsListBox.ForeColor = System.Drawing.SystemColors.Control;
            this.materialsListBox.FormattingEnabled = true;
            this.materialsListBox.ItemHeight = 25;
            this.materialsListBox.Location = new System.Drawing.Point(0, 0);
            this.materialsListBox.Margin = new System.Windows.Forms.Padding(6);
            this.materialsListBox.Name = "materialsListBox";
            this.materialsListBox.Size = new System.Drawing.Size(742, 271);
            this.materialsListBox.TabIndex = 0;
            this.materialsListBox.SelectedIndexChanged += new System.EventHandler(this.materialsListBox_AfterSelect);
            this.materialsListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.materialsListBox_RightClick);
            // 
            // materialEditorControl
            // 
            this.materialEditorControl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.materialEditorControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialEditorControl.ForeColor = System.Drawing.SystemColors.Control;
            this.materialEditorControl.Location = new System.Drawing.Point(0, 0);
            this.materialEditorControl.Margin = new System.Windows.Forms.Padding(12);
            this.materialEditorControl.Name = "materialEditorControl";
            this.materialEditorControl.Size = new System.Drawing.Size(742, 252);
            this.materialEditorControl.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.assetsTreeView);
            this.panel1.Controls.Add(this.assetPreviewPanel);
            this.panel1.Controls.Add(this.AssetsLabelPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 927);
            this.panel1.TabIndex = 7;
            // 
            // assetsTreeView
            // 
            this.assetsTreeView.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.assetsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assetsTreeView.ForeColor = System.Drawing.SystemColors.Control;
            this.assetsTreeView.Location = new System.Drawing.Point(0, 42);
            this.assetsTreeView.Margin = new System.Windows.Forms.Padding(6);
            this.assetsTreeView.Name = "assetsTreeView";
            this.assetsTreeView.Size = new System.Drawing.Size(500, 385);
            this.assetsTreeView.TabIndex = 1;
            this.assetsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.assetsTreeView_AfterSelect);
            this.assetsTreeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.assetsTreeView_DoubleClick);
            this.assetsTreeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.assetsTreeView_RightClick);
            // 
            // assetPreviewPanel
            // 
            this.assetPreviewPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.assetPreviewPanel.Controls.Add(this.assetInfo);
            this.assetPreviewPanel.Controls.Add(this.assetsPictureBox);
            this.assetPreviewPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.assetPreviewPanel.Location = new System.Drawing.Point(0, 427);
            this.assetPreviewPanel.MinimumSize = new System.Drawing.Size(0, 500);
            this.assetPreviewPanel.Name = "assetPreviewPanel";
            this.assetPreviewPanel.Size = new System.Drawing.Size(500, 500);
            this.assetPreviewPanel.TabIndex = 2;
            // 
            // assetsPictureBox
            // 
            this.assetsPictureBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.assetsPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.assetsPictureBox.Image = global::CaravelEditor.Properties.Resources.folder;
            this.assetsPictureBox.Location = new System.Drawing.Point(8, 8);
            this.assetsPictureBox.MaximumSize = new System.Drawing.Size(484, 484);
            this.assetsPictureBox.Name = "assetsPictureBox";
            this.assetsPictureBox.Size = new System.Drawing.Size(484, 439);
            this.assetsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.assetsPictureBox.TabIndex = 3;
            this.assetsPictureBox.TabStop = false;
            // 
            // AssetsLabelPanel
            // 
            this.AssetsLabelPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.AssetsLabelPanel.Controls.Add(this.assetsRefreshButton);
            this.AssetsLabelPanel.Controls.Add(this.AssetsLabel);
            this.AssetsLabelPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AssetsLabelPanel.Location = new System.Drawing.Point(0, 0);
            this.AssetsLabelPanel.Margin = new System.Windows.Forms.Padding(6);
            this.AssetsLabelPanel.Name = "AssetsLabelPanel";
            this.AssetsLabelPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.AssetsLabelPanel.Size = new System.Drawing.Size(500, 42);
            this.AssetsLabelPanel.TabIndex = 0;
            // 
            // assetsRefreshButton
            // 
            this.assetsRefreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.assetsRefreshButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("assetsRefreshButton.BackgroundImage")));
            this.assetsRefreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.assetsRefreshButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.assetsRefreshButton.FlatAppearance.BorderSize = 0;
            this.assetsRefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.assetsRefreshButton.Location = new System.Drawing.Point(435, 0);
            this.assetsRefreshButton.Name = "assetsRefreshButton";
            this.assetsRefreshButton.Size = new System.Drawing.Size(65, 36);
            this.assetsRefreshButton.TabIndex = 1;
            this.assetsRefreshButton.UseVisualStyleBackColor = false;
            this.assetsRefreshButton.Click += new System.EventHandler(this.assetsRefreshButton_Click);
            // 
            // AssetsLabel
            // 
            this.AssetsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.AssetsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetsLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.AssetsLabel.Location = new System.Drawing.Point(0, 0);
            this.AssetsLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.AssetsLabel.Name = "AssetsLabel";
            this.AssetsLabel.Size = new System.Drawing.Size(500, 36);
            this.AssetsLabel.TabIndex = 0;
            this.AssetsLabel.Text = "Assets";
            this.AssetsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // editorToolStrip
            // 
            this.editorToolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.editorToolStrip.CanOverflow = false;
            this.editorToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.editorToolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.editorToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.editorToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.editorToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editorToolsGrabButton,
            this.editorToolsCameraButton,
            this.editorToolsPaintbrushButton});
            this.editorToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.editorToolStrip.Location = new System.Drawing.Point(510, 120);
            this.editorToolStrip.Name = "editorToolStrip";
            this.editorToolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.editorToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.editorToolStrip.Size = new System.Drawing.Size(36, 119);
            this.editorToolStrip.TabIndex = 9;
            this.editorToolStrip.Text = "Editor Tools";
            // 
            // editorToolsGrabButton
            // 
            this.editorToolsGrabButton.Checked = true;
            this.editorToolsGrabButton.CheckOnClick = true;
            this.editorToolsGrabButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.editorToolsGrabButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editorToolsGrabButton.Image = ((System.Drawing.Image)(resources.GetObject("editorToolsGrabButton.Image")));
            this.editorToolsGrabButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editorToolsGrabButton.Name = "editorToolsGrabButton";
            this.editorToolsGrabButton.Size = new System.Drawing.Size(35, 36);
            this.editorToolsGrabButton.Text = "Manipulate Tool";
            this.editorToolsGrabButton.ToolTipText = "Manipulate Tool";
            this.editorToolsGrabButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripButton_Clicked);
            // 
            // editorToolsCameraButton
            // 
            this.editorToolsCameraButton.CheckOnClick = true;
            this.editorToolsCameraButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editorToolsCameraButton.Image = ((System.Drawing.Image)(resources.GetObject("editorToolsCameraButton.Image")));
            this.editorToolsCameraButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editorToolsCameraButton.Name = "editorToolsCameraButton";
            this.editorToolsCameraButton.Size = new System.Drawing.Size(35, 36);
            this.editorToolsCameraButton.Text = "Camera Tool";
            this.editorToolsCameraButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripButton_Clicked);
            // 
            // editorToolsPaintbrushButton
            // 
            this.editorToolsPaintbrushButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editorToolsPaintbrushButton.Image = ((System.Drawing.Image)(resources.GetObject("editorToolsPaintbrushButton.Image")));
            this.editorToolsPaintbrushButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editorToolsPaintbrushButton.Name = "editorToolsPaintbrushButton";
            this.editorToolsPaintbrushButton.Size = new System.Drawing.Size(35, 36);
            this.editorToolsPaintbrushButton.Text = "Create Tool";
            this.editorToolsPaintbrushButton.ToolTipText = "Create Tool";
            this.editorToolsPaintbrushButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripButton_Clicked);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.playButton);
            this.flowLayoutPanel1.Controls.Add(this.cameraToolOptions);
            this.flowLayoutPanel1.Controls.Add(this.transformToolOptions1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(500, 44);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(624, 56);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // playButton
            // 
            this.playButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.playButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("playButton.BackgroundImage")));
            this.playButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.playButton.Enabled = false;
            this.playButton.FlatAppearance.BorderSize = 0;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.ForeColor = System.Drawing.SystemColors.Control;
            this.playButton.Location = new System.Drawing.Point(30, 10);
            this.playButton.Margin = new System.Windows.Forms.Padding(30, 5, 3, 5);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(65, 40);
            this.playButton.TabIndex = 2;
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // cameraToolOptions
            // 
            this.cameraToolOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cameraToolOptions.Location = new System.Drawing.Point(110, 12);
            this.cameraToolOptions.Margin = new System.Windows.Forms.Padding(12);
            this.cameraToolOptions.Name = "cameraToolOptions";
            this.cameraToolOptions.Size = new System.Drawing.Size(234, 36);
            this.cameraToolOptions.TabIndex = 0;
            // 
            // transformToolOptions1
            // 
            this.transformToolOptions1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.transformToolOptions1.ForeColor = System.Drawing.SystemColors.Control;
            this.transformToolOptions1.Location = new System.Drawing.Point(12, 72);
            this.transformToolOptions1.Margin = new System.Windows.Forms.Padding(12);
            this.transformToolOptions1.Name = "transformToolOptions1";
            this.transformToolOptions1.Size = new System.Drawing.Size(486, 36);
            this.transformToolOptions1.TabIndex = 1;
            // 
            // terminalPanel
            // 
            this.terminalPanel.AutoSize = true;
            this.terminalPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.terminalPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.terminalPanel.Controls.Add(this.outputLabel);
            this.terminalPanel.Controls.Add(this.outputTextBox);
            this.terminalPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.terminalPanel.Location = new System.Drawing.Point(500, 571);
            this.terminalPanel.MinimumSize = new System.Drawing.Size(2, 400);
            this.terminalPanel.Name = "terminalPanel";
            this.terminalPanel.Padding = new System.Windows.Forms.Padding(10);
            this.terminalPanel.Size = new System.Drawing.Size(624, 400);
            this.terminalPanel.TabIndex = 12;
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.outputLabel.Location = new System.Drawing.Point(13, 10);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(82, 25);
            this.outputLabel.TabIndex = 1;
            this.outputLabel.Text = "Output:";
            // 
            // outputTextBox
            // 
            this.outputTextBox.AcceptsTab = true;
            this.outputTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.outputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.outputTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.outputTextBox.Location = new System.Drawing.Point(10, 52);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(602, 336);
            this.outputTextBox.TabIndex = 0;
            this.outputTextBox.Text = "";
            // 
            // editorWindow
            // 
            this.editorWindow.AllowDrop = true;
            this.editorWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorWindow.EditorForm = null;
            this.editorWindow.Location = new System.Drawing.Point(500, 100);
            this.editorWindow.Margin = new System.Windows.Forms.Padding(6);
            this.editorWindow.Name = "editorWindow";
            this.editorWindow.Size = new System.Drawing.Size(624, 471);
            this.editorWindow.TabIndex = 8;
            this.editorWindow.Text = "editorWindow";
            this.editorWindow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.editorWindow_RightClick);
            // 
            // startupPage
            // 
            this.startupPage.AutoSize = true;
            this.startupPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.startupPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startupPage.Eform = null;
            this.startupPage.ForeColor = System.Drawing.SystemColors.Control;
            this.startupPage.Location = new System.Drawing.Point(0, 44);
            this.startupPage.MinimumSize = new System.Drawing.Size(600, 600);
            this.startupPage.Name = "startupPage";
            this.startupPage.Size = new System.Drawing.Size(1894, 965);
            this.startupPage.TabIndex = 11;
            // 
            // assetInfo
            // 
            this.assetInfo.AutoSize = true;
            this.assetInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.assetInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.assetInfo.Location = new System.Drawing.Point(0, 453);
            this.assetInfo.Name = "assetInfo";
            this.assetInfo.Size = new System.Drawing.Size(500, 47);
            this.assetInfo.TabIndex = 4;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1894, 1009);
            this.Controls.Add(this.editorToolStrip);
            this.Controls.Add(this.editorWindow);
            this.Controls.Add(this.terminalPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.editorTabs);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.startupPage);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
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
            this.materialsTab.ResumeLayout(false);
            this.materialsSplitContainer.Panel1.ResumeLayout(false);
            this.materialsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.materialsSplitContainer)).EndInit();
            this.materialsSplitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.assetPreviewPanel.ResumeLayout(false);
            this.assetPreviewPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assetsPictureBox)).EndInit();
            this.AssetsLabelPanel.ResumeLayout(false);
            this.editorToolStrip.ResumeLayout(false);
            this.editorToolStrip.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.terminalPanel.ResumeLayout(false);
            this.terminalPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MaterialsListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSceneToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripProjectLabel;
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
        private System.Windows.Forms.ToolStripMenuItem entityTypeToolStripMenuItem;
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
        private ToolStripStatusLabel toolStripSceneLabel;
        private SplitContainer materialsSplitContainer;
        private ListBox materialsListBox;
        private MaterialEditorControl materialEditorControl;
        private ToolStrip editorToolStrip;
        private ToolStripButton editorToolsGrabButton;
        private ToolStripButton editorToolsCameraButton;
        private FlowLayoutPanel flowLayoutPanel1;
        private CameraToolOptions cameraToolOptions;
        private TransformToolOptions transformToolOptions1;
        private ToolStripMenuItem viewClickAreasToolStripMenuItem;
        private ToolStripMenuItem editSceneToolStripMenuItem;
        private ToolStripButton editorToolsPaintbrushButton;
        private ToolStripMenuItem addSceneAsChildToolStripMenuItem;
        private ToolStripMenuItem exportAsSceneToolStripMenuItem;
        private StartupPage startupPage;
        private Panel terminalPanel;
        private Panel assetPreviewPanel;
        private PictureBox assetsPictureBox;
        private Button playButton;
        private Label outputLabel;
        private RichTextBox outputTextBox;
        private Button assetsRefreshButton;
        private AssetInfo assetInfo;
    }
}

