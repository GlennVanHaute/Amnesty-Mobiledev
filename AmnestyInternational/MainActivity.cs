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
	[Activity (Label = "AmnestyInternational", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button buttonDonate = FindViewById<Button> (Resource.Id.donate);
			buttonDonate.Click += (sender, e) => {
				{
					var intent = new Intent(this, typeof(ContactActivity));
					StartActivity(intent);
				}
			};	


		}
	}
}


