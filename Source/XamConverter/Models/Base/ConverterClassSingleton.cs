namespace XamConverter
{
	public abstract class ConverterClassSingleton<T> : UnitOfMeasurementModel where T : UnitOfMeasurementModel, new()
	{
		static T _instance;

		protected ConverterClassSingleton(UnitOfMeasurement measurementType) : base(measurementType)
		{
			
		}

		public static T Instance => _instance ?? (_instance = new T());
	}
}
