using System;

using Xamarin.Forms;

namespace XamConverter
{
    public class BounceButton : Button
    {
        public BounceButton() : base() =>
            Clicked += HandleButtonClick;

        ~BounceButton() => Clicked -= HandleButtonClick;

        void HandleButtonClick(object sender, EventArgs e)
        {
            var bounceButton = sender as BounceButton;

            Device.BeginInvokeOnMainThread(async () =>
            {
                Unfocus();
                await bounceButton?.ScaleTo(1.05, 100);
                await bounceButton?.ScaleTo(1, 100);
            });
        }
    }
}

