using CarShowRoom;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Repository
{
    public class CarRepository
    {
        private const string ConnectionString = "workstation id=car-management.mssql.somee.com;packet size=4096;user id=ttiendat_SQLLogin_1;pwd=dmm1pmktuj;data source=car-management.mssql.somee.com;persist security info=False;initial catalog=car-management;Encrypt=true;TrustServerCertificate=true";
        SqlConnection connection = new SqlConnection(ConnectionString);
        private List<Car> cars;
        private CarRepository() {
            this.cars = new List<Car>();  
        }
        private static readonly CarRepository _instance = new CarRepository();
        public static CarRepository Instance => _instance;

        public List<Car> GetAllCars()
        {
            string SQL = "SELECT * FROM Cars";
            SqlCommand command = new SqlCommand(SQL, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Car car = new Car(
                            reader.GetString("code"),
                            reader.GetString("name"),
                            reader.GetString("brand"),
                            reader.GetDecimal("price"));
                        this.cars.Add(car);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return this.cars;
        }

        public void InserCar(Car newCar)
        {
            foreach (Car car in cars)
            {
                if (car.Code == newCar.Code)
                    return;
            }
            string SQL = "INSERT Cars VALUES (@Code, @Name, @Brand, @Price)";
            SqlCommand command = new SqlCommand(@SQL, connection);
            command.Parameters.AddWithValue("@Code", newCar.Code);
            command.Parameters.AddWithValue("@Name", newCar.Name);
            command.Parameters.AddWithValue("@Brand", newCar.Brand);
            command.Parameters.AddWithValue("@Price", newCar.Price);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        public Car GetCarByCode(string code)
        {
            Car car = new Car();
            string SQL = "SELECT * FROM Cars WHERE CODE LIKE @CODE";
            SqlCommand command = new SqlCommand(SQL, connection);
            command.Parameters.AddWithValue("@CODE", code);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        car.Code = reader.GetString("Code");
                        car.Name = reader.GetString("Name");
                        car.Brand = reader.GetString("Brand");
                        car.Price = reader.GetDecimal("Price");
                    }
                }
                return car;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();    
            }
            return null;

        }

        public void UpdateCarName(Car updateCar)
        {
            if (GetCarByCode(updateCar.Code) != null)
            {
                string SQL = "UPDATE Cars SET NAME = @CarName WHERE CODE = @CarCode";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@CarName", updateCar.Name);
                command.Parameters.AddWithValue("@CarCode", updateCar.Code);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void DeleteCar(Car deleteCar)
        {
            if (GetCarByCode(deleteCar.Code) != null)
            {
                string SQL = "DELETE Cars WHERE CODE LIKE @CarCode";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@CarCode", deleteCar.Code); 
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}