
namespace rClone_Downloader
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
            this.buttonBack = new System.Windows.Forms.Button();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.textBoxDest = new System.Windows.Forms.TextBox();
            this.panelLog = new System.Windows.Forms.Panel();
            this.log = new System.Windows.Forms.TextBox();
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
            this.panelControls = new System.Windows.Forms.Panel();
            this.containerControls = new System.Windows.Forms.SplitContainer();
            this.drivesList = new System.Windows.Forms.ComboBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.containerMain = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelLog.SuspendLayout();
            this.panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.containerControls)).BeginInit();
            this.containerControls.Panel1.SuspendLayout();
            this.containerControls.Panel2.SuspendLayout();
            this.containerControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.containerMain)).BeginInit();
            this.containerMain.Panel1.SuspendLayout();
            this.containerMain.Panel2.SuspendLayout();
            this.containerMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(2, 3);
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
            this.textBoxSource.Location = new System.Drawing.Point(119, 4);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.Size = new System.Drawing.Size(449, 20);
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
            this.buttonGo.Location = new System.Drawing.Point(493, 28);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 22);
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
            this.textBoxFilter.Location = new System.Drawing.Point(3, 29);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(484, 20);
            this.textBoxFilter.TabIndex = 3;
            this.textBoxFilter.Text = "Filter";
            this.textBoxFilter.TextChanged += new System.EventHandler(this.onTextFilterChange);
            this.textBoxFilter.Enter += new System.EventHandler(this.onTextFilterEnter);
            this.textBoxFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onTextFilterKey);
            this.textBoxFilter.Leave += new System.EventHandler(this.onTextFilterLeave);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowse.Location = new System.Drawing.Point(490, 3);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 22);
            this.buttonBrowse.TabIndex = 6;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.onButtonBrowse);
            // 
            // textBoxDest
            // 
            this.textBoxDest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDest.ForeColor = System.Drawing.Color.Gray;
            this.textBoxDest.Location = new System.Drawing.Point(3, 4);
            this.textBoxDest.Name = "textBoxDest";
            this.textBoxDest.Size = new System.Drawing.Size(481, 20);
            this.textBoxDest.TabIndex = 5;
            this.textBoxDest.Text = "Destination";
            this.textBoxDest.TextChanged += new System.EventHandler(this.onTextDestChange);
            this.textBoxDest.Enter += new System.EventHandler(this.onTextDestEnter);
            this.textBoxDest.Leave += new System.EventHandler(this.onTextDestLeave);
            // 
            // panelLog
            // 
            this.panelLog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelLog.Controls.Add(this.log);
            this.panelLog.Location = new System.Drawing.Point(5, 709);
            this.panelLog.Margin = new System.Windows.Forms.Padding(0);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(444, 15);
            this.panelLog.TabIndex = 1;
            // 
            // log
            // 
            this.log.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.log.BackColor = System.Drawing.SystemColors.Control;
            this.log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.log.Location = new System.Drawing.Point(3, 0);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.Size = new System.Drawing.Size(441, 15);
            this.log.TabIndex = 1;
            this.log.TabStop = false;
            // 
            // radioPrompt
            // 
            this.radioPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radioPrompt.AutoSize = true;
            this.radioPrompt.Checked = true;
            this.radioPrompt.Location = new System.Drawing.Point(212, -1);
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
            this.radioOverwrite.Location = new System.Drawing.Point(84, -1);
            this.radioOverwrite.Name = "radioOverwrite";
            this.radioOverwrite.Size = new System.Drawing.Size(70, 17);
            this.radioOverwrite.TabIndex = 12;
            this.radioOverwrite.Text = "Overwrite";
            this.radioOverwrite.UseVisualStyleBackColor = true;
            this.radioOverwrite.Click += new System.EventHandler(this.onOverwriteClick);
            // 
            // radioSkip
            // 
            this.radioSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radioSkip.AutoSize = true;
            this.radioSkip.Location = new System.Drawing.Point(160, -1);
            this.radioSkip.Name = "radioSkip";
            this.radioSkip.Size = new System.Drawing.Size(46, 17);
            this.radioSkip.TabIndex = 13;
            this.radioSkip.Text = "Skip";
            this.radioSkip.UseVisualStyleBackColor = true;
            this.radioSkip.Click += new System.EventHandler(this.onSkipClicked);
            // 
            // listFiles
            // 
            this.listFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader10,
            this.columnHeader4});
            this.listFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listFiles.GridLines = true;
            this.listFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listFiles.HideSelection = false;
            this.listFiles.Location = new System.Drawing.Point(0, 0);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(476, 636);
            this.listFiles.SmallImageList = this.imageList1;
            this.listFiles.TabIndex = 0;
            this.listFiles.UseCompatibleStateImageBehavior = false;
            this.listFiles.View = System.Windows.Forms.View.Details;
            this.listFiles.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.onListChange);
            this.listFiles.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.onDrag);
            this.listFiles.DoubleClick += new System.EventHandler(this.onListClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 281;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Date Modified";
            this.columnHeader10.Width = 108;
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
            // 
            // listDownloads
            // 
            this.listDownloads.AllowDrop = true;
            this.listDownloads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader8});
            this.listDownloads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDownloads.FullRowSelect = true;
            this.listDownloads.GridLines = true;
            this.listDownloads.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listDownloads.HideSelection = false;
            this.listDownloads.Location = new System.Drawing.Point(0, 0);
            this.listDownloads.Name = "listDownloads";
            this.listDownloads.Size = new System.Drawing.Size(668, 636);
            this.listDownloads.TabIndex = 0;
            this.listDownloads.UseCompatibleStateImageBehavior = false;
            this.listDownloads.View = System.Windows.Forms.View.Details;
            this.listDownloads.DragDrop += new System.Windows.Forms.DragEventHandler(this.onDragDrop);
            this.listDownloads.DragOver += new System.Windows.Forms.DragEventHandler(this.onDragOver);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 296;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            this.columnHeader2.Width = 93;
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
            // panelControls
            // 
            this.panelControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControls.Controls.Add(this.containerControls);
            this.panelControls.Location = new System.Drawing.Point(8, 8);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(1148, 53);
            this.panelControls.TabIndex = 2;
            // 
            // containerControls
            // 
            this.containerControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.containerControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.containerControls.Location = new System.Drawing.Point(0, 0);
            this.containerControls.Name = "containerControls";
            // 
            // containerControls.Panel1
            // 
            this.containerControls.Panel1.Controls.Add(this.drivesList);
            this.containerControls.Panel1.Controls.Add(this.buttonGo);
            this.containerControls.Panel1.Controls.Add(this.textBoxSource);
            this.containerControls.Panel1.Controls.Add(this.textBoxFilter);
            this.containerControls.Panel1.Controls.Add(this.buttonBack);
            // 
            // containerControls.Panel2
            // 
            this.containerControls.Panel2.Controls.Add(this.buttonRemove);
            this.containerControls.Panel2.Controls.Add(this.buttonAdd);
            this.containerControls.Panel2.Controls.Add(this.buttonClear);
            this.containerControls.Panel2.Controls.Add(this.buttonCancel);
            this.containerControls.Panel2.Controls.Add(this.buttonDownload);
            this.containerControls.Panel2.Controls.Add(this.buttonBrowse);
            this.containerControls.Panel2.Controls.Add(this.textBoxDest);
            this.containerControls.Size = new System.Drawing.Size(1148, 53);
            this.containerControls.SplitterDistance = 574;
            this.containerControls.TabIndex = 0;
            // 
            // drivesList
            // 
            this.drivesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drivesList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drivesList.FormattingEnabled = true;
            this.drivesList.Location = new System.Drawing.Point(35, 4);
            this.drivesList.Name = "drivesList";
            this.drivesList.Size = new System.Drawing.Size(78, 21);
            this.drivesList.Sorted = true;
            this.drivesList.TabIndex = 1;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(84, 28);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 22);
            this.buttonRemove.TabIndex = 11;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.onButtonRemove);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(3, 28);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 22);
            this.buttonAdd.TabIndex = 10;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.onButtonAdd);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(165, 28);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 22);
            this.buttonClear.TabIndex = 9;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.onClearClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(409, 28);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 22);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.onCancelClick);
            // 
            // buttonDownload
            // 
            this.buttonDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDownload.Enabled = false;
            this.buttonDownload.Location = new System.Drawing.Point(490, 28);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(75, 22);
            this.buttonDownload.TabIndex = 7;
            this.buttonDownload.Text = "Download";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.onButtonDownload);
            // 
            // containerMain
            // 
            this.containerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.containerMain.Location = new System.Drawing.Point(8, 67);
            this.containerMain.Name = "containerMain";
            // 
            // containerMain.Panel1
            // 
            this.containerMain.Panel1.Controls.Add(this.listFiles);
            // 
            // containerMain.Panel2
            // 
            this.containerMain.Panel2.Controls.Add(this.listDownloads);
            this.containerMain.Size = new System.Drawing.Size(1148, 636);
            this.containerMain.SplitterDistance = 476;
            this.containerMain.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radioPrompt);
            this.panel1.Controls.Add(this.radioOverwrite);
            this.panel1.Controls.Add(this.radioSkip);
            this.panel1.Location = new System.Drawing.Point(876, 709);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 17);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Default Action:";
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 729);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.containerMain);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.panelLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 768);
            this.Name = "MainUI";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "rClone Downloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onClosing);
            this.panelLog.ResumeLayout(false);
            this.panelLog.PerformLayout();
            this.panelControls.ResumeLayout(false);
            this.containerControls.Panel1.ResumeLayout(false);
            this.containerControls.Panel1.PerformLayout();
            this.containerControls.Panel2.ResumeLayout(false);
            this.containerControls.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.containerControls)).EndInit();
            this.containerControls.ResumeLayout(false);
            this.containerMain.Panel1.ResumeLayout(false);
            this.containerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.containerMain)).EndInit();
            this.containerMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.TextBox textBoxDest;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.SplitContainer containerControls;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.TextBox log;
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
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.RadioButton radioPrompt;
        private System.Windows.Forms.RadioButton radioOverwrite;
        private System.Windows.Forms.RadioButton radioSkip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ImageList imageList1;
    }
}

