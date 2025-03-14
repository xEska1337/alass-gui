using allas_gui.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using System.Configuration;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;

namespace allas_gui
{
    public partial class MainWindow : Form
    {

        public string folderPath = "";
        public string selectedVideoFile = "";
        public string selectedReferenceSubs = "";
        public string selectedSubsToSync = "";
        public string alassPath = "";
        public string subOutput = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Load settings
            try
            {
                negativeTimestampCheck.Checked = Properties.Settings.Default.nagativeTimestampSetting;
                disableFPSGuessCheck.Checked = Properties.Settings.Default.fpsGuessingSetting;
                noSplitingCheck.Checked = Properties.Settings.Default.noSplitingSetting;
                speedOptimizationCheck.Checked = Properties.Settings.Default.speedOptSetting;
                closeCMDCheck.Checked = Properties.Settings.Default.closeCMDSetting;
                splitPenalty.Value = Properties.Settings.Default.splitPenalitSetting;
                interval.Value = Properties.Settings.Default.intervalSetting;
                this.Location = new Point(Properties.Settings.Default.PX, Properties.Settings.Default.PY);
                subsNameLikeVideoCheck.Checked = Properties.Settings.Default.subsLikeVideoSetting;
                replaceSubsCheck.Checked = Properties.Settings.Default.replaceSubsSetting;
                langugeCode.SelectedIndex = Properties.Settings.Default.selectedLanguageCodeSetting;
            }
            catch (ConfigurationErrorsException) {}

            //Check if alass is in exe directory
            string exeDirectory = AppContext.BaseDirectory;
            alassPath = Path.Combine(exeDirectory, "alass-windows64");
            if (!Directory.Exists(alassPath))
            {
                if (MessageBox.Show("You don't have alass-windows64 folder in exe directory. Copy alass-windows64 folder in to exe directory",
                               "No alass",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error) == DialogResult.OK)
                {
                    System.Environment.Exit(0);
                }
            }
        }

        private void browseFolderDialog_Click(object sender, EventArgs e)
        {
            //Browser dialog
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    mainPath.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void scanFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(mainPath.Text))
            {
                folderPath = mainPath.Text;
                //Scan for files
                string[] mkvFiles = Directory.GetFiles(folderPath, "*.mkv");
                string[] mp4Files = Directory.GetFiles(folderPath, "*.mp4");
                string[] aviFiles = Directory.GetFiles(folderPath, "*.avi");
                string[] movFiles = Directory.GetFiles(folderPath, "*.mov");
                string[] tsFiles = Directory.GetFiles(folderPath, "*.ts");
                string[] m4vFiles = Directory.GetFiles(folderPath, "*.m4v");

                string[] videoFiles = mkvFiles.Concat(mp4Files)
                                         .Concat(aviFiles)
                                         .Concat(movFiles)
                                         .Concat(tsFiles)
                                         .Concat(m4vFiles)
                                         .ToArray();

                string[] srtFiles = Directory.GetFiles(folderPath, "*.srt");
                string[] ssaFiles = Directory.GetFiles(folderPath, "*.ssa");
                string[] assFiles = Directory.GetFiles(folderPath, "*.ass");
                string[] idxFiles = Directory.GetFiles(folderPath, "*.idx");

                string[] subFiles = srtFiles.Concat(ssaFiles)
                                            .Concat(assFiles)
                                            .Concat(idxFiles)
                                            .ToArray();

                //Add filest to list
                videoFileList.Items.Clear();
                foreach (string video in videoFiles)
                {
                    videoFileList.Items.Add(Path.GetFileName(video));
                }

                referenceSubsList.Items.Clear();
                subsToSyncList.Items.Clear();
                foreach (string sub in subFiles)
                {
                    referenceSubsList.Items.Add(Path.GetFileName(sub));
                    subsToSyncList.Items.Add(Path.GetFileName(sub));
                }
            }
            else
            {
                MessageBox.Show("Select correct folder path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void videoFileList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Check selected file
            if (videoFileList.SelectedIndex != -1)
            {
                string selectedFileName = videoFileList.SelectedItem.ToString();
                selectedVideoFile = "\"" + Path.Combine(folderPath, selectedFileName) + "\"";
            }
        }
        private void referenceSubsList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Check selected file
            if (referenceSubsList.SelectedIndex != -1)
            {
                string selectedFileName = referenceSubsList.SelectedItem.ToString();
                selectedReferenceSubs = "\"" + Path.Combine(folderPath, selectedFileName) + "\"";
            }
        }

