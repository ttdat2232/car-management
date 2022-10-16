using CarShowRoom;
using Repository;

internal class Program
{
    private static void Main(string[] args)
    {
        CarRepository carRepository = CarRepository.Instance;

        List<Car> cars = carRepository.GetAllCars();
        foreach(Car car in cars)
        {
            Console.WriteLine($"CODE: {car.Code} NAME: {car.Name} BRAND: {car.Brand} PRICE: {car.Price}");
        }
    }
}