using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;


namespace EmployeesApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbHelper dbHelper = new DbHelper();
        }
        static void addEmployee(string name, string surname, int registiriton_number)
        {
            string connectionString = "Your Connection String Here;";

            string query = "INSERT INTO Employees (name, surname, registration_number) VALUES (@name, @surname, @registration_number)";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@surname", surname);
                        command.Parameters.AddWithValue("@registration_number", registiriton_number);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Employee added succesfully.");
                        }
                        else
                        {
                            Console.WriteLine("No rows affected.");
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }
        static void deleteEmployee(string name, string surname, int registiriton_number)
        {
            string connectionString = "Your Connection String Here;";

            string query = "DELETE FROM Employees WHERE Name = @Name AND Surname = @Surname AND RegistrationNumber = @RegistrationNumber";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@surname", surname);
                        command.Parameters.AddWithValue("@registration_number", registiriton_number);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Employee deleted succesfully.");
                        }
                        else
                        {
                            Console.WriteLine("No rows affected.");
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void findEmployee(int registration_number)
        {
            string connectionString = "Your Connection String Here;";

            string query = "SELECT name, surname, registration_number FROM Employees WHERE registration_number = @registration_number";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@registration_number", registration_number);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string name = reader["name"].ToString();
                                string surname = reader["surname"].ToString();
                                int regNum = Convert.ToInt32(reader["registration_number"].ToString());

                                Console.WriteLine($"Employee found: {name} {surname}, Registration Number: {regNum}");
                            }
                            else
                            {
                                Console.WriteLine("No employee found with the given registration number.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }


        }
        static void updateEmployee(int registration_number, string newName, string newSurname) {

            string connectionString = "Your Connection String Here;";

            string query = "UPDATE Employees SET name = @newName, surname = @newSurname WHERE registration_number = @registration_number";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@newName", newName);
                        command.Parameters.AddWithValue("@newSurname", newSurname);
                        command.Parameters.AddWithValue("@registration_number", registration_number);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Employee updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No employee updated.");
                        }
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
        static void printAllEmployees() {

            string connectionString = "Your Connection String Here;";

            string query = "SELECT * FROM Employees";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader["Name"].ToString();
                                string surname = reader["surname"].ToString();
                                int registration_number = Convert.ToInt32(reader["registration_number"]);

                                Console.WriteLine($"Name: {name}, Surname: {surname}, Registration Number: {registration_number}");
                            }
                        }

                    }
                    connection.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class DbHelper
    {
        public void addEmployee(string name, string surname, int registiriton_number)
        {
            string connectionString = "Your Connection String Here;";

            string query = "INSERT INTO Employees (name, surname, registration_number) VALUES (@name, @surname, @registration_number)";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@surname", surname);
                        command.Parameters.AddWithValue("@registration_number", registiriton_number);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Employee added succesfully.");
                        }
                        else
                        {
                            Console.WriteLine("No rows affected.");
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }
        public void deleteEmployee(string name, string surname, int registiriton_number)
        {
            string connectionString = "Your Connection String Here;";

            string query = "DELETE FROM Employees WHERE Name = @Name AND Surname = @Surname AND RegistrationNumber = @RegistrationNumber";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@surname", surname);
                        command.Parameters.AddWithValue("@registration_number", registiriton_number);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Employee deleted succesfully.");
                        }
                        else
                        {
                            Console.WriteLine("No rows affected.");
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void findEmployee(int registration_number)
        {
            string connectionString = "Your Connection String Here;";

            string query = "SELECT name, surname, registration_number FROM Employees WHERE registration_number = @registration_number";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@registration_number", registration_number);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string name = reader["name"].ToString();
                                string surname = reader["surname"].ToString();
                                int regNum = Convert.ToInt32(reader["registration_number"].ToString());

                                Console.WriteLine($"Employee found: {name} {surname}, Registration Number: {regNum}");
                            }
                            else
                            {
                                Console.WriteLine("No employee found with the given registration number.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }


        }
        public void updateEmployee(int registration_number, string newName, string newSurname)
        {

            string connectionString = "Your Connection String Here;";

            string query = "UPDATE Employees SET name = @newName, surname = @newSurname WHERE registration_number = @registration_number";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@newName", newName);
                        command.Parameters.AddWithValue("@newSurname", newSurname);
                        command.Parameters.AddWithValue("@registration_number", registration_number);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Employee updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No employee updated.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void printAllEmployees()
        {

            string connectionString = "Your Connection String Here;";

            string query = "SELECT * FROM Employees";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader["Name"].ToString();
                                string surname = reader["surname"].ToString();
                                int registration_number = Convert.ToInt32(reader["registration_number"]);

                                Console.WriteLine($"Name: {name}, Surname: {surname}, Registration Number: {registration_number}");
                            }
                        }

                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void clearDb()
        {
            string connectionString = "Your Connection String Here;";

            string query = "DELETE FROM Employees";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"All employees deleted successfully. Rows affected: {rowsAffected}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}