using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = " "; 

        // Створення таблиці "Products"
        string createTableQuery = @"
            CREATE TABLE Products (
                ProductID INT PRIMARY KEY IDENTITY(1,1),
                ProductName NVARCHAR(255) NOT NULL,
                ProductType NVARCHAR(255) NOT NULL,
                Supplier NVARCHAR(255) NOT NULL,
                Quantity INT NOT NULL,
                Cost DECIMAL(18, 2) NOT NULL,
                SupplyDate DATE NOT NULL
            )";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            Console.WriteLine("Таблиця 'Products' створена.");

            // Вставка даних
            InsertProduct(connection, "Лаптоп", "Електроніка", "ABC Електроніка", 10, 1200.50m, DateTime.Now);
            InsertProduct(connection, "Книга", "Книги", "Книгарня 'Читай-Гарно'", 50, 15.99m, DateTime.Now.AddDays(-30));
         
        }
    }

    static void InsertProduct(SqlConnection connection, string productName, string productType, string supplier,
                              int quantity, decimal cost, DateTime supplyDate)
    {
        string insertDataQuery = @"
            INSERT INTO Products (ProductName, ProductType, Supplier, Quantity, Cost, SupplyDate)
            VALUES (@ProductName, @ProductType, @Supplier, @Quantity, @Cost, @SupplyDate)";

        using (SqlCommand command = new SqlCommand(insertDataQuery, connection))
        {
            command.Parameters.AddWithValue("@ProductName", productName);
            command.Parameters.AddWithValue("@ProductType", productType);
            command.Parameters.AddWithValue("@Supplier", supplier);
            command.Parameters.AddWithValue("@Quantity", quantity);
            command.Parameters.AddWithValue("@Cost", cost);
            command.Parameters.AddWithValue("@SupplyDate", supplyDate);

            command.ExecuteNonQuery();
        }

        Console.WriteLine($"Дані для товару '{productName}' вставлені.");
    }
}
