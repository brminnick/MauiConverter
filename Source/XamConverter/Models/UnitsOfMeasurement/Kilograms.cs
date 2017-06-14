namespace XamConverter
{
    public class Kilograms : UnitOfMeasurementModel
	{
        static Kilograms _instance;

		Kilograms() : base(UnitOfMeasurement.Mass)
		{
		}

        public static Kilograms Instance => _instance ?? (_instance = new Kilograms());

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
