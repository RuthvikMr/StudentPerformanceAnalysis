using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using MySql.Data.MySqlClient;

namespace Student_Performance_Analysis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void groupBox1_Enter_1(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox2.Visible = true;
            groupBox1.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT* FROM registration WHERE username= @usr AND password= @pass", db.getConnection());
            command.Parameters.Add("@usr", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBox2.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0 && textBox1.Text != "admin" && textBox2.Text != "asas")
            {
                // MessageBox.Show("welcome ");

                this.Hide();
                Form2 f2 = new Form2(textBox1.Text);//passing value to form2
                f2.ShowDialog();
                this.Close();

            }
            else if (table.Rows.Count > 0 || textBox1.Text == "admin" && textBox2.Text == "asas")
            {
                this.Hide();
                Form3 f3 = new Form3(textBox1.Text);
                f3.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password \n Please Try Again");

                textBox1.Clear();
                textBox2.Clear();
            }

        }

    

    private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = true;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("INSERT INTO registration(username,Reg_no, email,class,semester, password,phone) VALUES (@user,@regno,@email,@class,@semester,@password,@phone)", db.getConnection());
            command.Parameters.Add("@user", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@regno", MySqlDbType.VarChar).Value = textBox5.Text;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBox4.Text;
            command.Parameters.Add("@class", MySqlDbType.VarChar).Value = comboBox1.Text;
            command.Parameters.Add("@semester", MySqlDbType.VarChar).Value = comboBox2.Text;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = textBox8.Text;
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = textBox7.Text;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Registration Successfull... Please Login Now");
            }
            else
            {
                MessageBox.Show("something went wrong");
            }


            db.closeConnection();

            textBox3.Clear();
            textBox4.Clear();
            textBox7.Clear();
            textBox8.Clear();


        }
    }
    }





    

