using System;
		
using UIKit;
using System.Collections.Generic;
using System.IO;

namespace TableViewHeaderFooter.iOS
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
			table = new UITableView (View.Bounds, UITableViewStyle.Grouped);
			table.AutoresizingMask = UIViewAutoresizing.All;
			CreateTableItems();
			Add (table);
		}
		protected void CreateTableItems ()
		{
			List<TableItem> veges = new List<TableItem>();

			// Credit for test data to 
			// http://en.wikipedia.org/wiki/List_of_culinary_vegetables
			var lines = File.ReadLines("VegeData2.txt");
			foreach (var line in lines) {
				var vege = line.Split(',');
				veges.Add (new TableItem(vege[1]) {SubHeading=vege[0]} );
			}

			table.Source = new TableSource(veges, this);
		}
		public override void DidReceiveMemoryWarning ()
		{		
			base.DidReceiveMemoryWarning ();		
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
