namespace XamConverter
{
	public class Yards : UnitOfMeasurementModel
	{
        static Yards _instance;

		Yards() : base(UnitOfMeasurement.Length)
		{
		}

        public static Yards Instance => _instance ?? (_instance = new Yards());

		public override double ConvertFromBaseUnits(double unitInCentimeters)
		{
			return unitInCentimeters / 91.44;
		}

		public override double ConvertToBaseUnits(double unitInYards)
		{
			return unitInYards * 91.44;
		}
	}
}
