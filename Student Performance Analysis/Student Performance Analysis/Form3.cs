using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Performance_Analysis
{
    public partial class Form3 : Form
    {
        MySqlDataAdapter adapter;
        DataSet ds;
        MySqlCommandBuilder cmdb;
        MySqlConnection con = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=login");
        public Form3(string name)
        {
            InitializeComponent();
            label2.Text = name;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)//fetch the records
        {
            try
            {
                DB db = new DB();
                // DataTable table = new DataTable();


                if (comboBox1.Text == "INT MCA" || comboBox1.Text == "BCA")
                {

                    db.openConnection();
                    adapter = new MySqlDataAdapter("select  id,username,Reg_no,cryptography,mobileCommunication,cSharp,OOAD from registration where class='" + comboBox1.Text + "'", con);

                    
                    ds = new System.Data.DataSet();
                    adapter.Fill(ds, "registration");
                    dataGridView1.DataSource = ds.Tables[0];
                    
                }

                else if (comboBox1.Text == "B.Com" || comboBox1.Text == "M.Com")
                {

                    adapter = new MySqlDataAdapter("select  id,username,Reg_no,accounts,businessStudies,incomeTax,statistics from registration where class='" + comboBox1.Text + "'", con);
                    ds = new System.Data.DataSet();
                    adapter.Fill(ds, "registration");
                    dataGridView1.DataSource = ds.Tables[0];
                
                }
                else
                {
                    MessageBox.Show("Comming soon...\n Work in Progress...");
                }

                db.closeConnection();
                dataGridView1.Visible = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            dataGridView2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)//update record
        {
            try
            {

                cmdb = new MySqlCommandBuilder(adapter);
                adapter.UpdateCommand = cmdb.GetUpdateCommand();
                adapter.Update(ds, "registration");
                MessageBox.Show("Marks Updated");

                button3.Visible = true;

                button4.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)//view record
        {
            DB db = new DB();
            if (comboBox1.Text == "INT MCA" || comboBox1.Text == "BCA")
            {

                db.openConnection();
                adapter = new MySqlDataAdapter("select  id,username,Reg_no,cryptography,mobileCommunication,cSharp,OOAD from registration where class='" + comboBox1.Text + "'", con);
                ds = new System.Data.DataSet();
                adapter.Fill(ds, "registration");
                dataGridView2.DataSource = ds.Tables[0];

                cmdb = new MySqlCommandBuilder(adapter);//updating in view
                adapter.UpdateCommand = cmdb.GetUpdateCommand();
                adapter.Update(ds, "registration");
            }

            else if (comboBox1.Text == "B.Com" || comboBox1.Text == "M.Com")
            {

                adapter = new MySqlDataAdapter("select  id,username,Reg_no,accounts,businessStudies,incomeTax,statistics from registration where class='" + comboBox1.Text + "'", con);
                ds = new System.Data.DataSet();
                adapter.Fill(ds, "registration");
                dataGridView2.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Comming soon...\n Work in Progress...");
            }

            db.closeConnection();
            dataGridView2.Visible = true;
            dataGridView1.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)//edit record
        {
            dataGridView2.Visible = false;
            dataGridView1.Visible = true;
            cmdb = new MySqlCommandBuilder(adapter);
            adapter.UpdateCommand = cmdb.GetUpdateCommand();
            adapter.Update(ds, "registration");
        }
    }
}

