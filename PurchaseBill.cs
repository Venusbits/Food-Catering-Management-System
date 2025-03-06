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
    public partial class PurchaseBill : Form
    {
        dbCodeclass db = new dbCodeclass();
        public PurchaseBill()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void PurchaseBill_Load(object sender, EventArgs e)
        {
            db.FillCombo(comboBox1, "Select * from Supdetail", "Name", "ID");
            db.FillCombo(comboBox2, "Select * from Prodsupplied", "ProdName", "ProdID");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label10.Text = comboBox1.SelectedValue.ToString();
                DataTable dt = db.GettableData("Select * from Supdetail where ID=" + label10.Text);
                if (dt.Rows.Count >= 1)
                {
                    textBox2.Text = dt.Rows[0]["Contact"].ToString();
                }
            }
            catch { }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label14.Text = comboBox2.SelectedValue.ToString();
                DataTable dt = db.GettableData("Select * from Prodsupplied where ProdID=" + label14.Text);
                if (dt.Rows.Count >= 1)
                {
                    textBox6.Text = dt.Rows[0]["Prodtype"].ToString();
                    textBox3.Text = dt.Rows[0]["Amount"].ToString();
                }
            }
            catch { }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetmaxID();
        }
        void GetmaxID()
        {
            textBox1.Text = db.GetAutoID("Select MAX(PID) from PurchaseBill").ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Missing Fields");
                    return;
                }
                db.ExecuteSqlQuery("Insert into PurchaseBill(PID,SupID,ProdID,Amount,SupName,Supproduct,Quantity,Date,Contact,ProdType,Total,Total_Amount)values(" + textBox1.Text + ",'" + label10.Text + "','" + label14.Text + "','"+textBox3.Text+"','"+comboBox1.Text.ToString()+"','"+comboBox2.Text.ToString()+"','"+textBox4.Text+"','"+dateTimePicker1.Value.ToString("MM/dd/yyyy")+"','"+textBox2.Text+"','"+textBox6.Text+"','"+textBox5.Text+"','"+textBox7.Text+"')");
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
            textBox6.Text = "";
        }

            private void button7_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void textBox4_TextChanged(object sender, EventArgs e)
            {
                try
                {
                    textBox5.Text = (double.Parse(textBox4.Text) * double.Parse(textBox3.Text)).ToString();
                }
                catch { }
            }

            private void button1_Click(object sender, EventArgs e)
            {

                try
                {
                    listView1.Items.Add(label14.Text).SubItems.AddRange(new string[] { comboBox2.Text, textBox6.Text, textBox3.Text, textBox4.Text, textBox5.Text });
                }
                catch { }
                if (MessageBox.Show("Do you want to add another product?", "Add products", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    label14.Focus();
                }

            }
            void disctotalamt()
            {
                double sum = 0;
                try
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        sum += double.Parse(listView1.Items[i].SubItems[5].Text);
                    }
                }
                catch { }
                textBox7.Text = sum.ToString();
            }

            private void button3_Click(object sender, EventArgs e)
            {
                disctotalamt();
            }

      }
    }

