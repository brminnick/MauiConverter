using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using AsyncAwaitBestPractices;
using Xamarin.Forms;

namespace XamConverter
{
    public class ConversionViewModel : BaseViewModel
	{
        #region Constant Fields
        readonly WeakEventManager<string> _conversionErrorEventManager = new WeakEventManager<string>();
		readonly Dictionary<string, UnitOfMeasurementModel> _unitOfMeasurementDictionary = new Dictionary<string, UnitOfMeasurementModel>
		{
			{ "Miles", Miles.Instance },
			{ "Meters", Meters.Instance },
            { "Kilometers", Kilometers.Instance },
            { "Yards", Yards.Instance },
			{ "Pounds", Pounds.Instance },
			{ "Ounces", Ounces.Instance },
			{ "Kilograms", Kilograms.Instance },
			{ "Fahrenheit", Fahrenheit.Instance },
			{ "Celsius", Celsius.Instance }
		};
		#endregion

		#region Fields
		int _unitTypePickerSelectedIndex;
		string _numberToConvertEntryText, _convertedNumberLabelText, _originalUnitsPickerSelectedItem,
			_convertedUnitsPickerSelectedItem, _titleText;
		ICommand _convertButtonCommand, _originalUnitsPickerSelectedIndexChangedCommand,
			_convertedUnitsPickerSelectedIndexChangedCommand, _unitTypePickerSelectedIndexChangedCommand;
		List<string> _originalUnitsPickerList, _convertedUnitsPickerList, _unitTypePickerList;
		#endregion

		#region Constructors
		public ConversionViewModel()
		{
			NumberToConvertEntryText = 0.ToString();

			var initialUnitOfMeasurement = (UnitOfMeasurement)0;

			PopulateUnitTypePickerList();
			PopulateUnitsPickerLists(initialUnitOfMeasurement);
			SetTitleText(initialUnitOfMeasurement);
		}
		#endregion

		#region Events
		public event EventHandler<string> ConversionError
        {
            add => _conversionErrorEventManager.AddEventHandler(value);
            remove => _conversionErrorEventManager.RemoveEventHandler(value);
        }
        #endregion

        #region Properties
        public ICommand ConvertButtonCommand => _convertButtonCommand ??
			(_convertButtonCommand = new Command(ExecuteConvertButtonCommand));

		public ICommand OriginalUnitsPickerSelectedIndexChangedCommand => _originalUnitsPickerSelectedIndexChangedCommand ??
			(_originalUnitsPickerSelectedIndexChangedCommand = new Command(ExecuteOriginalUnitsPickerSelectedIndexChangedCommand));

		public ICommand ConvertedUnitsPickerSelectedIndexChangedCommand => _convertedUnitsPickerSelectedIndexChangedCommand ??
			(_convertedUnitsPickerSelectedIndexChangedCommand = new Command(ExecuteConvertedUnitsPickerSelectedIndexChangedCommand));

		public ICommand UnitTypePickerSelectedIndexChangedCommand => _unitTypePickerSelectedIndexChangedCommand ??
			(_unitTypePickerSelectedIndexChangedCommand = new Command(ExecuteUnitTypePickerSelectedIndexChangedCommand));

		public List<string> UnitTypePickerList
		{
			get => _unitTypePickerList;
			set => SetProperty(ref _unitTypePickerList, value);
		}

		public List<string> OriginalUnitsPickerList
		{
			get => _originalUnitsPickerList;
			set => SetProperty(ref _originalUnitsPickerList, value);
		}

		public string TitleText
		{
			get => _titleText;
			set => SetProperty(ref _titleText, value);
		}

		public List<string> ConvertedUnitsPickerList
		{
			get => _convertedUnitsPickerList;
			set => SetProperty(ref _convertedUnitsPickerList, value);
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
		#endregion

		#region Methods
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

		void PopulateUnitTypePickerList()
		{
			var unitTypeLPickerList = new List<string>();

			foreach (UnitOfMeasurement item in Enum.GetValues(typeof(UnitOfMeasurement)))
				unitTypeLPickerList.Add(item.ToString());

			UnitTypePickerList = unitTypeLPickerList;
		}

		void ExecuteOriginalUnitsPickerSelectedIndexChangedCommand()
		{
            if (ConvertedUnitsPickerSelectedItem != null && NumberToConvertEntryText != null)
            {
                ConvertUnits();
            }
        }

		void ExecuteConvertedUnitsPickerSelectedIndexChangedCommand()
		{
            if (OriginalUnitsPickerSelectedItem != null && NumberToConvertEntryText != null)
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
			var isOriginalUnitsPickerSelectedItemNull = OriginalUnitsPickerSelectedItem is null;
			var isConvertedUnitsPickerSelectedItemNull = ConvertedUnitsPickerSelectedItem is null;
			var isNumberToConvertEntryTextInvalid = !double.TryParse(NumberToConvertEntryText, out _);

			if (isOriginalUnitsPickerSelectedItemNull || isConvertedUnitsPickerSelectedItemNull || isNumberToConvertEntryTextInvalid)
			{
				var errorStringBuilder = new StringBuilder();

				if (isOriginalUnitsPickerSelectedItemNull)
					errorStringBuilder.AppendLine("Original Unit Not Selected");
				if (isConvertedUnitsPickerSelectedItemNull)
					errorStringBuilder.AppendLine("Converted Unit Not Selected");
				if (isNumberToConvertEntryTextInvalid)
					errorStringBuilder.AppendLine("Number to Convert Invalid");

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
            if (OriginalUnitsPickerSelectedItem != null && ConvertedUnitsPickerSelectedItem != null && NumberToConvertEntryText != null)
            {
                ConvertUnits();
            }
        }

		void ConvertUnits()
		{
			try
			{
				var numberToConvert = double.Parse(NumberToConvertEntryText);

				var firstItemSelectedType = _unitOfMeasurementDictionary.FirstOrDefault(x => x.Key.Equals(OriginalUnitsPickerSelectedItem)).Value;
				var secondItemSelectedType = _unitOfMeasurementDictionary.FirstOrDefault(x => x.Key.Equals(ConvertedUnitsPickerSelectedItem)).Value;

				var inputAsBaseUnits = firstItemSelectedType.ConvertToBaseUnits(numberToConvert);

				var inputAsConvertedUnits = secondItemSelectedType.ConvertFromBaseUnits(inputAsBaseUnits);

				ConvertedNumberLabelText = $"{NumberToConvertEntryText} {OriginalUnitsPickerSelectedItem} = {inputAsConvertedUnits.ToString("N")} {ConvertedUnitsPickerSelectedItem}";
			}
			catch
			{
				ConvertedNumberLabelText = string.Empty;
			}
		}

		void OnConversionError(string message) => _conversionErrorEventManager.HandleEvent(this, message, nameof(ConversionError));
		#endregion
	}
}
