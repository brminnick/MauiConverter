namespace XamConverter
{
	public class Pounds : UnitOfMeasurementSingleton<Pounds>
	{
		public Pounds() : base(UnitOfMeasurement.Mass)
		{
		}

		public override double ConvertFromBaseUnits(double unitsInGrams)
		{
			return unitsInGrams / 450;
		}

		public override double ConvertToBaseUnits(double unitsInPounds)
		{
			return unitsInPounds * 450;
		}
	}
}
