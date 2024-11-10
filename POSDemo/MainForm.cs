using POSDemo.Screens.Customer;
using POSDemo.Screens.products;
using POSDemo.Screens.Suppliers;
using POSDemo.Screens.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void editProdutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.Show();
        }

        private void editProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUser frm = new NewUser();
            frm.Show();
        }

        private void listProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductList frm = new ProductList();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductList frm = new ProductList();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CustomerMangement s = new CustomerMangement();
            s.Show();
        }

        private void اعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerMangement c = new CustomerMangement();
            c.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Suppliers s = new Suppliers();
            s.Show();
        }

        private void الموردينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Suppliers s = new Suppliers();
            s.Show();
        }

        private void تسجيلدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }
    }
}
