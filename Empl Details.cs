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
    public partial class Empl_Details : Form
    {
        dbCodeclass db = new dbCodeclass();
        public Empl_Details()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetmaxID();
        }
       
        void GetmaxID()
        {
            textBox1.Text = db.GetAutoID("Select MAX(ID) from EmplDetail").ToString();
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
                db.ExecuteSqlQuery("Insert into EmplDetail(ID,EName,EQualification,Address,Email,Contact,DOJ,Designation)values(" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"','"+dateTimePicker1.Value.ToString("MM/dd/yyyy")+"','"+textBox8.Text+"')");
                db.FillGridData(dataGridView1, "Select * from EmplDetail");
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
            textBox8.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }

            db.ExecuteSqlQuery("Update EmplDetail SET EName='" + textBox2.Text + "',EQualification='" + textBox3.Text + "',Address='" + textBox4.Text + "',Email='"+ textBox5.Text +"',Contact="+textBox6.Text +",DOJ='"+dateTimePicker1.Value.ToString()+"',Designation='"+textBox8.Text+"'where ID=" + textBox1.Text);
            db.FillGridData(dataGridView1, "Select * from EmplDetail");
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
                db.ExecuteSqlQuery("delete from EmplDetail where ID =" + textBox1.Text);
            }
            db.FillGridData(dataGridView1, "Select * from EmplDetail");
            MessageBox.Show("deleted data successfully..");
        }
        

        private void Empl_Details_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void Empl_Details_Load(object sender, EventArgs e)
        {
            db.FillGridData(dataGridView1, "select * from EmplDetail ");

        }

        

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox7.Text == "")
                {
                    db.FillGridData(dataGridView1, "Select * from EmplDetail");
                    return;
                }
                else if (comboBox1.SelectedIndex == 0)
                {
                    db.FillGridData(dataGridView1, "Select * from EmplDetail where ID=" + textBox7.Text + "");
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    db.FillGridData(dataGridView1, "Select * from EmplDetail where EName like'" + textBox7.Text+"%'");
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    db.FillGridData(dataGridView1, "Select * from EmplDetail where EQualification like '" + textBox7.Text +"%'");
                }
                else 
                {
                    db.FillGridData(dataGridView1, "Select * from EmplDetail where Contact like'" + textBox7.Text + "%'");
                }
                
            }
            catch { }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == ' ' || char.IsLetter(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == ',' || char.IsDigit(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
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

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
           /* Regex rg = new Regex(@"^(([A-Za-z0-9.]+))@([A-Za-z0-9]+).\w{2,3}$");
            if (textBox5.Text == "")
            {
                textBox3.Focus();
            }
            else if (!rg.IsMatch(textBox3.Text))
            {
                MessageBox.Show("Not valid Email ID");
                textBox5.Clear();
                textBox5.Focus();
            }*/
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
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
                textBox2.Text = dataGridView1.SelectedRows[0].Cells["EName"].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells["EQualification"].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells["Address"].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells["Email"].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells["Contact"].Value.ToString();
                dateTimePicker1.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells["DOJ"].Value.ToString());
                textBox8.Text = dataGridView1.SelectedRows[0].Cells["Designation"].Value.ToString();
            }
            catch
            { }
        }
   }
}
