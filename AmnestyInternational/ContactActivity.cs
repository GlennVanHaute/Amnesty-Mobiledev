
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

			var inputName = FindViewById<EditText> (Resource.Id.inputName);
			var inputEmail = FindViewById<EditText> (Resource.Id.inputEmail);
			var inputStreet = FindViewById<EditText> (Resource.Id.inputStreet);
			var inputZipcode = FindViewById<EditText> (Resource.Id.inputZipcode);
			var inputCity = FindViewById<EditText> (Resource.Id.inputCity);
			var inputCountry = FindViewById<EditText> (Resource.Id.inputCountry);


			inputName.FocusChange += delegate{

				if (String.IsNullOrWhiteSpace(inputName.Text.ToString())){
					inputName.Error = "Dit veld is nog niet ingevuld";
				}
			};
			inputEmail.FocusChange += delegate{

				if (String.IsNullOrWhiteSpace(inputEmail.Text.ToString())){
					inputEmail.Error = "Dit veld is nog niet ingevuld";
				}
				inputEmail.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

					//mail validation
				
				};
			};
			inputStreet.FocusChange += delegate{

				if (String.IsNullOrWhiteSpace(inputStreet.Text.ToString())){
					inputStreet.Error = "Dit veld is nog niet ingevuld";
				}
			};
			inputZipcode.FocusChange += delegate{

				if (String.IsNullOrWhiteSpace(inputZipcode.Text.ToString())){
					inputZipcode.Error = "Dit veld is nog niet ingevuld";
				}
			};
			inputCity.FocusChange += delegate{

				if (String.IsNullOrWhiteSpace(inputCity.Text.ToString())){
					inputCity.Error = "Dit veld is nog niet ingevuld";
				}
			};
			inputCountry.FocusChange += delegate{

				if (String.IsNullOrWhiteSpace(inputCountry.Text.ToString())){
					inputCountry.Error = "Dit veld is nog niet ingevuld";
				}
			};

			goToBedrag.Click += (sender, e) => {
				{
					var intent = new Intent(this, typeof(BedragActivity));
					//data ophalen wat user invulde in field die dan doorsturen naar de setData
				
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

					if (String.IsNullOrWhiteSpace(inputName.Text.ToString()) || String.IsNullOrWhiteSpace(inputEmail.Text.ToString()) || String.IsNullOrWhiteSpace(inputStreet.Text.ToString()) || String.IsNullOrWhiteSpace(inputZipcode.Text.ToString()) || String.IsNullOrWhiteSpace(inputCity.Text.ToString()) || String.IsNullOrWhiteSpace(inputCountry.Text.ToString())  ){
						var ErrorButton = FindViewById<TextView> (Resource.Id.ErrorButton);

						ErrorButton.Text = "Niet alle velden zijn ingevuld";
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

