using FirstUWPApp.Views.ViewModels;
using Ninject.Modules;

namespace FirstUWPApp.AppConfig.NinjectModules
{
    public class ViewModelsModules : NinjectModule
    {
        public override void Load()
        {
            Bind<HomeViewModel>()
               .ToSelf()
               .InSingletonScope();
        }
    }
}
