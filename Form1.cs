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
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            Display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //runQuery();
        }

        private void Display()
        {
            DisplayAndSearch("SELECT `id` , `name` FROM `test`; ",dataGridView1);
        }

        

        private void runQuery()
        {
            string query = "INSERT INTO `test` (`id`, `name`) VALUES (NULL , 'Mikis');";

            string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=basayd";

            MySqlConnection DataBaseConnection = new MySqlConnection(MySQLConnectionString);

            MySqlCommand commandDataBase = new MySqlCommand(query, DataBaseConnection);
            
            commandDataBase.CommandTimeout = 60;
           
            try
            {

                DataBaseConnection.Open();
                //commandDataBase.CommandTimeout = 60;
                MySqlDataReader myReader = commandDataBase.ExecuteReader();
                DataBaseConnection.Close();

                MessageBox.Show("Query successfully executed");

            }catch(Exception e)
            {
                MessageBox.Show("Query error: " + e.Message);
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormCustomer form = new FormCustomer();
            form.ShowDialog();
        }


        private void UpdateQuery(string id)
        {
            string query = "UPDATE `tests` SET name=@Name  WHERE `id` = @id ;";

            string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=basayd";

            MySqlConnection DataBaseConnection = new MySqlConnection(MySQLConnectionString);

            MySqlCommand commandDataBase = new MySqlCommand(query, DataBaseConnection);

            commandDataBase.CommandTimeout = 60;

            commandDataBase.CommandType = CommandType.Text;
            commandDataBase.Parameters.Add("@Name", MySqlDbType.VarChar).Value = textBox1.Text;
            commandDataBase.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
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

        private void DeleteQuery(string id)
        {
            string query = "DELETE FROM `test` WHERE `id` = @id ;";

            string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=basayd";

            MySqlConnection DataBaseConnection = new MySqlConnection(MySQLConnectionString);

            MySqlCommand commandDataBase = new MySqlCommand(query, DataBaseConnection);

            commandDataBase.CommandTimeout = 60;

            commandDataBase.CommandType = CommandType.Text;
            commandDataBase.Parameters.Add("@Name", MySqlDbType.VarChar).Value = textBox1.Text;
            commandDataBase.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
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

        public void DisplayAndSearch(string query, DataGridView dgv)
        {
            
            string sql = query;
            string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=basayd";
            MySqlConnection con = new MySqlConnection(MySQLConnectionString);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
           
            adp.Fill(table);
            //dgv.DataSource = table;
            dgv.DataSource = table;
            con.Close();


        }

        private void label2_Click(object sender, EventArgs e)
        {
            //label2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Display();
        }
    }
}
