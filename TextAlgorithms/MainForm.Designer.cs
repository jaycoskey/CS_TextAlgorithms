namespace TextAlgorithmsForm
{
    partial class MainForm
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
            TextAlgorithms.Properties.Settings settings1 = new TextAlgorithms.Properties.Settings();
            this.inputLabel1 = new System.Windows.Forms.Label();
            this.inputLabel2 = new System.Windows.Forms.Label();
            this.inputTextBox1 = new System.Windows.Forms.TextBox();
            this.inputTextBox2 = new System.Windows.Forms.TextBox();
            this.levenshteinTextBox = new System.Windows.Forms.TextBox();
            this.computeStatsButton = new System.Windows.Forms.Button();
            this.levenshteinLabel = new System.Windows.Forms.Label();
            this.threeStringGroupBox = new System.Windows.Forms.GroupBox();
            this.longestCommonSubsequencesTextBox = new System.Windows.Forms.TextBox();
            this.longestCommonSubsequencesLabel = new System.Windows.Forms.Label();
            this.longestCommonSubstringsTextBox = new System.Windows.Forms.TextBox();
            this.longestCommonSubstringsLabel = new System.Windows.Forms.Label();
            this.damerauLevenshteinTextBox = new System.Windows.Forms.TextBox();
            this.damerauLevenshteinLabel = new System.Windows.Forms.Label();
            this.optimalStringAlignmentTextBox = new System.Windows.Forms.TextBox();
            this.optimalStringAlignmentLabel = new System.Windows.Forms.Label();
            this.inputGroupBox = new System.Windows.Forms.GroupBox();
            this.inputValidatorTextBox3 = new System.Windows.Forms.TextBox();
            this.inputValidatorTextBox2 = new System.Windows.Forms.TextBox();
            this.inputValidatorTextBox1 = new System.Windows.Forms.TextBox();
            this.inputLabel3 = new System.Windows.Forms.Label();
            this.inputTextBox3 = new System.Windows.Forms.TextBox();
            this.statsTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.oneStringGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.longestPalindromesTextBox = new System.Windows.Forms.TextBox();
            this.stringLengthLabel = new System.Windows.Forms.Label();
            this.stringLengthTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.threeStringTodoLabel = new System.Windows.Forms.Label();
            this.inputValidatorTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.threeStringGroupBox.SuspendLayout();
            this.inputGroupBox.SuspendLayout();
            this.statsTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.oneStringGroupBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputLabel1
            // 
            this.inputLabel1.AutoSize = true;
            this.inputLabel1.Location = new System.Drawing.Point(13, 32);
            this.inputLabel1.Name = "inputLabel1";
            this.inputLabel1.Size = new System.Drawing.Size(53, 13);
            this.inputLabel1.TabIndex = 0;
            this.inputLabel1.Text = "String #1:";
            // 
            // inputLabel2
            // 
            this.inputLabel2.AutoSize = true;
            this.inputLabel2.Location = new System.Drawing.Point(13, 98);
            this.inputLabel2.Name = "inputLabel2";
            this.inputLabel2.Size = new System.Drawing.Size(53, 13);
            this.inputLabel2.TabIndex = 1;
            this.inputLabel2.Text = "String #2:";
            // 
            // inputTextBox1
            // 
            this.inputTextBox1.Location = new System.Drawing.Point(80, 29);
            this.inputTextBox1.Name = "inputTextBox1";
            this.inputTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.inputTextBox1.Size = new System.Drawing.Size(494, 20);
            this.inputTextBox1.TabIndex = 2;
            // 
            // inputTextBox2
            // 
            this.inputTextBox2.Location = new System.Drawing.Point(80, 95);
            this.inputTextBox2.Name = "inputTextBox2";
            this.inputTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.inputTextBox2.Size = new System.Drawing.Size(494, 20);
            this.inputTextBox2.TabIndex = 3;
            // 
            // levenshteinTextBox
            // 
            this.levenshteinTextBox.Enabled = false;
            this.levenshteinTextBox.Location = new System.Drawing.Point(204, 21);
            this.levenshteinTextBox.Name = "levenshteinTextBox";
            this.levenshteinTextBox.ReadOnly = true;
            this.levenshteinTextBox.Size = new System.Drawing.Size(352, 20);
            this.levenshteinTextBox.TabIndex = 4;
            // 
            // computeStatsButton
            // 
            this.computeStatsButton.Location = new System.Drawing.Point(117, 261);
            this.computeStatsButton.Name = "computeStatsButton";
            this.computeStatsButton.Size = new System.Drawing.Size(349, 23);
            this.computeStatsButton.TabIndex = 6;
            this.computeStatsButton.Text = "Compute String Statistics";
            this.computeStatsButton.UseVisualStyleBackColor = true;
            this.computeStatsButton.Click += new System.EventHandler(this.computeStatsButton_Click);
            // 
            // levenshteinLabel
            // 
            this.levenshteinLabel.AutoSize = true;
            this.levenshteinLabel.Location = new System.Drawing.Point(13, 24);
            this.levenshteinLabel.Name = "levenshteinLabel";
            this.levenshteinLabel.Size = new System.Drawing.Size(188, 13);
            this.levenshteinLabel.TabIndex = 7;
            this.levenshteinLabel.Text = "Levenshtein distance between strings:";
            // 
            // threeStringGroupBox
            // 
            this.threeStringGroupBox.Controls.Add(this.longestCommonSubsequencesTextBox);
            this.threeStringGroupBox.Controls.Add(this.longestCommonSubsequencesLabel);
            this.threeStringGroupBox.Controls.Add(this.longestCommonSubstringsTextBox);
            this.threeStringGroupBox.Controls.Add(this.longestCommonSubstringsLabel);
            this.threeStringGroupBox.Controls.Add(this.damerauLevenshteinTextBox);
            this.threeStringGroupBox.Controls.Add(this.damerauLevenshteinLabel);
            this.threeStringGroupBox.Controls.Add(this.optimalStringAlignmentTextBox);
            this.threeStringGroupBox.Controls.Add(this.optimalStringAlignmentLabel);
            this.threeStringGroupBox.Controls.Add(this.levenshteinLabel);
            this.threeStringGroupBox.Controls.Add(this.levenshteinTextBox);
            this.threeStringGroupBox.Location = new System.Drawing.Point(12, 6);
            this.threeStringGroupBox.Name = "threeStringGroupBox";
            this.threeStringGroupBox.Size = new System.Drawing.Size(562, 198);
            this.threeStringGroupBox.TabIndex = 16;
            this.threeStringGroupBox.TabStop = false;
            this.threeStringGroupBox.Text = "Two Strings Stats";
            // 
            // longestCommonSubsequencesTextBox
            // 
            this.longestCommonSubsequencesTextBox.AcceptsReturn = true;
            this.longestCommonSubsequencesTextBox.Location = new System.Drawing.Point(204, 96);
            this.longestCommonSubsequencesTextBox.Multiline = true;
            this.longestCommonSubsequencesTextBox.Name = "longestCommonSubsequencesTextBox";
            this.longestCommonSubsequencesTextBox.ReadOnly = true;
            this.longestCommonSubsequencesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.longestCommonSubsequencesTextBox.Size = new System.Drawing.Size(352, 39);
            this.longestCommonSubsequencesTextBox.TabIndex = 15;
            // 
            // longestCommonSubsequencesLabel
            // 
            this.longestCommonSubsequencesLabel.AutoSize = true;
            this.longestCommonSubsequencesLabel.Location = new System.Drawing.Point(13, 108);
            this.longestCommonSubsequencesLabel.Name = "longestCommonSubsequencesLabel";
            this.longestCommonSubsequencesLabel.Size = new System.Drawing.Size(169, 13);
            this.longestCommonSubsequencesLabel.TabIndex = 14;
            this.longestCommonSubsequencesLabel.Text = "Longest common subsequence(s):";
            // 
            // longestCommonSubstringsTextBox
            // 
            this.longestCommonSubstringsTextBox.AcceptsReturn = true;
            this.longestCommonSubstringsTextBox.Location = new System.Drawing.Point(204, 141);
            this.longestCommonSubstringsTextBox.Multiline = true;
            this.longestCommonSubstringsTextBox.Name = "longestCommonSubstringsTextBox";
            this.longestCommonSubstringsTextBox.ReadOnly = true;
            this.longestCommonSubstringsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.longestCommonSubstringsTextBox.Size = new System.Drawing.Size(352, 39);
            this.longestCommonSubstringsTextBox.TabIndex = 13;
            // 
            // longestCommonSubstringsLabel
            // 
            this.longestCommonSubstringsLabel.AutoSize = true;
            this.longestCommonSubstringsLabel.Location = new System.Drawing.Point(13, 152);
            this.longestCommonSubstringsLabel.Name = "longestCommonSubstringsLabel";
            this.longestCommonSubstringsLabel.Size = new System.Drawing.Size(147, 13);
            this.longestCommonSubstringsLabel.TabIndex = 12;
            this.longestCommonSubstringsLabel.Text = "Longest common substring(s):";
            // 
            // damerauLevenshteinTextBox
            // 
            this.damerauLevenshteinTextBox.Enabled = false;
            this.damerauLevenshteinTextBox.Location = new System.Drawing.Point(204, 44);
            this.damerauLevenshteinTextBox.Name = "damerauLevenshteinTextBox";
            this.damerauLevenshteinTextBox.ReadOnly = true;
            this.damerauLevenshteinTextBox.Size = new System.Drawing.Size(352, 20);
            this.damerauLevenshteinTextBox.TabIndex = 11;
            // 
            // damerauLevenshteinLabel
            // 
            this.damerauLevenshteinLabel.AutoSize = true;
            this.damerauLevenshteinLabel.Location = new System.Drawing.Point(13, 47);
            this.damerauLevenshteinLabel.Name = "damerauLevenshteinLabel";
            this.damerauLevenshteinLabel.Size = new System.Drawing.Size(157, 13);
            this.damerauLevenshteinLabel.TabIndex = 10;
            this.damerauLevenshteinLabel.Text = "Damerau-Levenshtein distance:";
            // 
            // optimalStringAlignmentTextBox
            // 
            this.optimalStringAlignmentTextBox.Enabled = false;
            this.optimalStringAlignmentTextBox.Location = new System.Drawing.Point(204, 70);
            this.optimalStringAlignmentTextBox.Name = "optimalStringAlignmentTextBox";
            this.optimalStringAlignmentTextBox.ReadOnly = true;
            this.optimalStringAlignmentTextBox.Size = new System.Drawing.Size(352, 20);
            this.optimalStringAlignmentTextBox.TabIndex = 9;
            // 
            // optimalStringAlignmentLabel
            // 
            this.optimalStringAlignmentLabel.AutoSize = true;
            this.optimalStringAlignmentLabel.Location = new System.Drawing.Point(13, 73);
            this.optimalStringAlignmentLabel.Name = "optimalStringAlignmentLabel";
            this.optimalStringAlignmentLabel.Size = new System.Drawing.Size(164, 13);
            this.optimalStringAlignmentLabel.TabIndex = 8;
            this.optimalStringAlignmentLabel.Text = "Optimal string alignment distance:";
            // 
            // inputGroupBox
            // 
            this.inputGroupBox.Controls.Add(this.inputValidatorTextBox3);
            this.inputGroupBox.Controls.Add(this.inputValidatorTextBox2);
            this.inputGroupBox.Controls.Add(this.inputValidatorTextBox1);
            this.inputGroupBox.Controls.Add(this.inputLabel3);
            this.inputGroupBox.Controls.Add(this.inputTextBox3);
            this.inputGroupBox.Controls.Add(this.inputLabel2);
            this.inputGroupBox.Controls.Add(this.inputLabel1);
            this.inputGroupBox.Controls.Add(this.inputTextBox1);
            this.inputGroupBox.Controls.Add(this.inputTextBox2);
            this.inputGroupBox.Location = new System.Drawing.Point(12, 38);
            this.inputGroupBox.Name = "inputGroupBox";
            this.inputGroupBox.Size = new System.Drawing.Size(601, 217);
            this.inputGroupBox.TabIndex = 17;
            this.inputGroupBox.TabStop = false;
            this.inputGroupBox.Text = "Input";
            // 
            // inputValidatorTextBox3
            // 
            this.inputValidatorTextBox3.BackColor = System.Drawing.SystemColors.Control;
            this.inputValidatorTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputValidatorTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputValidatorTextBox3.ForeColor = System.Drawing.Color.Red;
            this.inputValidatorTextBox3.Location = new System.Drawing.Point(105, 182);
            this.inputValidatorTextBox3.Name = "inputValidatorTextBox3";
            this.inputValidatorTextBox3.ReadOnly = true;
            this.inputValidatorTextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.inputValidatorTextBox3.Size = new System.Drawing.Size(469, 13);
            this.inputValidatorTextBox3.TabIndex = 8;
            this.inputValidatorTextBox3.Visible = false;
            // 
            // inputValidatorTextBox2
            // 
            this.inputValidatorTextBox2.BackColor = System.Drawing.SystemColors.Control;
            this.inputValidatorTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputValidatorTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputValidatorTextBox2.ForeColor = System.Drawing.Color.Red;
            this.inputValidatorTextBox2.Location = new System.Drawing.Point(105, 121);
            this.inputValidatorTextBox2.Name = "inputValidatorTextBox2";
            this.inputValidatorTextBox2.ReadOnly = true;
            this.inputValidatorTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.inputValidatorTextBox2.Size = new System.Drawing.Size(469, 13);
            this.inputValidatorTextBox2.TabIndex = 7;
            this.inputValidatorTextBox2.Visible = false;
            // 
            // inputValidatorTextBox1
            // 
            this.inputValidatorTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.inputValidatorTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputValidatorTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputValidatorTextBox1.ForeColor = System.Drawing.Color.Red;
            this.inputValidatorTextBox1.Location = new System.Drawing.Point(105, 55);
            this.inputValidatorTextBox1.Name = "inputValidatorTextBox1";
            this.inputValidatorTextBox1.ReadOnly = true;
            this.inputValidatorTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.inputValidatorTextBox1.Size = new System.Drawing.Size(469, 13);
            this.inputValidatorTextBox1.TabIndex = 6;
            this.inputValidatorTextBox1.Visible = false;
            // 
            // inputLabel3
            // 
            this.inputLabel3.AutoSize = true;
            this.inputLabel3.Location = new System.Drawing.Point(13, 159);
            this.inputLabel3.Name = "inputLabel3";
            this.inputLabel3.Size = new System.Drawing.Size(53, 13);
            this.inputLabel3.TabIndex = 4;
            this.inputLabel3.Text = "String #3:";
            // 
            // inputTextBox3
            // 
            this.inputTextBox3.Location = new System.Drawing.Point(80, 156);
            this.inputTextBox3.Name = "inputTextBox3";
            this.inputTextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.inputTextBox3.Size = new System.Drawing.Size(494, 20);
            this.inputTextBox3.TabIndex = 5;
            // 
            // statsTabControl
            // 
            this.statsTabControl.AccessibleName = "";
            this.statsTabControl.Controls.Add(this.tabPage1);
            this.statsTabControl.Controls.Add(this.tabPage2);
            this.statsTabControl.Controls.Add(this.tabPage3);
            settings1.Name = "";
            settings1.SettingsKey = "";
            this.statsTabControl.DataBindings.Add(new System.Windows.Forms.Binding("Text", settings1, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.statsTabControl.Location = new System.Drawing.Point(8, 316);
            this.statsTabControl.Name = "statsTabControl";
            this.statsTabControl.SelectedIndex = 0;
            this.statsTabControl.Size = new System.Drawing.Size(605, 242);
            this.statsTabControl.TabIndex = 18;
            this.statsTabControl.Text = settings1.Name;
            this.statsTabControl.SelectedIndexChanged += new System.EventHandler(this.statsTabControl_SelectionChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.oneStringGroupBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(597, 216);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "One String Stats";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // oneStringGroupBox
            // 
            this.oneStringGroupBox.Controls.Add(this.label1);
            this.oneStringGroupBox.Controls.Add(this.longestPalindromesTextBox);
            this.oneStringGroupBox.Controls.Add(this.stringLengthLabel);
            this.oneStringGroupBox.Controls.Add(this.stringLengthTextBox);
            this.oneStringGroupBox.Location = new System.Drawing.Point(27, 15);
            this.oneStringGroupBox.Name = "oneStringGroupBox";
            this.oneStringGroupBox.Size = new System.Drawing.Size(553, 195);
            this.oneStringGroupBox.TabIndex = 17;
            this.oneStringGroupBox.TabStop = false;
            this.oneStringGroupBox.Text = "One Strings Stats";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Longest palindromes";
            // 
            // longestPalindromesTextBox
            // 
            this.longestPalindromesTextBox.AcceptsReturn = true;
            this.longestPalindromesTextBox.Location = new System.Drawing.Point(204, 53);
            this.longestPalindromesTextBox.Multiline = true;
            this.longestPalindromesTextBox.Name = "longestPalindromesTextBox";
            this.longestPalindromesTextBox.ReadOnly = true;
            this.longestPalindromesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.longestPalindromesTextBox.Size = new System.Drawing.Size(343, 36);
            this.longestPalindromesTextBox.TabIndex = 8;
            // 
            // stringLengthLabel
            // 
            this.stringLengthLabel.AutoSize = true;
            this.stringLengthLabel.Location = new System.Drawing.Point(13, 24);
            this.stringLengthLabel.Name = "stringLengthLabel";
            this.stringLengthLabel.Size = new System.Drawing.Size(66, 13);
            this.stringLengthLabel.TabIndex = 7;
            this.stringLengthLabel.Text = "String length";
            // 
            // stringLengthTextBox
            // 
            this.stringLengthTextBox.Enabled = false;
            this.stringLengthTextBox.Location = new System.Drawing.Point(204, 21);
            this.stringLengthTextBox.Name = "stringLengthTextBox";
            this.stringLengthTextBox.ReadOnly = true;
            this.stringLengthTextBox.Size = new System.Drawing.Size(343, 20);
            this.stringLengthTextBox.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.threeStringGroupBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(597, 216);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Two String Stats";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(597, 216);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Three String Stats";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.threeStringTodoLabel);
            this.groupBox1.Location = new System.Drawing.Point(27, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 200);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Three Strings Stats";
            // 
            // threeStringTodoLabel
            // 
            this.threeStringTodoLabel.AutoSize = true;
            this.threeStringTodoLabel.Location = new System.Drawing.Point(13, 24);
            this.threeStringTodoLabel.Name = "threeStringTodoLabel";
            this.threeStringTodoLabel.Size = new System.Drawing.Size(303, 13);
            this.threeStringTodoLabel.TabIndex = 7;
            this.threeStringTodoLabel.Text = "See my GeneralizedSuffixTree project at github.com/jaycoskey";
            // 
            // inputValidatorTextBox
            // 
            this.inputValidatorTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.inputValidatorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputValidatorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputValidatorTextBox.ForeColor = System.Drawing.Color.Red;
            this.inputValidatorTextBox.Location = new System.Drawing.Point(8, 290);
            this.inputValidatorTextBox.Name = "inputValidatorTextBox";
            this.inputValidatorTextBox.Size = new System.Drawing.Size(601, 13);
            this.inputValidatorTextBox.TabIndex = 19;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.helpMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(625, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "&File";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitMenuItem.Text = "E&xit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpMenuItem.Text = "&Help";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutMenuItem.Text = "&About";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 570);
            this.Controls.Add(this.inputValidatorTextBox);
            this.Controls.Add(this.statsTabControl);
            this.Controls.Add(this.computeStatsButton);
            this.Controls.Add(this.inputGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.threeStringGroupBox.ResumeLayout(false);
            this.threeStringGroupBox.PerformLayout();
            this.inputGroupBox.ResumeLayout(false);
            this.inputGroupBox.PerformLayout();
            this.statsTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.oneStringGroupBox.ResumeLayout(false);
            this.oneStringGroupBox.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label inputLabel1;
        private System.Windows.Forms.Label inputLabel2;
        private System.Windows.Forms.TextBox inputTextBox1;
        private System.Windows.Forms.TextBox inputTextBox2;
        private System.Windows.Forms.TextBox levenshteinTextBox;
        private System.Windows.Forms.Button computeStatsButton;
        private System.Windows.Forms.Label levenshteinLabel;
        private System.Windows.Forms.GroupBox threeStringGroupBox;
        private System.Windows.Forms.GroupBox inputGroupBox;
        private System.Windows.Forms.TabControl statsTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label inputLabel3;
        private System.Windows.Forms.TextBox inputTextBox3;
        private System.Windows.Forms.GroupBox oneStringGroupBox;
        private System.Windows.Forms.Label stringLengthLabel;
        private System.Windows.Forms.TextBox stringLengthTextBox;
        private System.Windows.Forms.TextBox inputValidatorTextBox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox longestCommonSubsequencesTextBox;
        private System.Windows.Forms.Label longestCommonSubsequencesLabel;
        private System.Windows.Forms.TextBox longestCommonSubstringsTextBox;
        private System.Windows.Forms.Label longestCommonSubstringsLabel;
        private System.Windows.Forms.TextBox damerauLevenshteinTextBox;
        private System.Windows.Forms.Label damerauLevenshteinLabel;
        private System.Windows.Forms.TextBox optimalStringAlignmentTextBox;
        private System.Windows.Forms.Label optimalStringAlignmentLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label threeStringTodoLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.TextBox inputValidatorTextBox3;
        private System.Windows.Forms.TextBox inputValidatorTextBox2;
        private System.Windows.Forms.TextBox inputValidatorTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox longestPalindromesTextBox;
    }
}
