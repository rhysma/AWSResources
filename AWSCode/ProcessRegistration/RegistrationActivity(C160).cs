using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Amazon.Kinesis;
using Amazon.Kinesis.Model;
using System.IO;
using System.Text.RegularExpressions;
using Android.Content.PM;

namespace ExploreOTCAndroid
{
    [Activity(Label = "RegistrationActivity", Theme = "@style/CustomTheme", NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class RegistrationActivity : Activity
    {
        //setup the shared preferences file where main app data items will be stored
        ISharedPreferences prefs = Application.Context.GetSharedPreferences("APP_DATA", FileCreationMode.Private);

        Student currentStudent = new Student();

        //flag to keep track of errors
        bool isError = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Registration);

            //don't actually let them on this view if they are registered
            ISharedPreferencesEditor editor = prefs.Edit();
            string email = prefs.GetString("email", "");
            if (email != "")
            {
                Finish();
            }

                Button submitButton = FindViewById<Button>(Resource.Id.button1);

            //button click event
            submitButton.Click += SubmitButton_Click;

            //this is the "star" rating bar
            RatingBar perception = FindViewById<RatingBar>(Resource.Id.ratingBar1);

            perception.RatingBarChange += (o, es) => {
                currentStudent.Perception = perception.Rating;
            };

            //The data for populating the spinner can be found in Resources/Values/Strings.xml
            //populate spinner
            Spinner spinner = FindViewById<Spinner>(Resource.Id.schoolSpinner);
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.school_array, Android.Resource.Layout.SimpleSpinnerItem);



            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
        }

        /// <summary>
        /// Need to check for the Android hardware back press to ensure the user cannot bypass the registration page.
        /// </summary>
        public override void OnBackPressed()
        {
            // This prevents a user from being able to hit the back button and leave the login page.
            //check to see if this device has already registered.  
            ISharedPreferencesEditor editor = prefs.Edit();
            string email = prefs.GetString("email", "");
            if (email == "")
            {
                return;
            }

            base.OnBackPressed();
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            //add currently selected spinner value to the student object
            currentStudent.School = spinner.GetItemAtPosition(e.Position).ToString();

            //string toast = string.Format("The school is {0}", spinner.GetItemAtPosition(e.Position));
            //Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        private async void SubmitButton_Click(object sender, System.EventArgs e)
        {
            //Disable the submit button so the user can't accidentally submit
            //  the registration twice
            FindViewById<Button>(Resource.Id.button1).Enabled = false;

            //reset all of the error flags onClick
            isError = false;
            TextView errorFirstName = FindViewById<TextView>(Resource.Id.errorFirstName);
            errorFirstName.Text = "";
            TextView errorLastName = FindViewById<TextView>(Resource.Id.errorLastName);
            errorLastName.Text = "";
            TextView errorEmail = FindViewById<TextView>(Resource.Id.errorEmail);
            errorEmail.Text = "";
            TextView errorPhone = FindViewById<TextView>(Resource.Id.errorPhone);
            errorPhone.Text = "";


            EditText firstname = FindViewById<EditText>(Resource.Id.firstName);

            //check that the information in the field is valid
            //and that it isn't blank
            if (firstname.Text != "" || Regex.IsMatch(firstname.Text, "^[A-Za-z]$"))
            {
                currentStudent.FirstName = firstname.Text;
            }
            else
            {
                errorFirstName.Text = "Please enter your first name";
                isError = true;
            }
           

            EditText lastname = FindViewById<EditText>(Resource.Id.lastName);
            
            //check that the information in the field is valid
            //and that it isn't blank
            if (lastname.Text != "" || Regex.IsMatch(lastname.Text, "^[A-Za-z]$"))
            {
                currentStudent.LastName = lastname.Text;
            }
            else
            {
                errorLastName.Text = "Please enter your last name";
                isError = true;
            }

            EditText email = FindViewById<EditText>(Resource.Id.email);

            //check that the information in the field is valid
            //and that it isn't blank
            if (email.Text != "" || Regex.IsMatch(email.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                currentStudent.Email = email.Text;
            }
            else
            {
                errorEmail.Text = "Please enter your email";
                isError = true;
            }

            EditText phone = FindViewById<EditText>(Resource.Id.phoneNo);

            //check that the information in the field is valid
            //and that it isn't blank
            if (phone.Text != "" || Regex.IsMatch(phone.Text, @"^\(? (\d{ 3})\)?[\s\-]? (\d{3})\-? (\d{4})$"))
            {
                currentStudent.Phone = phone.Text;
            }
            else
            {
                errorPhone.Text = "Please enter your phone number";
                isError = true;
            }

            if(isError)
            {
                //Enable the submit button again so the user can press it 
                //  since the validation failed
                FindViewById<Button>(Resource.Id.button1).Enabled = true;
            }
            else
            {
                //add data to shared preferences
                ISharedPreferencesEditor editor = prefs.Edit();
                editor.PutString("firstname", currentStudent.FirstName);
                editor.PutString("lastname", currentStudent.LastName);
                editor.PutString("email", currentStudent.Email);
                editor.PutString("school", currentStudent.School);
                editor.PutString("phone", currentStudent.Phone);

                DateTime time = DateTime.Now;
                editor.PutString("timestamp", time.ToString("T"));


                //write to SP
                editor.Apply();

                //information needs to be added to the database using the AWS Lambda function

                var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(WebApp.AWSKey, WebApp.AWSSecret);

                try
                {

                    string dataAsJson = JsonConvert.SerializeObject(currentStudent);
                    byte[] dataAsBytes = Encoding.UTF8.GetBytes(dataAsJson);
                    using (MemoryStream memoryStream = new MemoryStream(dataAsBytes))
                    {
                        //create config that points to AWS region
                        AmazonKinesisConfig config = new AmazonKinesisConfig();
                        config.RegionEndpoint = Amazon.RegionEndpoint.USEast1;

                        //create client that pulls creds from config
                        AmazonKinesisClient kinesisClient = new AmazonKinesisClient(awsCredentials, Amazon.RegionEndpoint.USEast1);

                        //create put request
                        PutRecordRequest requestRecord = new PutRecordRequest();
                        requestRecord.StreamName = "exploreOTCData";

                        //give partition key that is used to place record in particular shard
                        requestRecord.PartitionKey = "registration";

                        //add record as memory stream
                        requestRecord.Data = memoryStream;

                        //PUT the record to Kinesis
                        Toast.MakeText(this, "Processing registration...", ToastLength.Long);
                        PutRecordResponse response = await kinesisClient.PutRecordAsync(requestRecord);
                        Console.WriteLine(response);
                    }


                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }


                //close this activity
                Finish();
            }
           
            
        }
    }
}