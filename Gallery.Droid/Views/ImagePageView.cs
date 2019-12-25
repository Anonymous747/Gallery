using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Gallery.Core.ViewModels;
using Gallery.Droid.Converters;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace Gallery.Droid.Views
{
    [MvxFragmentPresentation(typeof(RootViewModel), Resource.Id.content_frame, true)]
    [Register(nameof(ImagePageView))]
    class ImagePageView : BaseFragment<ImagePageViewModel>
    {
        public ImageView Image { get; set; }
        public EditText Name { get; set; }
        public TextInputEditText Data { get; set; }
        public Button Cancel { get; set; }
        public Button Edit { get; set; }

        private Android.Support.V7.Widget.Toolbar _toolbar;
        protected override int FragmentId => Resource.Layout.image_page_view;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            _toolbar = view.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar_img_page);

            Image = view.FindViewById<ImageView>(Resource.Id.image_page);
            Name = view.FindViewById<EditText>(Resource.Id.txt_name_page);
            Data = view.FindViewById<TextInputEditText>(Resource.Id.txt_data_page);
            Cancel = view.FindViewById<Button>(Resource.Id.btn_image_cancel);
            Edit = view.FindViewById<Button>(Resource.Id.btn_image_edit);

            InitBinding();
           
            this.AddBindings(_toolbar, "Title City.Name");
            _toolbar.SetTitleTextColor(Resource.Color.white); 

            return view;
        }
        private void InitBinding()
        {
            var set = this.CreateBindingSet<ImagePageView, ImagePageViewModel>();
            set.Bind(Image)
                .For(i => i.Drawable)
                .To(vm => vm.City.Path)
                .WithConversion<ImageNameToDrawableConverter>();
            set.Bind(Name)
                .For(i => i.Text)
                .To(vm => vm.City.Name);
            set.Bind(Data)
                .For(i => i.Text)
                .To(vm => vm.City.Data);
            set.Bind(Edit)
                .To(vm => vm.EditImageCommand);
            set.Bind(Cancel)
                .To(vm => vm.CancelImageCommand);
            set.Apply();
        }
    }
}