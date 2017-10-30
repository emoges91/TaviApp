using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading;

namespace Taxi.Droid
{
	[Activity (Label = "Taxi.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        private Button myBtnSignUp;
        private Button myBtnLogin;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            myBtnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            myBtnSignUp.Click += (object sender, EventArgs args) =>
            {
                //pull dialog
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                Dialog_SignUp signUp = new Dialog_SignUp();
                signUp.Show(transaction, "dialog fragment");

                signUp.mySignUpEventCompleted += SignUp_mySignUpEventCompleted;
            };

            myBtnLogin = FindViewById<Button>(Resource.Id.btnSignIn);
            myBtnLogin.Click += MyBtnLogin_Click;
		}

        private void MyBtnLogin_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Home));
            this.StartActivity(intent);
            this.Finish();
        }

        private void SignUp_mySignUpEventCompleted(object sender, OnSignUpEventArgs e)
        {
            Console.WriteLine(e.FirstName);
            Console.WriteLine(e.Email);
            Console.WriteLine(e.Password);
        }

        private void Request()
        {
            //My custom request to the server. 

        }
    }
}


