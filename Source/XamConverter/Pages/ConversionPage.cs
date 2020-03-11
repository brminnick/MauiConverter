using Xamarin.Forms;
using Xamarin.Forms.Markup;
using static Xamarin.Forms.Markup.GridRowsColumns;

namespace XamConverter
{
    partial class ConversionPage
    {
        enum Row { UnitType, NumberToConvert, OriginalUnits, ConvertedUnits, ConvertedNumber, ConvertButton };
        enum Column { Label, Input };
        
        void Build()
        {
            var vm = ViewModel;
            BackgroundColor = ColorConstants.LightPurple;
            this.Bind(nameof(vm.TitleText));

            Content = new Grid {
                ColumnSpacing = 20,

                RowDefinitions = Rows.Define (
                    (Row.UnitType, Star),
                    (Row.NumberToConvert, Star),
                    (Row.OriginalUnits, Star),
                    (Row.ConvertedUnits, Star),
                    (Row.ConvertedNumber, Star),
                    (Row.ConvertButton, new GridLength(2, GridUnitType.Star))),

                ColumnDefinitions = Columns.Define (
                    (Column.Label, Star),
                    (Column.Input, Star)),

                Children = {
                    new DarkPurpleLabel ("Unit Type")
                        .Row (Row.UnitType) .Column (Column.Label),

                    new UnitsPicker ("Unit Type")
                        .Row (Row.UnitType) .Column (Column.Input)
                        .Bind (Picker.ItemsSourceProperty, nameof(vm.UnitTypePickerList))
                        .Bind (Picker.SelectedIndexProperty, nameof(vm.UnitTypePickerSelectedIndex))
                        .Bind (UnitsPicker.SelectedIndexChangedCommandProperty, nameof(vm.UnitTypePickerSelectedIndexChangedCommand)),

                    new DarkPurpleLabel ("Number to Convert")
                        .Row (Row.NumberToConvert) .Column (Column.Label),

                    new NumberToConvertEntry ()
                        .Row (Row.NumberToConvert) .Column(Column.Input)
                        .Bind (Entry.TextProperty, nameof(vm.NumberToConvertEntryText)),

                    new DarkPurpleLabel ("Original Units")
                        .Row (Row.OriginalUnits) .Column (Column.Label),

                    new UnitsPicker ("Original Units")
                        .Row (Row.OriginalUnits) .Column (Column.Input)
                        .Bind (Picker.ItemsSourceProperty, nameof(vm.OriginalUnitsPickerList))
                        .Bind (Picker.SelectedItemProperty, nameof(vm.OriginalUnitsPickerSelectedItem))
                        .Bind (UnitsPicker.SelectedIndexChangedCommandProperty, nameof(vm.OriginalUnitsPickerSelectedIndexChangedCommand)),

                    new DarkPurpleLabel ("Converted Units")
                        .Row (Row.ConvertedUnits) .Column(Column.Label),

                    new UnitsPicker ("Converted Units")
                        .Row (Row.ConvertedUnits) .Column(Column.Input)
                        .Bind (Picker.ItemsSourceProperty, nameof(vm.ConvertedUnitsPickerList))
                        .Bind (Picker.SelectedItemProperty, nameof(vm.ConvertedUnitsPickerSelectedItem))
                        .Bind (UnitsPicker.SelectedIndexChangedCommandProperty, nameof(vm.ConvertedUnitsPickerSelectedIndexChangedCommand)),

                    new DarkPurpleLabel ("") { HorizontalTextAlignment = TextAlignment.Center }
                        .Row (Row.ConvertedNumber) .ColumnSpan (All<Column>())
                        .Bind (Label.TextProperty, nameof(vm.ConvertedNumberLabelText)),

                    new ConvertButton ()
                        .Row (Row.ConvertButton) .ColumnSpan (All<Column>()) .FillExpandHorizontal()
                        .Bind (Button.CommandProperty, nameof(vm.ConvertButtonCommand))
                }
            } .Center ();
        }

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
