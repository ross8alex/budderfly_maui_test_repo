using Budderfly_MAUI_Test.Repositories;
using Budderfly_MAUI_Test.Services;
using Budderfly_MAUI_Test.ViewModels;
using Budderfly_MAUI_Test.Views;
using Microsoft.Extensions.Logging;

namespace Budderfly_MAUI_Test
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            //Services
            builder.Services.AddTransient<EnergySavingTipDAL>();
            builder.Services.AddTransient<ImageService>();
            
            //ViewModels
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<EnergySavingTipEntryViewModel>();

            //Views
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<EnergySavingTipEntryPage>();

            return builder.Build();
        }
    }
}
