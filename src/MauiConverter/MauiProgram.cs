using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;

namespace MauiConverter;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder()
                        .UseMauiApp<App>()
                        .UseMauiCommunityToolkit()
                        .UseMauiCommunityToolkitMarkup();

        // Add Shell
        builder.Services.AddSingleton<AppShell>();

        // Add Pages + Viewmodels
        builder.Services.AddTransientWithShellRoute<ConversionPage, ConversionViewModel>();

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

    static IServiceCollection AddTransientWithShellRoute<TPage, TViewModel>(this IServiceCollection services)
        where TPage : BaseContentPage<TViewModel>
        where TViewModel : BaseViewModel
    {
        return services.AddTransientWithShellRoute<TPage, TViewModel>(AppShell.GetRoute<TPage, TViewModel>());
    }
}