using Microsoft.Data.SqlClient;
using Projet.Domain;

namespace Projet.Data
{
    public class PrinterDaoDB : IPrinterDao
{
    SqlConnection connection = DbFactory.GetConnection();
    SqlCommand command = new SqlCommand();

    public void AddPrinter(Printer printer)
    {
        connection.Open();
        command.Connection = connection;
        command.CommandText = @"INSERT INTO Printers 
                (InventoryNumber, Brand, PrintSpeed, Resolution, DeliveryDate, 
                 SupplierId, AssignedTo, AssignmentType, DepartmentId, CreatedAt) 
                VALUES 
                (@InventoryNumber, @Brand, @PrintSpeed, @Resolution, @DeliveryDate, 
                 @SupplierId, @AssignedTo, @AssignmentType, @DepartmentId, @CreatedAt)";

        command.Parameters.AddWithValue("@InventoryNumber", printer.InventoryNumber);
        command.Parameters.AddWithValue("@Brand", printer.Brand);
        command.Parameters.AddWithValue("@PrintSpeed", printer.PrintSpeed);
        command.Parameters.AddWithValue("@Resolution", printer.Resolution);
        command.Parameters.AddWithValue("@DeliveryDate", (object)printer.DeliveryDate ?? DBNull.Value);
        command.Parameters.AddWithValue("@SupplierId", (object)printer.SupplierId ?? DBNull.Value);
        command.Parameters.AddWithValue("@AssignedTo", printer.AssignedTo);
        command.Parameters.AddWithValue("@AssignmentType", printer.AssignmentType);
        command.Parameters.AddWithValue("@DepartmentId", (object)printer.DepartmentId ?? DBNull.Value);
        command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

        command.ExecuteNonQuery();
        command.Parameters.Clear();
        connection.Close();
    }

    public Printer GetPrinter(string inventoryNumber)
    {
        connection.Open();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM Printers WHERE InventoryNumber = @InventoryNumber";
        command.Parameters.AddWithValue("@InventoryNumber", inventoryNumber);

        SqlDataReader rd = command.ExecuteReader();
        command.Parameters.Clear();

        if (rd.Read())
        {
            Printer printer = new Printer
            {
                InventoryNumber = rd["InventoryNumber"].ToString(),
                Brand = rd["Brand"].ToString(),
                PrintSpeed = Convert.ToInt32(rd["PrintSpeed"]),
                Resolution = rd["Resolution"].ToString(),
                DeliveryDate = rd["DeliveryDate"] != DBNull.Value ? Convert.ToDateTime(rd["DeliveryDate"]) : null,
                SupplierId = rd["SupplierId"] != DBNull.Value ? Convert.ToInt32(rd["SupplierId"]) : null,
                AssignedTo = rd["AssignedTo"].ToString(),
                AssignmentType = rd["AssignmentType"].ToString(),
                DepartmentId = rd["DepartmentId"] != DBNull.Value ? Convert.ToInt32(rd["DepartmentId"]) : null
            };

            rd.Close();
            connection.Close();
            return printer;
        }
        else
        {
            connection.Close();
            return null;
        }
    }

    public List<Printer> GetPrinters()
    {
        List<Printer> liste = new List<Printer>();
        connection.Open();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM Printers";

        SqlDataReader rd = command.ExecuteReader();

        while (rd.Read())
        {
            Printer printer = new Printer
            {
                InventoryNumber = rd["InventoryNumber"].ToString(),
                Brand = rd["Brand"].ToString(),
                PrintSpeed = Convert.ToInt32(rd["PrintSpeed"]),
                Resolution = rd["Resolution"].ToString(),
                DeliveryDate = rd["DeliveryDate"] != DBNull.Value ? Convert.ToDateTime(rd["DeliveryDate"]) : null,
                SupplierId = rd["SupplierId"] != DBNull.Value ? Convert.ToInt32(rd["SupplierId"]) : null,
                AssignedTo = rd["AssignedTo"].ToString(),
                AssignmentType = rd["AssignmentType"].ToString(),
                DepartmentId = rd["DepartmentId"] != DBNull.Value ? Convert.ToInt32(rd["DepartmentId"]) : null
            };
            liste.Add(printer);
        }

        rd.Close();
        connection.Close();
        return liste;
    }

    public List<Printer> GetPrintersByDepartment(int departmentId)
    {
        List<Printer> liste = new List<Printer>();
        connection.Open();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM Printers WHERE DepartmentId = @DepartmentId";
        command.Parameters.AddWithValue("@DepartmentId", departmentId);

        SqlDataReader rd = command.ExecuteReader();
        command.Parameters.Clear();

        while (rd.Read())
        {
            Printer printer = new Printer
            {
                InventoryNumber = rd["InventoryNumber"].ToString(),
                Brand = rd["Brand"].ToString(),
                PrintSpeed = Convert.ToInt32(rd["PrintSpeed"]),
                Resolution = rd["Resolution"].ToString(),
                DeliveryDate = rd["DeliveryDate"] != DBNull.Value ? Convert.ToDateTime(rd["DeliveryDate"]) : null,
                SupplierId = rd["SupplierId"] != DBNull.Value ? Convert.ToInt32(rd["SupplierId"]) : null,
                AssignedTo = rd["AssignedTo"].ToString(),
                AssignmentType = rd["AssignmentType"].ToString(),
                DepartmentId = rd["DepartmentId"] != DBNull.Value ? Convert.ToInt32(rd["DepartmentId"]) : null
            };
            liste.Add(printer);
        }

        rd.Close();
        connection.Close();
        return liste;
    }

    public void UpdatePrinter(string inventoryNumber, Printer newPrinter)
    {
        connection.Open();
        command.Connection = connection;
        command.CommandText = @"UPDATE Printers SET 
                Brand = @Brand, PrintSpeed = @PrintSpeed, Resolution = @Resolution,
                DeliveryDate = @DeliveryDate, SupplierId = @SupplierId,
                AssignedTo = @AssignedTo, AssignmentType = @AssignmentType, 
                DepartmentId = @DepartmentId, UpdatedAt = @UpdatedAt 
                WHERE InventoryNumber = @InventoryNumber";

        command.Parameters.AddWithValue("@InventoryNumber", inventoryNumber);
        command.Parameters.AddWithValue("@Brand", newPrinter.Brand);
        command.Parameters.AddWithValue("@PrintSpeed", newPrinter.PrintSpeed);
        command.Parameters.AddWithValue("@Resolution", newPrinter.Resolution);
        command.Parameters.AddWithValue("@DeliveryDate", (object)newPrinter.DeliveryDate ?? DBNull.Value);
        command.Parameters.AddWithValue("@SupplierId", (object)newPrinter.SupplierId ?? DBNull.Value);
        command.Parameters.AddWithValue("@AssignedTo", newPrinter.AssignedTo);
        command.Parameters.AddWithValue("@AssignmentType", newPrinter.AssignmentType);
        command.Parameters.AddWithValue("@DepartmentId", (object)newPrinter.DepartmentId ?? DBNull.Value);
        command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);

        command.ExecuteNonQuery();
        command.Parameters.Clear();
        connection.Close();
    }

    public void DeletePrinter(string inventoryNumber)
    {
        connection.Open();
        command.Connection = connection;
        command.CommandText = "DELETE FROM Printers WHERE InventoryNumber = @InventoryNumber";
        command.Parameters.AddWithValue("@InventoryNumber", inventoryNumber);

        command.ExecuteNonQuery();
        command.Parameters.Clear();
        connection.Close();
    }
}