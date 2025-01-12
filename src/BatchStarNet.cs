using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace StarNet2Batch {
    public partial class BatchStarNet:Form {

        private string? starnetExePath = null;
        private int currentFileIndex = 0;
        private string outputDirectoryPath = null;
        private string[] filesToProcess;
        private CommonOpenFileDialog openOutputDirectoryDialog;

        /// <summary>
        /// Initialization
        /// </summary>
        public BatchStarNet() {
            InitializeComponent();
        }

        /// <summary>
        /// Postback for StarNet++.exe location dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openStarNetExeFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
            if(sender is OpenFileDialog ofd) {
                string[] files = ofd.FileNames;
                if(files.Length == 1) {
                    if(files[0].Contains("starnet++.exe")) {
                        starnetExePath = files[0];
                        lblStarNetExePath.Text = starnetExePath;
                    } else {
                        starnetExePath = null;
                    }
                }
            }
            if(starnetExePath == null) {
                lblStarNetExePath.Text = "Invalid";
            }
        }

        /// <summary>
        /// Postback for StarNet++.exe location browse button to show browse dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butStarNetExePath_Click(object sender, EventArgs e) {
            openStarNetExeFileDialog.ShowDialog();
        }

        /// <summary>
        /// Postback for images browse button to show file browser dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butSelectFiles_Click(object sender, EventArgs e) {
            openFilesToProcessDialog.ShowDialog();
        }

        /// <summary>
        /// Postback for output directory browse button to show dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butSelectOutputDirectory_Click(object sender, EventArgs e) {
            if(openOutputDirectoryDialog == null) {
                openOutputDirectoryDialog = new CommonOpenFileDialog() { IsFolderPicker = true };
            }

            if(openOutputDirectoryDialog.ShowDialog() == CommonFileDialogResult.Ok) {
                outputDirectoryPath = openOutputDirectoryDialog.FileName;
                lblOutputDirectory.Text = outputDirectoryPath;
            }
        }

        /// <summary>
        /// Postback for images selection dialog. Adds all files to the <c>filesToProcess</c> and 
        /// user displayed file list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFilesToProcessDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
            if(sender is OpenFileDialog ofd) {
                filesToProcess = ofd.FileNames;
                lstSelectedFiles.Items.Clear();
                foreach(string file in filesToProcess) {
                    lstSelectedFiles.Items.Add(file);
                }

            }
        }

        /// <summary>
        /// Postback for the run button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void butRun_Click(object sender, EventArgs e) {
            Debug.WriteLine("Running...");
            await RunProcess();
        }

        /// <summary>
        /// Async function which initiates the batch process of images and then finalizes the processing
        /// once all images have been processed. Also updates the progress bar and status as necessary.
        /// </summary>
        /// <returns></returns>
        private async Task RunProcess() {
            currentFileIndex = -1;
            progressBar1.Maximum = filesToProcess.Length;

            foreach(string file in filesToProcess) {
                currentFileIndex++;                
                progressBar1.Value = currentFileIndex;
                lblProcessStatus.Text = $"Working: {currentFileIndex+1} / {filesToProcess.Length}";
                await ProcessFile(file, outputDirectoryPath, starnetExePath);
            }

            FinishedProcessing();
        }

        /// <summary>
        /// Processes a single image file with StarNet.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="outDirectory"></param>
        /// <param name="starnetPath"></param>
        /// <returns></returns>
        private async Task ProcessFile(string filePath, string outDirectory, string starnetPath) {
            
            string outFileName = Path.GetFileNameWithoutExtension(filePath) + "_starless" + Path.GetExtension(filePath);
            string outFilePath = Path.Combine(outDirectory, outFileName);

            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = starnetPath;
            processInfo.ErrorDialog = true;
            processInfo.UseShellExecute = false;
            processInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processInfo.RedirectStandardOutput = true;
            processInfo.RedirectStandardError = true;
            processInfo.ArgumentList.Add(filePath);
            processInfo.ArgumentList.Add(outFilePath);
            processInfo.ArgumentList.Add("256");
            processInfo.WorkingDirectory = Path.GetDirectoryName(starnetPath);

            prcRunStarNet = new Process();
            prcRunStarNet.StartInfo = processInfo;
            prcRunStarNet.Start();
            await prcRunStarNet.WaitForExitAsync();
        }

        /// <summary>
        /// Finishes the process by updating the process bar and status text.
        /// </summary>
        private void FinishedProcessing() {
            progressBar1.Value = filesToProcess.Length;
            lblProcessStatus.Text = "Finished!";
        }
    }
}
