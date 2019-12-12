using Android.OS;
using Android.Runtime;
using Android.Views;
using Gallery.Core.ViewModels;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace Gallery.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register(nameof(StartView))]
    public class StartView : BaseFragment<StartViewModel>
    {
        protected override int FragmentId => Resource.Layout.start_view;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            return view;
        }
    }
}