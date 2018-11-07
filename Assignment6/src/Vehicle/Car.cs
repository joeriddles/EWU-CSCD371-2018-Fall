using System;

namespace Vehicle
{
	public class Car : Vehicle, IDriveable
	{
		public bool HasSpoiler { get; set; }
		public bool Driving { get; set; }

		public Car(int year, string make, string model, int horsePower, decimal cost, bool hasSpoiler) : base(year, make, model, horsePower, cost)
		{
			HasSpoiler = hasSpoiler;
		}

		public string Drive()
		{
			return $"We should probably stay on the road in our {Model}.";
		}
	}
}
