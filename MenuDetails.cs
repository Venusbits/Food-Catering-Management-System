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
    public partial class MenuDetails : Form
    {
        dbCodeclass db = new dbCodeclass();
        public MenuDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetmaxID();
        }
        void GetmaxID()
        {
            textBox1.Text = db.GetAutoID("Select MAX(DishID) from MenuDetails").ToString();
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
                db.ExecuteSqlQuery("Insert into MenuDetails(DishID,DishName,Price)values(" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "')");
                db.FillGridData(dataGridView1, "Select * from MenuDetails");
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
           if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }

           db.ExecuteSqlQuery("Update MenuDetails SET DishName='" + textBox2.Text + "',Price='" + textBox3.Text + "' where DishID=" + textBox1.Text);
           db.FillGridData(dataGridView1, "Select * from MenuDetails");
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
                db.ExecuteSqlQuery("delete from MenuDetails where DishID =" + textBox1.Text);
            }
            db.FillGridData(dataGridView1, "Select * from MenuDetails");
            MessageBox.Show("deleted data successfully..");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text == "")
                {
                    db.FillGridData(dataGridView1, "Select * from MenuDetails");
                    return;
                }
                else if (comboBox1.SelectedIndex == 0)
                {
                    db.FillGridData(dataGridView1, "Select * from MenuDetails where DishID=" + textBox4.Text + "");
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    db.FillGridData(dataGridView1, "Select * from MenuDetails where DishName like'" + textBox4.Text + "%'");
                }
                else
                {
                    db.FillGridData(dataGridView1, "Select * from MenuDetails where price like '" + textBox4.Text + "%'");
                }


            }
            catch { }
        }

        private void MenuDetails_Load(object sender, EventArgs e)
        {
            db.FillGridData(dataGridView1, "select * from MenuDetails ");
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            GridDataDisplay();
        }
        void GridDataDisplay()
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells["DishID"].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells["DishName"].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells["Price"].Value.ToString();
                
            }
            catch { }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        decimal light = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (light == 0)
            {
                light = 1;
                pictureBox2.ImageLocation = "D:\\Ashwini\\FoodCateringManagementSystem\\FoodCateringManagementSystem\\images\\9.jpg";
                label6.Text = "Marathi Thali";
            }
            else if (light == 1)
            {
                light = 2;
                pictureBox2.ImageLocation = "D:\\Ashwini\\FoodCateringManagementSystem\\FoodCateringManagementSystem\\images\\10.jpg"; ;
                label6.Text = "Rajasthani Thali";
            }
            else if (light == 2)
            {
                light = 3;
                pictureBox2.ImageLocation = "D:\\Ashwini\\FoodCateringManagementSystem\\FoodCateringManagementSystem\\images\\11.jpeg"; ;
                label6.Text = "Punjabi Thali";
            }
            else if (light == 3)
            {
                light = 0;
                pictureBox2.ImageLocation = "D:\\Ashwini\\FoodCateringManagementSystem\\FoodCateringManagementSystem\\images\\8.jpg";
                label6.Text = "Gujrathi Thali";
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
