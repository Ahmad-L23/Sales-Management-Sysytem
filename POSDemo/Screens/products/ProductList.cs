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
    public partial class ProductList : Form
    {
        POSTutEntities db = new POSTutEntities();
        int id=0;
        POSDemo.DB.Proudct res;

        string imagepath="";
        public ProductList()
        {
            InitializeComponent();

           dataGridView1.DataSource = db.Proudcts.ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtName.Text=="")
                dataGridView1.DataSource = db.Proudcts.Where(x => x.Code == txtbarcode.Text).ToList();
            else
                dataGridView1.DataSource = db.Proudcts.Where(x => x.Code == txtbarcode.Text || x.Name.Contains(txtName.Text)).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Proudcts.ToList();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                res = db.Proudcts.SingleOrDefault(x => x.Id == id);

                txtFormParcode.Text = res.Code;
                txtFormName.Text = res.Name;
                txtPrice.Text = res.Price.ToString();
                txtQty.Text = res.Quantity.ToString();
                txtNotes.Text = res.Notes;
                pictureBox1.ImageLocation = res.Image;
            }

            catch { }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            res.Code = txtFormParcode.Text;
            res.Name = txtFormName.Text;
            res.Price = decimal.Parse(txtPrice.Text);
            res.Quantity = int.Parse(txtQty.Text);
            res.Notes = txtNotes.Text;

            if (imagepath != "")
            {
                string newPath = Environment.CurrentDirectory + "\\Images\\Products\\" + res.Id + "jpg";
                File.Copy(imagepath, newPath,true);

                res.Image = newPath;
            }

            db.SaveChanges();

            MessageBox.Show("تم حفظ التعديلات");
           
            dataGridView1.DataSource = db.Proudcts.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void button5_Click(object sender, EventArgs e)
        {
          var r = MessageBox.Show("هل نريد الحذف", "تأكيد الحذف", MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                var res = db.Proudcts.Find(id);
                db.Proudcts.Remove(res);

                db.SaveChanges();

                MessageBox.Show("تم الحذف");

                dataGridView1.DataSource = db.Proudcts.ToList();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Product frm = new Product();
            frm.Show();
        }
    }
}
