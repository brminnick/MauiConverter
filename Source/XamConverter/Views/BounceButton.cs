using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamConverter
{
    public class BounceButton : Button
    {
        public BounceButton() => Clicked += HandleButtonClick;

        void HandleButtonClick(object sender, EventArgs e)
        {
            var bounceButton = (BounceButton)sender;
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                Unfocus();
                await bounceButton.ScaleTo(1.05, 100);
                await bounceButton.ScaleTo(1, 100);
            });
        }
    }
}

