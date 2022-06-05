using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace XamConverter;

public class App : Microsoft.Maui.Controls.Application
{
    public App()
    {
        var mainPage = new Microsoft.Maui.Controls.NavigationPage(new ConversionPage())
        {
            BarBackgroundColor = ColorConstants.DarkPurple,
            BarTextColor = Colors.White
        };

        mainPage.On<Microsoft.Maui.Controls.PlatformConfiguration.iOS>().SetPrefersLargeTitles(true);

        MainPage = mainPage;
    }
}
