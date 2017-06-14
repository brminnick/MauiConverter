namespace XamConverter
{
	public class Ounces : UnitOfMeasurementModel
	{
        static Ounces _instance;

		Ounces() : base(UnitOfMeasurement.Mass)
		{
		}

        public static Ounces Instance => _instance ?? (_instance = new Ounces());

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
