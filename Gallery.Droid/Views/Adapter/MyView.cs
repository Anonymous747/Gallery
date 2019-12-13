using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Gallery.Droid.Views.Adapter
{
    public class MyView : RecyclerView.ViewHolder
    {
        public View mMainView { get; set; }
        public TextView mName { get; set; }
        public TextView mData { get; set; }
        public ImageView mImage { get; set; }

        public MyView(View view, Action<int> listener) : base(view)
        {
            mMainView = view;
            mMainView.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
}