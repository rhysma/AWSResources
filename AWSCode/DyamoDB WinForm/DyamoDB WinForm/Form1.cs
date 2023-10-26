using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2.DocumentModel;

namespace DyamoDB_WinForm
{
    public partial class Form1 : Form
    {
        // Global variables
        public static bool operationSucceeded;
        public static bool operationFailed;
        public static AmazonDynamoDBClient client;
        public static Table tableName;
        public static TableDescription moviesTableDescription;
        public static string table;
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateTableButton_Click(object sender, EventArgs e)
        {
            //get the table name from the user
            string tableNameFromUser = TableNameBox.Text;
            table = tableNameFromUser;

            // Create a table
            int status = Ddb_Intro.CreateTable(tableNameFromUser, Ddb_Intro.table_items_attributes, Ddb_Intro.table_key_schema);
            
            TableStatusLabel.Text = "Table " + tableNameFromUser + " created successfully";
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //call the function that will create a connection client
            Ddb_Intro.CreateConnection();
        }

        private void CreateRecordButton_Click(object sender, EventArgs e)
        {
            //get the values from the user
            int id = Convert.ToInt32(IDBox.Text);
            string name = NameBox.Text;

            //call the add method 
            int status = Ddb_Intro.AddItem(id, name, table);

            if (status == 0)
            {
                AddStatusLabel.Text = "Record created successfully";
            }
            else
            {
                AddStatusLabel.Text = "error";
            }
        }

        private void GetButton_Click(object sender, EventArgs e)
        {
            //get all records from the table and display in the listbox
            List<Person> records = Ddb_Intro.GetRecords(table);

            foreach(Person item in records)
            {
                OutputBox.Items.Add(item);
            }
        }
    }
}
