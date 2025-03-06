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
    public partial class EmplDesg : Form
    {
        dbCodeclass db = new dbCodeclass();
        public EmplDesg()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void EmplDesg_Load(object sender, EventArgs e)
        {
            db.FillGridData(dataGridView1, "select * from EmplDesg ");
            db.FillCombo(comboBox1, "Select * from EmplDetail", "EmplName", "EmplID");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetmaxID();
        }
        void GetmaxID()
        {
            textBox1.Text = db.GetAutoID("Select MAX(ID) from EmplDesg").ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Missing Fields");
                    return;
                }
                db.ExecuteSqlQuery("Insert into EmplDesg(ID,Name,Designation,Description,Doj)values(" + textBox1.Text + ",'" +comboBox1.Text.ToString()+ "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "')");
                db.FillGridData(dataGridView1, "Select * from EmplDesg");
                MessageBox.Show("Save Data Successfully");
                clear();

            }
            catch { }
        }
        void clear()
        {
            textBox1.Text = "Auto";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }

            db.ExecuteSqlQuery("Update EmplDesg SET Designation='" + textBox3.Text + "',Description='" + textBox4.Text + "' where ID=" + textBox1.Text);
            db.FillGridData(dataGridView1, "Select * from EmplDesg");
            MessageBox.Show("Update Data successfully..");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Missing Fields");
            }
            if (MessageBox.Show(" Do you want to delete record", "delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.ExecuteSqlQuery("delete from EmplDesg where ID =" + textBox1.Text);
            }
            db.FillGridData(dataGridView1, "Select * from EmplDesg");
            MessageBox.Show("deleted data successfully..");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells["Designation"].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells["Description"].Value.ToString();
                dateTimePicker1.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells["DOJ"].Value.ToString());
                
            }
            catch { }
         }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = comboBox1.SelectedValue.ToString();
                DataTable dt = db.GettableData("Select * from EmplDesg where ID=" + textBox1.Text);
            }
            catch { }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "")
                {
                    db.FillGridData(dataGridView1, "Select * from EmplDesg");
                    return;
                }
                else if (comboBox2.SelectedIndex == 0)
                {
                    db.FillGridData(dataGridView1, "Select * from EmplDesg where ID=" + textBox2.Text + "");
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    db.FillGridData(dataGridView1, "Select * from EmplDesg where Name like'" + textBox2.Text + "%'");
                }
                else 
                {
                    db.FillGridData(dataGridView1, "Select * from EmplDesg where Designation like '" + textBox2.Text + "%'");
                }
                

            }
            catch { }
        }

       
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == ' ' || char.IsLetter(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
