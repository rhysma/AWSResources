using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace ExploreOTCAndroid
{
    [Activity(Label = "QR Scan History", Theme = "@style/CustomTheme", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ScanHistoryActivity : Activity
    {
        //setup the shared preferences file where main app data items will be stored
        ISharedPreferences prefs = Application.Context.GetSharedPreferences("APP_DATA", FileCreationMode.Private);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            TextView textHere = FindViewById<TextView>(Resource.Id.textView1);


            // Create your application here
            SetContentView(Resource.Layout.ScanHistory);

            //check to see if they have made a scan, if not, don't try to get the history
            ISharedPreferencesEditor editor = prefs.Edit();
            bool check = prefs.GetBoolean("hasScan", false);
            if(check)
            {
                GetRecords();
                //textHere.Text = "Getting Scan History...";
            }

        }

        private async void GetRecords()
        {
            //get the stored email of this user
            string email = prefs.GetString("email", "");

            //point the lambda call to the right location endpoint
            Amazon.RegionEndpoint region = Amazon.RegionEndpoint.USEast1;

            //credentials
            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(WebApp.AWSKey, WebApp.AWSSecret);

            TextView textHere = FindViewById<TextView>(Resource.Id.textView1);
            textHere.Text = "";
            try
            {
                //setup the lambda client with the credential and endpoint information
                Amazon.Lambda.AmazonLambdaClient client = new Amazon.Lambda.AmazonLambdaClient(awsCredentials, region);

                //payload has to be encapsulated in double quotes, thus the strange escape sequences here
                var invokeRequest = new Amazon.Lambda.Model.InvokeRequest { FunctionName = "GetScanHistory", InvocationType = "RequestResponse", Payload = "\"" + email + "\"" };
                
                //going to put this task on another thread so the UI doesn't lock up
                System.Threading.Tasks.Task<Amazon.Lambda.Model.InvokeResponse> responseTask = client.InvokeAsync(invokeRequest);

                await responseTask.ContinueWith((response) =>
                {
                    string statusText = "";
                    string informationalText = "Internal error: Unhandled branch point"; // Should always be set in the next "if"

                    if (response.IsCanceled) { statusText = "Cancelled"; informationalText = ""; }
                    else if (response.IsFaulted)
                    {
                        statusText = "Faulted";
                        informationalText = response.Exception.Message;
                        foreach (var exception in response.Exception.InnerExceptions)
                        {
                            informationalText += "\n" + exception.Message;
                        }
                    }
                    else if (response.IsCompleted)
                    {
                        statusText = "Finished";
                        var responseReader = new System.IO.StreamReader(response.Result.Payload);
                        informationalText = responseReader.ReadToEnd();
                    }

                    // This continuation is not run on the main UI thread, so need to set up
                    // another task perform the UI changes on the correct thread.
                    RunOnUiThread(() =>
                    {
                        Console.WriteLine(statusText);
                        Console.WriteLine(informationalText);

                        //now that we have the response we can deserialize it from Json to our object type
                        List<QRScan> scanList = JsonConvert.DeserializeObject<List<QRScan>>(informationalText);
                        foreach (QRScan scan in scanList)
                        {
                            textHere.Text += scan;
                            textHere.Text += "\n";
                        }

                    });
                });
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

        }
    }
}