using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        //exit from the application
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //got to previous (inventory page)
        private void button1_Click(object sender, EventArgs e)
        {
            //hide current form
            this.Hide();
            //create object for calling the Home page using bc
            Home bc = new Home();
            //show Home form 
            bc.ShowDialog();
        }

        //Developer information show using extra panel and different form
        private void button3_Click(object sender, EventArgs e)
        {
            //clear the panel1 first
            panel1.Controls.Clear();
            //call Rusho form to the panel1
            Rusho rusho = new Rusho()
            {
                TopLevel = false, TopMost = true
            };
            rusho.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(rusho);
            rusho.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //clear the panel1 first
            panel1.Controls.Clear();
            //call Mahin form to the panel1
            Mahin mahin = new Mahin()
            {
                TopLevel = false,
                TopMost = true
            };
            mahin.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(mahin);
            mahin.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //clear the panel1 first
            panel1.Controls.Clear();
            //panel1.Refresh();
            //call Rudra form to the panel1
            Rudro rudro = new Rudro()
            {
                TopLevel = false,
                TopMost = true
            };
            rudro.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(rudro);
            rudro.Show();
        }
    }
}
