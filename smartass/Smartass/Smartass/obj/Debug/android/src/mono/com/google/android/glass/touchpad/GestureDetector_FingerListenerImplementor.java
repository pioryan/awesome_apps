package mono.com.google.android.glass.touchpad;


public class GestureDetector_FingerListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.glass.touchpad.GestureDetector.FingerListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onFingerCountChanged:(II)V:GetOnFingerCountChanged_IIHandler:Android.Glass.Touchpad.GestureDetector/IFingerListenerInvoker, GoogleGlassBindings\n" +
			"";
		mono.android.Runtime.register ("Android.Glass.Touchpad.GestureDetector/IFingerListenerImplementor, GoogleGlassBindings, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", GestureDetector_FingerListenerImplementor.class, __md_methods);
	}


	public GestureDetector_FingerListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == GestureDetector_FingerListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Glass.Touchpad.GestureDetector/IFingerListenerImplementor, GoogleGlassBindings, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onFingerCountChanged (int p0, int p1)
	{
		n_onFingerCountChanged (p0, p1);
	}

	private native void n_onFingerCountChanged (int p0, int p1);

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
