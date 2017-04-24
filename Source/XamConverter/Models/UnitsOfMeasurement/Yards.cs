namespace XamConverter
{
	public class Yards : ConverterClassSingleton<Yards>
	{
		public Yards() : base(UnitOfMeasurement.Length)
		{
		}

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
