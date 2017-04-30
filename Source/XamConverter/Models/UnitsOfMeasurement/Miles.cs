namespace XamConverter
{
	public class Miles : UnitOfMeasurementSingleton<Miles>
	{
		public Miles() : base(UnitOfMeasurement.Length)
		{
		}

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
