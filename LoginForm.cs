using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FoodCateringManagementSystem
{
    public partial class LoginForm : Form
    {
        dbCodeclass db;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            db = new dbCodeclass();
            db.FillCombo(comboBox1, "Select * from LoginTable", "UserName", "UserType");
            //cledata();
            //cmbusername.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter password!....");
                textBox1.Focus();
                return;
            }
            DataTable dt = db.GettableData("Select * from LoginTable where UserName='" + comboBox1.Text + "' AND Password='" + textBox1.Text + "'");
            if (dt.Rows.Count >= 1)
            {
                if (dt.Rows[0]["UserType"].ToString().Equals("admin"))
                {
                    MessageBox.Show("Login Successfull");
                    mainform frm = new mainform();
                    frm.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Please enter valid Username and Password");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        }
}
