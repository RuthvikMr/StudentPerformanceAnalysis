using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Student_Performance_Analysis
{
    public partial class Form2 : Form
    {
        public Form2(string name)
        {
            InitializeComponent();
            label2.Text = name;
        }

        
        private void Form2_Load_1(object sender, EventArgs e)
        {
            tableLayoutPanel2.Visible = false;
            DB db = new DB();
            db.openConnection();

            string sqlquery = "SELECT * FROM registration where username='" + label2.Text + "'";
            string sqlquery2 = "select username,Reg_no,cryptography,mobileCommunication,cSharp,OOAD from registration where password='" + textBox6.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sqlquery, db.getConnection());

            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                label29.Text = (reader["id"].ToString());
                label28.Text = (reader["Reg_no"].ToString());
            }

            groupBox1.Visible = false;
            //result tab


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=login");
            db.openConnection();

            string sqlquery = "SELECT * FROM registration where password='" + textBox1.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sqlquery, db.getConnection());
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBox2.Text = (reader["username"].ToString());
                textBox4.Text = (reader["password"].ToString());
                textBox3.Text = (reader["phone"].ToString());
                textBox5.Text = (reader["email"].ToString());
                groupBox1.Visible = true;
            }
            else
            {
                MessageBox.Show("Wrong Password:");
                groupBox1.Visible = false;
            }
            db.closeConnection();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sum = 0;
            DB db = new DB();
            db.openConnection();
            string sqlquery = "SELECT username,Reg_no,class,semester,cryptography,cSharp,mobileCommunication,OOAD from registration where password='" + textBox6.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sqlquery, db.getConnection());
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                label26.Text = (reader["username"].ToString());
                label23.Text = (reader["Reg_no"].ToString());
                label22.Text = (reader["class"].ToString());
                label25.Text = (reader["semester"].ToString());
                label24.Text = (reader["cryptography"].ToString());
                label19.Text = (reader["cSharp"].ToString());
                label18.Text = (reader["mobileCommunication"].ToString());
                label21.Text = (reader["OOAD"].ToString());

            }
            else if (textBox6.Text == null)
            {
                MessageBox.Show("Enter Password");
            }

            db.closeConnection();
            sum = sum + Convert.ToInt32(label24.Text + label19.Text + label18.Text + label21.Text);
            if (sum < 140)
            {
                label20.Text = "F";
            }
            else if (sum >=141  || sum <= 200)
            {
                label20.Text = "P";
            }
            else if (sum >= 201 || sum <= 265)
            {
                label20.Text = "B";
            }
            else if (sum >= 266 || sum <= 300)
            {
                label20.Text = "B+";
            }
            else if (sum >= 301 || sum <= 375)
            {
                label20.Text = "A";
            }
            else if (sum >= 376)
            {
                label20.Text = "O";
            }
            tableLayoutPanel2.Visible = true;
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }
    }
}
