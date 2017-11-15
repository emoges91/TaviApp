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

namespace Taxi.Droid
{
    public class OnConfirmationArgs : EventArgs
    {
        private bool actionOK;

        public bool ActionOK
        {
            get { return actionOK; }
            set { actionOK = value; }
        }

        public OnConfirmationArgs(bool actionOK) : base()
        {
            ActionOK = actionOK;
        }
    }

    class Confirmation_Popup : DialogFragment
    {
        private Button btnCancelAction;
        private Button btnOkAction;

        public event EventHandler<OnConfirmationArgs> confirmationCompleted;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.Confirmation_Popup, container, false);

            btnCancelAction = view.FindViewById<Button>(Resource.Id.btnCancel);
            btnCancelAction.Click += btnCancelClick;

            btnOkAction = view.FindViewById<Button>(Resource.Id.btnOk);
            btnOkAction.Click += btnConfirmationClick;
            return view;
        }

        void btnConfirmationClick(object sender, EventArgs e)
        {
            //user clicked on: "Confirmar"
            confirmationCompleted.Invoke(this, new OnConfirmationArgs(true));
            this.Dismiss();
        }

        void btnCancelClick(object sender, EventArgs e)
        {
            //user clicked on: "Cancelar"
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //Set the title bar to invisible
            base.OnActivityCreated(savedInstanceState);
        }
    }
}
