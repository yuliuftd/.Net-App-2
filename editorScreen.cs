using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class editorScreen : Form
    {
        OpenFileDialog newOpenFile = new OpenFileDialog();
        string uName_enter = string.Empty;
        string uType_enter = string.Empty;
        private void editorScreen_FormClosing(object sender, FormClosedEventArgs e)
        {
            /* Application.Loginscreen.Show();*/
            Application.ExitThread();
        }
        public editorScreen(string uNameInput, string uType)
        {
            InitializeComponent();
            
            uName_enter = uNameInput;
            uType_enter = uType;
            fontSize.SelectedIndex = 0;
            fontSize.DropDownStyle = ComboBoxStyle.DropDownList;
            showUserName.Text = "Username:" + uName_enter + " | " + uType_enter;

        }

        //Menu items-------------------------------------------------------------------------------------------------

        //top  menu  "New", clear the richtextBox and start edit
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
        //top menu  "Open", open the file which is txt or rtf
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newOpenFile.Filter = "Text Files (*.txt)|*.txt| Rich Text Format (*.rtf)|*.rtf| All Files (*.*)|*.*";
            if (newOpenFile.ShowDialog() == DialogResult.OK)
            {
                string fileName = new FileInfo(newOpenFile.FileName).Extension;
                switch (fileName.ToLower())
                {
                    case ".txt":
                        richTextBox1.LoadFile(newOpenFile.FileName, RichTextBoxStreamType.PlainText);
                        break;
                    case ".rtf":
                        richTextBox1.LoadFile(newOpenFile.FileName, RichTextBoxStreamType.RichText);
                        break;
                }
                
            }
        }

        
        //top menu "Save", to save words in the richTextBox
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (uType_enter == "Edit")
            {
                StreamWriter file = new StreamWriter(File.Create(newOpenFile.FileName));
                file.Write(richTextBox1.Text);
                file.Close();
            }
            else
            {
                MessageBox.Show("You are not allowed to edit this file", "Warning!");
            }
        }
        
        //top menu "Save As", to save and create a new file which must have a filename
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (uType_enter == "Edit")
            {
                SaveFileDialog saveAs = new SaveFileDialog();

                saveAs.InitialDirectory = "c:\\Destop";
                saveAs.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf| All files (*.*)|*.*";
                saveAs.RestoreDirectory = true;
                if (saveAs.ShowDialog() == DialogResult.OK && saveAs.FileName.Length > 0)
                {
                    string fileName = new FileInfo(saveAs.FileName).Extension;
                    switch (fileName.ToLower())
                    {
                        case ".txt":
                            richTextBox1.SaveFile(newOpenFile.FileName, RichTextBoxStreamType.PlainText);
                            break;
                        case ".rtf":
                            richTextBox1.SaveFile(newOpenFile.FileName, RichTextBoxStreamType.RichText);
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("You are not allowed to edit this file", "Warning!");
            }
        }

        // top menu "Logout"
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Loginscreen login = new Loginscreen();
            login.Show();
            this.Hide();
        }

       
        // top menu "Cut"
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Cut();
            }
        }

        //top menu  "Copy"
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }
        //top menu  "Paste"
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
                {
                    richTextBox1.Paste();
                }
        }

        //top menu "Help", which has the information about this application.
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a Text Editor for .Net Programming Assignment2" + "\n Version:0.1.0" + "\n Name: Yu Liu", "About");
        }

        //ToolStrip Buttons-----------------------------------------------------------------------------------------------

        private void createNew_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void open_Button_Click(object sender, EventArgs e)
        {
            newOpenFile.Filter = "Text Files (*.txt)|*.txt| Rich Text Format (*.rtf)|*.rtf| All Files (*.*)|*.*";
            if (newOpenFile.ShowDialog() == DialogResult.OK)
            {
                string fileName = new FileInfo(newOpenFile.FileName).Extension;
                switch (fileName.ToLower())
                {
                    case ".txt":
                        richTextBox1.LoadFile(newOpenFile.FileName, RichTextBoxStreamType.PlainText);
                        break;
                    case ".rtf":
                        richTextBox1.LoadFile(newOpenFile.FileName, RichTextBoxStreamType.RichText);
                        break;
                }

            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (uType_enter == "Edit")
            {
                StreamWriter file = new StreamWriter(File.Create(newOpenFile.FileName));
                file.Write(richTextBox1.Text);
                file.Close();
            }
            else
            {
                MessageBox.Show("You are not allowed to edit this file", "Warning!");
            }
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            if (uType_enter == "Edit")
            {
                SaveFileDialog saveAs = new SaveFileDialog();

                saveAs.InitialDirectory = "c:\\Destop";
                saveAs.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf| All files (*.*)|*.*";
                saveAs.RestoreDirectory = true;
                if (saveAs.ShowDialog() == DialogResult.OK && saveAs.FileName.Length > 0)
                {
                    string fileName = new FileInfo(saveAs.FileName).Extension;
                    switch (fileName.ToLower())
                    {
                        case ".txt":
                            richTextBox1.SaveFile(newOpenFile.FileName, RichTextBoxStreamType.PlainText);
                            break;
                        case ".rtf":
                            richTextBox1.SaveFile(newOpenFile.FileName, RichTextBoxStreamType.RichText);
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("You are not allowed to edit this file", "Warning!");
            }
        }

        private void boldButton_Click(object sender, EventArgs e)
        {
            Font currentFont = richTextBox1.SelectionFont;
            Font newFont;
            if (currentFont.Bold)
            {
                newFont = new Font(currentFont, currentFont.Style & ~FontStyle.Bold);
            }
            else
            {
                newFont = new Font(currentFont, currentFont.Style | FontStyle.Bold);
            }
            richTextBox1.SelectionFont = newFont;
            richTextBox1.Focus();
        }

        private void italicsButton_Click(object sender, EventArgs e)
        {
            Font currentFont = richTextBox1.SelectionFont;
            Font newFont;
            if (currentFont.Italic)
            {
                newFont = new Font(currentFont, currentFont.Style & ~FontStyle.Italic);
            }
            else
            {
                newFont = new Font(currentFont, currentFont.Style | FontStyle.Italic);
            }
            richTextBox1.SelectionFont = newFont;
            richTextBox1.Focus();
        }

        private void underlineButton_Click(object sender, EventArgs e)
        {
            Font currentFont = richTextBox1.SelectionFont;
            Font newFont;
            if (currentFont.Underline)
            {
                newFont = new Font(currentFont, currentFont.Style & ~FontStyle.Underline);
            }
            else
            {
                newFont = new Font(currentFont, currentFont.Style | FontStyle.Underline);
            }
            richTextBox1.SelectionFont = newFont;
            richTextBox1.Focus();
        }


        public string[] FontSizeName = { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
        public float[] FontSize = { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        private void editorScreen_Load(object sender, EventArgs e)
        {
            foreach (string sizeName in FontSizeName)
            {
                this.fontSize.Items.Add(sizeName);
            }
        }
        private void fontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionFont = new Font(this.richTextBox1.SelectionFont.FontFamily, FontSize[this.fontSize.SelectedIndex], this.richTextBox1.SelectionFont.Style);
        }

        private void cutButton_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void pasteButton_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                richTextBox1.Paste();
            }
        }
    }
}
