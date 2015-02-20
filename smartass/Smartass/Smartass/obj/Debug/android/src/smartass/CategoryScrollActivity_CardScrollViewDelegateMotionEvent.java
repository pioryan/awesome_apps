package smartass;


public class CategoryScrollActivity_CardScrollViewDelegateMotionEvent
	extends com.google.android.glass.widget.CardScrollView
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_dispatchGenericFocusedEvent:(Landroid/view/MotionEvent;)Z:GetDispatchGenericFocusedEvent_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("Smartass.CategoryScrollActivity/CardScrollViewDelegateMotionEvent, Smartass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CategoryScrollActivity_CardScrollViewDelegateMotionEvent.class, __md_methods);
	}


	public CategoryScrollActivity_CardScrollViewDelegateMotionEvent (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == CategoryScrollActivity_CardScrollViewDelegateMotionEvent.class)
			mono.android.TypeManager.Activate ("Smartass.CategoryScrollActivity/CardScrollViewDelegateMotionEvent, Smartass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public CategoryScrollActivity_CardScrollViewDelegateMotionEvent (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == CategoryScrollActivity_CardScrollViewDelegateMotionEvent.class)
			mono.android.TypeManager.Activate ("Smartass.CategoryScrollActivity/CardScrollViewDelegateMotionEvent, Smartass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public CategoryScrollActivity_CardScrollViewDelegateMotionEvent (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == CategoryScrollActivity_CardScrollViewDelegateMotionEvent.class)
			mono.android.TypeManager.Activate ("Smartass.CategoryScrollActivity/CardScrollViewDelegateMotionEvent, Smartass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public boolean dispatchGenericFocusedEvent (android.view.MotionEvent p0)
	{
		return n_dispatchGenericFocusedEvent (p0);
	}

	private native boolean n_dispatchGenericFocusedEvent (android.view.MotionEvent p0);

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
