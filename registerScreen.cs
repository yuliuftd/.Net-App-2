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
    public partial class registerScreen : Form
    {
        public registerScreen()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string userName = regi_user.Text;
            string userPwd = regi_pwd.Text;
            string re_userPwd = regi_confirmPwd.Text;
            string firstName = regi_fName.Text;
            string lastName = regi_lName.Text;
            string date_of_birth = DoB.Value.ToString("dd-MM-yyyy");
            string user_Type = userType.Text;

            foreach (Control field in this.Controls)
            {
                if (field is TextBox)
                {
                    if (string.IsNullOrEmpty((field as TextBox).Text))                //Check empty textbox
                    {
                        MessageBox.Show("Please complete all your information!", "Error");
                        break;
                    }
                    else
                    {
                        if (userPwd == re_userPwd)                                 //Check password
                        {
                            string[] lines = File.ReadAllLines("login.txt");
                            int i = 0;
                            foreach (string line in lines)
                            {
                                string[] elements = line.Split(',');
                                string nameInList = elements[0];

                                if (userName == nameInList)                                //Check  Username
                                {
                                    MessageBox.Show("Username already exist! Please change another one...", "Warnning");                                    
                                    break;
                                }
                                i++;
                            }
                            if (i == lines.Length)
                            { 
                            using (StreamWriter user_info = new StreamWriter("login.txt"))
                            {
                                foreach (string line in lines)
                                {
                                    user_info.WriteLine(line);
                                }
                                user_info.WriteLine(userName + "," + userPwd + "," + user_Type + "," + firstName + "," + lastName + "," + date_of_birth);
                                user_info.Close();
                            }
                            MessageBox.Show("You have Registered successfully", "Congratulations");
                                Loginscreen login = new Loginscreen();
                                login.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Password does not match! Please try again...", "Error");
                            regi_pwd.Clear();
                            regi_confirmPwd.Clear();
                        }
                        break;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Loginscreen login = new Loginscreen();
            login.Show();

        }

        private void registerScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
