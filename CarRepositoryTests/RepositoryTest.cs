using CarShowRoom;
using Repository;
using System.Diagnostics;

namespace CarRepositoryTests
{
    public class Tests
    {
        private CarRepository carRepository = CarRepository.Instance;

        private static object[] GetCars { get; } =
        {
            new object[] {"C111", "TestName", "TestBrand", (decimal)1000},
            new object[] {"C112", "TestName", "TestBrand", (decimal)1000},
            new object[] {"C113", "TestName", "TestBrand", (decimal)1000}
        };

        [Test]
        public void Test_InsertCar_Given_Right_Argument_Return_Wells()
        {
            Car car = new Car("C004", "CIVIC RS", "Honda", 870m);
            carRepository.InserCar(car);
            Assert.IsNotNull(carRepository.GetCarByCode(car.Code));
        }

        [Test]
        [TestCase("COO5", "TestData", "TestData2", 100)]
        [TestCase("COO6", "TestData", "TestData2", 100)]
        [TestCase("COO7", "TestData", "TestData2", 100)]
        [TestCase("COO8", "TestData", "TestData2", 100)]
        public void Test_InsertCar_Given_Mutiple_Right_Arguments_Return_Wells(string code, string name, string brand, decimal price)
        {
            Car car = new Car(code, name, brand, price);
            carRepository.InserCar(car);
            Car createdCar = carRepository.GetCarByCode(car.Code);
            Assert.IsNotNull(createdCar);
        }

        [Test, TestCaseSource(nameof(GetCars))]
        public void Test_InsertCar_Given_Mutiple_Right_Arguments_Return_Wells_Ver2(string code, string name, string brand, decimal price)
        {
            Car car = new Car(code, name, brand, price);
            carRepository.InserCar(car);
            Car createdCar = carRepository.GetCarByCode(car.Code);
            Assert.IsNotNull(createdCar);
        }

        [Test]
        public void Test_UpdateCarName_Given_Right_Arguments_Return_Well()
        {
            Car updateCar = new Car("C004", "Brio", "TestData", 100m);
            carRepository.UpdateCarName(updateCar);
            Car updatedCar = carRepository.GetCarByCode(updateCar.Code);
            Assert.That(updateCar.Name.Equals(updatedCar.Name));
        }

        [Test]
        public void Should_Throw_Exception_By_Given_Wrong_Argurments_To_UpdateCarName()
        {
            Car car = new Car();
            car.Code = "C000";
            Assert.Throws<System.Exception>(() => carRepository.UpdateCarName(car));
        }

        [Test]
        public void Test_DeleteFunction_With_Right_Arguments_Should_Return_Well()
        {
            Car car = new Car();
            car.Code = "C008";
            carRepository.DeleteCar(car);
            Assert.That(carRepository.GetCarByCode(car.Code).Name == null);
        }
    }
}