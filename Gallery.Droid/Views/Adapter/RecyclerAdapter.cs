using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Gallery.Core.Models;
using Gallery.Droid.Views.Adapter;

namespace Gallery.Droid.Views.Recycler_Adapter
{
    public class RecyclerAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<City> mCities;
        public RecyclerAdapter(List<City> cities)
        {
            mCities = cities;
        }
        

        public override int ItemCount
        {
            get { return mCities.Count; }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyView myHolder = holder as MyView;
            myHolder.mName.Text = mCities[position].Name;
            myHolder.mData.Text = mCities[position].Data;
            string imagefileName = mCities[position].Path;
            imagefileName = imagefileName.Replace(".jpg", "").Replace(".png", "");
            int id = (int)typeof(Resource.Drawable).GetField(imagefileName).GetValue(null);
            myHolder.mImage.SetImageResource(id);
        }


        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_name, parent, false);

            TextView txtName = row.FindViewById<TextView>(Resource.Id.txt_name);
            ImageView imgPath = row.FindViewById<ImageView>(Resource.Id.img_path);
            TextView txtData = row.FindViewById<TextView>(Resource.Id.txt_data);

            MyView view = new MyView(row, OnClick) { mName = txtName, mData = txtData, mImage = imgPath };
            return view;
        }
        void OnClick(int position)
        {
            if (ItemClick != null)
                ItemClick(this, position);
        }
    }
}