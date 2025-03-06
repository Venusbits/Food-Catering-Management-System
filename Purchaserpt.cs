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
    public partial class Purchaserpt : Form
    {
        dbCodeclass db = new dbCodeclass();
        public Purchaserpt()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void Purchaserpt_Load(object sender, EventArgs e)
        {
            purchase1("select * from PurchaseBill", db.cn);
        }
        public void purchase1(string sql, SqlConnection cn)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            Database1DataSet ds = new Database1DataSet();
            da.Fill(ds, "PurchaseBill");
            Purchase rt = new Purchase();
            rt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rt;
        }
    }
}
