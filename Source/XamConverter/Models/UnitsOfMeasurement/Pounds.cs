namespace XamConverter
{
	public class Pounds : UnitOfMeasurementModel
	{
        static Pounds _instance;

		Pounds() : base(UnitOfMeasurement.Mass)
		{
		}

        public static Pounds Instance => _instance ?? (_instance = new Pounds());

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
