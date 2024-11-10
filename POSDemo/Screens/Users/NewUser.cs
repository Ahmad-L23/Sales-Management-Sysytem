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

namespace POSDemo.Screens.Users
{
    public partial class NewUser : Form
    {
        POSTutEntities db = new POSTutEntities();
        string imagepath = "";
        public NewUser()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User obj = new User
            {
                UserName = txtUser.Text,
                Password = txtPassword.Text,
                //Image = imagepath
             };
            db.Users.Add(obj);
            db.SaveChanges();
            if (imagepath != "")
            {
                string newPath = Environment.CurrentDirectory + "\\Images\\Users\\" + obj.Id + "jpg";
                File.Copy(imagepath, newPath);

                obj.Image = newPath;
                db.SaveChanges();
            }
            
            
            MessageBox.Show("تم الحفظ");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog()==DialogResult.OK)
            {
                imagepath = dialog.FileName;
               pictureBox1.ImageLocation= dialog.FileName;
            }
        }
    }
}
