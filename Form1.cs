using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1.Connect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection=new SqlConnection("Data Source=DESKTOP-T3K84PN;Initial Catalog=EMPLOYEES_2;Integrated Security=True;TrustServerCertificate=True");
        SqlCommand command = new SqlCommand();
        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query = "INSERT INTO USERS VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "')";
            command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Entry ADDED SUCCESSFULLY");
            displayData();
            
        }
        public void displayData()
        {
            connection.Open();
            string query = "SELECT *FROM USERS ";
            command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();

        }
    }
}
