using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FoodCateringManagementSystem
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }

        private void mainform_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empl_Details ed = new Empl_Details();
            ed.Show();
            this.Close();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            custdetail cd = new custdetail();
            cd.Show();
            this.Close();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prodsupplied ps = new Prodsupplied();
            ps.Show();
            this.Close();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuDetails md = new MenuDetails();
            md.Show();
            this.Close();
        }

        private void saleBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleBill sb = new SaleBill();
            sb.Show();
            this.Close();
        }

        private void purchaseBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseBill pb = new PurchaseBill();
            pb.Show();
            this.Close();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void saleBillReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleReportForm srf = new SaleReportForm();
            srf.Show();
            this.Close();
        }

        private void purchseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchaserpt prt = new Purchaserpt();
            prt.Show();
            this.Close();
        }

        private void customerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerReportForm  crt = new CustomerReportForm();
            crt.Show();
            this.Close();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm l = new LoginForm();
            l.Show();
        }

        private void supplierReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupprptForm sf = new SupprptForm();
            sf.Show();
            this.Close();
        }

    }
}
