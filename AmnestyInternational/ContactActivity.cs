﻿
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
	[Activity (Label = "ContactActivity")]			
	public class ContactActivity : Activity
	{		
		
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView (Resource.Layout.Contactgegevens);
			Button goToBedrag = FindViewById<Button> (Resource.Id.goToBedrag);
			TextView VoornaamNaam = FindViewById<TextView> (Resource.Id.VoornaamNaam);
			goToBedrag.Click += (sender, e) => {
				{
					var intent = new Intent(this, typeof(BedragActivity));
					//data ophalen wat user invulde in field die dan doorsturen naar de setData

					// intent.SetData("Naam_Data", data);
					StartActivity(intent);
				}
			};	
		}
	}
}

