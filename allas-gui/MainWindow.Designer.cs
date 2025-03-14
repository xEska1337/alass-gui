namespace allas_gui
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            mainPath = new TextBox();
            browseFolderDialogButton = new Button();
            openFileDialog1 = new OpenFileDialog();
            scanFolderButton = new Button();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label8 = new Label();
            langugeCode = new ComboBox();
            label5 = new Label();
            interval = new NumericUpDown();
            label4 = new Label();
            splitPenalty = new NumericUpDown();
            syncButton = new Button();
            groupBox1 = new GroupBox();
            replaceSubsCheck = new CheckBox();
            subsNameLikeVideoCheck = new CheckBox();
            closeCMDCheck = new CheckBox();
            speedOptimizationCheck = new CheckBox();
            noSplitingCheck = new CheckBox();
            disableFPSGuessCheck = new CheckBox();
            negativeTimestampCheck = new CheckBox();
            subsToSyncList = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            referenceSubsList = new ComboBox();
            videoFileList = new ComboBox();
            tabPage2 = new TabPage();
            label10 = new Label();
            myGithub = new Button();
            label9 = new Label();
            alassGitHubOpen = new Button();
            label7 = new Label();
            label6 = new Label();
            tabPage3 = new TabPage();
            label11 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)interval).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitPenalty).BeginInit();
            groupBox1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // mainPath
            // 
            mainPath.Location = new Point(8, 6);
            mainPath.Name = "mainPath";
            mainPath.Size = new Size(900, 23);
            mainPath.TabIndex = 0;
            // 
            // browseFolderDialogButton
            // 
            browseFolderDialogButton.Location = new Point(914, 6);
            browseFolderDialogButton.Name = "browseFolderDialogButton";
            browseFolderDialogButton.Size = new Size(145, 23);
            browseFolderDialogButton.TabIndex = 1;
            browseFolderDialogButton.Text = "Browse Folder Dialog";
            browseFolderDialogButton.UseVisualStyleBackColor = true;
            browseFolderDialogButton.Click += browseFolderDialog_Click;
            // 
            // scanFolderButton
            // 
            scanFolderButton.Location = new Point(914, 35);
            scanFolderButton.Name = "scanFolderButton";
            scanFolderButton.Size = new Size(145, 23);
            scanFolderButton.TabIndex = 2;
            scanFolderButton.Text = "Scan Folder";
            scanFolderButton.UseVisualStyleBackColor = true;
            scanFolderButton.Click += scanFolder_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 39);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 3;
            label1.Text = "Video file:";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1079, 354);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(langugeCode);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(interval);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(splitPenalty);
            tabPage1.Controls.Add(syncButton);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(subsToSyncList);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(referenceSubsList);
            tabPage1.Controls.Add(videoFileList);
            tabPage1.Controls.Add(mainPath);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(scanFolderButton);
            tabPage1.Controls.Add(browseFolderDialogButton);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1071, 326);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Sync";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(588, 123);
            label8.Name = "label8";
            label8.Size = new Size(113, 15);
            label8.TabIndex = 17;
            label8.Text = "Add language code:";
            // 
            // langugeCode
            // 
            langugeCode.DropDownStyle = ComboBoxStyle.DropDownList;
            langugeCode.FormattingEnabled = true;
            langugeCode.Items.AddRange(new object[] { "", "aar", "abk", "ace", "ach", "ada", "ady", "afa", "afh", "afr", "ain", "aka", "akk", "alb", "sqi", "ale", "alg", "alt", "amh", "ang", "anp", "apa", "ara", "arc", "arg", "arm ", "hye ", "arn", "arp", "art", "arw", "asm", "ast", "ath", "aus", "ava", "ave", "awa", "aym", "aze", "bad", "bai", "bak", "bal", "bam", "ban", "baq ", "eus", "bas", "bat", "bej", "bel", "bem", "ben", "ber", "bho", "bih", "bik", "bin", "bis", "bla", "bnt", "tib", "bod", "bos", "bra", "bre", "btk", "bua", "bug", "bul", "bur", "mya", "byn", "cad", "cai", "car", "cat", "cau", "ceb", "cel", "cze", "ces", "cha", "chb", "che", "chg", "chi", "zho", "chk", "chm", "chn", "cho", "chp", "chr", "chu", "chv", "chy", "cmc", "cnr", "cop", "cor", "cos", "cpe", "cpf", "cpp", "cre", "crh", "crp", "csb", "cus", "wel", "cym", "cze", "ces", "dak", "dan", "dar", "day", "del", "den", "ger", "deu", "dgr", "din", "div", "doi", "dra", "dsb", "dua", "dum", "dut", "nld", "dyu", "dzo", "efi", "egy", "eka", "gre", "ell", "elx", "eng", "enm", "epo", "est", "baq", "eus", "ewe", "ewo", "fan", "fao", "per", "fas", "fat", "fij", "fil", "fin", "fiu", "fon", "fre", "fra", "fre", "fra", "frm", "fro", "frr", "frs", "fry", "ful", "fur", "gaa", "gay", "gba", "gem", "geo", "kat", "ger", "deu", "gez", "gil", "gla", "gle", "glg", "glv", "gmh", "goh", "gon", "gor", "got", "grb", "grc", "gre", "ell", "grn", "gsw", "guj", "gwi", "hai", "hat", "hau", "haw", "heb", "her", "hil", "him", "hin", "hit", "hmn", "hmo", "hrv", "hsb", "hun", "hup", "arm", "hye", "iba", "ibo", "ice", "isl", "ido", "iii", "ijo", "iku", "ile", "ilo", "ina", "inc", "ind", "ine", "inh", "ipk", "ira", "iro", "ice", "isl", "ita", "jav", "jbo", "jpn", "jpr", "jrb", "kaa", "kab", "kac", "kal", "kam", "kan", "kar", "kas", "geo", "kat", "kau", "kaw", "kaz", "kbd", "kha", "khi", "khm", "kho", "kik", "kin", "kir", "kmb", "kok", "kom", "kon", "kor", "kos", "kpe", "krc", "krl", "kro", "kru", "kua", "kum", "kur", "kut", "lad", "lah", "lam", "lao", "lat", "lav", "lez", "lim", "lin", "lit", "lol", "loz", "ltz", "lua", "lub", "lug", "lui", "lun", "luo", "lus", "mac", "mkd", "mad", "mag", "mah", "mai", "mak", "mal", "man", "mao", "mri", "map", "mar", "mas", "may", "msa", "mdf", "mdr", "men", "mga", "mic", "min", "mis", "mac", "mkd", "mkh", "mlg", "mlt", "mnc", "mni", "mno", "moh", "mon", "mos", "mao", "mri", "may", "msa", "mul", "mun", "mus", "mwl", "mwr", "bur ", "mya", "myn", "myv", "nah", "nai", "nap", "nau", "nav", "nbl", "nde", "ndo", "nds", "nep", "new", "nia", "nic", "niu", "dut", "nld", "nno", "nob", "nog", "non", "nor", "nqo", "nso", "nub", "nwc", "nya", "nym", "nyn", "nyo", "nzi", "oci", "oji", "ori", "orm", "osa", "oss", "ota", "oto", "paa", "pag", "pal", "pam", "pan", "pap", "pau", "peo", "per", "fas", "phi", "phn", "pli", "pol", "pon", "por", "pra", "pro", "pus", "qaa-qtz", "que", "raj", "rap", "rar", "roa", "roh", "rom", "rum", "ron ", "rum", "ron", "run", "rup", "rus", "sad", "sag", "sah", "sai", "sal", "sam", "san", "sas", "sat", "scn", "sco", "sel", "sem", "sga", "sgn", "shn", "sid", "sin", "sio", "sit", "sla", "slo", "slk ", "slo ", "slk ", "slv", "sma", "sme", "smi", "smj", "smn", "smo", "sms", "sna", "snd", "snk", "sog", "som", "son", "sot", "spa", "alb ", "sqi ", "srd", "srn", "srp", "srr", "ssa", "ssw", "suk", "sun", "sus", "sux", "swa", "swe", "syc", "syr", "tah", "tai", "tam", "tat", "tel", "tem", "ter", "tet", "tgk", "tgl", "tha", "tib ", "bod", "tig", "tir", "tiv", "tkl", "tlh", "tli", "tmh", "tog", "ton", "tpi", "tsi", "tsn", "tso", "tuk", "tum", "tup", "tur", "tut", "tvl", "twi", "tyv", "udm", "uga", "uig", "ukr", "umb", "und", "urd", "uzb", "vai", "ven", "vie", "vol", "vot", "wak", "wal", "war", "was", "wel ", "cym ", "wen", "wln", "wol", "xal", "xho", "yao", "yap", "yid", "yor", "ypk", "zap", "zbl", "zen", "zgh", "zha", "chi ", "zho ", "znd", "zul", "zun", "zxx", "zza" });
            langugeCode.Location = new Point(588, 140);
            langugeCode.Name = "langugeCode";
            langugeCode.Size = new Size(121, 23);
            langugeCode.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(322, 174);
            label5.Name = "label5";
            label5.Size = new Size(211, 15);
            label5.TabIndex = 15;
            label5.Text = "Smallest recognized time interval (ms):";
            // 
            // interval
            // 
            interval.Location = new Point(322, 191);
            interval.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            interval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            interval.Name = "interval";
            interval.Size = new Size(132, 23);
            interval.TabIndex = 14;
            interval.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(322, 127);
            label4.Name = "label4";
            label4.Size = new Size(132, 15);
            label4.TabIndex = 13;
            label4.Text = "Split penalty (default 7):";
            // 
            // splitPenalty
            // 
            splitPenalty.Location = new Point(322, 144);
            splitPenalty.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            splitPenalty.Name = "splitPenalty";
            splitPenalty.Size = new Size(132, 23);
            splitPenalty.TabIndex = 12;
            splitPenalty.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // syncButton
            // 
            syncButton.Location = new Point(322, 272);
            syncButton.Name = "syncButton";
            syncButton.Size = new Size(387, 46);
            syncButton.TabIndex = 10;
            syncButton.Text = "Sync";
            syncButton.UseVisualStyleBackColor = true;
            syncButton.Click += syncButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(replaceSubsCheck);
            groupBox1.Controls.Add(subsNameLikeVideoCheck);
            groupBox1.Controls.Add(closeCMDCheck);
            groupBox1.Controls.Add(speedOptimizationCheck);
            groupBox1.Controls.Add(noSplitingCheck);
            groupBox1.Controls.Add(disableFPSGuessCheck);
            groupBox1.Controls.Add(negativeTimestampCheck);
            groupBox1.Location = new Point(116, 123);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 195);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Options";
            // 
            // replaceSubsCheck
            // 
            replaceSubsCheck.AutoSize = true;
            replaceSubsCheck.Location = new Point(6, 170);
            replaceSubsCheck.Name = "replaceSubsCheck";
            replaceSubsCheck.Size = new Size(114, 19);
            replaceSubsCheck.TabIndex = 6;
            replaceSubsCheck.Text = "Replace subtitles";
            replaceSubsCheck.UseVisualStyleBackColor = true;
            // 
            // subsNameLikeVideoCheck
            // 
            subsNameLikeVideoCheck.AutoSize = true;
            subsNameLikeVideoCheck.Location = new Point(6, 145);
            subsNameLikeVideoCheck.Name = "subsNameLikeVideoCheck";
            subsNameLikeVideoCheck.Size = new Size(171, 19);
            subsNameLikeVideoCheck.TabIndex = 5;
            subsNameLikeVideoCheck.Text = "Subtitle name like video file";
            subsNameLikeVideoCheck.UseVisualStyleBackColor = true;
            // 
            // closeCMDCheck
            // 
            closeCMDCheck.AutoSize = true;
            closeCMDCheck.Location = new Point(6, 122);
            closeCMDCheck.Name = "closeCMDCheck";
            closeCMDCheck.Size = new Size(156, 19);
            closeCMDCheck.TabIndex = 4;
            closeCMDCheck.Text = "Close CMD after syncing";
            closeCMDCheck.UseVisualStyleBackColor = true;
            // 
            // speedOptimizationCheck
            // 
            speedOptimizationCheck.AutoSize = true;
            speedOptimizationCheck.Location = new Point(6, 97);
            speedOptimizationCheck.Name = "speedOptimizationCheck";
            speedOptimizationCheck.Size = new Size(128, 19);
            speedOptimizationCheck.TabIndex = 3;
            speedOptimizationCheck.Text = "Speed optimization";
            speedOptimizationCheck.UseVisualStyleBackColor = true;
            // 
            // noSplitingCheck
            // 
            noSplitingCheck.AutoSize = true;
            noSplitingCheck.Location = new Point(6, 72);
            noSplitingCheck.Name = "noSplitingCheck";
            noSplitingCheck.Size = new Size(84, 19);
            noSplitingCheck.TabIndex = 2;
            noSplitingCheck.Text = "No spliting";
            noSplitingCheck.UseVisualStyleBackColor = true;
            // 
            // disableFPSGuessCheck
            // 
            disableFPSGuessCheck.AutoSize = true;
            disableFPSGuessCheck.Location = new Point(6, 47);
            disableFPSGuessCheck.Name = "disableFPSGuessCheck";
            disableFPSGuessCheck.Size = new Size(136, 19);
            disableFPSGuessCheck.TabIndex = 1;
            disableFPSGuessCheck.Text = "Disable FPS guessing";
            disableFPSGuessCheck.UseVisualStyleBackColor = true;
            // 
            // negativeTimestampCheck
            // 
            negativeTimestampCheck.AutoSize = true;
            negativeTimestampCheck.Location = new Point(6, 22);
            negativeTimestampCheck.Name = "negativeTimestampCheck";
            negativeTimestampCheck.Size = new Size(169, 19);
            negativeTimestampCheck.TabIndex = 0;
            negativeTimestampCheck.Text = "Allow negative timestamps";
            negativeTimestampCheck.UseVisualStyleBackColor = true;
            // 
            // subsToSyncList
            // 
            subsToSyncList.DropDownStyle = ComboBoxStyle.DropDownList;
            subsToSyncList.FormattingEnabled = true;
            subsToSyncList.Location = new Point(116, 94);
            subsToSyncList.Name = "subsToSyncList";
            subsToSyncList.Size = new Size(792, 23);
            subsToSyncList.TabIndex = 8;
            subsToSyncList.SelectionChangeCommitted += subsToSyncList_SelectionChangeCommitted;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 97);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 7;
            label3.Text = "Subtitle to sync:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 68);
            label2.Name = "label2";
            label2.Size = new Size(104, 15);
            label2.TabIndex = 6;
            label2.Text = "Reference subtitle:";
            // 
            // referenceSubsList
            // 
            referenceSubsList.DropDownStyle = ComboBoxStyle.DropDownList;
            referenceSubsList.FormattingEnabled = true;
            referenceSubsList.Location = new Point(116, 65);
            referenceSubsList.Name = "referenceSubsList";
            referenceSubsList.Size = new Size(792, 23);
            referenceSubsList.TabIndex = 5;
            referenceSubsList.SelectionChangeCommitted += referenceSubsList_SelectionChangeCommitted;
            // 
            // videoFileList
            // 
            videoFileList.DropDownStyle = ComboBoxStyle.DropDownList;
            videoFileList.FormattingEnabled = true;
            videoFileList.Location = new Point(116, 36);
            videoFileList.Name = "videoFileList";
            videoFileList.Size = new Size(792, 23);
            videoFileList.TabIndex = 4;
            videoFileList.SelectionChangeCommitted += videoFileList_SelectionChangeCommitted;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(myGithub);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(alassGitHubOpen);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(label6);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1071, 326);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "About";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(8, 177);
            label10.Name = "label10";
            label10.Size = new Size(161, 15);
            label10.TabIndex = 6;
            label10.Text = "Made by: Szymon Kaczmarek";
            // 
            // myGithub
            // 
            myGithub.Location = new Point(8, 195);
            myGithub.Name = "myGithub";
            myGithub.Size = new Size(96, 25);
            myGithub.TabIndex = 5;
            myGithub.Text = "github";
            myGithub.UseVisualStyleBackColor = true;
            myGithub.Click += myGithub_Click_1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(8, 69);
            label9.Name = "label9";
            label9.Size = new Size(340, 30);
            label9.TabIndex = 3;
            label9.Text = "Gui for Automatic Language-Agnostic Subtitle Synchronization\r\nhttps://github.com/kaegi/alass";
            // 
            // alassGitHubOpen
            // 
            alassGitHubOpen.Location = new Point(8, 102);
            alassGitHubOpen.Name = "alassGitHubOpen";
            alassGitHubOpen.Size = new Size(96, 25);
            alassGitHubOpen.TabIndex = 4;
            alassGitHubOpen.Text = "alass - github";
            alassGitHubOpen.UseVisualStyleBackColor = true;
            alassGitHubOpen.Click += alassGitHubOpen_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(8, 40);
            label7.Name = "label7";
            label7.Size = new Size(237, 15);
            label7.TabIndex = 2;
            label7.Text = "Supported subtitles types: .srt, .ssa, .ass, .idx\r\n";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 16);
            label6.Name = "label6";
            label6.Size = new Size(316, 15);
            label6.TabIndex = 1;
            label6.Text = "Supported video file types: .mkv, .mp4, .avi, .mov, .ts, .m4v\r\n";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label11);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1071, 326);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Auto";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(8, 53);
            label11.Name = "label11";
            label11.Size = new Size(36, 15);
            label11.TabIndex = 0;
            label11.Text = "To do";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1075, 351);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainWindow";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "alass gui";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)interval).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitPenalty).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox mainPath;
        private Button browseFolderDialogButton;
        private OpenFileDialog openFileDialog1;
        private Button scanFolderButton;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label2;
        private ComboBox referenceSubsList;
        private ComboBox videoFileList;
        private ComboBox subsToSyncList;
        private Label label3;
        private GroupBox groupBox1;
        private CheckBox noSplitingCheck;
        private CheckBox disableFPSGuessCheck;
        private CheckBox negativeTimestampCheck;
        private Button syncButton;
        private Label label4;
        private NumericUpDown splitPenalty;
        private Label label5;
        private NumericUpDown interval;
        private CheckBox speedOptimizationCheck;
        private CheckBox closeCMDCheck;
        private Label label6;
        private Button alassGitHubOpen;
        private Label label7;
        private CheckBox subsNameLikeVideoCheck;
        private Label label8;
        private ComboBox langugeCode;
        private CheckBox replaceSubsCheck;
        private Label label9;
        private Button myGithub;
        private Label label10;
        private TabPage tabPage3;
        private Label label11;
    }
}