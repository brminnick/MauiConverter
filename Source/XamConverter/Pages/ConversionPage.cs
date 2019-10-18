using Xamarin.Forms;

namespace XamConverter
{
    class ConversionPage : BaseContentPage<ConversionViewModel>
    {
        public ConversionPage()
        {
            ViewModel.ConversionError += HandleConversionError;

            var unitTypeLabel = new DarkPurpleLabel { Text = "Unit Type" };

            var unitTypePicker = new UnitsPicker { Title = "Unit Type" };
            unitTypePicker.SetBinding(Picker.ItemsSourceProperty, nameof(ConversionViewModel.UnitTypePickerList));
            unitTypePicker.SetBinding(Picker.SelectedIndexProperty, nameof(ConversionViewModel.UnitTypePickerSelectedIndex));
            unitTypePicker.SetBinding(UnitsPicker.SelectedIndexChangedCommandProperty, nameof(ConversionViewModel.UnitTypePickerSelectedIndexChangedCommand));

            var numberToConvertLabel = new DarkPurpleLabel { Text = "Number to Convert" };

            var numberToConvertEntry = new Entry
            {
                TextColor = Color.Black,
                Keyboard = Keyboard.Numeric,
                Placeholder = "Enter Number",
                BackgroundColor = ColorConstants.LightestPurple
            };
            numberToConvertEntry.SetBinding(Entry.TextProperty, nameof(ConversionViewModel.NumberToConvertEntryText));

            var originalUnitsLabel = new DarkPurpleLabel { Text = "Original Units" };

            var originalUnitsPicker = new UnitsPicker { Title = "Original Units" };
            originalUnitsPicker.SetBinding(Picker.ItemsSourceProperty, nameof(ConversionViewModel.OriginalUnitsPickerList));
            originalUnitsPicker.SetBinding(Picker.SelectedItemProperty, nameof(ConversionViewModel.OriginalUnitsPickerSelectedItem));
            originalUnitsPicker.SetBinding(UnitsPicker.SelectedIndexChangedCommandProperty, nameof(ConversionViewModel.OriginalUnitsPickerSelectedIndexChangedCommand));

            var convertedUnitsLabel = new DarkPurpleLabel { Text = "Converted Units" };

            var convertedUnitsPicker = new UnitsPicker { Title = "Converted Units" };
            convertedUnitsPicker.SetBinding(Picker.ItemsSourceProperty, nameof(ConversionViewModel.ConvertedUnitsPickerList));
            convertedUnitsPicker.SetBinding(Picker.SelectedItemProperty, nameof(ConversionViewModel.ConvertedUnitsPickerSelectedItem));
            convertedUnitsPicker.SetBinding(UnitsPicker.SelectedIndexChangedCommandProperty, nameof(ConversionViewModel.ConvertedUnitsPickerSelectedIndexChangedCommand));

            var convertButton = new BounceButton
            {
                Text = "Convert",
                TextColor = Color.White,
                Margin = 20,
                BackgroundColor = ColorConstants.DarkPurple,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            convertButton.SetBinding(Button.CommandProperty, nameof(ConversionViewModel.ConvertButtonCommand));

            var convertedNumberLabel = new DarkPurpleLabel { HorizontalTextAlignment = TextAlignment.Center };
            convertedNumberLabel.SetBinding(Label.TextProperty, nameof(ConversionViewModel.ConvertedNumberLabelText));

            this.SetBinding(TitleProperty, nameof(ConversionViewModel.TitleText));

            BackgroundColor = ColorConstants.LightPurple;

            var gridLayout = new Grid
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                ColumnSpacing = 20,

                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },

                RowDefinitions = {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) }
                }
            };

            gridLayout.Children.Add(unitTypeLabel, 0, 0);
            gridLayout.Children.Add(unitTypePicker, 1, 0);

            gridLayout.Children.Add(numberToConvertLabel, 0, 1);
            gridLayout.Children.Add(numberToConvertEntry, 1, 1);

            gridLayout.Children.Add(originalUnitsLabel, 0, 2);
            gridLayout.Children.Add(originalUnitsPicker, 1, 2);

            gridLayout.Children.Add(convertedUnitsLabel, 0, 3);
            gridLayout.Children.Add(convertedUnitsPicker, 1, 3);

            gridLayout.Children.Add(convertedNumberLabel, 0, 4);
            Grid.SetColumnSpan(convertedNumberLabel, 2);

            gridLayout.Children.Add(convertButton, 0, 5);
            Grid.SetColumnSpan(convertButton, 2);

            Content = gridLayout;
        }

        void HandleConversionError(object sender, string message) =>
            Device.BeginInvokeOnMainThread(async () => await DisplayAlert("Conversion Error", message, "OK"));
    }
}
