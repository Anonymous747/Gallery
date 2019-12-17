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
    [MvxFragmentPresentation(typeof(RootViewModel), Resource.Id.content_frame, true)]
    [Register(nameof(ImagePageView))]
    class ImagePageView : BaseFragment<ImagePageViewModel>
    {
        public string ImageName { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }

        private Android.Support.V7.Widget.Toolbar _toolbar;
        protected override int FragmentId => Resource.Layout.image_page_view;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            _toolbar = view.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            var image = view.FindViewById<ImageView>(Resource.Id.image_page);
            var txt_name = view.FindViewById<TextView>(Resource.Id.txt_name_page);
            var txt_data = view.FindViewById<TextView>(Resource.Id.txt_data_page);

            InitBinding();
            ImageName = ImageName.Replace(".jpg", "").Replace(".png", "");
            int id = (int)typeof(Resource.Drawable).GetField(ImageName).GetValue(null);
            var myImage = BitmapFactory.DecodeResource(Resources, id);
            image.SetImageBitmap(myImage);
            txt_name.Text = Name;
            txt_data.Text = Data;

            this.AddBindings(_toolbar, "Title City.Name");
            _toolbar.SetTitleTextColor(Resource.Color.white); 

            return view;
        }
        private void InitBinding()
        {
            var set = this.CreateBindingSet<ImagePageView, ImagePageViewModel>();
            set.Bind()
                .For(F => F.ImageName)
                .To(T => T.City.Path);
            set.Apply();

            set.Bind()
                .For(F => F.Name)
                .To(T => T.City.Name);
            set.Apply();

            set.Bind()
                .For(F => F.Data)
                .To(T => T.City.Data);
            set.Apply();
        }
    }
}