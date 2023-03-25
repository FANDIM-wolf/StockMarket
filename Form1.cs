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
            DisplayAndSearch("SELECT `id` , `name`  , `gold` , `silver` , `copper` FROM `test` WHERE `name` LIKE '%" + textBox1.Text + "%'", dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //runQuery();
        }

        private void Display()
        {
            DisplayAndSearch("SELECT `id` , `name` ,  `gold` , `silver` , `copper` FROM `test`  WHERE `name` LIKE '%" + textBox1.Text + "%'", dataGridView1);
        }



        private void runQuery()
        {
            string query = "INSERT INTO `test` (`id`, `name`) VALUES (NULL , 'Mikis');";

            string MySQLConnectionString = "DATA_INFO";

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

            } catch (Exception e)
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
            string query = "UPDATE `test` SET name=@Name , gold=" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + " , silver=" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + " , copper=" + dataGridView1.CurrentRow.Cells[4].Value.ToString() + " WHERE `id` = @id;";

            string MySQLConnectionString = "DATA_INFO";

            MySqlConnection DataBaseConnection = new MySqlConnection(MySQLConnectionString);

            MySqlCommand commandDataBase = new MySqlCommand(query, DataBaseConnection);

            commandDataBase.CommandTimeout = 60;

            commandDataBase.CommandType = CommandType.Text;
            commandDataBase.Parameters.Add("@Name", MySqlDbType.VarChar).Value = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            commandDataBase.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
            /*
            commandDataBase.Parameters.Add("@Gold", MySqlDbType.Int64).Value = 3;
            commandDataBase.Parameters.Add("@Silver", MySqlDbType.Int64).Value = 32;
            commandDataBase.Parameters.Add("@Copper", MySqlDbType.Int64).Value = 34;
            commandDataBase.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
           */

            DataBaseConnection.Open();
            commandDataBase.CommandTimeout = 2000;
            MySqlDataReader myReader = commandDataBase.ExecuteReader();
            DataBaseConnection.Close();

            MessageBox.Show("Query successfully executed");




        }

        private void DeleteQuery(string id)
        {
            string query = "DELETE FROM `test`  WHERE `id` = @id ;";

            string MySQLConnectionString = "DATA_INFO";

            MySqlConnection DataBaseConnection = new MySqlConnection(MySQLConnectionString);

            MySqlCommand commandDataBase = new MySqlCommand(query, DataBaseConnection);

            commandDataBase.CommandTimeout = 60;

            commandDataBase.CommandType = CommandType.Text;
            MessageBox.Show("Query successfully executed " + dataGridView1.CurrentRow.Cells[1].Value.ToString());
            commandDataBase.Parameters.Add("@Name", MySqlDbType.VarChar).Value = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            commandDataBase.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
            try
            {

                DataBaseConnection.Open();
                //commandDataBase.CommandTimeout = 60;
                if (id != null)
                {
                    MySqlDataReader myReader = commandDataBase.ExecuteReader();
                }
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
            string MySQLConnectionString = "DATA_INFO";
            MySqlConnection con = new MySqlConnection(MySQLConnectionString);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            
            adp.Fill(table);
            //dgv.DataSource = table;
            dgv.DataSource = table;
            dgv.Font = new Font("Tahoma", 15);
            con.Close();


        }

        private void label2_Click(object sender, EventArgs e)
        {
            //label2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {   
            // if we have at least one row we update current selcted object
            if (dataGridView1.Rows != null && dataGridView1.Rows.Count != 0)
            {
                string id_of_object = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (id_of_object == null || dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Cells[0] == null)
                {

                    Display();
                }
                UpdateQuery(id_of_object);
                Display();
            }
            
                
            Display();
        }

        //Remove from data base button
        private void button3_Click(object sender, EventArgs e)
        {
            string id_of_object = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DeleteQuery(id_of_object);
        }
    }
}
