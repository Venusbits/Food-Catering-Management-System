using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace FoodCateringManagementSystem
{
    public partial class Supdetails : Form
    {
        dbCodeclass db = new dbCodeclass();
        public Supdetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetmaxID();
        }
        void GetmaxID()
        {
            textBox1.Text = db.GetAutoID("Select MAX(ID) from Supdetail").ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Missing Fields");
                    return;
                }
                db.ExecuteSqlQuery("Insert into Supdetail(ID,Name,Contact,Email,Supproductstype)values(" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')");
                db.FillGridData(dataGridView1, "Select * from Supdetail");
                MessageBox.Show("Save Data Successfully");
                clear();

            }
            catch { }
        }
        void clear()
        {
            textBox1.Text = "Auto";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }

            db.ExecuteSqlQuery("Update Supdetail SET Name='" + textBox2.Text + "',contact='" + textBox3.Text + "',Email='" + textBox4.Text + "',Supproductstype='" + textBox5.Text + "' where ID=" + textBox1.Text);
            db.FillGridData(dataGridView1, "Select * from Supdetail");
            MessageBox.Show("Update Data successfully..");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Missing Fields");
            }
            if (MessageBox.Show(" Do you want to delete record", "delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.ExecuteSqlQuery("delete from custdetail where ID =" + textBox1.Text);
            }
            db.FillGridData(dataGridView1, "Select * from Supdetail");
            MessageBox.Show("deleted data successfully..");
        }

        private void Supdetails_Load(object sender, EventArgs e)
        {
            db.FillGridData(dataGridView1, "select * from Supdetail ");
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            GridDataDisplay();
        }
        void GridDataDisplay()
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells["contact"].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells["Email"].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells["Supproductstype"].Value.ToString();

            }
            catch { }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text == "")
                {
                    db.FillGridData(dataGridView1, "Select * from Supdetail");
                    return;
                }
                else if (comboBox1.SelectedIndex == 0)
                {
                    db.FillGridData(dataGridView1, "Select * from Supdetail where ID=" + textBox6.Text + "");
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    db.FillGridData(dataGridView1, "Select * from Supdetail where Name like'" + textBox6.Text + "%'");
                }
                else
                {
                    db.FillGridData(dataGridView1, "Select * from Supdetail where contact like '" + textBox6.Text + "%'");
                }


            }
            catch { }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == ' ' || char.IsLetter(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == ',' || char.IsDigit(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            Regex rg = new Regex(@"^[0-9]{10}$");
            if (textBox3.Text == "")
            {
                //textBox3.Focus();
            }
            else if (!rg.IsMatch(textBox3.Text))
            {
                MessageBox.Show("only 10 digit are allowed");
                //textBox3.Clear();
                //textBox3.Focus();
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            Regex rg = new Regex(@"^(([A-Za-z0-9.]+))@([A-Za-z0-9]+).\w{2,3}$");
            if (textBox5.Text == "")
            {
                textBox3.Focus();
            }
            else if (!rg.IsMatch(textBox3.Text))
            {
                MessageBox.Show("Not valid Email ID");
                textBox5.Clear();
                textBox5.Focus();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
