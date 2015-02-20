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
using Java.Util;

namespace Smartass
{
    public class ResultItemCards
    {
        private Context mContext;
        private List<Card> mCards;

        public ResultItemCards(Context context)
        {
            mContext = context;
            mCards = new List<Card>();
        }

        public void addResultItem(ResultItem ResultItem)
        {
            Card card = new Card(mContext);
            card.SetText(ResultItem.getText());

            // add background image to card, if available
            if (ResultItem.getImageResource() == null)
            {
                card.AddImage(ResultItem.getImageResource());
                card.SetImageLayout(Android.Glass.App.Card.ImageLayout.Full);
            }
            
            mCards.Add(card);
        }

        public List<Card> getCards()
        {
            int numCards = mCards.Count();
            for (int i = 0; i < numCards; ++i)
            {
                // show the user what item he is on and how many there are. E.g., 3 of 10
                mCards[i].SetFootnote(String.Format(Locale.Us.ToString(), "%d of %d", i + 1, numCards));
            }

            return mCards;
        }
    }
}