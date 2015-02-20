
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
	public sealed class ResultManager
	{
		private const int Result_COUNT = 2;
		private const int NO_SELECTED_Result = -1;

		private static readonly ResultManager ourInstance = new ResultManager ();

		private ResultManager ()
		{
		}

		public static ResultManager Instance { 
			get { return ourInstance; } 
		}

		private ResultItem[] categories;

		public int Count {
			get { return categories != null ? categories.Length : 0; }
		}

		public int FoundCount {
			get {
				int foundCount = 0;
				if (categories != null) {
					foreach (ResultItem Result in categories)
						foundCount += Result.getText() != null ? 1 : 0;
				}
				return foundCount;
			}
		}

		private int indexOfLastSelectedResult = NO_SELECTED_Result;

		public ResultItem ResultAt (int i)
		{
			return categories != null && i < Count ? categories [i] : null;
		}

		public ResultItem LastSelectedResult {
			get {
				return indexOfLastSelectedResult == NO_SELECTED_Result ?
					null : categories [indexOfLastSelectedResult];
			}

			set {
				for (int i = 0; i < categories.Length; i++) {
					if (value == categories [i]) {
						indexOfLastSelectedResult = i;
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
					message = String.Format ("Congratulations!!\nYou have viewed all %d result", Count);
				else
					message = String.Format ("You have found %d of %d items", FoundCount, Count);

				return message;
			}
		}

		public String FooterMessage {
			get {
				return LastSelectedResult != null ? "Last find: " + LastSelectedResult.getText() : "";
			}
		}

		private String BuildNewGameMessage ()
		{
			StringBuilder builder = new StringBuilder ("Result are the following:\n");
			for (int i = 0; i < Count; i++) {
				if (i != 0)
					builder.Append (", ");
                builder.Append(ResultAt(i).getText());
			}

			return builder.ToString ();
		}

		public void InitializeWithNewCategories ()
		{
			Random r = new Random ();
			int ResultNumber = r.Next (Result_COUNT);
			Log.Debug ("Smartass", String.Format ("Random Result index: %d", ResultNumber));

			String[] ResultNames = null;
            
			if (ResultNames != null) {
				categories = new ResultItem[ResultNames.Count()];
				int index = -1;
                foreach (String ResultName in ResultNames)
                    categories[++index] = new ResultItem(ResultName);
			}

		}

	}
}

