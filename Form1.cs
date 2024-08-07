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

namespace lab9tryagain2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection cnn;
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoDatabase;Integrated Security=True";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";
            sql = "Select TutorialID, TutorialName from DemoTable";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "\n";
            }
            dataReader.Close();
            command.Dispose();
            /*            cnn.Close();*/

            //create all necessary variables
            /*            SqlCommand insertCommand;*/

            //INSERTING STUFF
            SqlDataAdapter adapter = new SqlDataAdapter();

            sql = "Insert into DemoTable (TutorialID, TutorialName) VALUES (3, '" + "VB.NET" + "')";

            command = new SqlCommand(sql, cnn);

            adapter.InsertCommand = new SqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();


            //UPDATING STUFF
            sql = "UPDATE DemoTable SET TutorialName='" + "VB.NET Complete" + "' WHERE TutorialID=3";

            command = new SqlCommand(sql, cnn);
            adapter.UpdateCommand = new SqlCommand(sql, cnn);
            adapter.UpdateCommand.ExecuteNonQuery();
            command.Dispose();

            //DELETING STUFF
            sql = "DELETE DemoTable WHERE TutorialID=3";
            command = new SqlCommand(sql, cnn);
            adapter.DeleteCommand = new SqlCommand(sql, cnn);
            adapter.DeleteCommand.ExecuteNonQuery();
            command.Dispose();

            MessageBox.Show("done!");
            /*            command.Dispose();*/
            cnn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'demoDatabaseDataSet.DemoTable' table. You can move, or remove it, as needed.
            this.demoTableTableAdapter.Fill(this.demoDatabaseDataSet.DemoTable);

        }

        /*        private void Insert(object sender, EventArgs e)
                {
                    //create all necessary variables
                    SqlCommand command;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    String sql = "";

                    //write sql query
                    sql = "Insert into DemoTable (TutorialID, TutorialName) VALUES (3, '" + "VB.NET" + "')";

                    command = new SqlCommand(sql, cnn);
                }*/
    }
}
