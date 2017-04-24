namespace XamConverter
{
	public class Meters : ConverterClassSingleton<Meters>
	{
		public Meters() : base(UnitOfMeasurement.Length)
		{
		}

		public override double ConvertFromBaseUnits(double valueInMeters)
		{
			return valueInMeters / 100;
		}

		public override double ConvertToBaseUnits(double valueInBaseUnit)
		{
			return valueInBaseUnit * 100;
		}
	}
}
