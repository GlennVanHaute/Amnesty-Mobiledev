
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
//using Newtonsoft.Json;

namespace AmnestyInternational
{
	[Activity (Label = "ContactActivity")]			
	public class ContactActivity : Activity
	{		
		
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			var autoCompleteOptions = new String[] { "België", "Nederland", "Luxemburg", "Frankrijk", "Groot-Brittannië" };
		
			// Create your application here
			SetContentView (Resource.Layout.Contactgegevens);
			Button goToBedrag = FindViewById<Button> (Resource.Id.goToBedrag);
			TextView VoornaamNaam = FindViewById<TextView> (Resource.Id.VoornaamNaam);
			ArrayAdapter autoCompleteAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, autoCompleteOptions);
			var autocompleteTextView = FindViewById<AutoCompleteTextView>(Resource.Id.inputCountry);
			autocompleteTextView.Adapter = autoCompleteAdapter;





			goToBedrag.Click += (sender, e) => {
				{
					var intent = new Intent(this, typeof(BedragActivity));
					//data ophalen wat user invulde in field die dan doorsturen naar de setData
				
					var inputName = FindViewById<EditText> (Resource.Id.inputName);
					var inputEmail = FindViewById<EditText> (Resource.Id.inputEmail);
					var inputStreet = FindViewById<EditText> (Resource.Id.inputStreet);
					var inputZipcode = FindViewById<EditText> (Resource.Id.inputZipcode);
					var inputCity = FindViewById<EditText> (Resource.Id.inputCity);
					var inputCountry = FindViewById<EditText> (Resource.Id.inputCountry);

					//Donator donator = new Donator();
					//donator.name = inputName.Text.ToString();
					//donator.email = inputEmail.Text.ToString();
					//donator.street = inputStreet.Text.ToString();
					//donator.zipcode = inputZipcode.Text.ToString();
					//donator.city = inputCity.Text.ToString();
					//donator.country = inputCountry.Text.ToString();
					//intent.PutExtra("donator_name", JsonConvert.SerializeObject(donator));


					intent.PutExtra("donator_name", inputName.Text.ToString());
					intent.PutExtra("donator_email", inputEmail.Text.ToString());
					intent.PutExtra("donator_street", inputStreet.Text.ToString());
					intent.PutExtra("donator_zipcode", inputZipcode.Text.ToString());
					intent.PutExtra("donator_city", inputCity.Text.ToString());
					intent.PutExtra("donator_country", inputCountry.Text.ToString());
					if (String.IsNullOrWhiteSpace(inputName.Text.ToString())){
						inputName.Error = "Dit veld is leeg";
					}
					else{
						StartActivity(intent);

					}
				}
			};

//			var nameField = FindViewById<EditText> (Resource.Id.name);
//			var test = nameField.Text.ToString();
//
//			var textView = FindViewById<TextView> (Resource.Id.VoornaamNaam);
//
//			nameField.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
//
//				textView.Text = e.Text.ToString ();
//
//			};


		}
	}
}

