using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace Led
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\DB\AppDB.mdf;Integrated Security=True;Connect Timeout=30"); //schimba location cu path-ul bazei tale de date create. LoginTable e tabel cu id, username, password
            string query = "Select * from LoginTable where username = '" + textBox1.Text.Trim() + "' and password = '" + textBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl); 
            if(dtbl.Rows.Count == 1)
            {
                Form1 frm1 = new Form1();
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
