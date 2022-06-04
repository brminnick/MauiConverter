using System.Text;
using System.Windows.Input;

namespace XamConverter
{
    class ConversionViewModel : BaseViewModel
    {
        readonly static IReadOnlyDictionary<string, UnitOfMeasurementModel> _unitOfMeasurementDictionary = new Dictionary<string, UnitOfMeasurementModel>
        {
            { nameof(Celsius), Celsius.Instance },
            { nameof(Fahrenheit), Fahrenheit.Instance },
            { nameof(Feet), Feet.Instance },
            { nameof(Kelvin), Kelvin.Instance },
            { nameof(Kilograms), Kilograms.Instance },
            { nameof(Kilometers), Kilometers.Instance },
            { nameof(Meters), Meters.Instance },
            { nameof(Ounces), Ounces.Instance },
            { nameof(Miles), Miles.Instance },
            { nameof(Pounds), Pounds.Instance },
            { nameof(Yards), Yards.Instance },
        };

        readonly WeakEventManager _conversionErrorEventManager = new();

        int _unitTypePickerSelectedIndex;

        string _numberToConvertEntryText = 0.ToString(),
                _convertedNumberLabelText = string.Empty,
                _originalUnitsPickerSelectedItem = string.Empty,
                _convertedUnitsPickerSelectedItem = string.Empty,
                _titleText = string.Empty;

        IReadOnlyList<string> _originalUnitsPickerList = Enumerable.Empty<string>().ToList(),
                                _convertedUnitsPickerList = Enumerable.Empty<string>().ToList();

        public ConversionViewModel()
        {
            var temp = Kelvin.Instance;
            UnitOfMeasurement initialUnitOfMeasurement = 0;

            ConvertButtonCommand = new Command(ExecuteConvertButtonCommand);
            UnitTypePickerSelectedIndexChangedCommand = new Command(ExecuteUnitTypePickerSelectedIndexChangedCommand);
            OriginalUnitsPickerSelectedIndexChangedCommand = new Command(ExecuteOriginalUnitsPickerSelectedIndexChangedCommand);
            ConvertedUnitsPickerSelectedIndexChangedCommand = new Command(ExecuteConvertedUnitsPickerSelectedIndexChangedCommand);

            PopulateUnitsPickerLists(initialUnitOfMeasurement);
            SetTitleText(initialUnitOfMeasurement);
        }

        public event EventHandler<string> ConversionError
        {
            add => _conversionErrorEventManager.AddEventHandler(value);
            remove => _conversionErrorEventManager.RemoveEventHandler(value);
        }

        public IReadOnlyList<string> UnitTypePickerList { get; } = Enum.GetNames(typeof(UnitOfMeasurement));

        public ICommand ConvertButtonCommand { get; }
        public ICommand UnitTypePickerSelectedIndexChangedCommand { get; }
        public ICommand OriginalUnitsPickerSelectedIndexChangedCommand { get; }
        public ICommand ConvertedUnitsPickerSelectedIndexChangedCommand { get; }

        public IReadOnlyList<string> OriginalUnitsPickerList
        {
            get => _originalUnitsPickerList;
            set => SetProperty(ref _originalUnitsPickerList, value);
        }

        public IReadOnlyList<string> ConvertedUnitsPickerList
        {
            get => _convertedUnitsPickerList;
            set => SetProperty(ref _convertedUnitsPickerList, value);
        }

        public string TitleText
        {
            get => _titleText;
            set => SetProperty(ref _titleText, value);
        }

        public string NumberToConvertEntryText
        {
            get => _numberToConvertEntryText;
            set => SetProperty(ref _numberToConvertEntryText, value, ExecuteNumberToConvertEntryTextChanged);
        }

        public string ConvertedNumberLabelText
        {
            get => _convertedNumberLabelText;
            set => SetProperty(ref _convertedNumberLabelText, value);
        }

        public string OriginalUnitsPickerSelectedItem
        {
            get => _originalUnitsPickerSelectedItem;
            set => SetProperty(ref _originalUnitsPickerSelectedItem, value);
        }

        public int UnitTypePickerSelectedIndex
        {
            get => _unitTypePickerSelectedIndex;
            set => SetProperty(ref _unitTypePickerSelectedIndex, value);
        }

        public string ConvertedUnitsPickerSelectedItem
        {
            get => _convertedUnitsPickerSelectedItem;
            set => SetProperty(ref _convertedUnitsPickerSelectedItem, value);
        }

