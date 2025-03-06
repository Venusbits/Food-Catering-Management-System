using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
namespace FoodCateringManagementSystem
{
    public partial class SupprptForm : Form
    {
        dbCodeclass db = new dbCodeclass();
        public SupprptForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            supplier1("Select * from Supdetail", db.cn);
        }
        public void supplier1(string sql, SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from Supdetail where ID=" + textBox1.Text, con);
            Database1DataSet ds = new Database1DataSet();
            da1.Fill(ds, "Supdetail");
            SuppReport cr = new SuppReport();
            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
        }
    }
}
