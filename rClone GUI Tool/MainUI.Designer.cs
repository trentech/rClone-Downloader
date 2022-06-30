
namespace rClone_GUI
{
    partial class MainUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            this.textBoxRemote = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.textBoxLocal = new System.Windows.Forms.TextBox();
            this.panelLog = new System.Windows.Forms.Panel();
            this.log = new System.Windows.Forms.Label();
            this.radioPrompt = new System.Windows.Forms.RadioButton();
            this.radioOverwrite = new System.Windows.Forms.RadioButton();
            this.radioSkip = new System.Windows.Forms.RadioButton();
            this.listRemoteFiles = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuRemote = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.listQueue = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuQueue = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.drivesList = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listLocalFiles = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuLocal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.panel5 = new System.Windows.Forms.Panel();
            this.syncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panelLog.SuspendLayout();
            this.contextMenuRemote.SuspendLayout();
            this.contextMenuQueue.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuLocal.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxRemote
            // 
            this.textBoxRemote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRemote.Enabled = false;
            this.textBoxRemote.ForeColor = System.Drawing.Color.Gray;
            this.textBoxRemote.Location = new System.Drawing.Point(102, 4);
            this.textBoxRemote.Name = "textBoxRemote";
            this.textBoxRemote.Size = new System.Drawing.Size(467, 20);
            this.textBoxRemote.TabIndex = 2;
            this.textBoxRemote.Text = "/";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.Location = new System.Drawing.Point(494, 31);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 21);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.onButtonSearch);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilter.ForeColor = System.Drawing.Color.Gray;
            this.textBoxFilter.Location = new System.Drawing.Point(3, 31);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(485, 20);
            this.textBoxFilter.TabIndex = 3;
            this.textBoxFilter.Text = "Filter";
            this.textBoxFilter.TextChanged += new System.EventHandler(this.onTextFilterChange);
            this.textBoxFilter.Enter += new System.EventHandler(this.onTextFilterEnter);
            this.textBoxFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onTextFilterKey);
            this.textBoxFilter.Leave += new System.EventHandler(this.onTextFilterLeave);
            // 
            // textBoxLocal
            // 
            this.textBoxLocal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLocal.Enabled = false;
            this.textBoxLocal.ForeColor = System.Drawing.Color.Gray;
            this.textBoxLocal.Location = new System.Drawing.Point(3, 4);
            this.textBoxLocal.Name = "textBoxLocal";
            this.textBoxLocal.Size = new System.Drawing.Size(564, 20);
            this.textBoxLocal.TabIndex = 5;
            this.textBoxLocal.Text = "..";
            // 
            // panelLog
            // 
            this.panelLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelLog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelLog.Controls.Add(this.log);
            this.panelLog.Location = new System.Drawing.Point(8, 587);
            this.panelLog.Margin = new System.Windows.Forms.Padding(0);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(444, 18);
            this.panelLog.TabIndex = 0;
            // 
            // log
            // 
            this.log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.log.AutoSize = true;
            this.log.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Assertive;
            this.log.Location = new System.Drawing.Point(1, 2);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(0, 13);
            this.log.TabIndex = 0;
            this.log.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioPrompt
            // 
            this.radioPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radioPrompt.AutoSize = true;
            this.radioPrompt.Checked = true;
            this.radioPrompt.Location = new System.Drawing.Point(209, 2);
            this.radioPrompt.Name = "radioPrompt";
            this.radioPrompt.Size = new System.Drawing.Size(58, 17);
            this.radioPrompt.TabIndex = 14;
            this.radioPrompt.TabStop = true;
            this.radioPrompt.Text = "Prompt";
            this.radioPrompt.UseVisualStyleBackColor = true;
            this.radioPrompt.Click += new System.EventHandler(this.onPromptClick);
            // 
            // radioOverwrite
            // 
            this.radioOverwrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radioOverwrite.AutoSize = true;
            this.radioOverwrite.Location = new System.Drawing.Point(81, 2);
            this.radioOverwrite.Name = "radioOverwrite";
            this.radioOverwrite.Size = new System.Drawing.Size(70, 17);
            this.radioOverwrite.TabIndex = 12;
            this.radioOverwrite.TabStop = true;
            this.radioOverwrite.Text = "Overwrite";
            this.radioOverwrite.UseVisualStyleBackColor = true;
            this.radioOverwrite.Click += new System.EventHandler(this.onOverwriteClick);
            // 
            // radioSkip
            // 
            this.radioSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radioSkip.AutoSize = true;
            this.radioSkip.Location = new System.Drawing.Point(157, 2);
            this.radioSkip.Name = "radioSkip";
            this.radioSkip.Size = new System.Drawing.Size(46, 17);
            this.radioSkip.TabIndex = 13;
            this.radioSkip.TabStop = true;
            this.radioSkip.Text = "Skip";
            this.radioSkip.UseVisualStyleBackColor = true;
            this.radioSkip.Click += new System.EventHandler(this.onSkipClicked);
            // 
            // listRemoteFiles
            // 
            this.listRemoteFiles.AllowDrop = true;
            this.listRemoteFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listRemoteFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader10,
            this.columnHeader4});
            this.listRemoteFiles.ContextMenuStrip = this.contextMenuRemote;
            this.listRemoteFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listRemoteFiles.GridLines = true;
            this.listRemoteFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listRemoteFiles.HideSelection = false;
            this.listRemoteFiles.Location = new System.Drawing.Point(0, 0);
            this.listRemoteFiles.Margin = new System.Windows.Forms.Padding(0);
            this.listRemoteFiles.Name = "listRemoteFiles";
            this.listRemoteFiles.Size = new System.Drawing.Size(572, 308);
            this.listRemoteFiles.SmallImageList = this.imageList;
            this.listRemoteFiles.TabIndex = 0;
            this.listRemoteFiles.TabStop = false;
            this.listRemoteFiles.UseCompatibleStateImageBehavior = false;
            this.listRemoteFiles.View = System.Windows.Forms.View.Details;
            this.listRemoteFiles.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.onListLocalDrag);
            this.listRemoteFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.onListRemoteDragDrop);
            this.listRemoteFiles.DragOver += new System.Windows.Forms.DragEventHandler(this.onListRemoteDragOver);
            this.listRemoteFiles.DoubleClick += new System.EventHandler(this.onListRemoteDoubleClick);
            this.listRemoteFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.onListRemoteKeyDown);
            this.listRemoteFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.onListRemoteRightClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 365;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Date Modified";
            this.columnHeader10.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Size";
            this.columnHeader4.Width = 80;
            // 
            // contextMenuRemote
            // 
            this.contextMenuRemote.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem1,
            this.deleteToolStripMenuItem1,
            this.newFolderToolStripMenuItem1,
            this.syncToolStripMenuItem1});
            this.contextMenuRemote.Name = "contextMenuRemote";
            this.contextMenuRemote.Size = new System.Drawing.Size(135, 92);
            this.contextMenuRemote.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.onListRemoteContextMenuClick);
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.refreshToolStripMenuItem1.Text = "Refresh";
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            // 
            // newFolderToolStripMenuItem1
            // 
            this.newFolderToolStripMenuItem1.Name = "newFolderToolStripMenuItem1";
            this.newFolderToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.newFolderToolStripMenuItem1.Text = "New Folder";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "file_icon.png");
            this.imageList.Images.SetKeyName(1, "folder_icon.png");
            this.imageList.Images.SetKeyName(2, "drive_icon.png");
            this.imageList.Images.SetKeyName(3, "back_icon.png");
            // 
            // listQueue
            // 
            this.listQueue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader12,
            this.columnHeader13});
            this.listQueue.ContextMenuStrip = this.contextMenuQueue;
            this.listQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listQueue.GridLines = true;
            this.listQueue.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listQueue.HideSelection = false;
            this.listQueue.Location = new System.Drawing.Point(0, 0);
            this.listQueue.Margin = new System.Windows.Forms.Padding(0);
            this.listQueue.Name = "listQueue";
            this.listQueue.Size = new System.Drawing.Size(1150, 196);
            this.listQueue.TabIndex = 0;
            this.listQueue.TabStop = false;
            this.listQueue.UseCompatibleStateImageBehavior = false;
            this.listQueue.View = System.Windows.Forms.View.Details;
            this.listQueue.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.onListQueueColumnWidthChanging);
            this.listQueue.MouseClick += new System.Windows.Forms.MouseEventHandler(this.onListQueueRightClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Operation";
            this.columnHeader1.Width = 735;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            this.columnHeader2.Width = 94;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Progress";
            this.columnHeader5.Width = 142;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Speed";
            this.columnHeader7.Width = 105;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "ETA";
            this.columnHeader8.Width = 74;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Hidden Size";
            this.columnHeader12.Width = 0;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Hidden Date";
            this.columnHeader13.Width = 0;
            // 
            // contextMenuQueue
            // 
            this.contextMenuQueue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.cancelToolStripMenuItem,
            this.startStripMenuItem1});
            this.contextMenuQueue.Name = "contextMenuStrip1";
            this.contextMenuQueue.Size = new System.Drawing.Size(173, 92);
            this.contextMenuQueue.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.onListQueueContextMenuClick);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.cancelToolStripMenuItem.Text = "Cancel Downloads";
            // 
            // startStripMenuItem1
            // 
            this.startStripMenuItem1.Name = "startStripMenuItem1";
            this.startStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.startStripMenuItem1.Text = "Start Downloads";
            // 
            // drivesList
            // 
            this.drivesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drivesList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drivesList.FormattingEnabled = true;
            this.drivesList.Location = new System.Drawing.Point(3, 4);
            this.drivesList.Name = "drivesList";
            this.drivesList.Size = new System.Drawing.Size(93, 21);
            this.drivesList.Sorted = true;
            this.drivesList.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.listRemoteFiles);
            this.panel3.Location = new System.Drawing.Point(0, 60);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(572, 308);
            this.panel3.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.buttonSearch);
            this.panel2.Controls.Add(this.textBoxFilter);
            this.panel2.Controls.Add(this.drivesList);
            this.panel2.Controls.Add(this.textBoxRemote);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(572, 60);
            this.panel2.TabIndex = 0;
            // 
            // listLocalFiles
            // 
            this.listLocalFiles.AllowDrop = true;
            this.listLocalFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listLocalFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader9,
            this.columnHeader11});
            this.listLocalFiles.ContextMenuStrip = this.contextMenuLocal;
            this.listLocalFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLocalFiles.GridLines = true;
            this.listLocalFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listLocalFiles.HideSelection = false;
            this.listLocalFiles.Location = new System.Drawing.Point(0, 0);
            this.listLocalFiles.Name = "listLocalFiles";
            this.listLocalFiles.Size = new System.Drawing.Size(570, 308);
            this.listLocalFiles.SmallImageList = this.imageList;
            this.listLocalFiles.TabIndex = 0;
            this.listLocalFiles.UseCompatibleStateImageBehavior = false;
            this.listLocalFiles.View = System.Windows.Forms.View.Details;
            this.listLocalFiles.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.onListRemoteDrag);
            this.listLocalFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.onListLocalDragDrop);
            this.listLocalFiles.DragOver += new System.Windows.Forms.DragEventHandler(this.onListLocalDragOver);
            this.listLocalFiles.DoubleClick += new System.EventHandler(this.onListLocalDoubleClick);
            this.listLocalFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.onListLocalRightClick);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Name";
            this.columnHeader6.Width = 365;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Date Modified";
            this.columnHeader9.Width = 120;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Size";
            this.columnHeader11.Width = 80;
            // 
            // contextMenuLocal
            // 
            this.contextMenuLocal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.newFolderToolStripMenuItem,
            this.syncToolStripMenuItem});
            this.contextMenuLocal.Name = "contextMenuStrip1";
            this.contextMenuLocal.Size = new System.Drawing.Size(135, 92);
            this.contextMenuLocal.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.onListLocalContextMenuClick);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // newFolderToolStripMenuItem
            // 
            this.newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            this.newFolderToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.newFolderToolStripMenuItem.Text = "New Folder";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.textBoxLocal);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(570, 60);
            this.panel4.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radioPrompt);
            this.panel1.Controls.Add(this.radioOverwrite);
            this.panel1.Controls.Add(this.radioSkip);
            this.panel1.Location = new System.Drawing.Point(881, 585);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 20);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Copy Action:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Location = new System.Drawing.Point(5, 5);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer2.Panel1MinSize = 200;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listQueue);
            this.splitContainer2.Panel2MinSize = 200;
            this.splitContainer2.Size = new System.Drawing.Size(1154, 576);
            this.splitContainer2.SplitterDistance = 372;
            this.splitContainer2.TabIndex = 2;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.panel3);
            this.splitContainer3.Panel1.Controls.Add(this.panel2);
            this.splitContainer3.Panel1MinSize = 350;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.panel5);
            this.splitContainer3.Panel2.Controls.Add(this.panel4);
            this.splitContainer3.Panel2MinSize = 350;
            this.splitContainer3.Size = new System.Drawing.Size(1154, 372);
            this.splitContainer3.SplitterDistance = 576;
            this.splitContainer3.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.listLocalFiles);
            this.panel5.Location = new System.Drawing.Point(0, 60);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(570, 308);
            this.panel5.TabIndex = 1;
            // 
            // syncToolStripMenuItem
            // 
            this.syncToolStripMenuItem.Name = "syncToolStripMenuItem";
            this.syncToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.syncToolStripMenuItem.Text = "Sync";
            // 
            // syncToolStripMenuItem1
            // 
            this.syncToolStripMenuItem1.Name = "syncToolStripMenuItem1";
            this.syncToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.syncToolStripMenuItem1.Text = "Sync";
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 609);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 600);
            this.Name = "MainUI";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "rClone GUI Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onClosing);
            this.panelLog.ResumeLayout(false);
            this.panelLog.PerformLayout();
            this.contextMenuRemote.ResumeLayout(false);
            this.contextMenuQueue.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuLocal.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxLocal;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxRemote;
        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.ListView listQueue;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView listRemoteFiles;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ComboBox drivesList;
        private System.Windows.Forms.RadioButton radioPrompt;
        private System.Windows.Forms.RadioButton radioOverwrite;
        private System.Windows.Forms.RadioButton radioSkip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label log;
        private System.Windows.Forms.ListView listLocalFiles;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ContextMenuStrip contextMenuQueue;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuLocal;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFolderToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ContextMenuStrip contextMenuRemote;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newFolderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem syncToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem syncToolStripMenuItem;
    }
}

