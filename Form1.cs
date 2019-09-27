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

namespace Coffe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-VJNJ93K\; DataBase=COFFESHOP; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command

                string commandString = @"SELECT * FROM Customer";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Execute
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    DataGridView.DataSource = dataTable;
                }
                else
                {
                    DataGridView.DataSource = null;
                    MessageBox.Show("No Data Found");
                }


                //Close
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something is Wrong");
            }

        
    }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {

                //Connection
                string connectionString = @"Server=DESKTOP-VJNJ93K\; DataBase=COFFESHOP; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"INSERT INTO Customer (Name, Address,Contact) Values ('" + nameTextBox.Text + "', '" + addressTextBox.Text + "'," + contactTextBox.Text + ")";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Execute
                int isExecuted = sqlCommand.ExecuteNonQuery();

                if (isExecuted > 0)
                {
                    MessageBox.Show("Saved");
                }
                else
                {
                    MessageBox.Show("Not Saved");
                }

                //Close
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        
    }

        private void delButton_Click(object sender, EventArgs e)
        {
            //Connection
            string connectionString = @"Server=DESKTOP-VJNJ93K\; DataBase=COFFESHOP; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            //DELETE FROM Items WHERE ID = 3
            string commandString = @"DELETE FROM Customer WHERE Id = " + idTextBox.Text + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Execute
            int isExecuted = sqlCommand.ExecuteNonQuery();

            if (isExecuted > 0)
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

            //Close
            sqlConnection.Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // SQL connection
            string connectionString = @"Server=DESKTOP-VJNJ93K\; DataBase=COFFESHOP; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            //Sql Command

            string commandString = "SELECT * FROM Customer WHERE Id =" + idTextBox.Text + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            //Execute
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                MessageBox.Show("Search Match");
                DataGridView.DataSource = dataTable;

            }
            else
            {
                MessageBox.Show("Search Data Not Match");
            }
            sqlConnection.Close();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            // SQL connection 
            string connectionString = @"Server=DESKTOP-VJNJ93K\; DataBase=COFFESHOP; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            //Sql Command

            string commandString = @"UPDATE Customer SET Name ='" + nameTextBox.Text + "', Address ='" + addressTextBox.Text + "', Contact = " + contactTextBox.Text + " WHERE Id =" + idTextBox.Text + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            int isExecute = sqlCommand.ExecuteNonQuery();
            if (isExecute > 0)
            {
                MessageBox.Show("Successfully Updated");
            }
            else
            {
                MessageBox.Show("Updated Failed");
            }

            sqlConnection.Close();
        }
    }
    
}
