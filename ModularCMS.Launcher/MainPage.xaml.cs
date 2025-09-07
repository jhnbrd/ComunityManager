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
        public MainPage(IMessengerService messengerService)
        {
            InitializeComponent();
        }
    }
}
