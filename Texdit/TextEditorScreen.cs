using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Texdit
{
    public partial class TextEditorScreen : Form
    {
        private UserAccount userAcccount;
        LoginScreen loginScreen;
        private string currentFile;

        public TextEditorScreen(UserAccount userAccount, LoginScreen loginScreen)
        {
            InitializeComponent();
            this.userAcccount = userAccount;
            this.loginScreen = loginScreen;
        }



        private void TextEditorScreen_Load(object sender, EventArgs e)
        {
            userLabel.Text = $"Welcome to Texdit, {userAcccount.FirstName} {userAcccount.LastName}! | Username: {userAcccount.Username}";
            if (userAcccount.UserType == "View")
            {
                newToolStripButton.Enabled = false;
                saveToolStripButton.Enabled = false;
                saveAsToolStripButton4.Enabled = false;
                boldToolStripButton.Enabled = false;
                underlineToolStripButton.Enabled = false;
                italicToolStripButton.Enabled = false;
                fontSizeComboBox.Enabled = false;
                leftToolStrip.Enabled = false;
                fontToolStripMenuItem.Enabled = false;
                newToolStripMenuItem.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                editStripMenuTab.Enabled = false;
                // Only allow user to view and open any text file
                richTextBox.ReadOnly = true;
            }
        }



        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutBox = new AboutForm();
            aboutBox.Show();
        }

        // Handles the logic for the cut button in the leftToolStrip and menuStrip
        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            // Check if the text selection is more than 0 characters
            if (richTextBox.SelectionLength > 0)
                richTextBox.Cut();
        }

        // Handles the logic for the Copy function in the leftToolStrip and menuStrip
        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            // Check if the text selection is more than 0 characters
            if (richTextBox.SelectionLength > 0)
                richTextBox.Copy();
        }

        // Handles the logic for the Paste function in the leftToolStrip and menuStrip
        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }

        // Allows user to change and select the font size or change the font size of a selected text
        private void fontSizeComboBox_TextChanged(object sender, EventArgs e)
        {
            Font currentFont = richTextBox.SelectionFont;
            if (Int32.TryParse(fontSizeComboBox.Text, out int fontSize))
            {
                // Change the current selection font to a new fontSize by updating its font size and keeping its current font family and font style
                richTextBox.SelectionFont = new Font(currentFont.FontFamily, fontSize, currentFont.Style);
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // The log out code is already built in with the FormClosingEvent
            Close();

        }

        private void boldToolStripButton_Click(object sender, EventArgs e)
        {
            // Get the current selected text Font properties
            Font currentFont = richTextBox.SelectionFont;

            // First, check if the current text is bold or not
            if (currentFont.Bold)
            {
                // Then, check if the font is currently has italic property or underline property or both italic and underline property enabled
                if (currentFont.Underline && currentFont.Italic)
                {
                    richTextBox.SelectionFont = new Font(currentFont, FontStyle.Italic | FontStyle.Underline);
                }
                else if (currentFont.Underline)
                {
                    richTextBox.SelectionFont = new Font(currentFont, FontStyle.Underline);
                }
                else if (currentFont.Italic)
                {
                    richTextBox.SelectionFont = new Font(currentFont, FontStyle.Italic);
                }
                // Else if the selected has only bold font style, remove the bold style property and convert it to a regular text
                else
                {
                    richTextBox.SelectionFont = new Font(currentFont, FontStyle.Regular);
                }

                // Uncheck the bold button so user knows the bold property is not being used
                boldToolStripButton.Checked = false;
            }

            // If the text is not bold, add a bold style property to the current selection font of the rich text box including the current font style if exist.
            else
            {
                richTextBox.SelectionFont = new Font(currentFont, currentFont.Style | FontStyle.Bold);

                // Check the bold button
                boldToolStripButton.Checked = true;
            }
        }

        private void italicToolStripButton_Click(object sender, EventArgs e)
        {
            // Get the current selected text Font properties
            Font currentFont = richTextBox.SelectionFont;

            // First, check if the current text is italicised or not
            if (currentFont.Italic)
            {
                // Then, check if the font is currently has bold property or underline property or both bold and underline property enabled
                if (currentFont.Underline && currentFont.Bold)
                {
                    richTextBox.SelectionFont = new Font(currentFont, FontStyle.Bold | FontStyle.Underline);
                }
                else if (currentFont.Underline)
                {
                    richTextBox.SelectionFont = new Font(currentFont, FontStyle.Underline);
                }
                else if (currentFont.Bold)
                {
                    richTextBox.SelectionFont = new Font(currentFont, FontStyle.Bold);
                }
                // Else if the selected has only italic font style, remove the italic style property and convert it to a regular text
                else
                {
                    richTextBox.SelectionFont = new Font(currentFont, FontStyle.Regular);
                }

                // Uncheck the Italic button so user knows the bold property is not being used
                italicToolStripButton.Checked = false;
            }

            // If the text is not Italic, add an Italic style property to the current selection font of the rich text box including the current font style if exist.
            else
            {
                richTextBox.SelectionFont = new Font(currentFont, currentFont.Style | FontStyle.Italic);

                // Check the Italic button
                italicToolStripButton.Checked = true;
            }
        }

        private void underlineToolStripButton_Click(object sender, EventArgs e)
        {
            // Get the current selected text Font properties
            Font currentFont = richTextBox.SelectionFont;

            // First, check if the current text is underlined or not
            if (currentFont.Underline)
            {
                // Then, check if the font is currently has Italic property or Bold property or both bold and italic property enabled
                if (currentFont.Italic && currentFont.Bold)
                {
                    richTextBox.SelectionFont = new Font(currentFont, FontStyle.Bold | FontStyle.Italic);
                }
                else if (currentFont.Italic)
                {
                    richTextBox.SelectionFont = new Font(currentFont, FontStyle.Italic);
                }
                else if (currentFont.Bold)
                {
                    richTextBox.SelectionFont = new Font(currentFont, FontStyle.Bold);
                }
                // Else if the selected has only Underline font style, remove the italic style property and convert it to a regular text
                else
                {
                    richTextBox.SelectionFont = new Font(currentFont, FontStyle.Regular);
                }

                // Uncheck the underline button so user knows the bold property is not being used
                underlineToolStripButton.Checked = false;
            }

            // If the text is not Underline, add an underline style property to the current selection font of the rich text box including the current font style if exist.
            else
            {
                richTextBox.SelectionFont = new Font(currentFont, currentFont.Style | FontStyle.Underline);

                // Check the Underline button
                underlineToolStripButton.Checked = true;
            }
        }


        // Get the current state of the text and its size 
        private void UpdateFontStyleButtonState()
        {
            Font currentFont = richTextBox.SelectionFont;
            if (currentFont != null)
            {
                boldToolStripButton.Checked = currentFont.Bold;
                italicToolStripButton.Checked = currentFont.Italic;
                underlineToolStripButton.Checked = currentFont.Underline;
                // Grab the current font size of the text
                fontSizeComboBox.Text = currentFont.Size.ToString();
            }
        }

        private void richTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            UpdateFontStyleButtonState();
        }

        private void richTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateFontStyleButtonState();
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionFont = new Font(dialog.Font.Name, dialog.Font.Size, dialog.Font.Style);
                fontSizeComboBox.Text = Convert.ToString(dialog.Font.Size);
            }
        }

        // Save the file
        private void SaveFile()
        {
            string fileExtension = Path.GetExtension(currentFile);
            if (fileExtension == ".rtf")
                File.WriteAllText(currentFile, richTextBox.Rtf);
            else if (fileExtension == ".txt")
                File.WriteAllText(currentFile, richTextBox.Text);
        }

        // Handles the  "Load the file from open Dialog" logic
        private void LoadFile()
        {
            // CHeck if the extension is .rtf or .txt, then load the file depending if its Plain Text (Txt) or Rich Text (rtf)
            string fileExtension = Path.GetExtension(currentFile);
            if (fileExtension == ".rtf")
                richTextBox.LoadFile(currentFile, RichTextBoxStreamType.RichText);
            else if (fileExtension == ".txt")
                richTextBox.LoadFile(currentFile, RichTextBoxStreamType.PlainText);
        }

        // Ensure that if user closes the text editor or logout, check if it has been saved or not
        private DialogResult UnsavedChanges()
        {
            // IF no change, set the Dialog Result to None
            DialogResult result = DialogResult.None;

            // Check if current file exists then check if the content of the current Rich Text box RTF / TXT is the same as the one that has been saved previously
            if (!string.IsNullOrEmpty(currentFile) &&
                File.ReadAllText(currentFile) != richTextBox.Rtf &&
                File.ReadAllText(currentFile) != richTextBox.Text &&
                (result = MessageBox.Show($"Do you want to change saves to\n{currentFile}?", "Save File",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)) == DialogResult.Yes)
            {
                SaveFile();

                // Bypass closing event handler after clicking Yes, save then close instead of opening the saveAsDialog again
                result = DialogResult.None;
            }

            // Check if the current text edior has been saved or not if user accidentally press new or close the application
            else if (string.IsNullOrEmpty(currentFile) && richTextBox.TextLength > 0)
            {
                result = MessageBox.Show("Do you wish to save changes to this text?", "Save FIle", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                
            }

            return result;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult result = UnsavedChanges();
            if (result == DialogResult.Yes)
            {
                saveAsToolStripMenuItem_Click(sender, e);
                currentFile = string.Empty;
                // Set the Texdit tab - text (top of screen)
                Text = "Texdit - Your personal text editor";
                richTextBox.Text = string.Empty;
            }
            else if (result != DialogResult.Cancel)
            {
                currentFile = string.Empty;
                // Set the Texdit tab - text (top of screen)
                Text = "Texdit - Your personal text editor";
                richTextBox.Text = string.Empty;
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            // Set the title of the dialog
            openDialog.Title = "Open a text file";
            // Set the file extension filer for the open Dialog
            openDialog.Filter = "Rich Text Format files (*.rtf)|*.rtf|Plain Text files (*.txt)|*.txt|All files (*.*)|*.*";

            DialogResult dr = openDialog.ShowDialog();

            // Check the dialog result
            if (dr == DialogResult.OK)
            {
                // Set the current file attribute to the openDialog File name
                currentFile = openDialog.FileName;
                Text = "Texdit - Your personal text editor - " + currentFile;
                LoadFile();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if the current file is not empty or null
            if (!string.IsNullOrEmpty(currentFile))
            {
                SaveFile();
                MessageBox.Show("File has been saved successfully!", "Save File", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                saveAsToolStripMenuItem_Click(this, new EventArgs());
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            // Set the title of the dialog
            saveDialog.Title = "Save As Your Texdit File";
            // Set the save file extension to filter to allow user choose what type of file they wish to save as
            saveDialog.Filter = "Rich Text Format files (*.rtf)|*.rtf|Plain Text files (*.txt)|*.txt|All files (*.*)|*.*";

            DialogResult dr = saveDialog.ShowDialog();

            if (dr == DialogResult.OK)
            {
                // Set the currentFile String attribute to the File name saved by the user
                currentFile = saveDialog.FileName;
                Text = "Texdit - Your personal text editor - " + currentFile;
                SaveFile();
            }
        }


        // When closing the Text Editor Screen, make sure the loginScreen which was hidden is also closed
        private void TextEditorScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = UnsavedChanges();

            // Handles the Logout logic
            if (new StackTrace().GetFrames().Any(x => x.GetMethod().Name == "Close"))
            {
               
                if (result == DialogResult.Yes)
                {
                    saveAsToolStripMenuItem_Click(sender, e);
                    loginScreen.Show();
                }

                // If user wish to not save the file or the current text, then automatically redirect to the Login Screen
                else if (result != DialogResult.Cancel)
                {
                    loginScreen.Show();
                }
                
                // If user wish to cancel logout, then go back to current text editor
                else if (result == DialogResult.Cancel)
                {
                   // Cancel the log out process
                    e.Cancel = true;
                }
            }

            // Handles when user press "x" logic or ALT+F4
            else
            {
                if (result == DialogResult.Yes)
                {
                    saveAsToolStripMenuItem_Click(sender, e);
                    e.Cancel = false;
                    loginScreen.Close();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (result == DialogResult.No)
                {
                    loginScreen.Close();
                    e.Cancel = false;
                }
                else
                {
                    loginScreen.Close();

                }
            }
        }

    }
    
}

      

