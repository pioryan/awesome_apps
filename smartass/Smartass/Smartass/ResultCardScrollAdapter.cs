using Android.Glass.App;
using Android.Glass.Widget;
using Android.Views;
using System.Collections.Generic;
using System.Linq;

namespace Smartass
{
    public class ResultCardScrollAdapter : CardScrollAdapter
    {
        private List<Card> mCards;

        public ResultCardScrollAdapter(List<Card> cards)
        {
            mCards = cards;
        }

        public override int GetPosition(Java.Lang.Object item)
        {
            return mCards.FindIndex(f => f == item);
        }

        public int GetCount()
        {
            return mCards.Count();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            return mCards[position].View;
        }

        public override int Count
        {
            get { return mCards.Count(); }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return mCards[position];
        }
    }
}