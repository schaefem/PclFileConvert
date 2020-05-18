namespace PclFileConvert
{
    partial class dlgShell
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblPclDir = new System.Windows.Forms.Label();
            this.btnPclDir = new System.Windows.Forms.Button();
            this.slePclDir = new System.Windows.Forms.TextBox();
            this.panMain = new System.Windows.Forms.TableLayoutPanel();
            this.slePclExtension = new System.Windows.Forms.TextBox();
            this.lblPclExtension = new System.Windows.Forms.Label();
            this.sleGhostParams = new System.Windows.Forms.TextBox();
            this.lblGhostParams = new System.Windows.Forms.Label();
            this.btnGhostExecutable = new System.Windows.Forms.Button();
            this.sleGhostExecutable = new System.Windows.Forms.TextBox();
            this.lblGhostExecutable = new System.Windows.Forms.Label();
            this.btnTargetDir = new System.Windows.Forms.Button();
            this.sleTargetDir = new System.Windows.Forms.TextBox();
            this.lblTargetDir = new System.Windows.Forms.Label();
            this.mleLog = new System.Windows.Forms.TextBox();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.sleIntervall = new System.Windows.Forms.NumericUpDown();
            this.lblIntervall = new System.Windows.Forms.Label();
            this.ckbStart = new System.Windows.Forms.CheckBox();
            this.lblDeleteOldPdf = new System.Windows.Forms.Label();
            this.sleDeleteOldPdf = new System.Windows.Forms.NumericUpDown();
            this.lblDeleteOldPdfInfo = new System.Windows.Forms.Label();
            this.ckbRemovePclFiles = new System.Windows.Forms.CheckBox();
            this.binSettings = new System.Windows.Forms.BindingSource(this.components);
            this.panMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sleIntervall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sleDeleteOldPdf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPclDir
            // 
            this.lblPclDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPclDir.Location = new System.Drawing.Point(3, 0);
            this.lblPclDir.Name = "lblPclDir";
            this.lblPclDir.Size = new System.Drawing.Size(194, 24);
            this.lblPclDir.TabIndex = 0;
            this.lblPclDir.Text = "Zu überwachender Ordner";
            this.lblPclDir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPclDir
            // 
            this.btnPclDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPclDir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPclDir.Location = new System.Drawing.Point(500, 0);
            this.btnPclDir.Margin = new System.Windows.Forms.Padding(0);
            this.btnPclDir.Name = "btnPclDir";
            this.btnPclDir.Size = new System.Drawing.Size(30, 24);
            this.btnPclDir.TabIndex = 1;
            this.btnPclDir.Text = "...";
            this.btnPclDir.UseVisualStyleBackColor = true;
            this.btnPclDir.Click += new System.EventHandler(this.LookForDir);
            // 
            // slePclDir
            // 
            this.slePclDir.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.binSettings, "PclInputFolder", true));
            this.slePclDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slePclDir.Location = new System.Drawing.Point(200, 3);
            this.slePclDir.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.slePclDir.Name = "slePclDir";
            this.slePclDir.Size = new System.Drawing.Size(300, 20);
            this.slePclDir.TabIndex = 2;
            // 
            // panMain
            // 
            this.panMain.ColumnCount = 7;
            this.panMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.panMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.panMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.panMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.panMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panMain.Controls.Add(this.slePclExtension, 4, 4);
            this.panMain.Controls.Add(this.lblPclExtension, 3, 4);
            this.panMain.Controls.Add(this.sleGhostParams, 4, 2);
            this.panMain.Controls.Add(this.lblGhostParams, 3, 2);
            this.panMain.Controls.Add(this.btnGhostExecutable, 2, 2);
            this.panMain.Controls.Add(this.sleGhostExecutable, 1, 2);
            this.panMain.Controls.Add(this.lblGhostExecutable, 0, 2);
            this.panMain.Controls.Add(this.btnTargetDir, 5, 0);
            this.panMain.Controls.Add(this.sleTargetDir, 4, 0);
            this.panMain.Controls.Add(this.lblTargetDir, 3, 0);
            this.panMain.Controls.Add(this.lblPclDir, 0, 0);
            this.panMain.Controls.Add(this.btnPclDir, 2, 0);
            this.panMain.Controls.Add(this.slePclDir, 1, 0);
            this.panMain.Controls.Add(this.mleLog, 0, 9);
            this.panMain.Controls.Add(this.btnSaveSettings, 0, 10);
            this.panMain.Controls.Add(this.sleIntervall, 1, 4);
            this.panMain.Controls.Add(this.lblIntervall, 0, 4);
            this.panMain.Controls.Add(this.ckbStart, 1, 10);
            this.panMain.Controls.Add(this.lblDeleteOldPdf, 0, 6);
            this.panMain.Controls.Add(this.sleDeleteOldPdf, 1, 6);
            this.panMain.Controls.Add(this.lblDeleteOldPdfInfo, 2, 6);
            this.panMain.Controls.Add(this.ckbRemovePclFiles, 0, 8);
            this.panMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMain.Location = new System.Drawing.Point(0, 0);
            this.panMain.Name = "panMain";
            this.panMain.RowCount = 11;
            this.panMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.panMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.panMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.panMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.panMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.panMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panMain.Size = new System.Drawing.Size(1072, 586);
            this.panMain.TabIndex = 3;
            // 
            // slePclExtension
            // 
            this.slePclExtension.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.binSettings, "PclExtension", true));
            this.slePclExtension.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slePclExtension.Location = new System.Drawing.Point(730, 61);
            this.slePclExtension.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.slePclExtension.Name = "slePclExtension";
            this.slePclExtension.Size = new System.Drawing.Size(300, 20);
            this.slePclExtension.TabIndex = 16;
            // 
            // lblPclExtension
            // 
            this.lblPclExtension.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPclExtension.Location = new System.Drawing.Point(533, 58);
            this.lblPclExtension.Name = "lblPclExtension";
            this.lblPclExtension.Size = new System.Drawing.Size(194, 24);
            this.lblPclExtension.TabIndex = 15;
            this.lblPclExtension.Text = "Dateierweiterung für PCL-Dateien";
            this.lblPclExtension.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sleGhostParams
            // 
            this.sleGhostParams.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.binSettings, "GhostPclParams", true));
            this.sleGhostParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sleGhostParams.Location = new System.Drawing.Point(730, 32);
            this.sleGhostParams.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.sleGhostParams.Name = "sleGhostParams";
            this.sleGhostParams.Size = new System.Drawing.Size(300, 20);
            this.sleGhostParams.TabIndex = 10;
            // 
            // lblGhostParams
            // 
            this.lblGhostParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGhostParams.Location = new System.Drawing.Point(533, 29);
            this.lblGhostParams.Name = "lblGhostParams";
            this.lblGhostParams.Size = new System.Drawing.Size(194, 24);
            this.lblGhostParams.TabIndex = 9;
            this.lblGhostParams.Text = "Parameter für GhostPCL";
            this.lblGhostParams.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGhostExecutable
            // 
            this.btnGhostExecutable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGhostExecutable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGhostExecutable.Location = new System.Drawing.Point(500, 29);
            this.btnGhostExecutable.Margin = new System.Windows.Forms.Padding(0);
            this.btnGhostExecutable.Name = "btnGhostExecutable";
            this.btnGhostExecutable.Size = new System.Drawing.Size(30, 24);
            this.btnGhostExecutable.TabIndex = 8;
            this.btnGhostExecutable.Text = "...";
            this.btnGhostExecutable.UseVisualStyleBackColor = true;
            this.btnGhostExecutable.Click += new System.EventHandler(this.btnGhostExecutable_Click);
            // 
            // sleGhostExecutable
            // 
            this.sleGhostExecutable.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.binSettings, "GhostPclPath", true));
            this.sleGhostExecutable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sleGhostExecutable.Location = new System.Drawing.Point(200, 32);
            this.sleGhostExecutable.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.sleGhostExecutable.Name = "sleGhostExecutable";
            this.sleGhostExecutable.Size = new System.Drawing.Size(300, 20);
            this.sleGhostExecutable.TabIndex = 7;
            // 
            // lblGhostExecutable
            // 
            this.lblGhostExecutable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGhostExecutable.Location = new System.Drawing.Point(3, 29);
            this.lblGhostExecutable.Name = "lblGhostExecutable";
            this.lblGhostExecutable.Size = new System.Drawing.Size(194, 24);
            this.lblGhostExecutable.TabIndex = 6;
            this.lblGhostExecutable.Text = "Pfad GhostPCL";
            this.lblGhostExecutable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTargetDir
            // 
            this.btnTargetDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTargetDir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTargetDir.Location = new System.Drawing.Point(1030, 0);
            this.btnTargetDir.Margin = new System.Windows.Forms.Padding(0);
            this.btnTargetDir.Name = "btnTargetDir";
            this.btnTargetDir.Size = new System.Drawing.Size(30, 24);
            this.btnTargetDir.TabIndex = 5;
            this.btnTargetDir.Text = "...";
            this.btnTargetDir.UseVisualStyleBackColor = true;
            this.btnTargetDir.Click += new System.EventHandler(this.LookForDir);
            // 
            // sleTargetDir
            // 
            this.sleTargetDir.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.binSettings, "PdfOutputFolder", true));
            this.sleTargetDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sleTargetDir.Location = new System.Drawing.Point(730, 3);
            this.sleTargetDir.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.sleTargetDir.Name = "sleTargetDir";
            this.sleTargetDir.Size = new System.Drawing.Size(300, 20);
            this.sleTargetDir.TabIndex = 4;
            // 
            // lblTargetDir
            // 
            this.lblTargetDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTargetDir.Location = new System.Drawing.Point(533, 0);
            this.lblTargetDir.Name = "lblTargetDir";
            this.lblTargetDir.Size = new System.Drawing.Size(194, 24);
            this.lblTargetDir.TabIndex = 3;
            this.lblTargetDir.Text = "Zielordner für PDF-Ausgabe";
            this.lblTargetDir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mleLog
            // 
            this.panMain.SetColumnSpan(this.mleLog, 6);
            this.mleLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mleLog.Location = new System.Drawing.Point(3, 143);
            this.mleLog.Multiline = true;
            this.mleLog.Name = "mleLog";
            this.mleLog.ReadOnly = true;
            this.mleLog.Size = new System.Drawing.Size(1054, 410);
            this.mleLog.TabIndex = 11;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveSettings.Location = new System.Drawing.Point(3, 559);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(194, 24);
            this.btnSaveSettings.TabIndex = 12;
            this.btnSaveSettings.Text = "EINSTELLUNGEN SPEICHERN";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // sleIntervall
            // 
            this.sleIntervall.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.binSettings, "LookupInterval", true));
            this.sleIntervall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sleIntervall.Location = new System.Drawing.Point(203, 61);
            this.sleIntervall.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.sleIntervall.Name = "sleIntervall";
            this.sleIntervall.Size = new System.Drawing.Size(294, 20);
            this.sleIntervall.TabIndex = 13;
            // 
            // lblIntervall
            // 
            this.lblIntervall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIntervall.Location = new System.Drawing.Point(3, 58);
            this.lblIntervall.Name = "lblIntervall";
            this.lblIntervall.Size = new System.Drawing.Size(194, 24);
            this.lblIntervall.TabIndex = 14;
            this.lblIntervall.Text = "Suchintervall in PCL-Ordner";
            this.lblIntervall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckbStart
            // 
            this.ckbStart.AutoSize = true;
            this.ckbStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckbStart.Location = new System.Drawing.Point(203, 559);
            this.ckbStart.Name = "ckbStart";
            this.ckbStart.Size = new System.Drawing.Size(294, 24);
            this.ckbStart.TabIndex = 17;
            this.ckbStart.Text = "Nach PCL-Dateien suchen";
            this.ckbStart.UseVisualStyleBackColor = true;
            this.ckbStart.CheckedChanged += new System.EventHandler(this.ckbStart_CheckedChanged);
            // 
            // lblDeleteOldPdf
            // 
            this.lblDeleteOldPdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDeleteOldPdf.Location = new System.Drawing.Point(3, 87);
            this.lblDeleteOldPdf.Name = "lblDeleteOldPdf";
            this.lblDeleteOldPdf.Size = new System.Drawing.Size(194, 24);
            this.lblDeleteOldPdf.TabIndex = 18;
            this.lblDeleteOldPdf.Text = "Tagesanzahl alte PDF löschen";
            this.lblDeleteOldPdf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sleDeleteOldPdf
            // 
            this.sleDeleteOldPdf.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.binSettings, "DeleteOldPdfDayCounter", true));
            this.sleDeleteOldPdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sleDeleteOldPdf.Location = new System.Drawing.Point(203, 90);
            this.sleDeleteOldPdf.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.sleDeleteOldPdf.Name = "sleDeleteOldPdf";
            this.sleDeleteOldPdf.Size = new System.Drawing.Size(294, 20);
            this.sleDeleteOldPdf.TabIndex = 19;
            // 
            // lblDeleteOldPdfInfo
            // 
            this.panMain.SetColumnSpan(this.lblDeleteOldPdfInfo, 3);
            this.lblDeleteOldPdfInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDeleteOldPdfInfo.Location = new System.Drawing.Point(503, 87);
            this.lblDeleteOldPdfInfo.Name = "lblDeleteOldPdfInfo";
            this.lblDeleteOldPdfInfo.Size = new System.Drawing.Size(524, 24);
            this.lblDeleteOldPdfInfo.TabIndex = 20;
            this.lblDeleteOldPdfInfo.Text = "0 Tage = es werden keine alten PDF gelöscht";
            this.lblDeleteOldPdfInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckbRemovePclFiles
            // 
            this.ckbRemovePclFiles.AutoSize = true;
            this.panMain.SetColumnSpan(this.ckbRemovePclFiles, 2);
            this.ckbRemovePclFiles.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.binSettings, "RemovePclFiles", true));
            this.ckbRemovePclFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckbRemovePclFiles.Location = new System.Drawing.Point(3, 119);
            this.ckbRemovePclFiles.Name = "ckbRemovePclFiles";
            this.ckbRemovePclFiles.Size = new System.Drawing.Size(494, 18);
            this.ckbRemovePclFiles.TabIndex = 21;
            this.ckbRemovePclFiles.Text = "PCL-Dateien nach PDF-Konvertierung löschen";
            this.ckbRemovePclFiles.UseVisualStyleBackColor = true;
            // 
            // binSettings
            // 
            this.binSettings.DataSource = typeof(PclFileConvert.Settings);
            // 
            // dlgShell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 586);
            this.Controls.Add(this.panMain);
            this.Name = "dlgShell";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PCL-File Convert";
            this.panMain.ResumeLayout(false);
            this.panMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sleIntervall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sleDeleteOldPdf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSettings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPclDir;
        private System.Windows.Forms.Button btnPclDir;
        private System.Windows.Forms.TextBox slePclDir;
        private System.Windows.Forms.TableLayoutPanel panMain;
        private System.Windows.Forms.TextBox sleGhostExecutable;
        private System.Windows.Forms.Label lblGhostExecutable;
        private System.Windows.Forms.Button btnTargetDir;
        private System.Windows.Forms.TextBox sleTargetDir;
        private System.Windows.Forms.Label lblTargetDir;
        private System.Windows.Forms.TextBox sleGhostParams;
        private System.Windows.Forms.Label lblGhostParams;
        private System.Windows.Forms.Button btnGhostExecutable;
        private System.Windows.Forms.TextBox mleLog;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.TextBox slePclExtension;
        private System.Windows.Forms.Label lblPclExtension;
        private System.Windows.Forms.NumericUpDown sleIntervall;
        private System.Windows.Forms.Label lblIntervall;
        private System.Windows.Forms.CheckBox ckbStart;
        private System.Windows.Forms.BindingSource binSettings;
        private System.Windows.Forms.Label lblDeleteOldPdf;
        private System.Windows.Forms.NumericUpDown sleDeleteOldPdf;
        private System.Windows.Forms.Label lblDeleteOldPdfInfo;
        private System.Windows.Forms.CheckBox ckbRemovePclFiles;
    }
}

