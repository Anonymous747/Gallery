using Gallery.Core.Rest.Implementation;
using Gallery.Core.Rest.Intarface;
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
            CreatableTypes()
                .EndingWith("Serviсe")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            // register the appstart object
            RegisterAppStart<RootViewModel>();
        }
    }
}
