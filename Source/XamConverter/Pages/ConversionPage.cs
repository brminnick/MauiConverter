using Xamarin.Forms;
using Xamarin.Forms.Markup;
using static Xamarin.Forms.Markup.GridRowsColumns;

namespace XamConverter
{
    class ConversionPage : BaseContentPage<ConversionViewModel>
    {
        public ConversionPage()
        {
            ViewModel.ConversionError += HandleConversionError;

            this.SetBinding(TitleProperty, nameof(ConversionViewModel.TitleText));

            BackgroundColor = ColorConstants.LightPurple;

            Content = new Grid
            {
                ColumnSpacing = 20,

                RowDefinitions = Rows.Define(
                    (Row.UnitType, new GridLength(1, GridUnitType.Star)),
                    (Row.NumberToConvert, new GridLength(1, GridUnitType.Star)),
                    (Row.OriginalUnits, new GridLength(1, GridUnitType.Star)),
                    (Row.ConvertedUnits, new GridLength(1, GridUnitType.Star)),
                    (Row.ConvertedNumber, new GridLength(1, GridUnitType.Star)),
                    (Row.ConvertButton, new GridLength(2, GridUnitType.Star))),

                ColumnDefinitions = Columns.Define(
                    (Column.Label, new GridLength(1, GridUnitType.Star)),
                    (Column.Input, new GridLength(1, GridUnitType.Star))),

                Children =
                {
                    new DarkPurpleLabel("Unit Type").Row(Row.UnitType).Column(Column.Label),

                    new UnitsPicker("Unit Type").Row(Row.UnitType).Column(Column.Input)
                        .Bind(Picker.ItemsSourceProperty, nameof(ConversionViewModel.UnitTypePickerList))
                        .Bind(Picker.SelectedIndexProperty, nameof(ConversionViewModel.UnitTypePickerSelectedIndex))
                        .Bind(UnitsPicker.SelectedIndexChangedCommandProperty, nameof(ConversionViewModel.UnitTypePickerSelectedIndexChangedCommand)),

                    new DarkPurpleLabel("Number to Convert").Row(Row.NumberToConvert).Column(Column.Label),

                    new NumberToConvertEntry().Row(Row.NumberToConvert).Column(Column.Input)
                        .Bind(Entry.TextProperty, nameof(ConversionViewModel.NumberToConvertEntryText)),

                    new DarkPurpleLabel("Original Units").Row(Row.OriginalUnits).Column(Column.Label),

                    new UnitsPicker("Original Units").Row(Row.OriginalUnits).Column(Column.Input)
                        .Bind(Picker.ItemsSourceProperty, nameof(ConversionViewModel.OriginalUnitsPickerList))
                        .Bind(Picker.SelectedItemProperty, nameof(ConversionViewModel.OriginalUnitsPickerSelectedItem))
                        .Bind(UnitsPicker.SelectedIndexChangedCommandProperty, nameof(ConversionViewModel.OriginalUnitsPickerSelectedIndexChangedCommand)),

                    new DarkPurpleLabel("Converted Units").Row(Row.ConvertedUnits).Column(Column.Label),

                    new UnitsPicker("Converted Units").Row(Row.ConvertedUnits).Column(Column.Input)
                        .Bind(Picker.ItemsSourceProperty, nameof(ConversionViewModel.ConvertedUnitsPickerList))
                        .Bind(Picker.SelectedItemProperty, nameof(ConversionViewModel.ConvertedUnitsPickerSelectedItem))
                        .Bind(UnitsPicker.SelectedIndexChangedCommandProperty, nameof(ConversionViewModel.ConvertedUnitsPickerSelectedIndexChangedCommand)),

                    new DarkPurpleLabel(""){ HorizontalTextAlignment = TextAlignment.Center }.Row(Row.ConvertedNumber).ColumnSpan(2)
                        .Bind(Label.TextProperty, nameof(ConversionViewModel.ConvertedNumberLabelText)),

                    new ConvertButton().FillExpandHorizontal().Row(Row.ConvertButton).ColumnSpan(2)
                        .Bind(Button.CommandProperty, nameof(ConversionViewModel.ConvertButtonCommand))
                }
            }.Center();
        }

        void HandleConversionError(object sender, string message) =>
            Device.BeginInvokeOnMainThread(async () => await DisplayAlert("Conversion Error", message, "OK"));

        enum Row { UnitType, NumberToConvert, OriginalUnits, ConvertedUnits, ConvertedNumber, ConvertButton };
        enum Column { Label, Input };

        class NumberToConvertEntry : Entry
        {
            public NumberToConvertEntry()
            {
                TextColor = Color.Black;
                Keyboard = Keyboard.Numeric;
                Placeholder = "Enter Number";
                BackgroundColor = ColorConstants.LightestPurple;
            }
        }

        class ConvertButton : Button
        {
            public ConvertButton()
            {
                Text = "Convert";
                TextColor = Color.White;
                Margin = 20;
                BackgroundColor = ColorConstants.DarkPurple;
            }
        }
    }
}
