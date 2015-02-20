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
using Android.Glass.App;
using Android.Util;
using Android.Glass.Widget;

namespace Smartass
{
    public class ResultActivity : Activity
    {
        public const string WEB_RESULT = "Web Result";
        private Card mCard;
        private CardScrollView mCardScrollView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            mCardScrollView = new CardScrollView(this);

            SetContentView(mCardScrollView);
        }
    }
}