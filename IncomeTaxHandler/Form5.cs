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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void pay_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
           payment th = new payment
            {
                nid = textBox1.Text,
                receipt_number = textBox2.Text,
                account_number = textBox3.Text,
                amount =Convert.ToDouble (textBox5.Text)
               

            };

            pd.payments.InsertOnSubmit(th);
            pd.SubmitChanges();
            MessageBox.Show("Payment done successfully");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserView u = new UserView();
            u.Show();
            Visible = false;
        }
    }
}
