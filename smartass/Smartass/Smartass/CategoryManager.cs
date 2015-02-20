
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

namespace Smartass
{
	public sealed class CategoryManager
	{
		private const int CATEGORY_COUNT = 2;
		private const int NO_SELECTED_CATEGORY = -1;

		private static readonly CategoryManager ourInstance = new CategoryManager ();

		private CategoryManager ()
		{
		}

		public static CategoryManager Instance { 
			get { return ourInstance; } 
		}

		private Category[] categories;

		public int Count {
			get { return categories != null ? categories.Length : 0; }
		}

		public int FoundCount {
			get {
				int foundCount = 0;
				if (categories != null) {
					foreach (Category category in categories)
						foundCount += category.PhotoFileName != null ? 1 : 0;
				}
				return foundCount;
			}
		}

		private int indexOfLastSelectedCategory = NO_SELECTED_CATEGORY;

		public Category CategoryAt (int i)
		{
			return categories != null && i < Count ? categories [i] : null;
		}

		public Category LastSelectedCategory {
			get {
				return indexOfLastSelectedCategory == NO_SELECTED_CATEGORY ?
					null : categories [indexOfLastSelectedCategory];
			}

			set {
				for (int i = 0; i < categories.Length; i++) {
					if (value == categories [i]) {
						indexOfLastSelectedCategory = i;
						break;
					}
				}
			}
		}

		public string StatusMessage {
			get {
				string message;

				if (Count == 0)
					message = "Select Start Game to begin";
				else if (FoundCount == 0)
					message = BuildNewGameMessage ();
				else if (FoundCount == Count)
					message = String.Format ("Congratulations!!\nYou have found all %d items", Count);
				else
					message = String.Format ("You have found %d of %d items", FoundCount, Count);

				return message;
			}
		}

		public String FooterMessage {
			get {
				return LastSelectedCategory != null ? "Last find: " + LastSelectedCategory.Name : "";
			}
		}

		private String BuildNewGameMessage ()
		{
			StringBuilder builder = new StringBuilder ("Search for items in these categories:\n");
			for (int i = 0; i < Count; i++) {
				if (i != 0)
					builder.Append (", ");
				builder.Append (CategoryAt (i).Name);
			}

			return builder.ToString ();
		}

		public void InitializeWithNewCategories ()
		{
			Random r = new Random ();
			int categoryNumber = r.Next (CATEGORY_COUNT);
			Log.Debug ("HuntCSXForGlass", String.Format ("Random category index: %d", categoryNumber));

			String[] categoryNames = null;
			switch (categoryNumber) {
			case 0:
				categoryNames = new String[]{ "Love", "Cat", "Robot" };
				break;
			case 1:
				categoryNames = new String[]{ "Stretchy", "Bird", "Holiday" };
				break;
			}
			if (categoryNames != null) {
				categories = new Category[categoryNames.Length];
				int index = -1;
				foreach (String categoryName in categoryNames)
					categories [++index] = new Category {
						Name = categoryName
					};
			}

		}

	}
}

