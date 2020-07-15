using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Markup;
using static Xamarin.Forms.Markup.GridRowsColumns;
using static XamConverter.Views.MarkupExtensions;

namespace XamConverter
{
    class ConversionPage : BaseContentPage<ConversionViewModel>
    {
        public ConversionPage()
        {
            BackgroundColor = ColorConstants.LightPurple;
            ViewModel.ConversionError += HandleConversionError;

            this.Bind(nameof(ConversionViewModel.TitleText));

            Content = new Grid
            {
                ColumnSpacing = 20,

                RowDefinitions = Rows.Define(
                    (Row.UnitType, Star),
                    (Row.NumberToConvert, Star),
                    (Row.OriginalUnits, Star),
                    (Row.ConvertedUnits, Star),
                    (Row.ConvertedNumber, Star),
                    (Row.ConvertButton, Stars(2))),

                ColumnDefinitions = Columns.Define(
                    (Column.Label, Star),
                    (Column.Input, Star)),

                Children =
                {
                    new DarkPurpleLabel("Unit Type")
                       .Row(Row.UnitType).Column(Column.Label),

                    new UnitsPicker("Unit Type")
                       .Row(Row.UnitType).Column(Column.Input)
                       .Bind(Picker.ItemsSourceProperty, nameof(ConversionViewModel.UnitTypePickerList))
                       .Bind(UnitsPicker.SelectedIndexChangedCommandProperty, nameof(ConversionViewModel.UnitTypePickerSelectedIndexChangedCommand))
                       .Bind(nameof(ConversionViewModel.UnitTypePickerSelectedIndex)),

                    new DarkPurpleLabel("Number to Convert")
                       .Row(Row.NumberToConvert).Column(Column.Label),

                    new NumberToConvertEntry()
                       .Row(Row.NumberToConvert).Column(Column.Input)
                       .Bind(nameof(ConversionViewModel.NumberToConvertEntryText)),

                    new DarkPurpleLabel("Original Units")
                       .Row(Row.OriginalUnits).Column(Column.Label),

                    new UnitsPicker("Original Units")
                       .Row(Row.OriginalUnits).Column(Column.Input)
                       .Bind(Picker.ItemsSourceProperty, nameof(ConversionViewModel.OriginalUnitsPickerList))
                       .Bind(UnitsPicker.SelectedIndexChangedCommandProperty, nameof(ConversionViewModel.OriginalUnitsPickerSelectedIndexChangedCommand))
                       .Bind(Picker.SelectedItemProperty, nameof(ConversionViewModel.OriginalUnitsPickerSelectedItem)),

                    new DarkPurpleLabel("Converted Units")
                       .Row(Row.ConvertedUnits).Column(Column.Label),

                    new UnitsPicker("Converted Units")
                       .Row(Row.ConvertedUnits).Column(Column.Input)
                       .Bind(Picker.ItemsSourceProperty, nameof(ConversionViewModel.ConvertedUnitsPickerList))
                       .Bind(UnitsPicker.SelectedIndexChangedCommandProperty, nameof(ConversionViewModel.ConvertedUnitsPickerSelectedIndexChangedCommand))
                       .Bind(Picker.SelectedItemProperty, nameof(ConversionViewModel.ConvertedUnitsPickerSelectedItem)),

                    new DarkPurpleLabel("")
                       .Row(Row.ConvertedNumber).ColumnSpan(All<Column>()).TextCenterHorizontal()
                       .Bind(Label.TextProperty, nameof(ConversionViewModel.ConvertedNumberLabelText)),

                    new ConvertButton()
                       .Row(Row.ConvertButton).ColumnSpan(All<Column>()).FillExpandHorizontal()
                       .Bind(Button.CommandProperty, nameof(ConversionViewModel.ConvertButtonCommand))
                }
            }.Center();
        }

        enum Row { UnitType, NumberToConvert, OriginalUnits, ConvertedUnits, ConvertedNumber, ConvertButton };
        enum Column { Label, Input };

        void HandleConversionError(object sender, string message) =>
            MainThread.BeginInvokeOnMainThread(async () => await DisplayAlert("Conversion Error", message, "OK"));

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

        class ConvertButton : BounceButton
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
