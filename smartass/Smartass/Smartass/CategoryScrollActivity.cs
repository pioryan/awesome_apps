
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;

using Android.Glass.Touchpad;
using Android.Glass.Widget;
using Android.Media;
using System.Net.Http;
using System.Net.Http.Headers;
using Android.Util;
using System.Threading;
using Android.Glass.App;

namespace Smartass
{
    [Activity(Label = "CategoryScrollActivity")]
    public class CategoryScrollActivity : Activity, GestureDetector.IBaseListener
    {
        public const string EXTRA_PHOTO_FILE_NAME = "photo file name";

        string newPhotoFileName;
        GestureDetector gestureDector;
        CardScrollView cardScrollView;
        AudioManager audioManager;

        Handler handler = new Handler();
        Card mCard;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            audioManager = GetSystemService(Context.AudioService) as AudioManager;

            gestureDector = new GestureDetector(this);
            gestureDector.SetBaseListener(this);

            newPhotoFileName = Intent.GetStringExtra(EXTRA_PHOTO_FILE_NAME);
        }

        public bool OnGesture(Gesture gesture)
        {
            bool handled = false;
            var result = "Web result";
                   
            if (gesture == Gesture.Tap)
            {
                Log.Debug("Smartass Logging", "On Gesture: " + gesture.ToString());
                
                //Toast.MakeText(this, "tap tap tap", ToastLength.Short).Show();
                if (newPhotoFileName != null)
                {
                    Log.Debug("Smartass Logging", "newPhotoFileName: " + newPhotoFileName.ToString());


                    Log.Debug("Smartass Logging", "Calling Http");

                    for (var x = 0; x <= 3; x++)
                    {
                        try
                        {
                            using (var client = new HttpClient())
                            {
                                var photoFileName = "file name";
                                client.BaseAddress = new Uri("http://ys-mailroom.cloudapp.net:8888/");
                                client.DefaultRequestHeaders.Accept.Clear();
                                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                                HttpResponseMessage response = client.GetAsync("api/factoid?input=wilfred").Result;
                                Log.Debug("Smartass Logging", response.IsSuccessStatusCode.ToString());
                                if (response.IsSuccessStatusCode)
                                {
                                    result = response.Content.ReadAsStringAsync().Result;
                                    //Toast.MakeText(this, "dito na ako", ToastLength.Short).Show();
                                }

                                Log.Debug("Smartass Logging", result);
                                x = 5;
                            }
                        }

                        catch (System.Exception ex)
                        {
                            Handler handler = new Handler();
                            Log.Debug("Smartass Logging", ex.ToString());   
                        }
                    }

                    Log.Debug("Smartass Logging", "After loop");

                    mCard = new Card(this);
                    mCard.SetText("result asdfasdf asdf asdf ");
                    mCard.SetFootnote("Swipe down to exit...");
                    //mCard.SetImageLayout(ImageLayout.FULL);
                    //mCard.AddImage(R.drawable.icecream);
                    SetContentView(mCard.View);

                    audioManager.PlaySoundEffect((SoundEffect)13);
                    handled = false;
                }
            }
            else if (gesture == Gesture.SwipeDown)
            {
                audioManager.PlaySoundEffect((SoundEffect)15);
                handled = true;
            }

            if (handled)
                Finish();

            return handled;
        }

        public override bool OnGenericMotionEvent(Android.Views.MotionEvent e)
        {
            return gestureDector.OnMotionEvent(e);
        }

        private class CardScrollViewDelegateMotionEvent : CardScrollView
        {
            GestureDetector gestureDector;
            internal CardScrollViewDelegateMotionEvent(Context context, GestureDetector gestureDector)
                : base(context)
            {
                this.gestureDector = gestureDector;
            }

            protected override bool DispatchGenericFocusedEvent(Android.Views.MotionEvent e)
            {
                bool handled = false;

                if (gestureDector.OnMotionEvent(e))
                    handled = true;
                else
                    handled = base.DispatchGenericFocusedEvent(e);

                return handled;
            }
        }
    }
}

