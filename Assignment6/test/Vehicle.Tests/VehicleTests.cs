using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Vehicle.VehicleUtils;

namespace Vehicle.Tests
{
	[TestClass]
	public class VehicleTests
	{
		[TestMethod]
		public void Car_CreateCar_Success()
		{
			Car car = new Car(2002, "Dodge", "Neon", 120, 5000, false);
			Assert.IsNotNull(car);
			Assert.AreEqual(2002, car.Year);
			Assert.IsFalse(car.HasSpoiler);
			Assert.IsFalse(car.Driving);
			Assert.AreEqual("We should probably stay on the road in our Neon.", car.Drive());
		}

		[TestMethod]
		public void Truck_CreateTruck_Success()
		{
			Truck truck = new Truck(2018, "Chevy", "Silverado", 400, 40000, 98);
			Assert.IsNotNull(truck);
			Assert.AreEqual(2018, truck.Year);
			Assert.AreEqual(98, truck.BedLength);
			Assert.IsFalse(truck.Driving);
			Assert.AreEqual("Let's go off-roading' in our Silverado!", truck.Drive());
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Car_CreateCar_Fail()
		{
			Car car = new Car(2002, null, null, 0, 0, false);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void truck_CreateTruck_Fail()
		{
			Truck truck = new Truck(2002, null, null, 0, 0, -5);
		}

		[TestMethod]
		public void Struct_ChangeLocalProperty_GlobalUnchanged()
		{
			Truck truck = new Truck(2018, "Chevy", "Silverado", 400, 40000, 98);
			Truck newTruck = UpgradeHorsePower(truck);
			Assert.AreEqual(400, truck.HorsePower);
			Assert.AreEqual(500, newTruck.HorsePower);
		}

		[TestMethod]
		public void Class_ChangeLocalProperty_GlobalChanged()
		{
			Car car = new Car(2002, "Dodge", "Neon", 120, 5000, false);
			Car newCar = UpgradeHorsePower(car);
			Assert.AreEqual(220, car.HorsePower);
			Assert.AreEqual(220, newCar.HorsePower);
		}

		[TestMethod]
		public void Struct_ChangeLocalProperty_GlobalChanged()
		{
			Truck truck = new Truck(2018, "Chevy", "Silverado", 400, 40000, 98);
			Truck newTruck = UpgradeHorsePower(ref truck);
			Assert.AreEqual(500, truck.HorsePower);
			Assert.AreEqual(500, newTruck.HorsePower);
		}

		[TestMethod]
		public void Class_CreateNewInstance_GlobalChanged()
		{
			Car car = new Car(2002, "Dodge", "Neon", 120, 5000, hasSpoiler: false);
			Car newCar = NewCarWithSpoiler(car);
			Assert.IsTrue(car.HasSpoiler);
			Assert.IsTrue(newCar.HasSpoiler);
		}

		[TestMethod]
		public void Struct_CastToInterface_GlobalChanged()
		{
			Truck truck = new Truck(2018, "Chevy", "Silverado", 400, 40000, 98);
			IDriveable iDriveable = (IDriveable) truck;
			Assert.IsFalse(iDriveable.Driving);
			var driving = Drive(iDriveable);
			Assert.IsTrue(iDriveable.Driving);
			Assert.AreEqual("We're driving!", driving);
		}
	}
}
