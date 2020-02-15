using Gallery.Core.Services.Interfaces;
using Gallery.Core.Services.Realisation;
using Gallery.Core.ViewModels;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace Gallery.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            /*CreatableTypes()
                .EndingWith("Servise")
                .AsInterfaces()
                .RegisterAsSingleton();*/


            //Mvx.IoCProvider.RegisterSingleton<ICityServise>(new CityServise());

            // register the appstart object
            RegisterAppStart<RootViewModel>();
        }
    }
}
