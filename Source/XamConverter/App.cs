using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace XamConverter;

class App : Microsoft.Maui.Controls.Application
{
    public App(ConversionPage conversionPage)
    {
        var mainPage = new Microsoft.Maui.Controls.NavigationPage(conversionPage)
        {
            BarBackgroundColor = ColorConstants.DarkPurple,
            BarTextColor = Colors.White
        };

        mainPage.On<Microsoft.Maui.Controls.PlatformConfiguration.iOS>().SetPrefersLargeTitles(true);

        MainPage = mainPage;
    }
}
