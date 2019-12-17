using Android.OS;
using Android.Runtime;
using Android.Views;
using Gallery.Core.ViewModels;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace Gallery.Droid.Views
{
    [MvxFragmentPresentation(typeof(RootViewModel), Resource.Id.content_frame, true)]
    [Register(nameof(SettingView))]
    public class SettingView : BaseFragment<SettingViewModel>
    {
        protected override int FragmentId => Resource.Layout.setting_view;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            return view;
        }
    }
}