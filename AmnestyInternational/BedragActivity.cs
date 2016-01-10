
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
		private bool IsIbanChecksumValid(string iban) {
			if(iban.Length < 4 || iban[0] == ' ' || iban[1] == ' ' || iban[2] == ' ' || iban[3] == ' ') throw new InvalidOperationException();

			var checksum = 0;
			var ibanLength = iban.Length;
			for(int charIndex = 0;charIndex < ibanLength;charIndex++) {
				if(iban[charIndex] == ' ') continue;

				int value;
				var c = iban[(charIndex + 4) % ibanLength];
				if((c >= '0') && (c <= '9')) {
					value = c - '0';
				} else if((c >= 'A') && (c <= 'Z')) {
					value = c - 'A';
					checksum = (checksum * 10 + (value / 10 + 1)) % 97;
					value %= 10;
				} else if((c >= 'a') && (c <= 'z')) {
					value = c - 'a';
					checksum = (checksum * 10 + (value / 10 + 1)) % 97;
					value %= 10;
				} else throw new InvalidOperationException();

				checksum = (checksum * 10 + value) % 97;
			}
			return checksum == 1;
		}
		
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

			var kaartnummer = FindViewById<EditText> (Resource.Id.rekeningnummer);
			kaartnummer.FocusChange += delegate{

				if (this.IsIbanChecksumValid(kaartnummer.Text.ToString())){
					kaartnummer.Error = "Iban is niet geldig.";
				}
			};

			// Create your application here
			SetContentView (Resource.Layout.Bedrag);

			Button backToMain = FindViewById<Button> (Resource.Id.backToMain);
			TextView naamId = FindViewById<TextView> (Resource.Id.naamId);
			naamId.Text = donator_name ;
			// naamID aanpassen met de data dat we binnenkrijgen via de vorige intent -> naamID.Text (code voor de text van selected id aan te passen)
			backToMain.Click += (sender, e) => {
				{
					var intent = new Intent(this, typeof(ComfirmationActivity));
					//hier kunnen we data doorspelen naar de volgende Activity door deze aan de intent de linken.
					var amount = FindViewById<EditText> (Resource.Id.amount);

					intent.PutExtra("donator_name", donator_name);
					intent.PutExtra("donator_email", donator_email);
					intent.PutExtra("donator_street", donator_street);
					intent.PutExtra("donator_zipcode", donator_zipcode);
					intent.PutExtra("donator_city", donator_city);
					intent.PutExtra("donator_country",donator_country);
					intent.PutExtra("donator_amount", amount.Text.ToString());
					intent.PutExtra("donator_rekening", kaartnummer.Text.ToString());
					StartActivity(intent);
				}
			};

			Button backToContact = FindViewById<Button> (Resource.Id.backToContact);
			backToContact.Click += delegate{
				var intent = new Intent(this, typeof(ContactActivity));
				StartActivity(intent);

			};
		}
	}
}

