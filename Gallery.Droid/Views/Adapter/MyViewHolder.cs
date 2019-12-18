using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Gallery.Droid.Views.Adapter
{
    public class MyViewHolder : RecyclerView.ViewHolder
    {
        public TextView mName { get; set; }
        public TextView mData { get; set; }
        public ImageView mImage { get; set; }
        
        public MyViewHolder(View view) : base(view)
        {
            mName = view.FindViewById<TextView>(Resource.Id.txt_name);
            mImage = view.FindViewById<ImageView>(Resource.Id.img_path);
            mData = view.FindViewById<TextView>(Resource.Id.txt_data);
        }
    }
}