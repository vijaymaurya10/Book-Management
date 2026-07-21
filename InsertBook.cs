using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BookManagement
{
    public partial class Insert_Book : Form
    {
        string conString = "server=localhost;port=3306;database=Books;uid=root;pwd=vijay91@maurya;";
        public Insert_Book()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();

                string query = @"INSERT INTO books (BookCode,BookName,AuthorName,Category,Language,PublishYear,TotalPages,Price,Quantity,AvailableQty)
                
                VALUES
                (@Code,@Name,@Author,@Category,@Language,@Year,@Pages,@Price,@Qty,@Available)";


                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Code", txtBookCode.Text);
                cmd.Parameters.AddWithValue("@Name", txtBookName.Text);
                cmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
                cmd.Parameters.AddWithValue("@Language", txtLanguage.Text);
                cmd.Parameters.AddWithValue("@Year", txtYear.Text);
                cmd.Parameters.AddWithValue("@Pages", txtPages.Text);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@Qty", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@Available", txtAvailable.Text);


                cmd.ExecuteNonQuery();

                MessageBox.Show("Book Added Successfully");

                ClearData();
            }
        }
        private void ClearData()
        {
            txtBookCode.Clear();
            txtBookName.Clear();
            txtAuthor.Clear();
            txtCategory.Clear();
            txtLanguage.Clear();
            txtYear.Clear();
            txtPages.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtAvailable.Clear();

            txtBookCode.Focus();
        }
    }
}
