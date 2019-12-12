using System;
using System.Collections.Generic;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Gallery.Core.Models;
using Gallery.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace Gallery.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register(nameof(CollectionView))]
    class CollectionView : BaseFragment<CollectionViewModel>
    {
        private AppBarLayout _toolbar;
        private RecyclerView mRecyclerView;
        private RecyclerView.LayoutManager mLayoutManager;
        private RecyclerAdapter mAdapter;
        private List<City> mCities;
        protected override int FragmentId => Resource.Layout.collection_view;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            _toolbar = view.FindViewById<AppBarLayout>(Resource.Id.col_toolbar);
            this.AddBindings(_toolbar, "Title Collection");

            mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            mCities = ViewModel.Cities;
            mLayoutManager = new LinearLayoutManager(Activity);
            mRecyclerView.SetLayoutManager(mLayoutManager);
            mAdapter = new RecyclerAdapter(mCities);
            mRecyclerView.SetAdapter(mAdapter);
            mAdapter.ItemClick += OnItemClick;

            return view;
        }
        async void OnItemClick(object sender, int position)
        {
            await ViewModel.ImageSelected(ViewModel.Cities[position]);
        }
    }
    public class RecyclerAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<City> mCities;
        public RecyclerAdapter(List<City> cities)
        {
            mCities = cities;
        }
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