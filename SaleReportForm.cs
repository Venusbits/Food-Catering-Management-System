using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FoodCateringManagementSystem
{
    public partial class SaleReportForm : Form
    {
        dbCodeclass db = new dbCodeclass();
        public SaleReportForm()
        {
            InitializeComponent();
        }

        private void SaleReportForm_Load(object sender, EventArgs e)
        {
            sale1("select * from SaleBill", db.cn);
        }
        public void sale1(string sql, SqlConnection cn)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            Database1DataSet ds = new Database1DataSet();
            da.Fill(ds, "SaleBill");
            Salereport  st = new Salereport();
            st.SetDataSource(ds);
            crystalReportViewer1.ReportSource = st;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
