namespace XamConverter;

class BounceButton : Button
{
    public BounceButton() => Clicked += HandleButtonClick;

    void HandleButtonClick(object? sender, EventArgs e)
    {
        ArgumentNullException.ThrowIfNull(sender);

        var bounceButton = (BounceButton)sender;
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            Unfocus();
            await bounceButton.ScaleTo(1.05, 100);
            await bounceButton.ScaleTo(1, 100);
        });
    }
}

