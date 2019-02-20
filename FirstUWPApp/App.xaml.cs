using System;
using FilmFindService.Models;
using FilmsDataAccessLayer.Models;
using FirstUWPApp.Views;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FirstUWPApp
{
    sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            Init();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            LogingService.LoggingServices.Instance.WriteLine<App>("Start application", MetroLog.LogLevel.Info);

            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    rootFrame.Navigate(typeof(ContainerPage), e.Arguments);
                }

                Window.Current.Activate();
            }
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            LogingService.LoggingServices.Instance.WriteLine<App>("On suspending application", MetroLog.LogLevel.Info);
            var deferral = e.SuspendingOperation.GetDeferral();
            deferral.Complete();
        }

        private void Init()
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<FilmInfoDTO, FilmInfo>());
        }
    }
}