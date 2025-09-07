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

            window.Title = "Community Managagement System";
            window.Width = 1366;
            window.Height = 768;
            window.MinimumWidth = 1366;
            window.MinimumHeight = 768;
            window.MaximumWidth = 1366;
            window.MaximumHeight = 768;

            return window;
        }
    }
}
