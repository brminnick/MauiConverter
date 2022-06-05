using CommunityToolkit.Maui.Markup;
using Microsoft.Maui.Dispatching;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace XamConverter;

class ConversionPage : BaseContentPage<ConversionViewModel>
{
    readonly IDispatcher _dispatcher;

    public ConversionPage(IDispatcher dispatcher, ConversionViewModel conversionViewModel) : base(conversionViewModel)
    {
        _dispatcher = dispatcher;

        BackgroundColor = ColorConstants.LightPurple;
        BindingContext.ConversionError += HandleConversionError;

        this.Bind(TitleProperty, nameof(ConversionViewModel.TitleText));

        Content = new Grid
        {
            ColumnSpacing = 20,
            RowSpacing = 8,

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

                new Entry { BackgroundColor = ColorConstants.LightestPurple, Keyboard = Keyboard.Numeric }
                   .Row(Row.NumberToConvert).Column(Column.Input)
                   .Placeholder("Enter Number")
                   .TextColor(Colors.Black)
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

                new Button { BackgroundColor = ColorConstants.DarkPurple }
                   .Row(Row.ConvertButton).ColumnSpan(All<Column>()).FillHorizontal()
                   .Text("Convert", Colors.White)
                   .Margin(20)
                   .Bind(Button.CommandProperty, nameof(ConversionViewModel.ConvertButtonCommand), BindingMode.OneTime)
            }
        }.Center();
    }

    enum Row { UnitType, NumberToConvert, OriginalUnits, ConvertedUnits, ConvertedNumber, ConvertButton };
    enum Column { Label, Input };

    async void HandleConversionError(object? sender, string message) =>
        await _dispatcher.DispatchAsync(() => DisplayAlert("Conversion Error", message, "OK"));
}
