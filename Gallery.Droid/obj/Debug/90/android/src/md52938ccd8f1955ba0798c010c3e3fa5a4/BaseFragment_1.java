package md52938ccd8f1955ba0798c010c3e3fa5a4;


public abstract class BaseFragment_1
	extends md52938ccd8f1955ba0798c010c3e3fa5a4.BaseFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Gallery.Droid.Views.BaseFragment`1, Gallery.Droid", BaseFragment_1.class, __md_methods);
	}


	public BaseFragment_1 ()
	{
		super ();
		if (getClass () == BaseFragment_1.class)
			mono.android.TypeManager.Activate ("Gallery.Droid.Views.BaseFragment`1, Gallery.Droid", "", this, new java.lang.Object[] {  });
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
