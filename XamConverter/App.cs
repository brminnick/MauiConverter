using Xamarin.Forms;

namespace ConverterApp
{
	public class App : Application
	{
		public App()
		{
			MainPage = new NavigationPage(new ConversionPage())
			{
				BarBackgroundColor = ColorConstants.DarkPurple,
				BarTextColor = Color.White
			};
		}
	}
}
