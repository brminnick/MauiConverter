using Xamarin.Forms;

namespace XamConverter
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
