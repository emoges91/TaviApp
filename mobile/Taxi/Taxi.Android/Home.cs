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
using Taxi.Services;

namespace Taxi.Droid
{
    [Activity(Label = "Home")]
    public class Home: Activity
    {
        private Button btnRequestForTaxi;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.Home);

            btnRequestForTaxi = FindViewById<Button>(Resource.Id.requestTaxi);
            btnRequestForTaxi.Click += (object sender, EventArgs args) =>
            {
                //pull dialog
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                Confirmation_Popup confirmation = new Confirmation_Popup();
                confirmation.Show(transaction, "dialog fragment");

                confirmation.confirmationCompleted += Confirmation_confirmationEventCompleted;
            };
        }

        private void Confirmation_confirmationEventCompleted(object sender, OnConfirmationArgs e)
        {
            var test = HttpController.createUrlEnconde(e.ActionOK.ToString());
        }
    }
}