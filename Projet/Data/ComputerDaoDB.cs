using Microsoft.Data.SqlClient;
using Projet.Domain;

namespace Projet.Data
{
    public class ComputerDaoDB : IComputerDao
    {
        SqlConnection connection = DbFactory.GetConnection();
        SqlCommand command = new SqlCommand();

        public void AddComputer(Computer computer)
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = @"INSERT INTO Computers 
                (InventoryNumber, Brand, CPU, RAM, HardDrive, Screen, DeliveryDate, 
                 SupplierId, AssignedTo, AssignmentType, DepartmentId, CreatedAt) 
                VALUES 
                (@InventoryNumber, @Brand, @CPU, @RAM, @HardDrive, @Screen, @DeliveryDate, 
                 @SupplierId, @AssignedTo, @AssignmentType, @DepartmentId, @CreatedAt)";

            command.Parameters.AddWithValue("@InventoryNumber", computer.InventoryNumber);
            command.Parameters.AddWithValue("@Brand", computer.Brand);
            command.Parameters.AddWithValue("@CPU", computer.CPU);
            command.Parameters.AddWithValue("@RAM", computer.RAM);
            command.Parameters.AddWithValue("@HardDrive", computer.HardDrive);
            command.Parameters.AddWithValue("@Screen", computer.Screen);
            command.Parameters.AddWithValue("@DeliveryDate", (object)computer.DeliveryDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@SupplierId", (object)computer.SupplierId ?? DBNull.Value);
            command.Parameters.AddWithValue("@AssignedTo", computer.AssignedTo);
            command.Parameters.AddWithValue("@AssignmentType", computer.AssignmentType);
            command.Parameters.AddWithValue("@DepartmentId", (object)computer.DepartmentId ?? DBNull.Value);
            command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

            command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close();
        }

        public Computer GetComputer(string inventoryNumber)
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Computers WHERE InventoryNumber = @InventoryNumber";
            command.Parameters.AddWithValue("@InventoryNumber", inventoryNumber);

            SqlDataReader rd = command.ExecuteReader();
            command.Parameters.Clear();

            if (rd.Read())
            {
                Computer computer = new Computer
                {
                    InventoryNumber = rd["InventoryNumber"].ToString(),
                    Brand = rd["Brand"].ToString(),
                    CPU = rd["CPU"].ToString(),
                    RAM = rd["RAM"].ToString(),
                    HardDrive = rd["HardDrive"].ToString(),
                    Screen = rd["Screen"].ToString(),
                    DeliveryDate = rd["DeliveryDate"] != DBNull.Value ? Convert.ToDateTime(rd["DeliveryDate"]) : null,
                    SupplierId = rd["SupplierId"] != DBNull.Value ? Convert.ToInt32(rd["SupplierId"]) : null,
                    AssignedTo = rd["AssignedTo"].ToString(),
                    AssignmentType = rd["AssignmentType"].ToString(),
                    DepartmentId = rd["DepartmentId"] != DBNull.Value ? Convert.ToInt32(rd["DepartmentId"]) : null
                };

                rd.Close();
                connection.Close();
                return computer;
            }
            else
            {
                connection.Close();
                return null;
            }
        }

        public List<Computer> GetComputers()
        {
            List<Computer> liste = new List<Computer>();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Computers";

            SqlDataReader rd = command.ExecuteReader();

            while (rd.Read())
            {
                Computer computer = new Computer
                {
                    InventoryNumber = rd["InventoryNumber"].ToString(),
                    Brand = rd["Brand"].ToString(),
                    CPU = rd["CPU"].ToString(),
                    RAM = rd["RAM"].ToString(),
                    HardDrive = rd["HardDrive"].ToString(),
                    Screen = rd["Screen"].ToString(),
                    DeliveryDate = rd["DeliveryDate"] != DBNull.Value ? Convert.ToDateTime(rd["DeliveryDate"]) : null,
                    SupplierId = rd["SupplierId"] != DBNull.Value ? Convert.ToInt32(rd["SupplierId"]) : null,
                    AssignedTo = rd["AssignedTo"].ToString(),
                    AssignmentType = rd["AssignmentType"].ToString(),
                    DepartmentId = rd["DepartmentId"] != DBNull.Value ? Convert.ToInt32(rd["DepartmentId"]) : null
                };
                liste.Add(computer);
            }

            rd.Close();
            connection.Close();
            return liste;
        }

        public List<Computer> GetComputersByDepartment(int departmentId)
        {
            List<Computer> liste = new List<Computer>();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Computers WHERE DepartmentId = @DepartmentId";
            command.Parameters.AddWithValue("@DepartmentId", departmentId);

            SqlDataReader rd = command.ExecuteReader();
            command.Parameters.Clear();

            while (rd.Read())
            {
                Computer computer = new Computer
                {
                    InventoryNumber = rd["InventoryNumber"].ToString(),
                    Brand = rd["Brand"].ToString(),
                    CPU = rd["CPU"].ToString(),
                    RAM = rd["RAM"].ToString(),
                    HardDrive = rd["HardDrive"].ToString(),
                    Screen = rd["Screen"].ToString(),
                    DeliveryDate = rd["DeliveryDate"] != DBNull.Value ? Convert.ToDateTime(rd["DeliveryDate"]) : null,
                    SupplierId = rd["SupplierId"] != DBNull.Value ? Convert.ToInt32(rd["SupplierId"]) : null,
                    AssignedTo = rd["AssignedTo"].ToString(),
                    AssignmentType = rd["AssignmentType"].ToString(),
                    DepartmentId = rd["DepartmentId"] != DBNull.Value ? Convert.ToInt32(rd["DepartmentId"]) : null
                };
                liste.Add(computer);
            }

            rd.Close();
            connection.Close();
            return liste;
        }

        public void UpdateComputer(string inventoryNumber, Computer newComputer)
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = @"UPDATE Computers SET 
                Brand = @Brand, CPU = @CPU, RAM = @RAM, HardDrive = @HardDrive, 
                Screen = @Screen, DeliveryDate = @DeliveryDate, SupplierId = @SupplierId,
                AssignedTo = @AssignedTo, AssignmentType = @AssignmentType, 
                DepartmentId = @DepartmentId, UpdatedAt = @UpdatedAt 
                WHERE InventoryNumber = @InventoryNumber";

            command.Parameters.AddWithValue("@InventoryNumber", inventoryNumber);
            command.Parameters.AddWithValue("@Brand", newComputer.Brand);
            command.Parameters.AddWithValue("@CPU", newComputer.CPU);
            command.Parameters.AddWithValue("@RAM", newComputer.RAM);
            command.Parameters.AddWithValue("@HardDrive", newComputer.HardDrive);
            command.Parameters.AddWithValue("@Screen", newComputer.Screen);
            command.Parameters.AddWithValue("@DeliveryDate", (object)newComputer.DeliveryDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@SupplierId", (object)newComputer.SupplierId ?? DBNull.Value);
            command.Parameters.AddWithValue("@AssignedTo", newComputer.AssignedTo);
            command.Parameters.AddWithValue("@AssignmentType", newComputer.AssignmentType);
            command.Parameters.AddWithValue("@DepartmentId", (object)newComputer.DepartmentId ?? DBNull.Value);
            command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);

            command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close();
        }

        public void DeleteComputer(string inventoryNumber)
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "DELETE FROM Computers WHERE InventoryNumber = @InventoryNumber";
            command.Parameters.AddWithValue("@InventoryNumber", inventoryNumber);

            command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close();
        }
    }
}