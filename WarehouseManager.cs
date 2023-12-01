public class WarehouseManager
{
    private string connectionString; // рядок підключення до бази даних

    public WarehouseManager(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void Connect()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Під'єднано до бази даних 'Склад'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка під'єднання: {ex.Message}");
        }
    }

    public void Disconnect()
    {
        Console.WriteLine("Від'єднано від бази даних 'Склад'.");
    }

    public void DisplayAllProducts()
    {

        void Disconnect()
        {
            Console.WriteLine("Від'єднано від бази даних 'Склад'.");
        }

       void DisplayAllProducts()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Products";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "Products");

                    DataTable productsTable = dataSet.Tables["Products"];

                    Console.WriteLine("Всі товари:");

                    foreach (DataRow row in productsTable.Rows)
                    {
                        Console.WriteLine($"Назва: {row["ProductName"]}, Тип: {row["ProductType"]}, " +
                                          $"Постачальник: {row["Supplier"]}, Кількість: {row["Quantity"]}, " +
                                          $"Собівартість: {row["Cost"]}, Дата постачання: {row["SupplyDate"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при виведенні товарів: {ex.Message}");
            }
        }

    }

    private static void Connect1(WarehouseManager @this)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(@this.connectionString))
            {
                connection.Open();
                Console.WriteLine("Під'єднано до бази даних 'Склад'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка під'єднання: {ex.Message}");
        }
    }

    public void DisplayProductTypes()
    {

        string connectionString = "YourConnectionString";

        WarehouseManager warehouseManager = new WarehouseManager(connectionString);
        warehouseManager.Connect();

        // Виведення всіх товарів
        warehouseManager.DisplayAllProducts();

        warehouseManager.Disconnect();
    }

    public void DisplaySuppliers()
    {
        void Connect()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Під'єднано до бази даних 'Склад'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка під'єднання: {ex.Message}");
            }
        }

         void Disconnect()
        {
            Console.WriteLine("Від'єднано від бази даних 'Склад'.");
        }

       void DisplayAllProducts()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Products";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "Products");

                    DataTable productsTable = dataSet.Tables["Products"];

                    Console.WriteLine("Всі товари:");

                    foreach (DataRow row in productsTable.Rows)
                    {
                        Console.WriteLine($"Назва: {row["ProductName"]}, Тип: {row["ProductType"]}, " +
                                          $"Постачальник: {row["Supplier"]}, Кількість: {row["Quantity"]}, " +
                                          $"Собівартість: {row["Cost"]}, Дата постачання: {row["SupplyDate"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при виведенні товарів: {ex.Message}");
            }
        }

      void DisplaySuppliers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT DISTINCT Supplier FROM Products";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "Suppliers");

                    DataTable suppliersTable = dataSet.Tables["Suppliers"];

                    Console.WriteLine("Всі постачальники:");

                    foreach (DataRow row in suppliersTable.Rows)
                    {
                        Console.WriteLine($"Постачальник: {row["Supplier"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при виведенні постачальників: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            string connectionString = "YourConnectionString";

            WarehouseManager warehouseManager = new WarehouseManager(connectionString);
            warehouseManager.Connect();

            // Виведення всіх товарів
            warehouseManager.DisplayAllProducts();

            // Виведення всіх постачальників
            warehouseManager.DisplaySuppliers();

            warehouseManager.Disconnect();
        }
    }


}

class Programa
{
    static void Main()
    {
        string connectionString = "YourConnectionString"; 

        WarehouseManager warehouseManager = new WarehouseManager(connectionString);
        warehouseManager.Connect();

        warehouseManager.Disconnect();
    }
}
