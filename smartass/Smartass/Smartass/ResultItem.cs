using Android.Graphics.Drawables;
using Android.Util;
using Java.Net;
using System;

namespace Smartass
{
    public class ResultItem
    {
        public string text;
        public string imageUrl;

        public ResultItem(string name)
        {
            new ResultItem(name, null);
        }

        public ResultItem(string name, string imageUrl)
        {
            this.text = name;
            this.imageUrl= imageUrl;
        }

        public string getText()
        {
            return text;
        }

        public void setText(string value)
        {
            this.text = value;
        }

        public void setImageUrl(string value)
        {
            this.imageUrl = value;
        }


        public Drawable getImageResource()
        {
            Log.Debug("Smartass Logging", this.imageUrl);
            return this.drawableFromUrl(this.imageUrl);
        }

        private Drawable drawableFromUrl(String url)
        {
            try
            {

                System.IO.Stream input = new URL(url).OpenStream();
                Drawable d = Drawable.CreateFromStream(input, url);
                return d;
            }
            catch (Exception e)
            {
                Log.Debug("Smartass Logging", e.ToString());
                return null;
            }
        }
    }
}