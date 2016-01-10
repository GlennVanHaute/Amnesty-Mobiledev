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
	[Activity (Label = "ComfirmationActivity")]			
	public class ComfirmationActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			
				base.OnCreate (savedInstanceState);

				
			SetContentView (Resource.Layout.Donator);

			string donator_name = Intent.GetStringExtra("donator_name") ?? "Data not available";
			string donator_email = Intent.GetStringExtra("donator_email") ?? "Data not available";
			string donator_street = Intent.GetStringExtra("donator_street") ?? "Data not available";
			string donator_zipcode = Intent.GetStringExtra("donator_zipcode") ?? "Data not available";
			string donator_city = Intent.GetStringExtra("donator_city") ?? "Data not available";
			string donator_country = Intent.GetStringExtra("donator_country") ?? "Data not available";
			string donator_amount= Intent.GetStringExtra("donator_amount") ?? "Data not available";
			string donator_rekening= Intent.GetStringExtra("donator_rekening") ?? "Data not available";



			var NaamText = FindViewById<TextView> (Resource.Id.NaamText);
			NaamText.Text = "Naam: "+donator_name;
			var EmailText = FindViewById<TextView> (Resource.Id.EmailText);
			EmailText.Text = "Email: "+donator_email;
			var AdressText = FindViewById<TextView> (Resource.Id.AdressText);
			AdressText.Text = "Adress: "+donator_street;
			var PostcodeText = FindViewById<TextView> (Resource.Id.PostcodeText);
			PostcodeText.Text = "Postcode: "+donator_zipcode;
			var LandText = FindViewById<TextView> (Resource.Id.LandText);
			LandText.Text = "Land: "+donator_country;
			var BedragText = FindViewById<TextView> (Resource.Id.BedragText);
			BedragText.Text = "Maandelijks bedrag: "+donator_amount;
			var RekeningNummerText = FindViewById<TextView> (Resource.Id.RekeningNummerText);
			RekeningNummerText.Text = "Rekening nummer: "+donator_rekening;
			Button backtoMain = FindViewById<Button> (Resource.Id.backtoMain);
			Button backButton = FindViewById<Button> (Resource.Id.backButton);

			backtoMain.Click += delegate{
				var intent = new Intent(this, typeof(MainActivity));
				StartActivity(intent);

			};
			backButton.Click += delegate{
				var intent = new Intent(this, typeof(BedragActivity));
				StartActivity(intent);

			};

		}
	}
}

