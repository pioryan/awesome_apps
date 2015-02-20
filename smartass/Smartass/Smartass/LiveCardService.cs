
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
using Android.Glass.Timeline;

namespace Smartass
{
	[Service(Label="YouSource Smartass", Enabled=true, Exported=true)]
	[IntentFilter (new String[]{ "com.google.android.glass.action.VOICE_TRIGGER" })] 
	[MetaData("com.google.android.glass.VoiceTrigger", Resource = "@xml/voice_trigger_start")]
	class LiveCardService : Service
	{
		const string LIVE_CARD_TAG = "YSmartass Status";
		const string ACTION_STOP = "stop";

		RemoteViews liveCardViews;
		LiveCard liveCard;

		public override IBinder OnBind (Intent intent)
		{
			return null;
		}

		public override void OnDestroy ()
		{
			if (liveCard != null)
				liveCard.Unpublish ();
			base.OnDestroy ();
		}

		public override StartCommandResult OnStartCommand (Intent intent, StartCommandFlags flags, int startId)
		{
			if (liveCard == null) {
				liveCardViews = new RemoteViews (PackageName, 
					Resource.Layout.status_live_card_layout);
				liveCard = new LiveCard (this, LIVE_CARD_TAG);

				liveCard.SetViews (liveCardViews);

				Intent cardActionIntent = new Intent (this, typeof(MenuActivity));
				liveCard.SetAction (PendingIntent.GetActivity (this, 0, cardActionIntent, 0));
				liveCard.Publish (LiveCard.PublishMode.Reveal);
			} else {
					liveCard.Navigate ();
			}

			return StartCommandResult.Sticky;
		}

	}
}

