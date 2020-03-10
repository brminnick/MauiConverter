using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace XamConverter
{
	public class App : Xamarin.Forms.Application
	{
		public App()
		{
			Device.SetFlags(new[] { "Markup_Experimental" });

            var mainPage = new Xamarin.Forms.NavigationPage(new ConversionPage())
			{
				BarBackgroundColor = ColorConstants.DarkPurple,
				BarTextColor = Color.White
			};

            mainPage.On<iOS>().SetPrefersLargeTitles(true);

            MainPage = mainPage;
		}
	}
}
