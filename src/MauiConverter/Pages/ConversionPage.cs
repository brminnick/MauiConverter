using CommunityToolkit.Maui.Markup;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace MauiConverter;

class ConversionPage : BaseContentPage<ConversionViewModel>
{
    public ConversionPage(ConversionViewModel conversionViewModel) : base(conversionViewModel)
    {
        BackgroundColor = ColorConstants.LightPurple;
        BindingContext.ConversionError += HandleConversionError;

        this.Bind(TitleProperty, nameof(ConversionViewModel.TitleText));

        Content = new Grid
        {
            RowSpacing = 8,
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

                new Entry { Keyboard = Keyboard.Numeric }
                   .Row(Row.NumberToConvert).Column(Column.Input)
                   .Placeholder("Enter Number")
                   .TextColor(Colors.Black)
                   .BackgroundColor(ColorConstants.LightestPurple)
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

                new DarkPurpleLabel()
                   .Row(Row.ConvertedNumber).ColumnSpan(All<Column>()).TextCenterHorizontal()
                   .Bind(Label.TextProperty, nameof(ConversionViewModel.ConvertedNumberLabelText)),

                new BounceButton()
                   .Row(Row.ConvertButton).ColumnSpan(All<Column>()).FillHorizontal()
                   .BackgroundColor(ColorConstants.DarkPurple)
				   .Text("Convert", Colors.White)
                   .Margin(20)
                   .Bind(Button.CommandProperty, nameof(ConversionViewModel.ConvertButtonCommand), BindingMode.OneTime)
            }
        }.Center();
    }

    enum Row { UnitType, NumberToConvert, OriginalUnits, ConvertedUnits, ConvertedNumber, ConvertButton };
    enum Column { Label, Input };

    async void HandleConversionError(object? sender, string message) =>
        await Dispatcher.DispatchAsync(() => DisplayAlert("Conversion Error", message, "OK"));
}
