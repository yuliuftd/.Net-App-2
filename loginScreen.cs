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
    public partial class Loginscreen : Form
    {
        public Loginscreen()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        string uNameInput = string.Empty;
        string uType = string.Empty;
        private void button1_Click(object sender, EventArgs e)
        {
            uNameInput = uName.Text;            
            string line;
            StreamReader reader = new StreamReader("login.txt");
            string[] fileText = File.ReadAllLines("login.txt");
            int i = 0;

            while((line = reader.ReadLine()) != null)
            {
                string[] elements = line.Split(',');
                string user_Name = elements[0];
                string user_Pwd = elements[1];
                string user_type = elements[2];
                uType = user_type;

                if (uName.Text.ToString().Equals(user_Name) && uPwd.Text.ToString().Equals(user_Pwd))
                {
                    this.Hide();
                    editorScreen Editor = new editorScreen(uNameInput, uType);
                    Editor.Show();
                    break;
                }
                i++;
                if (i == fileText.Length )   //means  nothing match the user info, break the loop
                {           
                   break;
                }
            }
             
            // if nothing match the user info in the login.txt, popup window and clear textfield
             
            if (i == fileText.Length )
            {
                MessageBox.Show("Incorrect username or password, retry? ", "error");
                uName.Clear();
                uPwd.Clear();
                uName.Focus();
            }
            /*if (Array.IndexOf(lines, uNameInput, 0) == -1 || Array.IndexOf(lines, uNameInput, 0) == -1)
            {

            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            registerScreen Register = new registerScreen();
            Register.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
