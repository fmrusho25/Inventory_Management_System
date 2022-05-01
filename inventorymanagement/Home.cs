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
    public partial class Home : Form
    {
        //stablish connection with the database and application and create an object named 'con'
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\000inal\c#\C#priject\inventorymanagement\Database.mdf;Integrated Security=True");
        //initiallize sql commands using 'cmd'
        SqlCommand cmd;
        SqlDataAdapter adapt;
        //ID variable used in Updating and Deleting Record  
        int ID = 0;
        
        public Home()
        {
            InitializeComponent();
            //call the display data function to diasplay
            DisplayData();
        }

        //for exit from the application
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //for logout or going to loging page
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Pname.Text != "" && Cetagory.Text != "" && Instock.Text != "" && Price.Text != "" && Sellprice.Text != "" && Note.Text != "")
            {
                cmd = new SqlCommand("insert into product(Pname,Cetagory,Instock,Price, Sellprice, Note) values(@pname,@cetagory,@instock,@price,@sellprice,@note)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@pname", Pname.Text);
                cmd.Parameters.AddWithValue("@cetagory", Cetagory.Text);
                cmd.Parameters.AddWithValue("@instock", Instock.Text);
                cmd.Parameters.AddWithValue("@price", Price.Text);
                cmd.Parameters.AddWithValue("@sellprice", Sellprice.Text);
                cmd.Parameters.AddWithValue("@note", Note.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Product Inserted Successfully");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from product", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt; //call data or show all data from table
            con.Close();
        }

        //Clear Data  
        private void ClearData()
        {
            Pname.Text = "";
            Cetagory.Text = "";
            Instock.Text = "";
            Price.Text = "";
            Sellprice.Text = "";
            Note.Text = "";
            ID = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            Pname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Cetagory.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Instock.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            Price.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            Sellprice.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            Note.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Pname.Text != "" && Cetagory.Text != "" && Instock.Text != "" && Price.Text != "" && Sellprice.Text != "" && Note.Text != "")
            {
                cmd = new SqlCommand("update product set Pname=@pname,Cetagory=@cetagory,Instock=@instock,Price=@price,Sellprice=@sellprice,Note=@note where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@pname", Pname.Text);
                cmd.Parameters.AddWithValue("@cetagory", Cetagory.Text);
                cmd.Parameters.AddWithValue("@instock", Instock.Text);
                cmd.Parameters.AddWithValue("@price", Price.Text);
                cmd.Parameters.AddWithValue("@sellprice", Sellprice.Text);
                cmd.Parameters.AddWithValue("@note", Note.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Updated Successfully");
                con.Close();
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Product to Update.  Double click on the product elements for select.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new SqlCommand("delete product where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Product Deleted Successfully!");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select product to Delete .  Double click on the product elements for select.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            About ab = new About();
            ab.ShowDialog();
        }


        //search product
        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\000inal\c#\C#priject\inventorymanagement\Database.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from product where Pname  = @pname", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@pname",Pname.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ClearData();
            dataGridView1.DataSource = dt;
            //string valueToSearch= Pname.Text.ToString();
            // searchData(valueToSearch);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\000inal\c#\C#priject\inventorymanagement\Database.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from product", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        // public void searchData(string valueToSearch)
        //  {
        //   cmd = new SqlCommand("Select * from product where Pname= '%" + Pname.Text + "'", con);
        //  adapt = new SqlDataAdapter(cmd);
        //con.Open();
        //cmd.Parameters.AddWithValue("@id", ID);
        //cmd.Parameters.AddWithValue("@pname", Pname.Text);
        //cmd.Parameters.AddWithValue("@cetagory", Cetagory.Text);
        //cmd.Parameters.AddWithValue("@instock", Instock.Text);
        //cmd.Parameters.AddWithValue("@price", Price.Text);
        //cmd.Parameters.AddWithValue("@sellprice", Sellprice.Text);
        //cmd.Parameters.AddWithValue("@note", Note.Text);
        //cmd.ExecuteNonQuery();
        //  MessageBox.Show("Product Found");
        //   DataTable dt = new DataTable();
        //   adapt.Fill(dt);
        //  dataGridView1.ClearSelection();
        //   //  dataGridView1.DataSource = dt;
        // }
    }
}
