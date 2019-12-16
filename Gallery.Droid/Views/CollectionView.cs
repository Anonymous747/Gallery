using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Gallery.Core.ViewModels;
using Gallery.Droid.Views.Recycler_Adapter;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace Gallery.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register(nameof(CollectionView))]
    public class CollectionView : BaseFragment<CollectionViewModel>
    {
        private RecyclerView _mRecyclerView;
        private RecyclerView.LayoutManager _mLayoutManager;
        private RecyclerAdapter _mAdapter;
        protected override int FragmentId => Resource.Layout.collection_view;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            _mAdapter = new RecyclerAdapter();
            _mAdapter.ItemClick += OnItemClick;
            InitBinding();

            _mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            _mLayoutManager = new LinearLayoutManager(Activity);
            _mRecyclerView.SetLayoutManager(_mLayoutManager);
            _mRecyclerView.SetAdapter(_mAdapter);
            
        
            return view;
        }
        async void OnItemClick(object sender, int position)
        {
            await ViewModel.ImageSelected(ViewModel.Cities[position]);
        }
        private void InitBinding()
        {
            var set = this.CreateBindingSet<CollectionView, CollectionViewModel>();
            set.Bind(_mAdapter)
                .For(I => I._mCities)
                .To(A => A.Cities);
            set.Apply();
        }
    }
    
}