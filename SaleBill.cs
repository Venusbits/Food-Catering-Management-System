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
    public partial class SaleBill : Form
    {
        dbCodeclass db = new dbCodeclass();
        public SaleBill()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaleBill_Load(object sender, EventArgs e)
        {
            db.FillCombo(comboBox1, "Select * from MenuDetails", "DishName", "DishID");
            db.FillCombo(comboBox2, "Select * from custdetail", "Name", "ID");
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox6.Text = (double.Parse(textBox5.Text) * double.Parse(textBox4.Text)).ToString();
            }
            catch { }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label3.Text = comboBox2.SelectedValue.ToString();
                DataTable dt = db.GettableData("Select * from custdetail where ID=" + label3.Text);
                if (dt.Rows.Count >= 1)
                {
                    textBox2.Text = dt.Rows[0]["contact"].ToString();
                }
            }
            catch { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label15.Text = comboBox1.SelectedValue.ToString();
                DataTable dt = db.GettableData("Select * from MenuDetails where DishID=" + label15.Text);
                if (dt.Rows.Count >= 1)
                {
                    textBox4.Text = dt.Rows[0]["Price"].ToString();                    
                }
            }
            catch { }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetmaxID();
        }
        void GetmaxID()
        {
            textBox1.Text = db.GetAutoID("Select MAX(BillID) from SaleBill").ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Missing Fields");
                    return;
                }
                db.ExecuteSqlQuery("Insert into SaleBill(BillID,CustID,DishID,CustName,DishName,Quantity,Date,Contact,Price,Amount,Total_Amount)values(" + textBox1.Text + ",'" + label3.Text + "','" + label15.Text +"','"+comboBox2.Text.ToString()+"','"+comboBox1.Text.ToString()+"','"+textBox5.Text+"','"+dateTimePicker1.Value.ToString("MM/dd/yyyy")+"','"+textBox2.Text+"','"+textBox4.Text+"','"+textBox6.Text+"','"+textBox3.Text+"')");
                MessageBox.Show("Save Data Successfully");
                clear();

            }
            catch { }
        }
            void clear()
        {
            textBox1.Text = "Auto";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

            private void button4_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    listView1.Items.Add(label15.Text).SubItems.AddRange(new string[] {comboBox1.Text, textBox4.Text, textBox5.Text, textBox6.Text});
                }
                catch { }
                if (MessageBox.Show("Do you want to add another product?", "Add products", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    label15.Focus();
                }
                              
            }
            void disctotalamt()
            {
                double sum = 0;
                try
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        sum += double.Parse(listView1.Items[i].SubItems[4].Text);
                    }
                }
                catch { }
                textBox3.Text = sum.ToString();
            }

            private void listView1_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void button5_Click(object sender, EventArgs e)
            {
                disctotalamt();
            }
    }
}
