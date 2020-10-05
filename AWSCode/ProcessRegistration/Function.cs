using System;
using System.IO;
using System.Text;

using Amazon.Lambda.Core;
using Amazon.Lambda.KinesisEvents;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.SqlClient;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace ProcessRegistration
{
    public class Function
    {
        private SqlConnection myConnection = new SqlConnection("user id=<userid>;password=<password>;server=<servername>;database=<dbname>; connection timeout=30");
        private string databaseResponse = "";

        public void FunctionHandler(KinesisEvent kinesisEvent, ILambdaContext context)
        {
            try
            {
                context.Logger.LogLine(string.Format("Beginning to process {0} records...", (object)kinesisEvent.Records.Count));
                foreach (KinesisEvent.KinesisEventRecord record in (IEnumerable<KinesisEvent.KinesisEventRecord>)kinesisEvent.Records)
                {
                    context.Logger.LogLine(string.Format("Event ID: {0}", (object)record.EventId));
                    context.Logger.LogLine(string.Format("Event Name: {0}", (object)record.EventName));
                    string recordContents = this.GetRecordContents(record.Kinesis);
                    context.Logger.LogLine("Record Data:");
                    context.Logger.LogLine(recordContents);
                    this.AddRecord(JsonConvert.DeserializeObject<Student>(recordContents));
                    context.Logger.LogLine(this.databaseResponse);
                }
                context.Logger.LogLine("Stream processing complete.");
            }
            catch (Exception ex)
            {
                context.Logger.LogLine(ex.Message);
            }
        }

        private string GetRecordContents(KinesisEvent.Record streamRecord)
        {
            using (StreamReader streamReader = new StreamReader((Stream)streamRecord.Data, Encoding.ASCII))
                return streamReader.ReadToEnd();
        }

        private void AddRecord(Student myStudent)
        {
            try
            {
                //check the connection state
                try
                {
                    myConnection.Open();
                }
                catch (Exception ex)
                {
                    myConnection.Close();
                }

                SqlCommand sqlCommand = new SqlCommand("INSERT INTO dbo.Registration (FirstName, LastName, PhoneNo, UserEmail, School, Perception) Values(@Firstname, @Lastname, @Phone, @Email, @School, @Perception)", this.myConnection);
                sqlCommand.Parameters.AddWithValue("@Firstname", (object)myStudent.FirstName);
                sqlCommand.Parameters.AddWithValue("@Lastname", (object)myStudent.LastName);
                sqlCommand.Parameters.AddWithValue("@Email", (object)myStudent.Email);
                sqlCommand.Parameters.AddWithValue("@School", (object)myStudent.School);
                sqlCommand.Parameters.AddWithValue("@Phone", (object)myStudent.Phone);
                sqlCommand.Parameters.AddWithValue("@Perception", (object)myStudent.Perception.ToString());
                sqlCommand.ExecuteNonQuery();
                this.databaseResponse = "Database: Success";
            }
            catch (Exception ex)
            {
                this.databaseResponse = ex.Message;
            }

            myConnection.Close();
        }
    }

    public class Student
    {
        public string FirstName { get; set; }

        public string Email { get; set; }
        public string LastName { get; set; }

        public string School { get; set; }

        public string Phone { get; set; }

        public float Perception { get; set; }

        public bool HasSurvey { get; set; }
    }
}