namespace Vehicle
{
	public static class VehicleUtils
	{
		public static void Main(string[] args){}

		public static Car UpgradeHorsePower(Car car)
		{
			car.HorsePower += 100;
			return car;
		}

		public static Car NewCarWithSpoiler(Car car)
		{
			Car newCar = car;
			newCar.HasSpoiler = true;
			return newCar;
		}

		public static Truck UpgradeHorsePower(Truck truck)
		{
			truck.HorsePower += 100;
			return truck;
		}

		public static Truck UpgradeHorsePower(ref Truck truck)
		{
			truck.HorsePower += 100;
			return truck;
		}

		public static string Drive(IDriveable iDriveable)
		{
			iDriveable.Driving = true;
			return $"We're driving!";
		}
	}
}