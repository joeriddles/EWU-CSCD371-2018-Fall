using System;
using static System.Decimal;

namespace Vehicle
{
	public abstract class Vehicle : IComparable<Vehicle>
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

		protected Vehicle(int year, string make, string model, int horsePower, decimal cost)
		{
			if (year < 1900 || year > 2020 || string.IsNullOrEmpty(make) || string.IsNullOrEmpty(model) ||
			    horsePower < 0 || cost < 0)
				throw new ArgumentException();

			Year = year;
			Make = make;
			Model = model;
			HorsePower = horsePower;
			Cost = cost;
		}

		public int CompareTo(Vehicle other)
		{
			return Compare(Cost, other.Cost);
		}

		public override string ToString()
		{
			return $"{Year} {Make} {Model}";
		}
	}
}
