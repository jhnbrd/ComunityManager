using Microsoft.Extensions.DependencyInjection;

namespace ModularCMS.Launcher
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            MainPage = serviceProvider.GetService<MainPage>();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Title = "Barangay ERP - Login";
            window.Width = 1366;
            window.Height = 768;

            return window;
        }
    }
}
