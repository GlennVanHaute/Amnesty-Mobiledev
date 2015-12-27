﻿using Android.App;
using Android.Widget;
using Android.OS;

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
			buttonDonate.Click += delegate {
				
				SetContentView (Resource.Layout.Contactgegevens);
			};
				
//			Button buttonGoToBedrag = FindViewById<Button> (Resource.Id.goToBedrag);
//			buttonGoToBedrag.Click += delegate {
//
//				SetContentView (Resource.Layout.Bedrag);
//			};
		}
	}
}


