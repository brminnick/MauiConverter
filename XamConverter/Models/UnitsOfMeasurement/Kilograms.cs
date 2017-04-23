using System;
namespace ConverterApp
{
	public class Kilograms : ConverterClassSingleton<Kilograms>
	{
		public Kilograms() : base(UnitOfMeasurement.Mass)
		{
		}

		public override double ConvertFromBaseUnits(double numberInGrams)
		{
			return numberInGrams / 1000;
		}

		public override double ConvertToBaseUnits(double numberInKilograms)
		{
			return numberInKilograms * 1000;
		}
	}
}
