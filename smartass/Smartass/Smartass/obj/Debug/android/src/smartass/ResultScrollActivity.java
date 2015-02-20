package smartass;


public class ResultScrollActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer,
		com.google.android.glass.touchpad.GestureDetector.BaseListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onResume:()V:GetOnResumeHandler\n" +
			"n_onPause:()V:GetOnPauseHandler\n" +
			"n_onGenericMotionEvent:(Landroid/view/MotionEvent;)Z:GetOnGenericMotionEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_onGesture:(Lcom/google/android/glass/touchpad/Gesture;)Z:GetOnGesture_Lcom_google_android_glass_touchpad_Gesture_Handler:Android.Glass.Touchpad.GestureDetector/IBaseListenerInvoker, GoogleGlassBindings\n" +
			"";
		mono.android.Runtime.register ("Smartass.ResultScrollActivity, Smartass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ResultScrollActivity.class, __md_methods);
	}


	public ResultScrollActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ResultScrollActivity.class)
			mono.android.TypeManager.Activate ("Smartass.ResultScrollActivity, Smartass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();


	public void onPause ()
	{
		n_onPause ();
	}

	private native void n_onPause ();


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
