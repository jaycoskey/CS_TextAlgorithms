using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TextAlgorithms;

namespace TextAlgorithmsForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            Form aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        // Update all string stats for which there are enough strings entered.
        private void computeStatsButton_Click(object sender, EventArgs e)
        {
            TabPage selectedTab = statsTabControl.SelectedTab;

            bool isInput1Empty = (inputTextBox1.Text == String.Empty);
            bool isInput2Empty = (inputTextBox2.Text == String.Empty);
            bool isInput3Empty = (inputTextBox3.Text == String.Empty);

            bool isInput1Error = false; //  isInput1Empty;
            bool isInput2Error = false; //  isInput2Empty && (selectedTab == tabPage2 || selectedTab == tabPage3);
            bool isInput3Error = false; //  isInput3Empty && selectedTab == tabPage3;
            bool isInputError = isInput1Error || isInput2Error || isInput3Error;

            inputValidatorTextBox1.Text = isInput1Error ? "String #1 must be non-empty for all stats" : String.Empty;
            inputValidatorTextBox2.Text = isInput2Error
                ? "String #2 must be non-empty for 1-string and 2-string stats" : String.Empty;
            inputValidatorTextBox3.Text = isInput3Error
                ? "String #3 must be non-empty for 3-string stats" : String.Empty;

            inputValidatorTextBox1.Visible = isInput1Error;
            inputValidatorTextBox2.Visible = isInput2Error;
            inputValidatorTextBox3.Visible = isInput3Error;
            inputValidatorTextBox.Visible = isInputError;

            if (isInputError) {
                int numErrors = (isInput1Error ? 1 : 0)
                    + (isInput2Error ? 1 : 0)
                    + (isInput3Error ? 1 : 0);
                inputValidatorTextBox.Text = String.Format(
                    "Please fix the {0} error{1} above before continuing.",
                    numErrors,
                    numErrors == 1 ? String.Empty : "s"
                    );
                return;
            }
            inputValidatorTextBox.Text = String.Empty;

            // One String
            stringLengthTextBox.Text = Convert.ToString(
                StringLength.Length(inputTextBox1.Text)
                );
            List<string> palindromes = Palindrome.LongestPalindromes(inputTextBox1.Text);
            longestPalindromesTextBox.Text = String.Join(Environment.NewLine, palindromes);

            // Two Strings
            levenshteinTextBox.Text = Convert.ToString(
                StringDistance.LevenshteinDistance(inputTextBox1.Text, inputTextBox2.Text)
                );
            damerauLevenshteinTextBox.Text = Convert.ToString(
                StringDistance.DamerauLevenshteinDistance(inputTextBox1.Text, inputTextBox2.Text)
                );
            optimalStringAlignmentTextBox.Text = Convert.ToString(
                StringDistance.OptimalStringAlignmentDistance(inputTextBox1.Text, inputTextBox2.Text)
                );
            longestCommonSubsequencesTextBox.Text = String.Join(Environment.NewLine,
                CommonSubset.LongestCommonSubsequences(inputTextBox1.Text, inputTextBox2.Text)
                );
            longestCommonSubstringsTextBox.Text = String.Join(Environment.NewLine,
                CommonSubset.LongestCommonSubstrings(inputTextBox1.Text, inputTextBox2.Text)
                );
        }

        private static Color backColor_Enabled(bool value)
        {
            return value ? Color.White : Color.Gray;
        }

        private void setInput1_Enabled(bool value)
        {
            inputLabel1.Visible = value;
            inputTextBox1.Visible = value;
            inputValidatorTextBox1.Visible = value;
        }

        private void setInput2_Enabled(bool value)
        {
            inputLabel2.Visible = value;
            inputTextBox2.Visible = value;
            inputValidatorTextBox2.Visible = value;
        }

        private void setInput3_Enabled(bool value)
        {
            inputLabel3.Visible = value;
            inputTextBox3.Visible = value;
            inputValidatorTextBox3.Visible = value;
        }

        private void setInput_Enabled()
        {
            if (statsTabControl.SelectedTab == this.tabPage1)
            {
                setInput1_Enabled(true);
                setInput2_Enabled(false);
                setInput3_Enabled(false);
            }
            else if (statsTabControl.SelectedTab == this.tabPage2)
            {
                setInput1_Enabled(true);
                setInput2_Enabled(true);
                setInput3_Enabled(false);
            }
            else if (statsTabControl.SelectedTab == this.tabPage3)
            {
                setInput1_Enabled(true);
                setInput2_Enabled(true);
                setInput3_Enabled(true);
            }
            else
            {
                inputValidatorTextBox.BackColor = backColor_Enabled(true);
                inputValidatorTextBox.Enabled = true;
                inputValidatorTextBox.Text = "internal error: unrecognized tab: "
                    + statsTabControl.SelectedTab.Name + "\n";
            }
        }
        private void statsTabControl_SelectionChanged(object sender, EventArgs e)
        {
            this.setInput_Enabled();
        }
    }
}
