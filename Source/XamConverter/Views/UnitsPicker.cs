using System;

using Xamarin.Forms;

namespace XamConverter
{
    public class UnitsPicker : Picker
    {
        #region Properties
        public static readonly BindableProperty SelectedIndexChangedCommandProperty =
            BindableProperty.Create(nameof(SelectedIndexChangedCommand), typeof(Command), typeof(UnitsPicker), null);

        public Command SelectedIndexChangedCommand
        {
            get => (Command)GetValue(SelectedIndexChangedCommandProperty);
            set => SetValue(SelectedIndexChangedCommandProperty, value);
        }
        #endregion

        #region Constructors
        public UnitsPicker()
        {
            BackgroundColor = ColorConstants.LightestPurple;
            SelectedIndexChanged += HandleSelectedIndexChanged;
        }
        #endregion

        #region Finalizers
        ~UnitsPicker() => SelectedIndexChanged -= HandleSelectedIndexChanged;
        #endregion

        #region Methods
        void HandleSelectedIndexChanged(object sender, EventArgs e) =>
            SelectedIndexChangedCommand?.Execute(null);
        #endregion
    }
}
