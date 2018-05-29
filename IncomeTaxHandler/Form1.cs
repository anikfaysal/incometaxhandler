using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IncomeTaxHandler
{
    public partial class Login : Form
    {
       
        public Login()
        {
            InitializeComponent();
           
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = usern.Text;
            string password = passw.Text;
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");


            if (username == "" || password == "")
            {

                MessageBox.Show("Please Put Your Username and Password");
            }

            else
            {


                var i = (from a in pd.users
                         where a.username == username && a.password == password
                         select a);


                if (i.Any())
                {

                    if (username == "Anik" && password == "anik")
                    {
                        AdminView ad = new AdminView();
                        ad.Show();
                        Visible = false;

                    }
                    else
                    {
                        UserView uv = new UserView();
                        uv.Show();
                        Visible = false;


                    }

                }

                else
                {
                    MessageBox.Show("Invalid Username and Password ");

                }
            }


              }


          

        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration r = new Registration();
            r.Show();
            Visible = false;
        }
    }
}