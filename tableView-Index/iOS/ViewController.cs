using System;
		
using UIKit;
using System.IO;
using System.Collections.Generic;

namespace tableViewIndex.iOS
{
	public partial class ViewController : UIViewController
	{
		UITableView table;

		public ViewController (IntPtr handle) : base (handle)
		{		
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			table = new UITableView (View.Bounds);
			table.AutoresizingMask = UIViewAutoresizing.All;

			var lines = File.ReadLines ("VegeData.txt");
			List<string> veges = new List<string> ();
			foreach(var l in lines){
				veges.Add (l);
			}
			veges.Sort ((x,y) => {return x.CompareTo (y);});
			string[] tableItems = veges.ToArray();


			table.Source = new TableSource(tableItems,this);
			Add (table);

		}

		public override void DidReceiveMemoryWarning ()
		{		
			base.DidReceiveMemoryWarning ();		
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
