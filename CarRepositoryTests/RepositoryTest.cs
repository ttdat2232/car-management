using CarShowRoom;
using NUnit.Framework;
using Repository;
using System.Diagnostics;

namespace CarRepositoryTests
{
    
    [TestFixture]
    public class RepositoryTest
    {
        private CarRepository carRepository;

        private static object[] GetCars { get; } =
        {
            new object[] {"C111", "TestName", "TestBrand", (decimal)1000},
            new object[] {"C112", "TestName", "TestBrand", (decimal)1000},
            new object[] {"C113", "TestName", "TestBrand", (decimal)1000}
        };
        private static int i = 0;
        private static string[] Codes { get; } =
        {
            "C004",
            "C005",
            "C006",
            "C007",
            "C008",
            "C111",
            "C112",
            "C113"
        };

        [SetUp]
        public void Init()
        {
            carRepository = CarRepository.Instance;
            i++;
        }

        [Test]
        public void Test_01_InsertCar_Given_Right_Argument_Return_Wells()
        {
            Car car = new Car("C004", "CIVIC RS", "Honda", 870m);
            carRepository.InserCar(car);
            Assert.IsNotNull(carRepository.GetCarByCode(car.Code));
        }

        [Test]
        [TestCase("C005", "TestData", "TestData2", 100)]
        [TestCase("C006", "TestData", "TestData2", 100)]
        [TestCase("C007", "TestData", "TestData2", 100)]
        [TestCase("C008", "TestData", "TestData2", 100)]
        public void Test_02_InsertCar_Given_Mutiple_Right_Arguments_Return_Wells(string code, string name, string brand, decimal price)
        {
            Car car = new Car(code, name, brand, price);
            carRepository.InserCar(car);
            Car createdCar = carRepository.GetCarByCode(car.Code);
            Assert.IsNotNull(createdCar);
        }

        [Test, TestCaseSource("GetCars")]
        public void Test_03_InsertCar_Given_Mutiple_Right_Arguments_Return_Wells_Ver2(string code, string name, string brand, decimal price)
        {
            Car car = new Car(code, name, brand, price);
            carRepository.InserCar(car);
            Car createdCar = carRepository.GetCarByCode(car.Code);
            Assert.IsNotNull(createdCar);
        }

        [Test]
        public void Test_04_UpdateCarName_Given_Right_Arguments_Return_Well()
        {
            Car updateCar = new Car("C004", "Brio", "TestData", 100m);
            carRepository.UpdateCarName(updateCar);
            Car updatedCar = carRepository.GetCarByCode(updateCar.Code);
            Assert.That(updateCar.Name.Equals(updatedCar.Name));
        }

        [Test]
        public void Test_05_Should_Throw_Exception_By_Given_Wrong_Argurments_To_UpdateCarName()
        {
            Car car = new Car();
            car.Code = "C000";
            Assert.Throws<Exception>(() => carRepository.UpdateCarName(car));
        }

        [Test, TestCaseSource(nameof(Codes))]
        public void Test_06_DeleteFunction_With_Right_Arguments_Should_Return_Well(string code)
        {
            Car car = new Car();
            car.Code = code;
            carRepository.DeleteCar(car);
            Assert.That(carRepository.GetCarByCode(car.Code).Name == null);
        }
    }
}