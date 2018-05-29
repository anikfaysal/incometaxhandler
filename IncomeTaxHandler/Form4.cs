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
    public partial class UserView : Form
    {
        public UserView()
        {
            InitializeComponent();
        }

        //----toolbars-------

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            Visible = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Payment p = new Payment();
            p.Show();
            Visible = false;
            
           
        }

        //--------------Details Button---------

        private void details_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            var y = from a in pd.taxholders
                    where a.nid == textBox1.Text
                    select a;


            textBox4.Text = y.FirstOrDefault().firstname;
            //nidTxt.Text = y.FirstOrDefault().nid;
            textBox3.Text = y.FirstOrDefault().lastname;
            textBox2.Text = y.FirstOrDefault().gender;
            textBox6.Text = y.FirstOrDefault().blood;
            textBox8.Text = y.FirstOrDefault().catagor;
            label16.Text = y.FirstOrDefault().status;
            label18.Text = y.FirstOrDefault().code;




            allHolderstable.DataSource = y.ToList();
            
        }



        private void UserView_Load(object sender, EventArgs e)
        {
            UpdateTable1();
            UpdateTable2();
            UpdateTable3();
            UpdateTable4();
        }

        //----------shows tables----------


        void UpdateTable1()
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
             var x = from a in pd.taxholders           
                    select new {a.firstname,a.lastname,a.gender,a.status,a.catagor };

             allHolderstable.DataSource = x.ToList();
        }

        void UpdateTable2()
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");

            var x = from a in pd.taxholders
                    where a.status == "due"
                    select new {a.firstname,a.lastname,a.gender,a.status,a.catagor };

            dataGridView2.DataSource = x.ToList();

        }

        void UpdateTable3()
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");

            var x = from a in pd.taxholders
                    where a.status == "ok"
                    select new { a.firstname, a.lastname, a.gender, a.status, a.catagor };

            taxPayersTable.DataSource = x.ToList();

        }

        void UpdateTable4()
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            taxRateTable.DataSource = pd.taxrates;

        }

        //-----------ADD Button--------------

        private void button5_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            newregister th = new newregister
            {
                nid = textBox1.Text,
                firstname = textBox4.Text,
                lastname = textBox3.Text,
                gender = textBox2.Text,
                blood = textBox6.Text,
                taxcatagory = textBox8.Text,
                
            };

            pd.newregisters.InsertOnSubmit(th);
            pd.SubmitChanges();

            MessageBox.Show("New Member request has been submitted");
        }


        //-----------Update button-------------------

        private void button6_Click(object sender, EventArgs e)
        {

            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            updaterequest ur = new updaterequest
            {
                nid = textBox1.Text,
                firstname = textBox4.Text,
                lastname = textBox3.Text,
                gender = textBox2.Text,
                blood = textBox6.Text,
                taxcatagory = textBox8.Text,

            };

            pd.updaterequests.InsertOnSubmit(ur);
            pd.SubmitChanges();

            MessageBox.Show("Update request has been submitted");
        }

        //----------clear button-----------

        private void clear_Click(object sender, EventArgs e)
        {
        
           textBox1.Text = textBox4.Text = textBox3.Text = textBox2.Text = textBox6.Text = textBox8.Text = textBox5.Text = textBox10.Text = textBox11.Text = textBox12.Text = textBox13.Text = totalTextBox.Text =label16.Text=label18.Text= string.Empty;
           UpdateTable1();
        
        }

        //----------menu signout button-----------

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            Visible = false;
        }


        //----------menu close button-----------


        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //----------nid enter button-----------

        private void button1_Click(object sender, EventArgs e)
        {


            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            var y = from a in pd.taxholders
                    where a.nid == textBox5.Text
                    select a;


            textBox10.Text = y.FirstOrDefault().catagor;
            textBox12.Text = y.FirstOrDefault().status;
            textBox11.Text = y.FirstOrDefault().code;

        }

        private void calculate_Click(object sender, EventArgs e)
        {


            double inc =Convert.ToDouble(textBox13.Text);
            double TAX;
            double var1 = 0.10;
            double var2 = 0.15;
            double var3 = 0.20;
            double var4 = 0.25;
            double var5 = 0.30;

            if (textBox12.Text=="ok")
            {
                MessageBox.Show("You have already given you Income Tax");
            }


            else if (inc > 0 && inc <= 250000 && textBox11.Text=="A")
            {
                TAX = 3000;
                String s = Convert.ToString(TAX);
                totalTextBox.Text=s;
            }
            else if (inc > 250000 && inc <= 650000 && textBox11.Text == "A")
            {
                TAX = inc * var1;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }


            else if (inc > 650000 && inc <= 1150000 && textBox11.Text == "A")
            {
                TAX = inc * var2;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }

            else if (inc > 1150000 && inc <= 1750000 && textBox11.Text == "A")
            {
                TAX = inc * var3;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }

            else if (inc > 1750000 && inc <= 4750000 && textBox11.Text == "A")
            {
                TAX = inc * var4;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }


            else if (inc > 4750000 && textBox11.Text == "A")
            {
                TAX = inc * var5;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }

            else if (inc > 0 && inc <= 300000 && textBox11.Text == "B")
            {
                TAX = 3000;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }

            else if (inc > 300000 && inc <= 700000 && textBox11.Text == "B")
            {
                TAX = inc * var1;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }

            else if (inc > 700000 && inc <= 1200000 && textBox11.Text == "B")
            {
                TAX = inc * var2;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }

            else if (inc > 1200000 && inc <= 1800000 && textBox11.Text == "B")
            {
                TAX = inc * var3;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }

            else if (inc > 1800000 && inc <= 4800000 && textBox11.Text == "B")
            {
                TAX = inc * var4;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }

            else if (inc > 4800000 && textBox11.Text == "B")
            {
                TAX = inc * var5;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }


            else if (inc > 0 && inc <= 300000 && textBox11.Text == "C")
            {
                TAX = 3000;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }

            else if (inc > 300000 && inc <= 700000 && textBox11.Text == "C")
            {
                TAX = inc * var1;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }

            else if (inc > 700000 && inc <= 1200000 && textBox11.Text == "C")
            {
                TAX = inc * var2;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }

            else if (inc > 1200000 && inc <= 1800000 && textBox11.Text == "C")
            {
                TAX = inc * var3;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }

            else if (inc > 1800000 && inc <= 4800000 && textBox11.Text == "C")
            {
                TAX = inc * var4;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }

            else if (inc > 4800000 && textBox11.Text == "C")
            {
                TAX = inc * var5;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }

            else if (inc > 0 && inc <= 375000 && textBox11.Text == "D")
            {
                TAX = 3000;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }

            else if (inc > 375000 && inc <= 775000 && textBox11.Text == "D")
            {
                TAX = inc * var1;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }


            else if (inc > 775000 && inc <= 1275000 && textBox11.Text == "D")
            {
                TAX = inc * var2;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }


            else if (inc > 1275000 && inc <= 1875000 && textBox11.Text == "D")
            {
                TAX = inc * var3;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }


            else if (inc > 1875000 && inc <= 4875000 && textBox11.Text == "D")
            {
                TAX = inc * var4;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }


            else if (inc > 4875000 && textBox11.Text == "D")
            {
                TAX = inc * var5;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }

            else if (inc > 0 && inc <= 425000 && textBox11.Text == "E")
            {
                TAX = 3000;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }

            else if (inc > 425000 && inc <= 825000 && textBox11.Text == "E")
            {
                TAX = inc * var1;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }

            else if (inc > 825000 && inc <= 1325000 && textBox11.Text == "E")
            {
                TAX = inc * var2;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }

            else if (inc > 1325000 && inc <= 1925000 && textBox11.Text == "E")
            {
                TAX = inc * var3;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }

            else if (inc > 1925000 && inc <= 4925000 && textBox11.Text == "E")
            {
                TAX = inc * var4;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }

            else if (inc > 4925000 && textBox11.Text == "E")
            {
                TAX = inc * var5;
                String s = Convert.ToString(TAX);
                totalTextBox.Text = s;
            }


            else
            {
               MessageBox.Show("Please provide correct infromation");
            }



        }

        private void receiptBtn_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = ("         Income Tax Payment Receipt \n\n" + "\n    Nid Number:\t" + textBox5.Text + "\n\n    Receipt No:\t" + textBox5.Text + "\n\n    Tax-Caagory:\t" + textBox10.Text+
                "\n\n    Code:\t" + textBox11.Text + "\n\n    Income:\t" + textBox13.Text + "\n\n    Total Tax:\t" + totalTextBox.Text + "\n\n\n    Thank You For Paying Your Income Tax");
        }

        private void printBtn_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {

                printDocument1.Print();
            
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text,new Font("Arial",20,FontStyle.Regular),Brushes.Black,150,125);
        }

        
        //private void prit

    }

       // private void printBtn_Click()
      //  {
        
       // }
}
