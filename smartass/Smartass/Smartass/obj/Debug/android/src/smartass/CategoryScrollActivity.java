package smartass;


public class CategoryScrollActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer,
		com.google.android.glass.touchpad.GestureDetector.BaseListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onGenericMotionEvent:(Landroid/view/MotionEvent;)Z:GetOnGenericMotionEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_onGesture:(Lcom/google/android/glass/touchpad/Gesture;)Z:GetOnGesture_Lcom_google_android_glass_touchpad_Gesture_Handler:Android.Glass.Touchpad.GestureDetector/IBaseListenerInvoker, GoogleGlassBindings\n" +
			"";
		mono.android.Runtime.register ("Smartass.CategoryScrollActivity, Smartass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CategoryScrollActivity.class, __md_methods);
	}


	public CategoryScrollActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CategoryScrollActivity.class)
			mono.android.TypeManager.Activate ("Smartass.CategoryScrollActivity, Smartass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public boolean onGenericMotionEvent (android.view.MotionEvent p0)
	{
		return n_onGenericMotionEvent (p0);
	}

	private native boolean n_onGenericMotionEvent (android.view.MotionEvent p0);


	public boolean onGesture (com.google.android.glass.touchpad.Gesture p0)
	{
		return n_onGesture (p0);
	}

	private native boolean n_onGesture (com.google.android.glass.touchpad.Gesture p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
