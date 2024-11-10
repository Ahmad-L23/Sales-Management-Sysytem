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

namespace POSDemo.Screens.Customer
{
    public partial class CustomerMangement : Form
    {

        POSTutEntities db = new POSTutEntities();
        string imagepath = "";
        int id = 0;
        POSDemo.DB.Customer res;
        public CustomerMangement()
        {
            InitializeComponent();
            checkBox1.Checked = false;
            dataGridView1.DataSource = db.Customers.ToList();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFormParcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFormName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Customers.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtName.Text == "")
                dataGridView1.DataSource = db.Customers.Where(x => x.Phone.Contains(txtphone.Text)).ToList();
            else
                dataGridView1.DataSource = db.Customers.Where(x => x.Phone == txtphone.Text || x.Name.Contains(txtName.Text)).ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("اضافة عميل جديد", "هل انت متاكد من اضافة العميل كعميل جديد", MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes) {
                if (txtformname.Text == "" || txtformphone.Text == "")
                {
                    MessageBox.Show("الرجاء اكمال البيانات المطلوبة اولا");
                }

                else
                {
                    POSDemo.DB.Customer c = new POSDemo.DB.Customer();
                    c.Name = txtformname.Text;
                    c.Phone = txtformphone.Text;
                    c.Notes = txtnotes.Text;
                    c.Address = txtaddress.Text;
                    c.Company = txtcompany.Text;
                    c.Email = txtemail.Text;
                    c.IsActive = checkBox1.Checked;

                    db.Customers.Add(c);
                    db.SaveChanges();

                    MessageBox.Show("تم حفظ العميل");
                    if (imagepath != "")
                    {
                        string newPath = Environment.CurrentDirectory + "\\Images\\Customers\\" + c.Id + "jpg";
                        File.Copy(imagepath, newPath);

                        c.Image = newPath;
                        db.SaveChanges();
                    }
                    txtformname.Text = "";
                    txtformphone.Text = "";
                    txtnotes.Text = "";
                    txtaddress.Text = "";
                    txtcompany.Text = "";
                    txtemail.Text = "";
                    pictureBox1.ImageLocation = "";
                    checkBox1.Checked = false;
                    dataGridView1.DataSource = db.Customers.ToList();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            res.Name = txtformname.Text;
            res.Phone = txtformphone.Text;
            res.Address = txtaddress.Text;
            res.Company = txtcompany.Text;
            res.Email = txtemail.Text;
            res.Notes = txtnotes.Text;

            if (imagepath != "")
            {
                string newPath = Environment.CurrentDirectory + "\\Images\\Customers\\" + res.Id + "jpg";
                File.Copy(imagepath, newPath, true);

                res.Image = newPath;
            }

            db.SaveChanges();

            MessageBox.Show("تم حفظ التعديلات");

            dataGridView1.DataSource = db.Customers.ToList();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                res = db.Customers.SingleOrDefault(x => x.Id == id);

                txtformname.Text = res.Name;
                txtformphone.Text = res.Phone;
                txtaddress.Text = res.Address;
                txtcompany.Text = res.Company;
                txtemail.Text = res.Email;
                txtnotes.Text = res.Notes;
                if(res.IsActive==null)
                {
                    res.IsActive = false;
                }
                checkBox1.Checked = (bool)res.IsActive;
                pictureBox1.ImageLocation = res.Image;
            }

            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("هل نريد حذف", "تأكيد الحذف", MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                var res = db.Customers.Find(id);
                db.Customers.Remove(res);

                db.SaveChanges();

                MessageBox.Show("تم الحذف");

                dataGridView1.DataSource = db.Customers.ToList();
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
    }
}
