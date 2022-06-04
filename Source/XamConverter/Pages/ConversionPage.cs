using CommunityToolkit.Maui.Markup;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace XamConverter;

class ConversionPage : BaseContentPage<ConversionViewModel>
{
    public ConversionPage()
    {
        BackgroundColor = ColorConstants.LightPurple;
        ViewModel.ConversionError += HandleConversionError;

        this.Bind(TitleProperty, nameof(ConversionViewModel.TitleText));

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
                   .Bind(Picker.ItemsSourceProperty, nameof(ConversionViewModel.UnitTypePickerList), BindingMode.OneTime)
                   .Bind(Picker.SelectedIndexProperty, nameof(ConversionViewModel.UnitTypePickerSelectedIndex))
                   .Bind(UnitsPicker.SelectedIndexChangedCommandProperty, nameof(ConversionViewModel.UnitTypePickerSelectedIndexChangedCommand), BindingMode.OneTime),

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
                   .Bind(UnitsPicker.SelectedIndexChangedCommandProperty, nameof(ConversionViewModel.OriginalUnitsPickerSelectedIndexChangedCommand), BindingMode.OneTime),

                new DarkPurpleLabel("Converted Units")
                   .Row(Row.ConvertedUnits).Column(Column.Label),

                new UnitsPicker("Converted Units")
                   .Row(Row.ConvertedUnits).Column(Column.Input)
                   .Bind(Picker.ItemsSourceProperty, nameof(ConversionViewModel.ConvertedUnitsPickerList))
                   .Bind(Picker.SelectedItemProperty, nameof(ConversionViewModel.ConvertedUnitsPickerSelectedItem))
                   .Bind(UnitsPicker.SelectedIndexChangedCommandProperty, nameof(ConversionViewModel.ConvertedUnitsPickerSelectedIndexChangedCommand), BindingMode.OneTime),

                new DarkPurpleLabel("")
                   .Row(Row.ConvertedNumber).ColumnSpan(All<Column>()).TextCenterHorizontal()
                   .Bind(Label.TextProperty, nameof(ConversionViewModel.ConvertedNumberLabelText)),

                new ConvertButton()
                   .Row(Row.ConvertButton).ColumnSpan(All<Column>()).FillHorizontal()
                   .Bind(Button.CommandProperty, nameof(ConversionViewModel.ConvertButtonCommand), BindingMode.OneTime)
            }
        }.Center();
    }

    enum Row { UnitType, NumberToConvert, OriginalUnits, ConvertedUnits, ConvertedNumber, ConvertButton };
    enum Column { Label, Input };

    async void HandleConversionError(object? sender, string message) =>
        await MainThread.InvokeOnMainThreadAsync(() => DisplayAlert("Conversion Error", message, "OK"));

    class NumberToConvertEntry : Entry
    {
        public NumberToConvertEntry()
        {
            TextColor = Colors.Black;
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
            TextColor = Colors.White;
            Margin = 20;
            BackgroundColor = ColorConstants.DarkPurple;
        }
    }
}
