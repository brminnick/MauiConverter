using System;

using Xamarin.Forms;

namespace XamConverter
{
    public class UnitsPicker : Picker
    {
        public UnitsPicker()
        {
            BackgroundColor = ColorConstants.LightestPurple;
            SelectedIndexChanged += HandleSelectedIndexChanged;
        }

        public static readonly BindableProperty SelectedIndexChangedCommandProperty =
            BindableProperty.Create(nameof(SelectedIndexChangedCommand), typeof(Command), typeof(UnitsPicker), null);

        public Command SelectedIndexChangedCommand
        {
            get => (Command)GetValue(SelectedIndexChangedCommandProperty);
            set => SetValue(SelectedIndexChangedCommandProperty, value);
        }

        void HandleSelectedIndexChanged(object sender, EventArgs e) => SelectedIndexChangedCommand?.Execute(null);
    }
}
