namespace XamConverter
{
	public class Ounces : UnitOfMeasurementSingleton<Ounces>
	{
		public Ounces() : base(UnitOfMeasurement.Mass)
		{
		}

		public override double ConvertFromBaseUnits(double numberInGrams)
		{
			return numberInGrams / 28.35;
		}

		public override double ConvertToBaseUnits(double numberInOunces)
		{
			return numberInOunces * 28.35;
		}
	}
}
