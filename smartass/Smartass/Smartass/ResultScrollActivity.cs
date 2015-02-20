
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
using Java.IO;
using Android.Graphics.Drawables;
using Org.Json;
using System.IO;

namespace Smartass
{
    [Activity(Label = "ResultScrollActivity")]
    public class ResultScrollActivity : Activity, GestureDetector.IBaseListener
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

            Log.Debug("Smartass Logging", "ResultScrollActivity enter");

            SetupCardScrollView();

            newPhotoFileName = Intent.GetStringExtra(EXTRA_PHOTO_FILE_NAME);
        }

        void SetupCardScrollView()
        {
            Log.Debug("Smartass Logging", "Setup card scrollview");

            cardScrollView = new ResultScrollViewDelegateMotionEvent(this, gestureDector);
            cardScrollView.HorizontalScrollBarEnabled = true;
            cardScrollView.Adapter = new ResultCardScrollAdapter(this.createLoadingCard(this));
            SetContentView(cardScrollView);
        }

        private List<Card> createLoadingCard(Context context)
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(context).SetText("processing..."));
            return cards;
        }

        protected override void OnResume()
        {
            base.OnResume();
            cardScrollView.Activate();
        }

        protected override void OnPause()
        {
            base.OnPause();
            cardScrollView.Deactivate();
        }

        private void ProcessRequest()
        {
            
            Log.Debug("Smartass Logging", "Process request" + newPhotoFileName);
            var result = "";
            
            if (newPhotoFileName != null)
            {
                for (var x = 0; x <= 3; x++)
                {
                    try
                    {
                        Log.Debug("Smartass Logging", "http call: " + x.ToString());
                        Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                        FileStream file = new FileStream(newPhotoFileName, FileMode.Open);
                        Log.Debug("Smartass Logging", "Uploading");
                        using (var requestContent = new MultipartFormDataContent())
                        {
                            using (var fileContent = new StreamContent(file))
                            {

                                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                                {
                                    Name = "\"file\"",
                                    FileName = "\"" + Path.GetFileName(newPhotoFileName) + "\""
                                };

                                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                                requestContent.Add(fileContent);
                                Log.Debug("Smartass Logging", "HttpClientHandler");
                                using (var handler = new HttpClientHandler())
                                {
                                    Log.Debug("Smartass Logging", "HttpClient");
                                    using (var client = new HttpClient(handler, true))
                                    {
                                        var response = client.PostAsync("http://ys-mailroom.cloudapp.net:8888/api/Upload/", requestContent).Result;
                                        result = response.Content.ReadAsStringAsync().Result;
                                        Log.Debug("Smartass Logging", result);
                                    }
                                }
                            }
                        }

                        
                        Log.Debug("Smartass Logging", "items added to list.. add in scroll");

                        var results = new List<ResultItem>();
                        var items = new JSONArray(result);
                        Log.Debug("Smartass Logging", items.ToString());

                        string keys = "";
                        for (int w = 0;w < items.Length(); w++)
                        { 
                            JSONObject rec = items.GetJSONObject(w);
                            keys = keys +"," + rec.GetString("Text");
                        }

                        mCard = new Card(this);
                        mCard.SetText(keys);
                        mCard.SetFootnote("Swipe down go back...");
                        SetContentView(mCard.View);
                            
                        x = 5;
                    }

                    catch (System.Exception ex)
                    {
                        Toast.MakeText(this, "Something went wrong, retrying again...", ToastLength.Short).Show();
                        Log.Debug("Smartass Logging", "Retrying...");
                        Handler handler = new Handler();
                        Log.Debug("Smartass Logging", ex.ToString());
                    }
                }
            }
        }

        private List<Card> GetCards(List<ResultItem> items)
        {
            var results = new List<Card>();

            foreach(var item in items)
            {
               results.Add(new Card(this).SetText(item.getText()).SetFootnote("Swipe down do go back..."));
            }
            return results;
        }

        public bool OnGesture(Gesture gesture)
        {
            bool handled = false;
            var result = "Web result";
            if (gesture == Gesture.Tap)
            {
                ProcessRequest();
            }

            if (gesture == Gesture.SwipeDown)
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

        private class ResultScrollViewDelegateMotionEvent : CardScrollView
        {
            GestureDetector gestureDector;
            internal ResultScrollViewDelegateMotionEvent(Context context, GestureDetector gestureDector)
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

