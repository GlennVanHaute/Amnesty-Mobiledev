using System;

namespace AmnestyInternational
{
	public class Donator : Java.Lang.Object, IParcelable
	{
		public string name { get; set; }
		public string email { get; set; }
		public string street { get; set; }
		public string zipcode { get; set; }
		public string city { get; set; }
		public string country { get; set; }
		public int donation { get; set; }

		// constructor
		public Donator ()
		{
			
		}

		public Donator(Parcel parcel) {
			name = parcel.ReadString ();
		}

		public int DescribeContents()
		{
			return 0;
		}

		// Save this instance's values to the parcel
		public void WriteToParcel(Parcel dest, ParcelableWriteFlags flags)
		{
			dest.WriteInt(Id);
			dest.WriteString(Name);
		}

		// The creator creates an instance of the specified object
		private static readonly GenericParcelableCreator<SelectListItem> _creator
		= new GenericParcelableCreator<SelectListItem>((parcel) => new SelectListItem(parcel));

		[ExportField("CREATOR")]
		public static GenericParcelableCreator<SelectListItem> GetCreator()
		{
			return _creator;
		}
	}
}

