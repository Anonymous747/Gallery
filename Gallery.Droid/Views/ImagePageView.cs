using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Gallery.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace Gallery.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register(nameof(ImagePageView))]
    class ImagePageView : BaseFragment<ImagePageViewModel>
    {
        private Android.Support.V7.Widget.Toolbar _toolbar;
        protected override int FragmentId => Resource.Layout.image_page_view;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            _toolbar = view.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            var image = view.FindViewById<ImageView>(Resource.Id.image_page);
            var txt_name = view.FindViewById<TextView>(Resource.Id.txt_name_page);
            var txt_data = view.FindViewById<TextView>(Resource.Id.txt_data_page);

            string imagefileN = ViewModel.City.Path;
            imagefileN = imagefileN.Replace(".jpg", "").Replace(".png", "");
            int id = (int)typeof(Resource.Drawable).GetField(imagefileN).GetValue(null);
            var myImage = BitmapFactory.DecodeResource(Resources, id);
            image.SetImageBitmap(myImage);
            txt_name.Text = ViewModel.City.Name;
            txt_data.Text = ViewModel.City.Data;

            this.AddBindings(_toolbar, "Title City.Name");

            return view;
        }
    }
}