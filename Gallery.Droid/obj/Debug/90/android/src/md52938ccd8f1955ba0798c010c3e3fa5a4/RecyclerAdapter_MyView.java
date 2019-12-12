package md52938ccd8f1955ba0798c010c3e3fa5a4;


public class RecyclerAdapter_MyView
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Gallery.Droid.Views.RecyclerAdapter+MyView, Gallery.Droid", RecyclerAdapter_MyView.class, __md_methods);
	}


	public RecyclerAdapter_MyView (android.view.View p0)
	{
		super (p0);
		if (getClass () == RecyclerAdapter_MyView.class)
			mono.android.TypeManager.Activate ("Gallery.Droid.Views.RecyclerAdapter+MyView, Gallery.Droid", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
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
