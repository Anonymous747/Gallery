using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Gallery.Core.Models;
using Gallery.Droid.Views.Adapter;

namespace Gallery.Droid.Views.Recycler_Adapter
{
    public class RecyclerAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<City> _mCities
        {
            get;
            set;
        }

        public RecyclerAdapter()
        {
            _mCities = new List<City>();
        }   
        
        public override int ItemCount
        {
            get { return _mCities.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyViewHolder myHolder = holder as MyViewHolder;
            myHolder.mName.Text = _mCities[position].Name;
            myHolder.mData.Text = _mCities[position].Data;
            string imagefileName = _mCities[position].Path;
            imagefileName = imagefileName.Replace(".jpg", "").Replace(".png", "");
            int id = (int)typeof(Resource.Drawable).GetField(imagefileName).GetValue(null);
            myHolder.mImage.SetImageResource(id);
        }


        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_name, parent, false);
            MyViewHolder view = new MyViewHolder(row);
           
            return view;
        }
        private void OnClick(int position)
        {
            if (ItemClick != null)
                ItemClick(this, position);
        }
    }
}