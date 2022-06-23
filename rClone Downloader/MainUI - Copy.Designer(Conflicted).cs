
namespace rClone_Downloader
{
    partial class MainUI2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI2));
            this.buttonBack = new System.Windows.Forms.Button();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.textBoxDest = new System.Windows.Forms.TextBox();
            this.panelLog = new System.Windows.Forms.Panel();
            this.log = new System.Windows.Forms.Label();
            this.radioPrompt = new System.Windows.Forms.RadioButton();
            this.radioOverwrite = new System.Windows.Forms.RadioButton();
            this.radioSkip = new System.Windows.Forms.RadioButton();
            this.listFiles = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listDownloads = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.drivesList = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.containerMain = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.containerMain)).BeginInit();
            this.containerMain.Panel1.SuspendLayout();
            this.containerMain.Panel2.SuspendLayout();
            this.containerMain.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(3, 2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(27, 22);
            this.buttonBack.TabIndex = 0;
            this.buttonBack.Text = "<<";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.onButtonBack);
            // 
            // textBoxSource
            // 
            this.textBoxSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSource.ForeColor = System.Drawing.Color.Gray;
            this.textBoxSource.Location = new System.Drawing.Point(121, 3);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.Size = new System.Drawing.Size(446, 20);
            this.textBoxSource.TabIndex = 2;
            this.textBoxSource.Text = "Source";
            this.textBoxSource.Click += new System.EventHandler(this.onTextDestChange);
            this.textBoxSource.TextChanged += new System.EventHandler(this.onTextSourceChange);
            this.textBoxSource.Enter += new System.EventHandler(this.onTextSourceEnter);
            this.textBoxSource.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onTextSourceKey);
            this.textBoxSource.Leave += new System.EventHandler(this.onTextSourceLeave);
            // 
            // buttonGo
            // 
            this.buttonGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGo.Location = new System.Drawing.Point(492, 29);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 4;
            this.buttonGo.Text = "Go";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.onButtonGo);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilter.ForeColor = System.Drawing.Color.Gray;
            this.textBoxFilter.Location = new System.Drawing.Point(3, 31);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(483, 20);
            this.textBoxFilter.TabIndex = 3;
            this.textBoxFilter.Text = "Filter";
            this.textBoxFilter.TextChanged += new System.EventHandler(this.onTextFilterChange);
            this.textBoxFilter.Enter += new System.EventHandler(this.onTextFilterEnter);
            this.textBoxFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onTextFilterKey);
            this.textBoxFilter.Leave += new System.EventHandler(this.onTextFilterLeave);
            // 
            // textBoxDest
            // 
            this.textBoxDest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDest.Enabled = false;
            this.textBoxDest.ForeColor = System.Drawing.Color.Gray;
            this.textBoxDest.Location = new System.Drawing.Point(3, 3);
            this.textBoxDest.Name = "textBoxDest";
            this.textBoxDest.Size = new System.Drawing.Size(403, 20);
            this.textBoxDest.TabIndex = 5;
            this.textBoxDest.TextChanged += new System.EventHandler(this.onTextDestChange);
            this.textBoxDest.Enter += new System.EventHandler(this.onTextDestEnter);
            this.textBoxDest.Leave += new System.EventHandler(this.onTextDestLeave);
            // 
            // panelLog
            // 
            this.panelLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelLog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelLog.Controls.Add(this.log);
            this.panelLog.Location = new System.Drawing.Point(8, 539);
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
            this.radioOverwrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioOverwrite.Location = new System.Drawing.Point(82, 2);
            this.radioOverwrite.Name = "radioOverwrite";
            this.radioOverwrite.Size = new System.Drawing.Size(69, 17);
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
            // listFiles
            // 
            this.listFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader10,
            this.columnHeader4});
            this.listFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listFiles.GridLines = true;
            this.listFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listFiles.HideSelection = false;
            this.listFiles.Location = new System.Drawing.Point(0, 0);
            this.listFiles.Margin = new System.Windows.Forms.Padding(0);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(570, 466);
            this.listFiles.SmallImageList = this.imageList1;
            this.listFiles.TabIndex = 0;
            this.listFiles.TabStop = false;
            this.listFiles.UseCompatibleStateImageBehavior = false;
            this.listFiles.View = System.Windows.Forms.View.Details;
            this.listFiles.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.onListChange);
            this.listFiles.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.onDrag);
            this.listFiles.DoubleClick += new System.EventHandler(this.onListClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 382;
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "file_icon.png");
            this.imageList1.Images.SetKeyName(1, "folder_icon.png");
            this.imageList1.Images.SetKeyName(2, "drive_icon.png");
            this.imageList1.Images.SetKeyName(3, "back_icon.png");
            // 
            // listDownloads
            // 
            this.listDownloads.AllowDrop = true;
            this.listDownloads.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listDownloads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader8});
            this.listDownloads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDownloads.GridLines = true;
            this.listDownloads.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listDownloads.HideSelection = false;
            this.listDownloads.Location = new System.Drawing.Point(0, 0);
            this.listDownloads.Margin = new System.Windows.Forms.Padding(0);
            this.listDownloads.Name = "listDownloads";
            this.listDownloads.Size = new System.Drawing.Size(571, 265);
            this.listDownloads.TabIndex = 0;
            this.listDownloads.TabStop = false;
            this.listDownloads.UseCompatibleStateImageBehavior = false;
            this.listDownloads.View = System.Windows.Forms.View.Details;
            this.listDownloads.Click += new System.EventHandler(this.onRightClick);
            this.listDownloads.DragDrop += new System.Windows.Forms.DragEventHandler(this.onDragDrop);
            this.listDownloads.DragOver += new System.Windows.Forms.DragEventHandler(this.onDragOver);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 203;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            this.columnHeader2.Width = 87;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Progress";
            this.columnHeader5.Width = 123;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Speed";
            this.columnHeader7.Width = 76;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "ETA";
            this.columnHeader8.Width = 74;
            // 
            // drivesList
            // 
            this.drivesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drivesList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drivesList.FormattingEnabled = true;
            this.drivesList.Location = new System.Drawing.Point(37, 4);
            this.drivesList.Name = "drivesList";
            this.drivesList.Size = new System.Drawing.Size(78, 21);
            this.drivesList.Sorted = true;
            this.drivesList.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(412, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 22);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.onCancelClick);
            // 
            // buttonDownload
            // 
            this.buttonDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDownload.Enabled = false;
            this.buttonDownload.Location = new System.Drawing.Point(492, 3);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(75, 22);
            this.buttonDownload.TabIndex = 11;
            this.buttonDownload.Text = "Download";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.onButtonDownload);
            // 
            // containerMain
            // 
            this.containerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.containerMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.containerMain.Location = new System.Drawing.Point(8, 8);
            this.containerMain.Name = "containerMain";
            // 
            // containerMain.Panel1
            // 
            this.containerMain.Panel1.Controls.Add(this.panel3);
            this.containerMain.Panel1.Controls.Add(this.panel2);
            this.containerMain.Panel1MinSize = 410;
            // 
            // containerMain.Panel2
            // 
            this.containerMain.Panel2.Controls.Add(this.splitContainer1);
            this.containerMain.Panel2.Controls.Add(this.panel4);
            this.containerMain.Panel2MinSize = 410;
            this.containerMain.Size = new System.Drawing.Size(1148, 527);
            this.containerMain.SplitterDistance = 572;
            this.containerMain.TabIndex = 0;
            this.containerMain.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.listFiles);
            this.panel3.Location = new System.Drawing.Point(0, 60);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(570, 466);
            this.panel3.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.buttonGo);
            this.panel2.Controls.Add(this.buttonBack);
            this.panel2.Controls.Add(this.textBoxFilter);
            this.panel2.Controls.Add(this.drivesList);
            this.panel2.Controls.Add(this.textBoxSource);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(570, 60);
            this.panel2.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listDownloads);
            this.splitContainer1.Size = new System.Drawing.Size(571, 495);
            this.splitContainer1.SplitterDistance = 226;
            this.splitContainer1.TabIndex = 15;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader9,
            this.columnHeader11});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(571, 226);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.onFileExplorerDoubleClick);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Name";
            this.columnHeader6.Width = 361;
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
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.textBoxDest);
            this.panel4.Controls.Add(this.buttonCancel);
            this.panel4.Controls.Add(this.buttonDownload);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(570, 30);
            this.panel4.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radioPrompt);
            this.panel1.Controls.Add(this.radioOverwrite);
            this.panel1.Controls.Add(this.radioSkip);
            this.panel1.Location = new System.Drawing.Point(881, 537);
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
            // MainUI2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.containerMain);
            this.Controls.Add(this.panelLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 600);
            this.Name = "MainUI2";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "rClone Downloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onClosing);
            this.panelLog.ResumeLayout(false);
            this.panelLog.PerformLayout();
            this.containerMain.Panel1.ResumeLayout(false);
            this.containerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.containerMain)).EndInit();
            this.containerMain.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxDest;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.ListView listDownloads;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView listFiles;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ComboBox drivesList;
        private System.Windows.Forms.SplitContainer containerMain;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.RadioButton radioPrompt;
        private System.Windows.Forms.RadioButton radioOverwrite;
        private System.Windows.Forms.RadioButton radioSkip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label log;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

