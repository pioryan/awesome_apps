
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
using Android.Provider;
using Android.Glass.Media;
using System.Net.Http;
using Org.Apache.Http.Client.Methods;
using Java.Lang;
using Java.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Smartass
{
	[Activity (Label = "MenuActivity", Theme="@style/MenuTheme")]			
	public class MenuActivity : Activity
	{
		const int PHOTO_REQUEST_CODE = 1;

		bool optionsMenuOpen;
		bool attachedToWindow;
		bool takingPhoto;

		Handler handler = new Handler();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.menu_main, menu);
			return true;
		}

		public override void OpenOptionsMenu ()
		{
			if (!optionsMenuOpen && attachedToWindow) {
				optionsMenuOpen = true;
				base.OpenOptionsMenu ();
			}
		}

		public override void OnOptionsMenuClosed (IMenu menu)
		{
			base.OnOptionsMenuClosed (menu);
			optionsMenuOpen = false;

			if(!takingPhoto)
				Finish ();
		}

		public override void OnAttachedToWindow ()
		{
			base.OnAttachedToWindow ();
			attachedToWindow = true;

			OpenOptionsMenu ();
		}

		public override void OnDetachedFromWindow ()
		{
			base.OnDetachedFromWindow ();
			attachedToWindow = false;
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			var handled = true;

			switch (item.ItemId) {
                
			case Resource.Id.action_smartass_a_picture:
				HandleTakeAPicture();
				break;
			case Resource.Id.action_stop:
				HandleStop();
				break;
			default:
				handled = base.OnOptionsItemSelected (item);
				break;
			}
			return handled;
		}

		void HandleStartNewGame ()
		{
			Toast.MakeText (this, "Start selected", ToastLength.Short).Show ();
			CategoryManager.Instance.InitializeWithNewCategories ();
		}

		void HandleTakeAPicture ()
		{
			takingPhoto = true;

			handler.Post (() => {

				Intent photoIntent = new Intent (MediaStore.ActionImageCapture);
				StartActivityForResult (photoIntent, PHOTO_REQUEST_CODE);
			});
		}

		void HandleViewCategories ()
		{
			Toast.MakeText (this, "View categories selected", ToastLength.Short).Show ();
		}

		void HandleStop ()
		{
			Toast.MakeText (this, "Bye bye", ToastLength.Short).Show ();

			Action stopAction = () => {
				StopService (new Intent (this, typeof(LiveCardService)));
			};
			handler.Post (stopAction);
		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
            Toast.MakeText(this, "Start photo", ToastLength.Short).Show();

            if (PHOTO_REQUEST_CODE == requestCode && Result.Ok == resultCode)
            {
                string photoFileName = data.GetStringExtra(CameraManager.ExtraThumbnailFilePath);
                //Toast.MakeText (this, photoFileName, ToastLength.Short).Show ();

                handler.Post(() =>
                {
                    //Intent intent = new Intent(this, typeof(CategoryScrollActivity));
                    //intent.PutExtra(CategoryScrollActivity.EXTRA_PHOTO_FILE_NAME, photoFileName);
                    //StartActivity(intent);

                    Intent intent = new Intent(this, typeof(ResultScrollActivity));
                    intent.PutExtra(ResultScrollActivity.EXTRA_PHOTO_FILE_NAME, photoFileName);
                    StartActivity(intent);
                });
            }

            Finish ();
		}

	}
}

