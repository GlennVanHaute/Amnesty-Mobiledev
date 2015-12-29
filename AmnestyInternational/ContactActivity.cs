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
			goToBedrag.Click += (sender, e) => {
				{
					var intent = new Intent(this, typeof(BedragActivity));
					//hier kunnen we data doorspelen naar de volgende Activity door deze aan de intent de linken.
					StartActivity(intent);
				}
			};	
		}
	}
}
