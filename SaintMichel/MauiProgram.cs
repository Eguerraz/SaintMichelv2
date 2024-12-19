using Microsoft.Maui.Controls.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SaintMichel
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Enregistrement des services dans le conteneur DI
            builder.Services.AddSingleton<OffrePro_API>(); // Service API OffrePro
            builder.Services.AddSingleton<Event_API>(); // Service API Event

            builder.Services.AddSingleton<OffreProPageViewModel>(); // ViewModel OffrePro
            builder.Services.AddTransient<EventPageViewModel>(); // ViewModel Event
            builder.Services.AddTransient<EventPage>(); // View Event



            return builder.Build();
        }
    }
}
