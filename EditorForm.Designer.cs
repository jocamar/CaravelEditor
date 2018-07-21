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
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCollisionShapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewBoundingBoxesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCamerasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewBoundingCirclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEntityTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editorTabs = new Dotnetrix.Controls.TabControlEX();
            this.sceneTab = new System.Windows.Forms.TabPage();
            this.sceneSplitContainer = new System.Windows.Forms.SplitContainer();
            this.sceneEntitiesTreeView = new System.Windows.Forms.TreeView();
            this.entityTypesTab = new System.Windows.Forms.TabPage();
            this.materialsTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.assetsTreeView = new System.Windows.Forms.TreeView();
            this.AssetsLabelPanel = new System.Windows.Forms.Panel();
            this.AssetsLabel = new System.Windows.Forms.Label();
            this.editorWindow = new CaravelEditor.EditorWindow();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.editorTabs.SuspendLayout();
            this.sceneTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sceneSplitContainer)).BeginInit();
            this.sceneSplitContainer.Panel1.SuspendLayout();
            this.sceneSplitContainer.SuspendLayout();
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
            this.editToolStripMenuItem});
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
            this.openToolStripMenuItem,
            this.loadSceneToolStripMenuItem});
            this.projectToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.openToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open Project";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // loadSceneToolStripMenuItem
            // 
            this.loadSceneToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loadSceneToolStripMenuItem.Enabled = false;
            this.loadSceneToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.loadSceneToolStripMenuItem.Name = "loadSceneToolStripMenuItem";
            this.loadSceneToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadSceneToolStripMenuItem.Text = "Load Scene";
            this.loadSceneToolStripMenuItem.Click += new System.EventHandler(this.loadSceneToolStripMenuItem_Click);
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
            this.entitiesToolStripMenuItem,
            this.materialsToolStripMenuItem});
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
            this.createTypeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.createTypeToolStripMenuItem.Name = "createTypeToolStripMenuItem";
            this.createTypeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.createTypeToolStripMenuItem.Text = "Create Type";
            // 
            // removeTypeToolStripMenuItem
            // 
            this.removeTypeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.removeTypeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.removeTypeToolStripMenuItem.Name = "removeTypeToolStripMenuItem";
            this.removeTypeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeTypeToolStripMenuItem.Text = "Remove Type";
            // 
            // entitiesToolStripMenuItem
            // 
            this.entitiesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.entitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.entitiesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.entitiesToolStripMenuItem.Name = "entitiesToolStripMenuItem";
            this.entitiesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.entitiesToolStripMenuItem.Text = "Entities";
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addNewToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            this.addNewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addNewToolStripMenuItem.Text = "Add New";
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.removeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            // 
            // materialsToolStripMenuItem
            // 
            this.materialsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.materialsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewToolStripMenuItem1,
            this.removeToolStripMenuItem1});
            this.materialsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.materialsToolStripMenuItem.Name = "materialsToolStripMenuItem";
            this.materialsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.materialsToolStripMenuItem.Text = "Materials";
            // 
            // addNewToolStripMenuItem1
            // 
            this.addNewToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addNewToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.Control;
            this.addNewToolStripMenuItem1.Name = "addNewToolStripMenuItem1";
            this.addNewToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.addNewToolStripMenuItem1.Text = "Add New";
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.removeToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.Control;
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            this.removeToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.removeToolStripMenuItem1.Text = "Remove";
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
            this.sceneSplitContainer.SplitterDistance = 304;
            this.sceneSplitContainer.TabIndex = 1;
            // 
            // sceneEntitiesTreeView
            // 
            this.sceneEntitiesTreeView.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.sceneEntitiesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sceneEntitiesTreeView.ForeColor = System.Drawing.SystemColors.Control;
            this.sceneEntitiesTreeView.Location = new System.Drawing.Point(0, 0);
            this.sceneEntitiesTreeView.Name = "sceneEntitiesTreeView";
            this.sceneEntitiesTreeView.Size = new System.Drawing.Size(371, 304);
            this.sceneEntitiesTreeView.TabIndex = 0;
            this.sceneEntitiesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.entityTreeView_AfterSelect);
            // 
            // entityTypesTab
            // 
            this.entityTypesTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.entityTypesTab.ForeColor = System.Drawing.SystemColors.Control;
            this.entityTypesTab.Location = new System.Drawing.Point(4, 25);
            this.entityTypesTab.Name = "entityTypesTab";
            this.entityTypesTab.Padding = new System.Windows.Forms.Padding(3);
            this.entityTypesTab.Size = new System.Drawing.Size(377, 645);
            this.entityTypesTab.TabIndex = 1;
            this.entityTypesTab.Text = "Entity Types";
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
            // editorWindow
            // 
            this.editorWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorWindow.EditorForm = null;
            this.editorWindow.Location = new System.Drawing.Point(178, 24);
            this.editorWindow.Name = "editorWindow";
            this.editorWindow.Size = new System.Drawing.Size(717, 674);
            this.editorWindow.TabIndex = 8;
            this.editorWindow.Text = "editorWindow";
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
        private System.Windows.Forms.ToolStripMenuItem entitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
    }
}

