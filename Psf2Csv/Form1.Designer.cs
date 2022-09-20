
namespace Psf2Csv
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnAddPsf = new System.Windows.Forms.Button();
            this.btnBatchPsf = new System.Windows.Forms.Button();
            this.btnSaveList = new System.Windows.Forms.Button();
            this.txtQLPTool = new System.Windows.Forms.TextBox();
            this.txtVFSTool = new System.Windows.Forms.TextBox();
            this.lnkVFSTool = new System.Windows.Forms.LinkLabel();
            this.lnkQLPTool = new System.Windows.Forms.LinkLabel();
            this.lnkSeq2Sep = new System.Windows.Forms.LinkLabel();
            this.txtSeq2Sep = new System.Windows.Forms.TextBox();
            this.lnkDOSEMU = new System.Windows.Forms.LinkLabel();
            this.txtDOSEMU = new System.Windows.Forms.TextBox();
            this.ofdDOSEMU = new System.Windows.Forms.OpenFileDialog();
            this.ofdSeq2Sep = new System.Windows.Forms.OpenFileDialog();
            this.ofdQLPTool = new System.Windows.Forms.OpenFileDialog();
            this.ofdVFSTool = new System.Windows.Forms.OpenFileDialog();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.colFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVFSName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrackOf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSHA256 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVhName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVBName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ofdAddFile = new System.Windows.Forms.OpenFileDialog();
            this.sfdSaveList = new System.Windows.Forms.SaveFileDialog();
            this.sbStatus = new System.Windows.Forms.StatusStrip();
            this.sbiStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.fbdAddPsf = new System.Windows.Forms.FolderBrowserDialog();
            this.fbdBatchPsf = new System.Windows.Forms.FolderBrowserDialog();
            this.chkDontMerge = new System.Windows.Forms.CheckBox();
            this.lnkSepMode = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.sbStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddFile
            // 
            this.btnAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddFile.Location = new System.Drawing.Point(12, 441);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(114, 29);
            this.btnAddFile.TabIndex = 1;
            this.btnAddFile.Text = "Add Individual File";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnAddPsf
            // 
            this.btnAddPsf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddPsf.Location = new System.Drawing.Point(132, 441);
            this.btnAddPsf.Name = "btnAddPsf";
            this.btnAddPsf.Size = new System.Drawing.Size(79, 29);
            this.btnAddPsf.TabIndex = 2;
            this.btnAddPsf.Text = "Add PSF Set";
            this.btnAddPsf.UseVisualStyleBackColor = true;
            this.btnAddPsf.Click += new System.EventHandler(this.btnAddPsf_Click);
            // 
            // btnBatchPsf
            // 
            this.btnBatchPsf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBatchPsf.Location = new System.Drawing.Point(217, 441);
            this.btnBatchPsf.Name = "btnBatchPsf";
            this.btnBatchPsf.Size = new System.Drawing.Size(173, 29);
            this.btnBatchPsf.TabIndex = 3;
            this.btnBatchPsf.Text = "Make PSF Sets into VFS Files";
            this.btnBatchPsf.UseVisualStyleBackColor = true;
            this.btnBatchPsf.Click += new System.EventHandler(this.btnBatchPsf_Click);
            // 
            // btnSaveList
            // 
            this.btnSaveList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveList.Location = new System.Drawing.Point(396, 441);
            this.btnSaveList.Name = "btnSaveList";
            this.btnSaveList.Size = new System.Drawing.Size(112, 29);
            this.btnSaveList.TabIndex = 4;
            this.btnSaveList.Text = "Save CSV/VFS File";
            this.btnSaveList.UseVisualStyleBackColor = true;
            this.btnSaveList.Click += new System.EventHandler(this.btnSaveList_Click);
            // 
            // txtQLPTool
            // 
            this.txtQLPTool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtQLPTool.Location = new System.Drawing.Point(514, 441);
            this.txtQLPTool.Name = "txtQLPTool";
            this.txtQLPTool.Size = new System.Drawing.Size(204, 23);
            this.txtQLPTool.TabIndex = 5;
            this.txtQLPTool.Text = "qlptool.exe";
            // 
            // txtVFSTool
            // 
            this.txtVFSTool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtVFSTool.Location = new System.Drawing.Point(514, 470);
            this.txtVFSTool.Name = "txtVFSTool";
            this.txtVFSTool.Size = new System.Drawing.Size(204, 23);
            this.txtVFSTool.TabIndex = 6;
            this.txtVFSTool.Text = "vfstool.exe";
            // 
            // lnkVFSTool
            // 
            this.lnkVFSTool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkVFSTool.AutoSize = true;
            this.lnkVFSTool.Location = new System.Drawing.Point(724, 473);
            this.lnkVFSTool.Name = "lnkVFSTool";
            this.lnkVFSTool.Size = new System.Drawing.Size(50, 15);
            this.lnkVFSTool.TabIndex = 8;
            this.lnkVFSTool.TabStop = true;
            this.lnkVFSTool.Text = "VFSTool";
            this.lnkVFSTool.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVFSTool_LinkClicked);
            // 
            // lnkQLPTool
            // 
            this.lnkQLPTool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkQLPTool.AutoSize = true;
            this.lnkQLPTool.Location = new System.Drawing.Point(724, 444);
            this.lnkQLPTool.Name = "lnkQLPTool";
            this.lnkQLPTool.Size = new System.Drawing.Size(53, 15);
            this.lnkQLPTool.TabIndex = 9;
            this.lnkQLPTool.TabStop = true;
            this.lnkQLPTool.Text = "QLPTool";
            this.lnkQLPTool.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkQLPTool_LinkClicked);
            // 
            // lnkSeq2Sep
            // 
            this.lnkSeq2Sep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkSeq2Sep.AutoSize = true;
            this.lnkSeq2Sep.Location = new System.Drawing.Point(455, 473);
            this.lnkSeq2Sep.Name = "lnkSeq2Sep";
            this.lnkSeq2Sep.Size = new System.Drawing.Size(53, 15);
            this.lnkSeq2Sep.TabIndex = 11;
            this.lnkSeq2Sep.TabStop = true;
            this.lnkSeq2Sep.Text = "SEQ2SEP";
            this.lnkSeq2Sep.Visible = false;
            this.lnkSeq2Sep.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSeq2Sep_LinkClicked);
            // 
            // txtSeq2Sep
            // 
            this.txtSeq2Sep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSeq2Sep.Location = new System.Drawing.Point(245, 470);
            this.txtSeq2Sep.Name = "txtSeq2Sep";
            this.txtSeq2Sep.Size = new System.Drawing.Size(204, 23);
            this.txtSeq2Sep.TabIndex = 10;
            this.txtSeq2Sep.Text = "seq2sep.exe";
            this.txtSeq2Sep.Visible = false;
            // 
            // lnkDOSEMU
            // 
            this.lnkDOSEMU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkDOSEMU.AutoSize = true;
            this.lnkDOSEMU.Location = new System.Drawing.Point(180, 473);
            this.lnkDOSEMU.Name = "lnkDOSEMU";
            this.lnkDOSEMU.Size = new System.Drawing.Size(57, 15);
            this.lnkDOSEMU.TabIndex = 13;
            this.lnkDOSEMU.TabStop = true;
            this.lnkDOSEMU.Text = "DOS emu";
            this.lnkDOSEMU.Visible = false;
            this.lnkDOSEMU.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDOSEMU_LinkClicked);
            // 
            // txtDOSEMU
            // 
            this.txtDOSEMU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDOSEMU.Location = new System.Drawing.Point(12, 470);
            this.txtDOSEMU.Name = "txtDOSEMU";
            this.txtDOSEMU.Size = new System.Drawing.Size(162, 23);
            this.txtDOSEMU.TabIndex = 12;
            this.txtDOSEMU.Text = "msdos.exe";
            this.txtDOSEMU.Visible = false;
            // 
            // ofdDOSEMU
            // 
            this.ofdDOSEMU.FileName = "msdos.exe";
            this.ofdDOSEMU.Filter = "EXE files|*.exe|All files|*.*";
            this.ofdDOSEMU.RestoreDirectory = true;
            this.ofdDOSEMU.Title = "Select DOS Emulator";
            // 
            // ofdSeq2Sep
            // 
            this.ofdSeq2Sep.FileName = "seq2sep.exe";
            this.ofdSeq2Sep.Filter = "EXE files|*.exe|All files|*.*";
            this.ofdSeq2Sep.RestoreDirectory = true;
            this.ofdSeq2Sep.Title = "Select Seq2Sep.exe";
            // 
            // ofdQLPTool
            // 
            this.ofdQLPTool.FileName = "qlptool.exe";
            this.ofdQLPTool.Filter = "EXE files|*.exe|All files|*.*";
            this.ofdQLPTool.RestoreDirectory = true;
            this.ofdQLPTool.Title = "Select QLPTool";
            // 
            // ofdVFSTool
            // 
            this.ofdVFSTool.FileName = "vfstool.exe";
            this.ofdVFSTool.Filter = "EXE files|*.exe|All files|*.*";
            this.ofdVFSTool.RestoreDirectory = true;
            this.ofdVFSTool.Title = "Select VFSTool";
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowDrop = true;
            this.dgvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFileName,
            this.colVFSName,
            this.colTrackOf,
            this.colStack,
            this.colSHA256,
            this.colVhName,
            this.colTemp,
            this.colVBName});
            this.dgvFiles.Location = new System.Drawing.Point(15, 13);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.RowTemplate.Height = 25;
            this.dgvFiles.Size = new System.Drawing.Size(759, 422);
            this.dgvFiles.TabIndex = 14;
            this.dgvFiles.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvFiles_UserDeletingRow);
            this.dgvFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvFiles_DragDrop);
            this.dgvFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvFiles_DragEnter);
            // 
            // colFileName
            // 
            this.colFileName.HeaderText = "Filename";
            this.colFileName.MaxInputLength = 255;
            this.colFileName.Name = "colFileName";
            this.colFileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colVFSName
            // 
            this.colVFSName.HeaderText = "VFS Filename";
            this.colVFSName.MaxInputLength = 63;
            this.colVFSName.Name = "colVFSName";
            this.colVFSName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colTrackOf
            // 
            this.colTrackOf.HeaderText = "Track Source";
            this.colTrackOf.Name = "colTrackOf";
            this.colTrackOf.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colStack
            // 
            this.colStack.HeaderText = "Type/Stack";
            this.colStack.Name = "colStack";
            this.colStack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colSHA256
            // 
            this.colSHA256.HeaderText = "VH+VB Hash";
            this.colSHA256.Name = "colSHA256";
            this.colSHA256.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colSHA256.Visible = false;
            // 
            // colVhName
            // 
            this.colVhName.HeaderText = "VH Filename";
            this.colVhName.Name = "colVhName";
            this.colVhName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colVhName.Visible = false;
            // 
            // colTemp
            // 
            this.colTemp.HeaderText = "Track №";
            this.colTemp.Name = "colTemp";
            this.colTemp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colTemp.Visible = false;
            // 
            // colVBName
            // 
            this.colVBName.HeaderText = "VB Filename";
            this.colVBName.Name = "colVBName";
            this.colVBName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colVBName.Visible = false;
            // 
            // ofdAddFile
            // 
            this.ofdAddFile.Filter = resources.GetString("ofdAddFile.Filter");
            this.ofdAddFile.RestoreDirectory = true;
            this.ofdAddFile.Title = "Select file to add";
            // 
            // sfdSaveList
            // 
            this.sfdSaveList.Filter = "CSV files|*.csv|VFS files|*.vfs|All files|*.*";
            this.sfdSaveList.Title = "Save CSV/VFS";
            // 
            // sbStatus
            // 
            this.sbStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbiStatusText});
            this.sbStatus.Location = new System.Drawing.Point(0, 499);
            this.sbStatus.Name = "sbStatus";
            this.sbStatus.Size = new System.Drawing.Size(790, 22);
            this.sbStatus.TabIndex = 15;
            this.sbStatus.Text = "statusStrip1";
            this.sbStatus.DoubleClick += new System.EventHandler(this.sbStatus_DoubleClick);
            // 
            // sbiStatusText
            // 
            this.sbiStatusText.Name = "sbiStatusText";
            this.sbiStatusText.Size = new System.Drawing.Size(39, 17);
            this.sbiStatusText.Text = "Ready";
            // 
            // fbdAddPsf
            // 
            this.fbdAddPsf.Description = "PSF Set folder (Data files extracted with VGMToolbox)";
            this.fbdAddPsf.UseDescriptionForTitle = true;
            // 
            // fbdBatchPsf
            // 
            this.fbdBatchPsf.Description = "Select directory containing PSF sets";
            this.fbdBatchPsf.UseDescriptionForTitle = true;
            // 
            // chkDontMerge
            // 
            this.chkDontMerge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDontMerge.AutoSize = true;
            this.chkDontMerge.Location = new System.Drawing.Point(15, 474);
            this.chkDontMerge.Name = "chkDontMerge";
            this.chkDontMerge.Size = new System.Drawing.Size(232, 19);
            this.chkDontMerge.TabIndex = 16;
            this.chkDontMerge.Text = "Don\'t Pack Multiple SEQ files into PSQs";
            this.chkDontMerge.UseVisualStyleBackColor = true;
            // 
            // lnkSepMode
            // 
            this.lnkSepMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkSepMode.AutoSize = true;
            this.lnkSepMode.Location = new System.Drawing.Point(253, 475);
            this.lnkSepMode.Name = "lnkSepMode";
            this.lnkSepMode.Size = new System.Drawing.Size(125, 15);
            this.lnkSepMode.TabIndex = 17;
            this.lnkSepMode.TabStop = true;
            this.lnkSepMode.Text = "Enable SEQ2SEP Mode";
            this.lnkSepMode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSepMode_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 521);
            this.Controls.Add(this.lnkSepMode);
            this.Controls.Add(this.chkDontMerge);
            this.Controls.Add(this.sbStatus);
            this.Controls.Add(this.dgvFiles);
            this.Controls.Add(this.lnkDOSEMU);
            this.Controls.Add(this.txtDOSEMU);
            this.Controls.Add(this.lnkSeq2Sep);
            this.Controls.Add(this.txtSeq2Sep);
            this.Controls.Add(this.lnkQLPTool);
            this.Controls.Add(this.lnkVFSTool);
            this.Controls.Add(this.txtVFSTool);
            this.Controls.Add(this.txtQLPTool);
            this.Controls.Add(this.btnSaveList);
            this.Controls.Add(this.btnBatchPsf);
            this.Controls.Add(this.btnAddPsf);
            this.Controls.Add(this.btnAddFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PSF to CSV";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.sbStatus.ResumeLayout(false);
            this.sbStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnAddPsf;
        private System.Windows.Forms.Button btnBatchPsf;
        private System.Windows.Forms.Button btnSaveList;
        private System.Windows.Forms.TextBox txtQLPTool;
        private System.Windows.Forms.TextBox txtVFSTool;
        private System.Windows.Forms.LinkLabel lnkVFSTool;
        private System.Windows.Forms.LinkLabel lnkQLPTool;
        private System.Windows.Forms.LinkLabel lnkSeq2Sep;
        private System.Windows.Forms.TextBox txtSeq2Sep;
        private System.Windows.Forms.LinkLabel lnkDOSEMU;
        private System.Windows.Forms.TextBox txtDOSEMU;
        private System.Windows.Forms.OpenFileDialog ofdDOSEMU;
        private System.Windows.Forms.OpenFileDialog ofdSeq2Sep;
        private System.Windows.Forms.OpenFileDialog ofdQLPTool;
        private System.Windows.Forms.OpenFileDialog ofdVFSTool;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.OpenFileDialog ofdAddFile;
        private System.Windows.Forms.SaveFileDialog sfdSaveList;
        private System.Windows.Forms.StatusStrip sbStatus;
        private System.Windows.Forms.ToolStripStatusLabel sbiStatusText;
        private System.Windows.Forms.FolderBrowserDialog fbdAddPsf;
        private System.Windows.Forms.FolderBrowserDialog fbdBatchPsf;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVFSName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrackOf;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStack;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSHA256;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVhName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVBName;
        private System.Windows.Forms.CheckBox chkDontMerge;
        private System.Windows.Forms.LinkLabel lnkSepMode;
    }
}

