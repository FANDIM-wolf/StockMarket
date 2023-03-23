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

namespace StockMarket
{
    public partial class FormCustomer : Form
    {   
        
        public FormCustomer()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertQuery();
        }

        private void InsertQuery()
        {
            string query = "INSERT INTO `test` VALUES (NULL , @Name);";

            string MySQLConnectionString = "DATA ABOUT CONNECTION";

            MySqlConnection DataBaseConnection = new MySqlConnection(MySQLConnectionString);

            MySqlCommand commandDataBase = new MySqlCommand(query, DataBaseConnection);

            commandDataBase.CommandTimeout = 60;

            commandDataBase.CommandType = CommandType.Text;
            commandDataBase.Parameters.Add("@Name", MySqlDbType.VarChar).Value = textBox1.Text;

            try
            {

                DataBaseConnection.Open();
                //commandDataBase.CommandTimeout = 60;
                MySqlDataReader myReader = commandDataBase.ExecuteReader();
                DataBaseConnection.Close();

                MessageBox.Show("Query successfully executed");

            }
            catch (Exception e)
            {
                MessageBox.Show("Query error: " + e.Message);
            }

        }

        
    }
}
