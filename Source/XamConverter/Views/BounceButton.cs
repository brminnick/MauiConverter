using System;

using Xamarin.Forms;

namespace XamConverter
{
    public class BounceButton : Button
    {
        public BounceButton() => Clicked += HandleButtonClick;

        void HandleButtonClick(object sender, EventArgs e)
        {
            if (sender is BounceButton bounceButton)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    Unfocus();
                    await bounceButton.ScaleTo(1.05, 100);
                    await bounceButton.ScaleTo(1, 100);
                });
            }
        }
    }
}

