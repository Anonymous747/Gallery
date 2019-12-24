using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Gallery.Core.Models;
using Gallery.Core.ViewModels;
using Gallery.Droid.Views.Adapter;
using Gallery.Droid.Views.Extensions;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Presenters.Attributes;


namespace Gallery.Droid.Views
{
    [MvxFragmentPresentation(typeof(RootViewModel), Resource.Id.content_frame, true)]
    [Register(nameof(CollectionView))]
    public class CollectionView : BaseFragment<CollectionViewModel>
    {
        private MvxRecyclerView _mRecyclerView;
        private RecyclerView.LayoutManager _mLayoutManager;
        protected override int FragmentId => Resource.Layout.collection_view;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            _mRecyclerView = view.FindViewById<MvxRecyclerView>(Resource.Id.recyclerView);
            _mLayoutManager = new LinearLayoutManager(Activity);
            _mRecyclerView.SetLayoutManager(_mLayoutManager);
            InitBinding();
            
            return view;
        }
       
        private void InitBinding()
        {
            var set = this.CreateBindingSet<CollectionView, CollectionViewModel>();
            set.Bind(_mRecyclerView.BindItems<City>(this.BindingContext,
                delegate (View itemView, MvxFluentBindingDescriptionSet<MyMvxViewHolder<City>, City> itemSet) {
                    itemSet.Bind(itemView.FindViewById<TextView>(Resource.Id.txt_name))
                           .For(v => v.Text)
                           .To(vm => vm.Name);
                    itemSet.Bind(itemView.FindViewById<TextView>(Resource.Id.txt_data))
                           .For(v => v.Text)
                           .To(vm => vm.Data);
                    itemSet.Bind(itemView.FindViewById<ImageView>(Resource.Id.img_path))
                            .For(v => v.Drawable)
                            .To(vm => vm.Path);
                }))
            .For(v => v.ItemsSource)
            .To(vm => vm.Cities);
            set.Bind(_mRecyclerView)
                .For(v => v.ItemClick)
                .To(vm => vm.CitySelectedCommand);
            set.Apply();
        }
        public int Converter(string value)
        {
            value = value.Replace(".jpg", "").Replace(".png", "");
            return (int)typeof(Resource.Drawable).GetField(value).GetValue(null);
        }
    }    
}