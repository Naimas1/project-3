public class WarehouseManager
{
    private string connectionString;

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

    public void DisplaySuppliers()
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

    public void DisplayProductTypes()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT DISTINCT ProductType FROM Products";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "ProductTypes");

                DataTable productTypesTable = dataSet.Tables["ProductTypes"];

                Console.WriteLine("Всі типи товарів:");

                foreach (DataRow row in productTypesTable.Rows)
                {
                    Console.WriteLine($"Тип товару: {row["ProductType"]}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при виведенні типів товарів: {ex.Message}");
        }
    }

    public void InsertNewProduct(string productName, string productType, string supplier, int quantity, decimal cost, DateTime supplyDate)
    {
 
    }

    public void InsertNewProductType(string productType)
    {

    }

    public void InsertNewSupplier(string supplier)
    {

    }

    public void UpdateProductInfo(string productName, int newQuantity, decimal newCost)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Products SET Quantity = @NewQuantity, Cost = @NewCost " +
                               "WHERE ProductName = @ProductName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@NewQuantity", newQuantity);
                    command.Parameters.AddWithValue("@NewCost", newCost);

                    command.ExecuteNonQuery();
                }

                Console.WriteLine($"Інформацію про товар '{productName}' оновлено.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при оновленні інформації про товар: {ex.Message}");
        }
    }

    public void UpdateSupplierInfo(string supplierName, string newSupplierInfo)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Suppliers SET SupplierInfo = @NewSupplierInfo " +
                               "WHERE SupplierName = @SupplierName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SupplierName", supplierName);
                    command.Parameters.AddWithValue("@NewSupplierInfo", newSupplierInfo);

                    command.ExecuteNonQuery();
                }

                Console.WriteLine($"Інформацію про постачальника '{supplierName}' оновлено.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при оновленні інформації про постачальника: {ex.Message}");
        }
    }

    public void UpdateProductTypeInfo(string productType, string newProductTypeInfo)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE ProductTypes SET ProductTypeInfo = @NewProductTypeInfo " +
                               "WHERE ProductType = @ProductType";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductType", productType);
                    command.Parameters.AddWithValue("@NewProductTypeInfo", newProductTypeInfo);

                    command.ExecuteNonQuery();
                }

                Console.WriteLine($"Інформацію про тип товару '{productType}' оновлено.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при оновленні інформації про тип товару:
