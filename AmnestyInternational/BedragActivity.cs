
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
	[Activity (Label = "BedragActivity")]			
	public class BedragActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView (Resource.Layout.Bedrag);

			Button backToMain = FindViewById<Button> (Resource.Id.backToMain);
			TextView naamId = FindViewById<TextView> (Resource.Id.naamId);
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

