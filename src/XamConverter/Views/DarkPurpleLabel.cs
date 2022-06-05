namespace XamConverter;

class DarkPurpleLabel : Label
{
    public DarkPurpleLabel(in string text)
    {
        Text = text;
        TextColor = ColorConstants.DarkestPurple;
        VerticalTextAlignment = TextAlignment.Center;
    }
}
