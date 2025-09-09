using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using ModularCMS.Core.Data;
using ModularCMS.Core.Helpers;
using ModularCMS.Core.Services;
using MudBlazor;
using MudBlazor.Services;
using System.ComponentModel.Design;

namespace ModularCMS.Launcher
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = false;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 10000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            //builder.Services.AddDbContext<AppDbContext>(options =>
            //options.UseSqlServer("Data Source=127.0.0.1,9210;Initial Catalog=cms_it13;Persist Security Info=True;User ID=jihan438;Password=JihanPH438;Trust Server Certificate=True"));
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer("Data Source=MSI-JIHAN\\SQLEXPRESS;Initial Catalog=cms_it13;Integrated Security=True;Trust Server Certificate=True"));

            builder.Services.AddSingleton<IMessengerService, MessengerService>();
            builder.Services.AddSingleton<IPreferencesService, PreferencesService>();
            builder.Services.AddSingleton<SessionService>();
            builder.Services.AddScoped<AuthService>();
    //        builder.Services.AddDbContextFactory<AppDbContext>(options =>
    //options.UseSqlServer("Data Source=127.0.0.1,9210;Initial Catalog=cms_it13;Persist Security Info=True;User ID=jihan438;Password=JihanPH438;Trust Server Certificate=True"));
            builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlServer("Data Source=MSI-JIHAN\\SQLEXPRESS;Initial Catalog=cms_it13;Integrated Security=True;Trust Server Certificate=True"));
            
            builder.Services.AddTransient<MainPage>();

            var app = builder.Build();

            ServiceHelper.Initialize(app.Services);

            return app;
        }
    }
}
