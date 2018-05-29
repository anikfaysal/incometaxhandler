using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace IncomeTaxHandler
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login l = new Login();
            l.Show();
            Visible = false;
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            Do_Checked();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Do_Checked();
        }
        private void Do_Checked()
        {
            signUpBtn.Enabled = checkBox1.Checked;
        }

        private void signUpbtn_Click(object sender, EventArgs e)
        {
            if (usertxt.Text == "" || passtxt.Text == "" || emailtxt.Text=="")
            {
                MessageBox.Show("Please provide currect information");
            
            }
            else{
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            user ur = new user();
            ur.username = usertxt.Text;
            ur.password = passtxt.Text;
            ur.email = emailtxt.Text;

            pd.users.InsertOnSubmit(ur);
            pd.SubmitChanges();
            MessageBox.Show("Sign Up Successful");

            }
        
        
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://nbr.gov.bd/terms-of-use/eng");
        }
    }
}
