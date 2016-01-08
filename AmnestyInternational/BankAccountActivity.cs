
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

namespace AmnestyInternational
{
	[Activity (Label = "BankAccountActivity")]			
	public class BankAccountActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView (Resource.Layout.BankAccount);
			var IbanNumber = FindViewById<EditText> (Resource.Id.Iban);

				IbanNumber.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

					var butt = e.Text.ToString ();
				if(butt.Length == 4){
					butt = butt + " ";
					IbanNumber.Text += " ";
				
				}

				};


		}
	}
}

