using Xamarin.Forms;

namespace XamConverter
{
	public class DarkPurpleLabel : Label
	{
		public DarkPurpleLabel(string text)
		{
			Text = text;
			TextColor = ColorConstants.DarkestPurple;
			VerticalTextAlignment = TextAlignment.Center;
		}
	}
}
