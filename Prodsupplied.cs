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
    public partial class Prodsupplied : Form
    {
        dbCodeclass db = new dbCodeclass();
        public Prodsupplied()
        {
            InitializeComponent();
        }

        private void Prodsupplied_Load(object sender, EventArgs e)
        {
            db.FillGridData(dataGridView1, "select * from Prodsupplied ");
            db.FillCombo(comboBox1,"select * from Supdetail","Supproductstype","ID");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetmaxID();
        }
        void GetmaxID()
        {
            textBox1.Text = db.GetAutoID("Select MAX(ProdID) from Prodsupplied").ToString();
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
                db.ExecuteSqlQuery("Insert into Prodsupplied(ProdID,ProdName,Amount,ProdType)values(" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text.ToString() + "','" + textBox4.Text + "','" + textBox2.Text + "','");
                db.FillGridData(dataGridView1, "Select * from Prodsupplied");
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
            comboBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }

            db.ExecuteSqlQuery("Update Prodsupplied SET ProdName='" + textBox2.Text + "',Amount='" + textBox3.Text + "',ProdType='" + comboBox1.Text.ToString() + "' where ProdID=" + textBox1.Text);
            db.FillGridData(dataGridView1, "Select * from Prodsupplied");
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
                db.ExecuteSqlQuery("delete from Prodsupplied where ProdID =" + textBox1.Text);
            }
            db.FillGridData(dataGridView1, "Select * from Prodsupplied");
            MessageBox.Show("deleted data successfully..");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text == "")
                {
                    db.FillGridData(dataGridView1, "Select * from Prodsupplied");
                    return;
                }
                else if (comboBox2.SelectedIndex == 0)
                {
                    db.FillGridData(dataGridView1, "Select * from Prodsupplied where ProdID=" + textBox4.Text + "");
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    db.FillGridData(dataGridView1, "Select * from Prodsupplied where ProdName like'" + textBox4.Text + "%'");
                }
                else
                {
                    db.FillGridData(dataGridView1, "Select * from Prodsupplied where ProdType like '" + textBox4.Text + "%'");
                }


            }
            catch { }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            GridDataDisplay();
        }
        void GridDataDisplay()
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells["ProdID"].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells["ProdName"].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells["Amount"].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells["ProdType"].Value.ToString();
            }
            catch { }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
