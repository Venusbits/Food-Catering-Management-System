﻿using System;
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
    public partial class CustomerReportForm : Form
    {
        dbCodeclass db = new dbCodeclass();
        public CustomerReportForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customer1("Select * from custdetail", db.cn);
        }
        public void customer1(string sql, SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from custdetail where ID=" + textBox1.Text, con);
            Database1DataSet ds = new Database1DataSet();
            da1.Fill(ds, "custdetail");
            Custreport  cr = new Custreport();
            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
        }
    }
}
