
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
using Android.Util;
//using Newtonsoft.Json;

namespace AmnestyInternational
{
	[Activity (Label = "BedragActivity")]			
	public class BedragActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			//string json = Intent.GetStringExtra("donator");
			//Donator donator = JsonConvert.DeserializeObject<Donator> (json);
			// Log.Info("test", donator.name); 

			string donator_name = Intent.GetStringExtra("donator_name") ?? "Data not available";
			string donator_email = Intent.GetStringExtra("donator_email") ?? "Data not available";
			string donator_street = Intent.GetStringExtra("donator_street") ?? "Data not available";
			string donator_zipcode = Intent.GetStringExtra("donator_zipcode") ?? "Data not available";
			string donator_city = Intent.GetStringExtra("donator_city") ?? "Data not available";
			string donator_country = Intent.GetStringExtra("donator_country") ?? "Data not available";
			Log.Info ("donator_name", donator_name); // dit werkt!

			Log.Info ("donator_email", donator_email); // dit werkt!

		

			// Create your application here
			SetContentView (Resource.Layout.Bedrag);

			Button backToMain = FindViewById<Button> (Resource.Id.backToMain);
			TextView naamId = FindViewById<TextView> (Resource.Id.naamId);
			naamId.Text = donator_name ;
			// naamID aanpassen met de data dat we binnenkrijgen via de vorige intent -> naamID.Text (code voor de text van selected id aan te passen)
			backToMain.Click += (sender, e) => {
				{
					var intent = new Intent(this, typeof(MainActivity));
					//hier kunnen we data doorspelen naar de volgende Activity door deze aan de intent de linken.
					StartActivity(intent);
				}
			};
		}
	}
}