        void PopulateUnitsPickerLists(UnitOfMeasurement unitOfMeasurement)
        {
            var originalUnitsPickerList = new List<string>();
            var convertedUnitsPickerList = new List<string>();

            var listOfSelectedUnits = _unitOfMeasurementDictionary.Where(x => x.Value.MeasurementType.Equals(unitOfMeasurement));

            foreach (var item in listOfSelectedUnits)
            {
                originalUnitsPickerList.Add(item.Key);
                convertedUnitsPickerList.Add(item.Key);
            }

            OriginalUnitsPickerList = originalUnitsPickerList;
            ConvertedUnitsPickerList = convertedUnitsPickerList;
        }

        void ExecuteOriginalUnitsPickerSelectedIndexChangedCommand()
        {
            if (IsConvertedUnitsPickerSelectedItemValid()
                && IsNumberToConvertEntryTextValid())
            {
                ConvertUnits();
            }
        }

        void ExecuteConvertedUnitsPickerSelectedIndexChangedCommand()
        {
            if (IsOriginalUnitsPickerSelectedItemValid()
                && IsNumberToConvertEntryTextValid())
            {
                ConvertUnits();
            }
        }

        void ExecuteUnitTypePickerSelectedIndexChangedCommand()
        {
            var selectedUnitOfMeasurement = (UnitOfMeasurement)UnitTypePickerSelectedIndex;
            PopulateUnitsPickerLists(selectedUnitOfMeasurement);

            SetTitleText(selectedUnitOfMeasurement);
        }

        void SetTitleText(UnitOfMeasurement unitOfMeasurement) => TitleText = $"Convert {unitOfMeasurement}";

        void ExecuteConvertButtonCommand()
        {
            if (!IsOriginalUnitsPickerSelectedItemValid()
                || !IsConvertedUnitsPickerSelectedItemValid()
                || !IsNumberToConvertEntryTextValid())
            {
                var errorStringBuilder = new StringBuilder();

                if (!IsNumberToConvertEntryTextValid())
                    errorStringBuilder.AppendLine("Number to Convert Invalid");
                if (!IsOriginalUnitsPickerSelectedItemValid())
                    errorStringBuilder.AppendLine("Original Unit Not Selected");
                if (!IsConvertedUnitsPickerSelectedItemValid())
                    errorStringBuilder.AppendLine("Converted Unit Not Selected");

                errorStringBuilder.Remove(errorStringBuilder.Length - 1, 1);

                OnConversionError(errorStringBuilder.ToString());
            }
            else
            {
                ConvertUnits();
            }
        }

        void ExecuteNumberToConvertEntryTextChanged()
        {
            if (!string.IsNullOrWhiteSpace(OriginalUnitsPickerSelectedItem)
                && !string.IsNullOrWhiteSpace(ConvertedUnitsPickerSelectedItem)
                && !string.IsNullOrWhiteSpace(NumberToConvertEntryText))
            {
                ConvertUnits();
            }
        }

        void ConvertUnits()
        {
            try
            {
                var numberToConvert = double.Parse(NumberToConvertEntryText);

                var firstItemSelectedType = _unitOfMeasurementDictionary[OriginalUnitsPickerSelectedItem];
                var secondItemSelectedType = _unitOfMeasurementDictionary[ConvertedUnitsPickerSelectedItem];

                var inputAsBaseUnits = firstItemSelectedType.ConvertToBaseUnits(numberToConvert);

                var inputAsConvertedUnits = secondItemSelectedType.ConvertFromBaseUnits(inputAsBaseUnits);

                ConvertedNumberLabelText = $"{NumberToConvertEntryText} {OriginalUnitsPickerSelectedItem} = {inputAsConvertedUnits:N3} {ConvertedUnitsPickerSelectedItem}";
            }
            catch
            {
                ConvertedNumberLabelText = string.Empty;
            }
        }

        bool IsNumberToConvertEntryTextValid() => double.TryParse(NumberToConvertEntryText, out _);
        bool IsOriginalUnitsPickerSelectedItemValid() => !string.IsNullOrWhiteSpace(OriginalUnitsPickerSelectedItem);
        bool IsConvertedUnitsPickerSelectedItemValid() => !string.IsNullOrWhiteSpace(ConvertedUnitsPickerSelectedItem);

        void OnConversionError(string message) => _conversionErrorEventManager.HandleEvent(this, message, nameof(ConversionError));
    }
}
