using System;

namespace Vehicle
{
	public struct Truck : IDriveable
	{
		private int _year;
		public int Year
		{
			get => _year;
			set
			{
				if (value > 1900 && value < 2020)
					_year = value;
			}
		}

		private string _make;
		public string Make
		{
			get => _make;
			set
			{
				if (!string.IsNullOrEmpty(value))
					_make = value;
			}
		}

		private string _model;

		public string Model
		{
			get => _model;
			set
			{
				if (!string.IsNullOrEmpty(value))
					_model = value;
			}
		}

		private int _horsePower;

		public int HorsePower
		{
			get => _horsePower;
			set
			{
				if (value >= 0)
					_horsePower = value;
			}
		}

		private decimal _cost;

		public decimal Cost
		{
			get => _cost;
			set
			{
				if (value >= 0)
					_cost = value;
			}
		}

		private int _bedLength;
		public int BedLength
		{
			get => _bedLength;
			set
			{
				if (value >= 0)
					_bedLength = value;
			}
		}

		public bool Driving { get; set; }

		public Truck(int year, string make, string model, int horsePower, decimal cost, int bedLength) : this()
		{
			if (year < 1900 || year > 2020 || string.IsNullOrEmpty(make) || string.IsNullOrEmpty(model) ||
			    horsePower < 0 || cost < 0 || bedLength < 0)
				throw new ArgumentException();

			Year = year;
			Make = make;
			Model = model;
			HorsePower = horsePower;
			Cost = cost;
			BedLength = bedLength;
			Driving = false;
		}

		public Truck UpgradeHorsePower(Truck truck)
		{
			truck.HorsePower += 100;
			return truck;
		}

		public string Drive()
		{
			Driving = true;
			return $"Let's go off-roading' in our {Model}!";
		}
	}
}