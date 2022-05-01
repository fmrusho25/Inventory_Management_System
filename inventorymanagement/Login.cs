using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class Login : Form
    {
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;

        public Login()
        {
            InitializeComponent();
        }

        //database connection with the form
        private void Login_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\000inal\c#\C#priject\inventorymanagement\Database.mdf;Integrated Security=True");
            cn.Open();
        }

        //got to registration page
        private void Btnregister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registration = new Registration();
            registration.ShowDialog();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //if condition to check username and password both are matched or not
            if (txtpassword.Text != string.Empty || txtusername.Text != string.Empty)
            {
                //check the username and password combination is matched or not with the database
                cmd = new SqlCommand("select * from LoginTable where username='" + txtusername.Text + "' and password='"+txtpassword.Text+"'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    this.Hide();
                    Home home = new Home();
                    home.ShowDialog();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("Invalid username or password. Check again or You Can Register Now !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //exit from the application
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //show rhe password
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            txtpassword.UseSystemPasswordChar = false;
        }

        //hide the password
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            txtpassword.UseSystemPasswordChar = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
