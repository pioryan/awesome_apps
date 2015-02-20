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
using Android.Glass.Widget;
using Android.Graphics;

namespace Smartass
{
    class CategoryScrollAdapter : CardScrollAdapter
    {
        Context context;
        CategoryManager categoryManager;

        public CategoryScrollAdapter(Context context, CategoryManager categoryManager)
        {
            this.context = context;
            this.categoryManager = categoryManager;
        }

        public override int GetPosition(Java.Lang.Object o)
        {
            int position = AdapterView.InvalidPosition;

            if (o is Category)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (GetItem(i) == o)
                    {
                        position = i;
                        break;
                    }
                }
            }

            return position;
        }

        public override int Count
        {
            get { return categoryManager.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return categoryManager.CategoryAt(position);
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                LayoutInflater inflater = LayoutInflater.From(context);
                convertView = inflater.Inflate(Resource.Layout.category_card, parent);
            }

            TextView textName = convertView.FindViewById<TextView>(Resource.Id.name);
            ImageView imagePhoto = convertView.FindViewById<ImageView>(Resource.Id.photo);

            Category category = (Category)GetItem(position);

            textName.Text = category.Name;
            if (category.PhotoFileName != null)
            {
                Bitmap photoBitmap = BitmapFactory.DecodeFile(category.PhotoFileName);
                imagePhoto.SetImageBitmap(photoBitmap);
            }

            return convertView;
        }
    }
}