using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ootd
{
    public partial class Form3 : Form
    {
        // Koneksi Database
        OleDbConnection koneksi = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\HP\Documents\pelanggan.accdb;Persist Security Info=True");

        void ShowData()
        {
            // Buka Database
            koneksi.Open();
            string query = "select * from barang";
            OleDbDataAdapter da = new OleDbDataAdapter(query, koneksi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();

        }
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true })
                {
                    ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            koneksi.Open();
            string perintah = "insert into pelanggan (ID, Nama, Gender, Email, PhoneNumber) values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')";
            OleDbCommand cmd = new OleDbCommand(perintah, koneksi);
            //eksekusi perintah
            cmd.ExecuteNonQuery();
            //
            koneksi.Close();
            MessageBox.Show("Data Ditambahkan");
            ShowData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "Update pelanggan set Gender = '" + textBox3.Text + "', Email = '" + textBox4.Text + "', PhoneNumber = '" + textBox5.Text + "' Where Nama = '" + textBox2.Text + "'";
            OleDbCommand cmd = new OleDbCommand(perintah, koneksi);
            //eksekusi perintah
            cmd.ExecuteNonQuery();
            //
            koneksi.Close();
            MessageBox.Show("Data Telah Diubah");
            ShowData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "Delete from pelanggan where ID=" + textBox1.Text;
            OleDbCommand cmd = new OleDbCommand(perintah, koneksi);
            //eksekusi perintah
            cmd.ExecuteNonQuery();
            //
            koneksi.Close();
            MessageBox.Show("Data Telah Dihapus");
            ShowData();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string printah = "SELECT * FROM pelanggan WHERE Nama='" + textBox1.Text + "'";
            OleDbDataAdapter da = new OleDbDataAdapter(printah, koneksi);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }
    }
}
