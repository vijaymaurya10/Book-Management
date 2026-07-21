using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class SearchBook : Form
    {
        string conString = "server=localhost;port=3306;database=Books;uid=root;pwd=vijay91@maurya;";
        public SearchBook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                string query = "SELECT * FROM books WHERE bookName = @bookname";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@bookname", textBox1.Text.Trim());

                con.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Book not found.");
                    dataGridView1.DataSource = null;
                }
            }
        }
    }
}
