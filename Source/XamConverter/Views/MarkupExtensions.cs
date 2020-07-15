using Xamarin.Forms;

namespace XamConverter
{
    public static class MarkupExtensions
    {
        public static GridLength Stars(double value) => new GridLength(value, GridUnitType.Star);
    }
}
