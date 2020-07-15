using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Markup;
using static Xamarin.Forms.Markup.GridRowsColumns;
using static XamConverter.MarkupExtensions;

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
                       .Bind(Picker.SelectedIndexProperty, nameof(ConversionViewModel.UnitTypePickerSelectedIndex))
                       .Bind(UnitsPicker.SelectedIndexChangedCommandProperty, nameof(ConversionViewModel.UnitTypePickerSelectedIndexChangedCommand)),

                    new DarkPurpleLabel("Number to Convert")
                       .Row(Row.NumberToConvert).Column(Column.Label),

                    new NumberToConvertEntry()
                       .Row(Row.NumberToConvert).Column(Column.Input)
                       .Bind(Entry.TextProperty, nameof(ConversionViewModel.NumberToConvertEntryText)),

                    new DarkPurpleLabel("Original Units")
                       .Row(Row.OriginalUnits).Column(Column.Label),

                    new UnitsPicker("Original Units")
                       .Row(Row.OriginalUnits).Column(Column.Input)
                       .Bind(Picker.ItemsSourceProperty, nameof(ConversionViewModel.OriginalUnitsPickerList))
                       .Bind(Picker.SelectedItemProperty, nameof(ConversionViewModel.OriginalUnitsPickerSelectedItem))
                       .Bind(UnitsPicker.SelectedIndexChangedCommandProperty, nameof(ConversionViewModel.OriginalUnitsPickerSelectedIndexChangedCommand)),

                    new DarkPurpleLabel("Converted Units")
                       .Row(Row.ConvertedUnits).Column(Column.Label),

                    new UnitsPicker("Converted Units")
                       .Row(Row.ConvertedUnits).Column(Column.Input)
                       .Bind(Picker.ItemsSourceProperty, nameof(ConversionViewModel.ConvertedUnitsPickerList))
                       .Bind(Picker.SelectedItemProperty, nameof(ConversionViewModel.ConvertedUnitsPickerSelectedItem))
                       .Bind(UnitsPicker.SelectedIndexChangedCommandProperty, nameof(ConversionViewModel.ConvertedUnitsPickerSelectedIndexChangedCommand)),

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
