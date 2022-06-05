using System.Windows.Input;

namespace XamConverter;

class UnitsPicker : Picker
{
    public static readonly BindableProperty SelectedIndexChangedCommandProperty =
        BindableProperty.Create(nameof(SelectedIndexChangedCommand), typeof(ICommand), typeof(UnitsPicker), null);

    public UnitsPicker(string title)
    {
        Title = title;
        TextColor = Colors.Black;
        BackgroundColor = ColorConstants.LightestPurple;
        SelectedIndexChanged += HandleSelectedIndexChanged;
    }

    public ICommand? SelectedIndexChangedCommand
    {
        get => (ICommand?)GetValue(SelectedIndexChangedCommandProperty);
        set => SetValue(SelectedIndexChangedCommandProperty, value);
    }

    void HandleSelectedIndexChanged(object? sender, EventArgs e) => SelectedIndexChangedCommand?.Execute(null);
}
