using Microsoft.AspNetCore.Components.WebView;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.DependencyInjection;
using ModularCMS.Core.Helpers;
using ModularCMS.Core.Models;
using ModularCMS.Core.Services;
using ModularCMS.EmployeeSide;
using ModularCMS.ResidentSide;
using System.Diagnostics;

namespace ModularCMS.Launcher
{
    public partial class MainPage : ContentPage
    {
        private readonly AuthService _authService;
        private readonly IMessengerService _messengerService;
        public MainPage(IMessengerService messengerService)
        {
            InitializeComponent();
            _messengerService = messengerService;

            _messengerService.Register<LoginSuccessMessage>(HandleLoginSuccess);
        }

        private async void HandleLoginSuccess(LoginSuccessMessage message)
        {
            try
            {
                _messengerService.Unregister<LoginSuccessMessage>(HandleLoginSuccess);

                Debug.WriteLine($"Login successful for user type: {message.UserType}");

                blazorWebView.RootComponents.Clear();

                await Task.Delay(100);

                switch (message.UserType)
                {
                    case "Resident":
                        Debug.WriteLine("Setting up Resident app");
                        blazorWebView.HostPage = "wwwroot/index.html";
                        blazorWebView.RootComponents.Clear();
                        blazorWebView.RootComponents.Add(new RootComponent
                        {
                            Selector = "#app",
                            ComponentType = typeof(ResidentSide.App)
                        });
                        break;
                    case "Employee":
                        Debug.WriteLine("Setting up Employee app");
                        blazorWebView.HostPage = "wwwroot/index.html";
                        blazorWebView.RootComponents.Clear();
                        blazorWebView.RootComponents.Add(new RootComponent
                        {
                            Selector = "#app",
                            ComponentType = typeof(EmployeeSide.App)
                        });
                        break;
                    default:
                        Debug.WriteLine("Setting up default Launcher app");
                        blazorWebView.HostPage = "wwwroot/index.html";
                        blazorWebView.RootComponents.Clear();
                        blazorWebView.RootComponents.Add(new RootComponent
                        {
                            Selector = "#app",
                            ComponentType = typeof(ModularCMS.Launcher.App)
                        });
                        break;
                }

                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    if (blazorWebView.Handler?.PlatformView != null)
                    {
                        await Task.Delay(50);
                    }
                });

                Debug.WriteLine("BlazorWebView updated successfully");
            } catch (Exception ex)
            {
                Debug.WriteLine($"Error in HandleLoginSuccess: {ex.Message}");
                Debug.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }
    }
}
