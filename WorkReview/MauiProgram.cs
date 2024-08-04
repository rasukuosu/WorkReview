using Microsoft.Extensions.Logging;
using WorkReview.Models;

namespace WorkReview
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
            string dbPath = FileAccessHelper.GetLocalFilePath("gazouByte.db3");
            builder.Services.AddSingleton< GazouByteRepositry> (s => ActivatorUtilities.CreateInstance< GazouByteRepositry> (s, dbPath));

           

            return builder.Build();
        }
    }
}
