using CommunityToolkit.Maui.Markup;

namespace XamConverter;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder()
                        .UseMauiApp<App>()
                        .UseMauiCommunityToolkitMarkup();

        // Add Pages
        builder.Services.AddTransient<ConversionPage>();

        // Add ViewModels
        builder.Services.AddTransient<ConversionViewModel>();

        // Add Services
        builder.Services.AddSingleton(Feet.Instance);
        builder.Services.AddSingleton(Miles.Instance);
        builder.Services.AddSingleton(Yards.Instance);
        builder.Services.AddSingleton(Kelvin.Instance);
        builder.Services.AddSingleton(Meters.Instance);
        builder.Services.AddSingleton(Ounces.Instance);
        builder.Services.AddSingleton(Pounds.Instance);
        builder.Services.AddSingleton(Celsius.Instance);
        builder.Services.AddSingleton(Kilograms.Instance);
        builder.Services.AddSingleton(Fahrenheit.Instance);
        builder.Services.AddSingleton(Kilometers.Instance);

        return builder.Build();
    }
}