namespace StarNet2Batch {
    partial class BatchStarNet {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            openStarNetExeFileDialog = new OpenFileDialog();
            butStarNetExePath = new Button();
            lblStarNetExePath = new Label();
            butSelectFiles = new Button();
            lstSelectedFiles = new ListView();
            butRun = new Button();
            progressBar1 = new ProgressBar();
            openFilesToProcessDialog = new OpenFileDialog();
            prcRunStarNet = new System.Diagnostics.Process();
            butSelectOutputDirectory = new Button();
            lblOutputDirectory = new Label();
            lblProcessStatus = new Label();
            SuspendLayout();
            // 
            // openStarNetExeFileDialog
            // 
            openStarNetExeFileDialog.FileName = "openStarNetExeFileDialog";
            openStarNetExeFileDialog.FileOk += openStarNetExeFileDialog_FileOk;
            // 
            // butStarNetExePath
            // 
            butStarNetExePath.Location = new Point(12, 12);
            butStarNetExePath.Name = "butStarNetExePath";
            butStarNetExePath.Size = new Size(194, 34);
            butStarNetExePath.TabIndex = 0;
            butStarNetExePath.Text = "Select StartNet Exe";
            butStarNetExePath.UseVisualStyleBackColor = true;
            butStarNetExePath.Click += butStarNetExePath_Click;
            // 
            // lblStarNetExePath
            // 
            lblStarNetExePath.AutoSize = true;
            lblStarNetExePath.Location = new Point(212, 17);
            lblStarNetExePath.Name = "lblStarNetExePath";
            lblStarNetExePath.Size = new Size(24, 25);
            lblStarNetExePath.TabIndex = 1;
            lblStarNetExePath.Text = "...";
            // 
            // butSelectFiles
            // 
            butSelectFiles.Location = new Point(12, 92);
            butSelectFiles.Name = "butSelectFiles";
            butSelectFiles.Size = new Size(194, 34);
            butSelectFiles.TabIndex = 2;
            butSelectFiles.Text = "Select Files";
            butSelectFiles.UseVisualStyleBackColor = true;
            butSelectFiles.Click += butSelectFiles_Click;
            // 
            // lstSelectedFiles
            // 
            lstSelectedFiles.Location = new Point(12, 132);
            lstSelectedFiles.Name = "lstSelectedFiles";
            lstSelectedFiles.Size = new Size(776, 266);
            lstSelectedFiles.TabIndex = 3;
            lstSelectedFiles.UseCompatibleStateImageBehavior = false;
            lstSelectedFiles.View = View.List;
            // 
            // butRun
            // 
            butRun.Location = new Point(12, 404);
            butRun.Name = "butRun";
            butRun.Size = new Size(148, 34);
            butRun.TabIndex = 4;
            butRun.Text = "Run StarNet";
            butRun.UseVisualStyleBackColor = true;
            butRun.Click += butRun_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(166, 404);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(477, 34);
            progressBar1.TabIndex = 5;
            // 
            // openFilesToProcessDialog
            // 
            openFilesToProcessDialog.Multiselect = true;
            openFilesToProcessDialog.FileOk += openFilesToProcessDialog_FileOk;
            // 
            // prcRunStarNet
            // 
            prcRunStarNet.StartInfo.Domain = "";
            prcRunStarNet.StartInfo.LoadUserProfile = false;
            prcRunStarNet.StartInfo.Password = null;
            prcRunStarNet.StartInfo.StandardErrorEncoding = null;
            prcRunStarNet.StartInfo.StandardInputEncoding = null;
            prcRunStarNet.StartInfo.StandardOutputEncoding = null;
            prcRunStarNet.StartInfo.UseCredentialsForNetworkingOnly = false;
            prcRunStarNet.StartInfo.UserName = "";
            prcRunStarNet.SynchronizingObject = this;
            // 
            // butSelectOutputDirectory
            // 
            butSelectOutputDirectory.Location = new Point(12, 52);
            butSelectOutputDirectory.Name = "butSelectOutputDirectory";
            butSelectOutputDirectory.Size = new Size(224, 34);
            butSelectOutputDirectory.TabIndex = 6;
            butSelectOutputDirectory.Text = "Select Output Directory";
            butSelectOutputDirectory.UseVisualStyleBackColor = true;
            butSelectOutputDirectory.Click += butSelectOutputDirectory_Click;
            // 
            // lblOutputDirectory
            // 
            lblOutputDirectory.AutoSize = true;
            lblOutputDirectory.Location = new Point(242, 57);
            lblOutputDirectory.Name = "lblOutputDirectory";
            lblOutputDirectory.Size = new Size(24, 25);
            lblOutputDirectory.TabIndex = 7;
            lblOutputDirectory.Text = "...";
            // 
            // lblProcessStatus
            // 
            lblProcessStatus.AutoSize = true;
            lblProcessStatus.Location = new Point(649, 409);
            lblProcessStatus.Name = "lblProcessStatus";
            lblProcessStatus.Size = new Size(0, 25);
            lblProcessStatus.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblProcessStatus);
            Controls.Add(lblOutputDirectory);
            Controls.Add(butSelectOutputDirectory);
            Controls.Add(progressBar1);
            Controls.Add(butRun);
            Controls.Add(lstSelectedFiles);
            Controls.Add(butSelectFiles);
            Controls.Add(lblStarNetExePath);
            Controls.Add(butStarNetExePath);
            Name = "Form1";
            Text = "Batch StarNet";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openStarNetExeFileDialog;
        private Button butStarNetExePath;
        private Label lblStarNetExePath;
        private Button butSelectFiles;
        private ListView lstSelectedFiles;
        private Button butRun;
        private ProgressBar progressBar1;
        private OpenFileDialog openFilesToProcessDialog;
        private System.Diagnostics.Process prcRunStarNet;
        private Label lblOutputDirectory;
        private Button butSelectOutputDirectory;
        private Label lblProcessStatus;
    }
}
