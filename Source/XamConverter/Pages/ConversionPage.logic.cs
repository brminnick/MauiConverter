using Xamarin.Forms;

namespace XamConverter
{
    partial class ConversionPage : BaseContentPage<ConversionViewModel>
    {
        public ConversionPage()
        {
            ViewModel.ConversionError += HandleConversionError;
            Build();
        }

        void HandleConversionError(object sender, string message) =>
            Device.BeginInvokeOnMainThread(async () => await DisplayAlert("Conversion Error", message, "OK"));
    }
}
