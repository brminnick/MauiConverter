using Xamarin.Forms;

namespace XamConverter
{
	public class ConversionPage : BaseContentPage<ConversionViewModel>
	{
		public ConversionPage()
		{
			var unitTypeLabel = new DarkPurpleLabel { Text = "Unit Type", TextColor = ColorConstants.DarkestPurple };

			var unitTypePicker = new UnitsPicker
			{
				Title = "Unit Type"
			};
			unitTypePicker.SetBinding(Picker.ItemsSourceProperty, nameof(ViewModel.UnitTypePickerList));
			unitTypePicker.SetBinding(Picker.SelectedIndexProperty, nameof(ViewModel.UnitTypePickerSelectedIndex));
			unitTypePicker.SetBinding(UnitsPicker.SelectedIndexChangedCommandProperty, nameof(ViewModel.UnitTypePickerSelectedIndexChangedCommand));

			var numberToConvertLabel = new DarkPurpleLabel { Text = "Number to Convert", TextColor = ColorConstants.DarkestPurple };

			var numberToConvertEntry = new Entry
			{
				Keyboard = Keyboard.Numeric,
				Placeholder = "Enter Number",
				BackgroundColor = ColorConstants.LightestPurple
			};
			numberToConvertEntry.SetBinding(Entry.TextProperty, nameof(ViewModel.NumberToConvertEntryText));

			var originalUnitsLabel = new DarkPurpleLabel { Text = "Original Units", TextColor = ColorConstants.DarkestPurple };

			var originalUnitsPicker = new UnitsPicker { Title = "Original Units" };
			originalUnitsPicker.SetBinding(Picker.ItemsSourceProperty, nameof(ViewModel.OriginalUnitsPickerList));
			originalUnitsPicker.SetBinding(Picker.SelectedItemProperty, nameof(ViewModel.OriginalUnitsPickerSelectedItem));
			originalUnitsPicker.SetBinding(UnitsPicker.SelectedIndexChangedCommandProperty, nameof(ViewModel.OriginalUnitsPickerSelectedIndexChangedCommand));

			var convertedUnitsLabel = new DarkPurpleLabel { Text = "Converted Units", TextColor = ColorConstants.DarkestPurple };

			var convertedUnitsPicker = new UnitsPicker { Title = "Converted Units" };
			convertedUnitsPicker.SetBinding(Picker.ItemsSourceProperty, nameof(ViewModel.ConvertedUnitsPickerList));
			convertedUnitsPicker.SetBinding(Picker.SelectedItemProperty, nameof(ViewModel.ConvertedUnitsPickerSelectedItem));
			convertedUnitsPicker.SetBinding(UnitsPicker.SelectedIndexChangedCommandProperty, nameof(ViewModel.ConvertedUnitsPickerSelectedIndexChangedCommand));

			var convertButton = new Button
			{
				Text = "Convert",
				TextColor = Color.White,
				Margin = 20,
				BackgroundColor = ColorConstants.DarkPurple,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			convertButton.SetBinding(Button.CommandProperty, nameof(ViewModel.ConvertButtonCommand));

			var convertedNumberLabel = new DarkPurpleLabel { HorizontalTextAlignment = TextAlignment.Center };
			convertedNumberLabel.SetBinding(Label.TextProperty, nameof(ViewModel.ConvertedNumberLabelText));

			this.SetBinding(TitleProperty, nameof(ViewModel.TitleText));

			BackgroundColor = ColorConstants.LightPurple;

			var gridLayout = new Grid
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,

				ColumnSpacing = 20,

				RowDefinitions = {
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
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

			gridLayout.Children.Add(convertButton, 0, 4);
			Grid.SetColumnSpan(convertButton, 2);

			gridLayout.Children.Add(convertedNumberLabel, 0, 5);
			Grid.SetColumnSpan(convertedNumberLabel, 2);

			Content = gridLayout;
		}
	}
}