        private void subsToSyncList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Check selected file
            if (subsToSyncList.SelectedIndex != -1)
            {
                string selectedFileName = subsToSyncList.SelectedItem.ToString();
                selectedSubsToSync = "\"" + Path.Combine(folderPath, selectedFileName) + "\"";
            }
        }

        private void subOutName()
        {
            //Sub output name
            string languageCodeSelected = "";
            if (langugeCode.SelectedIndex != -1 && langugeCode.SelectedItem.ToString() != "")
            {
                languageCodeSelected = "." + langugeCode.SelectedItem.ToString();
            }


            if (subsNameLikeVideoCheck.Checked && !replaceSubsCheck.Checked && videoFileList.SelectedIndex != -1)
            {
                string fileName = Path.GetFileNameWithoutExtension(videoFileList.SelectedItem.ToString());
                string fileExtension = Path.GetExtension(subsToSyncList.SelectedItem.ToString());
                string fileNewName = fileName + "_synced" + languageCodeSelected + fileExtension;
                subOutput = "\"" + Path.Combine(folderPath, fileNewName) + "\"";
            }
            else if (subsNameLikeVideoCheck.Checked && replaceSubsCheck.Checked && videoFileList.SelectedIndex != -1)
            {
                string fileName = Path.GetFileNameWithoutExtension(videoFileList.SelectedItem.ToString());
                string fileExtension = Path.GetExtension(subsToSyncList.SelectedItem.ToString());
                string fileNewName = fileName + languageCodeSelected + fileExtension;
                subOutput = "\"" + Path.Combine(folderPath, fileNewName) + "\"";
            }
            else if (replaceSubsCheck.Checked)
            {
                string fileName = Path.GetFileNameWithoutExtension(subsToSyncList.SelectedItem.ToString());
                string fileExtension = Path.GetExtension(subsToSyncList.SelectedItem.ToString());
                string fileNewName = fileName + languageCodeSelected + fileExtension;
                subOutput = "\"" + Path.Combine(folderPath, fileNewName) + "\"";
            }
            else
            {
                string fileName = Path.GetFileNameWithoutExtension(subsToSyncList.SelectedItem.ToString());
                string fileExtension = Path.GetExtension(subsToSyncList.SelectedItem.ToString());
                string fileNewName = fileName + "_synced" + languageCodeSelected + fileExtension;
                subOutput = "\"" + Path.Combine(folderPath, fileNewName) + "\"";
            }
        }

        private void syncButton_Click(object sender, EventArgs e)
        {
            string commandToExecute = "\"";
            commandToExecute += alassPath + "\\alass.bat\"";
            string splitPenaltyValue = splitPenalty.Value.ToString();
            string intevalValue = interval.Value.ToString();
            if (referenceSubsList.SelectedIndex == -1 && videoFileList.SelectedIndex != -1 && subsToSyncList.SelectedIndex != -1)
            {
                subOutName();
                commandToExecute += " " + selectedVideoFile + " " + selectedSubsToSync + " " + subOutput + " --split-penalty " + splitPenaltyValue + " --interval " + intevalValue;

                if (negativeTimestampCheck.Checked)
                {
                    commandToExecute += " --allow-negative-timestamps";
                }
                if (disableFPSGuessCheck.Checked)
                {
                    commandToExecute += " --disable-fps-guessing";
                }
                if (noSplitingCheck.Checked)
                {
                    commandToExecute += " --no-split";
                }
                if (speedOptimizationCheck.Checked)
                {
                    commandToExecute += " --speed-optimization";
                }

                //Run alass
                string cmdCommand = "";
                if (closeCMDCheck.Checked)
                {
                    cmdCommand = "/C \"" + commandToExecute + "\"";
                }
                else
                {
                    cmdCommand = "/K \"" + commandToExecute + "\"";
                }
                System.Diagnostics.Process.Start("CMD.exe", cmdCommand);
            }
            else if ((referenceSubsList.SelectedIndex != -1 && videoFileList.SelectedIndex == -1 && subsToSyncList.SelectedIndex != -1) || (referenceSubsList.SelectedIndex != -1 && videoFileList.SelectedIndex != -1 && subsToSyncList.SelectedIndex != -1))
            {
                subOutName();
                commandToExecute += " " + selectedReferenceSubs + " " + selectedSubsToSync + " " + subOutput + " --split-penalty " + splitPenaltyValue + " --interval " + intevalValue;

                if (negativeTimestampCheck.Checked)
                {
                    commandToExecute += " --allow-negative-timestamps";
                }
                if (disableFPSGuessCheck.Checked)
                {
                    commandToExecute += " --disable-fps-guessing";
                }
                if (noSplitingCheck.Checked)
                {
                    commandToExecute += " --no-split";
                }
                if (speedOptimizationCheck.Checked)
                {
                    commandToExecute += " --speed-optimization";
                }

                //Run alass
                string cmdCommand = "";
                if (closeCMDCheck.Checked)
                {
                    cmdCommand = "/C \"" + commandToExecute + "\"";
                }
                else
                {
                    cmdCommand = "/K \"" + commandToExecute + "\"";
                }
                System.Diagnostics.Process.Start("CMD.exe", cmdCommand);
            }
            else
            {
                MessageBox.Show("Select at least video and subtitle to sync", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Save settings
            try
            {   
                Properties.Settings.Default.nagativeTimestampSetting = negativeTimestampCheck.Checked;
                Properties.Settings.Default.fpsGuessingSetting = disableFPSGuessCheck.Checked;
                Properties.Settings.Default.noSplitingSetting = noSplitingCheck.Checked;
                Properties.Settings.Default.speedOptSetting = speedOptimizationCheck.Checked;
                Properties.Settings.Default.closeCMDSetting = closeCMDCheck.Checked;
                Properties.Settings.Default.splitPenalitSetting = Math.Round(splitPenalty.Value);
                Properties.Settings.Default.intervalSetting = Math.Round(interval.Value);
                Properties.Settings.Default.PX = this.Location.X;
                Properties.Settings.Default.PY = this.Location.Y;
                Properties.Settings.Default.subsLikeVideoSetting = subsNameLikeVideoCheck.Checked;
                Properties.Settings.Default.replaceSubsSetting = replaceSubsCheck.Checked;
                Properties.Settings.Default.selectedLanguageCodeSetting = langugeCode.SelectedIndex;
                Properties.Settings.Default.Save(); 
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("The settings file is missing or corrupted. Settings will not be saved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void alassGitHubOpen_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/kaegi/alass") { UseShellExecute = true });
        }

        private void myGithub_Click_1(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/xEska1337") { UseShellExecute = true });
        }
    }
}