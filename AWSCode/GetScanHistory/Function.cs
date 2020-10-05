using System;
using System.IO;
using System.Text;

using Amazon.Lambda.Core;
using Amazon.Lambda.KinesisEvents;
using System.Data.SqlClient;
using System.Collections.Generic;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace GetScanHistory
{
    public class Function
    {

        public List<QRScan> FunctionHandler(string email, ILambdaContext context)
        {

            List<QRScan> scanList = new List<QRScan>();
            context.Logger.LogLine($"Beginning to process records...");

            using (var Conn = new SqlConnection("user id=<userid>;" +
                                        "password=<password>;server=<servername>;" +
                                        "database=<dbName>; " +
                                        "connection timeout=30"))
            {
                using (var Cmd = new SqlCommand("Select * FROM dbo.QR_Scan_Results where UserEmail='" + email + "'", Conn))
                {
                    Conn.Open(); 

                    SqlDataReader rdr = Cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        QRScan scan = new QRScan();
                        scan.ScannedProgram = rdr["Program"].ToString();
                        scan.Call = Convert.ToInt32(rdr["Call"]);
                        scan.Email = Convert.ToInt32(rdr["Email"]);
                        scan.Shadow = Convert.ToInt32(rdr["Shadow"]);
                        scan.Tour = Convert.ToInt32(rdr["Tour"]);
                        scan.Visit = Convert.ToInt32(rdr["Visit"]);
                        scanList.Add(scan);
                    }

                    Conn.Close();
                }
            }

            context.Logger.LogLine("processing complete.");
            return scanList;
        }

        public class QRScan
        {

            public string StudentEmail { get; set; }

            public string ScannedProgram { get; set; }

            public int Call { get; set; }

            public int Email { get; set; }

            public int Shadow { get; set; }

            public int Tour { get; set; }

            public int Visit { get; set; }

            public override string ToString()
            {
                return "Program: " + ScannedProgram;
            }
        }

    }
}