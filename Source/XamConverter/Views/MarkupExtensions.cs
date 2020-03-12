using Xamarin.Forms;

namespace XamConverter.Views
{
    public static class MarkupExtensions
    {
        public static GridLength Stars(double value) => new GridLength(value, GridUnitType.Star);
    }
}
