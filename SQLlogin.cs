using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Logindeneme
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            con = new SqlConnection("Data Source=DESKTOP-LS2R1V2;Initial Catalog=Ornek;Integrated Security=True");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select*From Kullanici_Bilgi where kullanici_adi='" + textBox1.Text +
                "'And sifre='" + textBox2.Text + "'";

            dr = com.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş başarılı!");
                Form2 gecis = new Form2();
                gecis.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("yanlış kullanıcı adi veya şifre!","Login");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           Close();
        }
    }
}
