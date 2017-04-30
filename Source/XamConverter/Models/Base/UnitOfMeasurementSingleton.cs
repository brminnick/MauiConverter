namespace XamConverter
{
	public abstract class UnitOfMeasurementSingleton<T> : UnitOfMeasurementModel where T : UnitOfMeasurementModel, new()
	{
		static T _instance;

		protected UnitOfMeasurementSingleton(UnitOfMeasurement measurementType) : base(measurementType)
		{
			
		}

		public static T Instance => _instance ?? (_instance = new T());
	}
}
