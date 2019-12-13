using System.Collections.Generic;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Gallery.Core.Models;
using Gallery.Core.ViewModels;
using Gallery.Droid.Views.Adapter;
using Gallery.Droid.Views.Recycler_Adapter;
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
    
}