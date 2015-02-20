package mono.com.google.android.glass.touchpad;


public class GestureDetector_BaseListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.glass.touchpad.GestureDetector.BaseListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onGesture:(Lcom/google/android/glass/touchpad/Gesture;)Z:GetOnGesture_Lcom_google_android_glass_touchpad_Gesture_Handler:Android.Glass.Touchpad.GestureDetector/IBaseListenerInvoker, GoogleGlassBindings\n" +
			"";
		mono.android.Runtime.register ("Android.Glass.Touchpad.GestureDetector/IBaseListenerImplementor, GoogleGlassBindings, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", GestureDetector_BaseListenerImplementor.class, __md_methods);
	}


	public GestureDetector_BaseListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == GestureDetector_BaseListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Glass.Touchpad.GestureDetector/IBaseListenerImplementor, GoogleGlassBindings, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


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
