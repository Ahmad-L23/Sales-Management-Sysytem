using POSDemo.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSDemo.Screens.products
{
    public partial class Product : Form
    {
        POSTutEntities db = new POSTutEntities();
        string imagepath = "";
        public Product()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtParcode.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("الرجاء اكمال البيانات المطلوبة اولا");
            }
            else
            {
                POSDemo.DB.Proudct P = new POSDemo.DB.Proudct();
                P.Name = txtName.Text;
                P.Code = txtParcode.Text;
                P.Notes = txtNotes.Text;

                int qty, price;

                int.TryParse(txtQty.Text,out qty);
                int.TryParse(txtPrice.Text,out price);

                P.Quantity = qty;
                P.Price = price;

                db.Proudcts.Add(P);
                db.SaveChanges();

                MessageBox.Show("تم حفظ المنتج");
                if (imagepath != "")
                {
                    string newPath = Environment.CurrentDirectory + "\\Images\\Products\\" + P.Id + "jpg";
                    File.Copy(imagepath, newPath);

                    P.Image = newPath;
                    db.SaveChanges();
                }
                txtName.Text = "";
                txtParcode.Text = "";
                txtPrice.Text = "";
                txtNotes.Text = "";
                txtQty.Text = "";
                pictureBox1.ImageLocation = "";
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagepath = dialog.FileName;
                pictureBox1.ImageLocation = dialog.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductList frm = new ProductList();
            frm.Show();
        }
    }
}
