﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Taxi.Droid
{
    public class OnSignUpEventArgs : EventArgs
    {
        private string myFirstName;
        private string myEmail;
        private string myPassword;

        public string FirstName
        {
            get { return myFirstName; }
            set { myFirstName = value; }
        }

        public string Email
        {
            get { return myEmail; }
            set { myEmail = value; }
        }

        public string Password
        {
            get { return myPassword; }
            set { myPassword = value; }
        }

        public OnSignUpEventArgs(string firstName, string email, string password) : base()
        {
            FirstName = firstName;
            Email = email;
            Password = password;
        }
    }
    class Dialog_SignUp : DialogFragment
    {
        private Button myBtnSignUp;
        private EditText myTextFirstName;
        private EditText myTextEmail;
        private EditText myTextPassword;

        public event EventHandler<OnSignUpEventArgs> mySignUpEventCompleted;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.Dialog_sign_up, container, false);

            myTextFirstName = view.FindViewById<EditText>(Resource.Id.txtFirstName);
            myTextEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            myTextPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            myBtnSignUp = view.FindViewById<Button>(Resource.Id.btnSignUpFragment);

            myBtnSignUp.Click += myBtnSignUpClick;
            return view;
        }

        void myBtnSignUpClick(object sender, EventArgs e)
        {
            //user clicked on sign up
            mySignUpEventCompleted.Invoke(this, new OnSignUpEventArgs(myTextFirstName.Text, myTextEmail.Text, myTextPassword.Text));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //Set the title bar to invisible
            base.OnActivityCreated(savedInstanceState);
        }
    }
}