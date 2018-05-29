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
    public partial class AdminView : Form
    {
        public AdminView()
        {
            InitializeComponent();
        }

        private void AdminView_Load(object sender, EventArgs e)
        {
            UpdateTable1();
            UpdateTable2();
            UpdateTable3();
            UpdateTable7();
            UpdateTable5();
            UpdateTable6();
            UpdateTable4();
            UpdateTable9();
            UpdateTable8();
        }

        //-------signout button-----------

        private void signOutBtn_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            Visible = false;
        }

        //-----------Show tables----------

        void UpdateTable1()
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            allHolderstable.DataSource = pd.taxholders;
        }

        void UpdateTable2()
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");

            var x = from a in pd.taxholders
                    where a.status == "due"
                    select a;

            duePayersTable.DataSource = x.ToList();
        
        }

        void UpdateTable3()
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");

            var x = from a in pd.taxholders
                    where a.status == "ok"
                    select a;

            taxPayersTable.DataSource = x.ToList();

        }

        void UpdateTable7()
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            paymentTable.DataSource = pd.payments;

        }

        void UpdateTable5()
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            newRegisterTable.DataSource = pd.newregisters;

        }

        void UpdateTable6()
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            updateTable.DataSource = pd.updaterequests;

        }

        void UpdateTable4()
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            taxRateTable.DataSource = pd.taxrates;

        }

        void UpdateTable9()
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView8.DataSource = pd.taxrates;

        }

        void UpdateTable8()
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView7.DataSource = pd.taxholders;
        }

        //------ends-------------

        //----------search button-----------

        private void searchBtn1_Click(object sender, EventArgs e)
        {       
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            var y = from a in pd.taxholders
                    where a.nid == search1Txt.Text
                    select a;

            nidTxt.Text = y.FirstOrDefault().nid;
            fstNameTxt.Text = y.FirstOrDefault().firstname;
            //nidTxt.Text = y.FirstOrDefault().nid;
            lastNameTxt.Text = y.FirstOrDefault().lastname;
            textBox2.Text = y.FirstOrDefault().gender;
            bloodTxt.Text = y.FirstOrDefault().blood;
            textBox3.Text = y.FirstOrDefault().catagor;
            textBox8.Text = y.FirstOrDefault().status;
            textBox9.Text = y.FirstOrDefault().code;
           
            


            allHolderstable.DataSource = y.ToList();
            dataGridView7.DataSource = y.ToList();
        
        }


        //---------clear button----------

       

        private void button7_Click(object sender, EventArgs e)
        {
            nidTxt.Text = fstNameTxt.Text = lastNameTxt.Text = textBox2.Text = bloodTxt.Text = textBox3.Text = textBox8.Text = textBox9.Text =search1Txt.Text= string.Empty;
            UpdateTable1();
            UpdateTable8();
        
        
        }


        //----------search button-----------


        private void searchBtnTxt_Click_1(object sender, EventArgs e)
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            var z = from a in pd.taxrates
                    where a.catagory_code == searchTxt2.Text
                    select a;

            textBox4.Text = z.FirstOrDefault().tax_catagory;
            textBox5.Text = z.FirstOrDefault().catagory_code;
            textBox6.Text = z.FirstOrDefault().income_range;
            textBox7.Text = z.FirstOrDefault().tax_rate;

            taxRateTable.DataSource = z.ToList();
            dataGridView8.DataSource = z.ToList();
        }

        //----------------clear button----------------

        private void button11_Click(object sender, EventArgs e)
        {
            textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text =searchTxt2.Text= string.Empty;
            UpdateTable9();
            UpdateTable4();
        }


        //----------insert button-----------

        private void button5_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            taxholder th = new taxholder
            {
                nid = nidTxt.Text,
                firstname=fstNameTxt.Text,
                lastname=lastNameTxt.Text,
                gender = textBox2.Text,
                blood=bloodTxt.Text,
                catagor = textBox3.Text,
                status = textBox8.Text,
                code = textBox9.Text

            };

            pd.taxholders.InsertOnSubmit(th);
            pd.SubmitChanges();
            UpdateTable1();
            UpdateTable8();
            UpdateTable3();
            UpdateTable2();
            MessageBox.Show("New Record Added");
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            var z = from a in pd.taxholders
                    where a.nid==nidTxt.Text
                    select a;

                z.First().nid = nidTxt.Text;
                z.First().firstname = fstNameTxt.Text;
                z.First().lastname = lastNameTxt.Text;
                z.First().gender = textBox2.Text;
                z.First().blood = bloodTxt.Text;
                z.First().catagor = textBox3.Text;
                z.First().status = textBox8.Text;
                z.First().code = textBox9.Text;

                pd.SubmitChanges();

                allHolderstable.DataSource = z.ToList();
                dataGridView7.DataSource = z.ToList();
                MessageBox.Show("Updated");
        
        }


        //----------Delete button-----------

        private void button8_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            var z = from a in pd.taxholders
                    where a.nid == nidTxt.Text
                    select a;

            foreach (taxholder p in z)
            {
                pd.taxholders.DeleteOnSubmit(p);
            }

            pd.SubmitChanges();

            allHolderstable.DataSource = z.ToList();
            dataGridView7.DataSource = z.ToList();
            MessageBox.Show("Deleted");

        }

        //----------insert tax button-----------

        private void button9_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            taxrate tr = new taxrate
            {
                tax_catagory = textBox4.Text,
                catagory_code = textBox5.Text,
                income_range = textBox6.Text,
                tax_rate = textBox7.Text
               

            };

            pd.taxrates.InsertOnSubmit(tr);
            pd.SubmitChanges();
            UpdateTable4();
            UpdateTable9();
            MessageBox.Show("New Record Added");
        }


        //----------update button-----------

        private void button10_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            var i = from a in pd.taxrates
                    where a.catagory_code == textBox5.Text
                    select a;

                
                i.First().catagory_code = textBox5.Text;
                i.First().tax_catagory = textBox4.Text;
                i.First().income_range = textBox6.Text;
                i.First().tax_rate = textBox7.Text;
            
            pd.SubmitChanges();

            taxRateTable.DataSource = i.ToList();
            dataGridView8.DataSource = i.ToList();
            MessageBox.Show("Updated");
        }

        //----------delete button-----------


        private void button12_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            var i = from a in pd.taxrates
                    where a.catagory_code == textBox5.Text
                    select a;

            foreach (taxrate p in i)
            {
                pd.taxrates.DeleteOnSubmit(p);
            }

            pd.SubmitChanges();

            taxRateTable.DataSource = i.ToList();
            dataGridView8.DataSource = i.ToList();
             MessageBox.Show("Deleted");
        }

        //-----search design---------

        private void search1Txt_MouseClick(object sender, MouseEventArgs e)
        {
            search1Txt.Text = "";
        }

        private void search1Txt_MouseLeave(object sender, EventArgs e)
        {

        }

        private void searchTxt2_MouseClick(object sender, MouseEventArgs e)
        {
            searchTxt2.Text = "";
        }



        //--------------cellclick starts---------------------


        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dr = this.dataGridView7.Rows[e.RowIndex];

                nidTxt.Text = dr.Cells["nid"].Value.ToString();
                fstNameTxt.Text = dr.Cells["firstname"].Value.ToString();

                lastNameTxt.Text = dr.Cells["lastname"].Value.ToString();
                textBox2.Text = dr.Cells["gender"].Value.ToString();
                bloodTxt.Text = dr.Cells["blood"].Value.ToString();
                textBox3.Text = dr.Cells["catagor"].Value.ToString();
                textBox8.Text = dr.Cells["status"].Value.ToString();
                textBox9.Text = dr.Cells["code"].Value.ToString();
                
            }

        }

        private void allHolderstable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dr = this.allHolderstable.Rows[e.RowIndex];

                nidTxt.Text = dr.Cells["nid"].Value.ToString();
                fstNameTxt.Text = dr.Cells["firstname"].Value.ToString();

                lastNameTxt.Text = dr.Cells["lastname"].Value.ToString();
                textBox2.Text = dr.Cells["gender"].Value.ToString();
                bloodTxt.Text = dr.Cells["blood"].Value.ToString();
                textBox3.Text = dr.Cells["catagor"].Value.ToString();
                textBox8.Text = dr.Cells["status"].Value.ToString();
                textBox9.Text = dr.Cells["code"].Value.ToString();

            }

        }

        private void duePayersTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
             if (e.RowIndex >= 0)
             {
                 DataGridViewRow dr = this.duePayersTable.Rows[e.RowIndex];

                 nidTxt.Text = dr.Cells["nid"].Value.ToString();
                 fstNameTxt.Text = dr.Cells["firstname"].Value.ToString();

                 lastNameTxt.Text = dr.Cells["lastname"].Value.ToString();
                 textBox2.Text = dr.Cells["gender"].Value.ToString();
                 bloodTxt.Text = dr.Cells["blood"].Value.ToString();
                 textBox3.Text = dr.Cells["catagor"].Value.ToString();
                 textBox8.Text = dr.Cells["status"].Value.ToString();
                 textBox9.Text = dr.Cells["code"].Value.ToString();
             }
        }

        private void taxPayersTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dr = this.taxPayersTable.Rows[e.RowIndex];

                nidTxt.Text = dr.Cells["nid"].Value.ToString();
                fstNameTxt.Text = dr.Cells["firstname"].Value.ToString();

                lastNameTxt.Text = dr.Cells["lastname"].Value.ToString();
                textBox2.Text = dr.Cells["gender"].Value.ToString();
                bloodTxt.Text = dr.Cells["blood"].Value.ToString();
                textBox3.Text = dr.Cells["catagor"].Value.ToString();
                textBox8.Text = dr.Cells["status"].Value.ToString();
                textBox9.Text = dr.Cells["code"].Value.ToString();
            }

        }

        private void newRegisterTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dr = this.newRegisterTable.Rows[e.RowIndex];

                nidTxt.Text = dr.Cells["nid"].Value.ToString();
                fstNameTxt.Text = dr.Cells["firstname"].Value.ToString();

                lastNameTxt.Text = dr.Cells["lastname"].Value.ToString();
                textBox2.Text = dr.Cells["gender"].Value.ToString();
                bloodTxt.Text = dr.Cells["blood"].Value.ToString();
                textBox3.Text = dr.Cells["taxcatagory"].Value.ToString();
               
            }

        }

        private void taxRateTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
             if (e.RowIndex >= 0)
             {
                 DataGridViewRow dr = this.taxRateTable.Rows[e.RowIndex];

                 textBox5.Text = dr.Cells["catagory_code"].Value.ToString();
                 textBox4.Text = dr.Cells["tax_catagory"].Value.ToString();

                 textBox6.Text = dr.Cells["income_range"].Value.ToString();
                 textBox7.Text = dr.Cells["tax_rate"].Value.ToString();

             }
        }

        private void dataGridView8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataClasses1DataContext pd = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ANIK\Documents\incometax.mdf;Integrated Security=True;Connect Timeout=30");
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dr = this.dataGridView8.Rows[e.RowIndex];

                textBox5.Text = dr.Cells["catagory_code"].Value.ToString();
                textBox4.Text = dr.Cells["tax_catagory"].Value.ToString();

                textBox6.Text = dr.Cells["income_range"].Value.ToString();
                textBox7.Text = dr.Cells["tax_rate"].Value.ToString();

            }
        }



        //--------------cellclick ends---------------------

        //---------toolbar signout---------

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            Visible = false;
        }

        //---------toolbar exit--------

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
