namespace XamConverter
{
	public class Miles : UnitOfMeasurementModel
	{
        static Miles _instance;

		Miles() : base(UnitOfMeasurement.Length)
		{
		}

        public static Miles Instance => _instance ?? (_instance = new Miles());

		public override double ConvertFromBaseUnits(double valueInCentimeters)
		{
			return valueInCentimeters / 160934;
		}

		public override double ConvertToBaseUnits(double valueInMilies)
		{
			return valueInMilies * 160934;
		}
	}
}
