package mono.com.google.android.glass.touchpad;


public class GestureDetector_TwoFingerScrollListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.glass.touchpad.GestureDetector.TwoFingerScrollListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onTwoFingerScroll:(FFF)Z:GetOnTwoFingerScroll_FFFHandler:Android.Glass.Touchpad.GestureDetector/ITwoFingerScrollListenerInvoker, GoogleGlassBindings\n" +
			"";
		mono.android.Runtime.register ("Android.Glass.Touchpad.GestureDetector/ITwoFingerScrollListenerImplementor, GoogleGlassBindings, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", GestureDetector_TwoFingerScrollListenerImplementor.class, __md_methods);
	}


	public GestureDetector_TwoFingerScrollListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == GestureDetector_TwoFingerScrollListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Glass.Touchpad.GestureDetector/ITwoFingerScrollListenerImplementor, GoogleGlassBindings, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public boolean onTwoFingerScroll (float p0, float p1, float p2)
	{
		return n_onTwoFingerScroll (p0, p1, p2);
	}

	private native boolean n_onTwoFingerScroll (float p0, float p1, float p2);

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
