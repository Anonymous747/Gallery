using Gallery.Core.ViewModels;
using MvvmCross.ViewModels;

namespace Gallery.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {

            // register the appstart object
            RegisterAppStart<MainViewModel>();
        }
    }
}
