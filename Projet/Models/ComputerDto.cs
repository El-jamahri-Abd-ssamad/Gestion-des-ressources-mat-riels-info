using System;
using System.ComponentModel.DataAnnotations;

namespace Projet.Models
{
    public class ComputerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le numéro d'inventaire est obligatoire")]
        public string InventoryNumber { get; set; }

        [Required(ErrorMessage = "La marque est obligatoire")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Le CPU est obligatoire")]
        public string CPU { get; set; }

        [Required(ErrorMessage = "La RAM est obligatoire")]
        public string RAM { get; set; }

        [Required(ErrorMessage = "Le disque dur est obligatoire")]
        public string HardDrive { get; set; }

        [Required(ErrorMessage = "L'écran est obligatoire")]
        public string Screen { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int SupplierId { get; set; }

        [Required(ErrorMessage = "L'affectation est obligatoire")]
        public string AssignedTo { get; set; }

        [Required(ErrorMessage = "Le type d'affectation est obligatoire")]
        public string AssignmentType { get; set; }

        public int DepartmentId { get; set; }

        public ComputerDto()
        {
            InventoryNumber = "?????";
            Brand = "?????";
            CPU = "?????";
            RAM = "?????";
            HardDrive = "?????";
            Screen = "?????";
            AssignedTo = "?????";
            AssignmentType = "Department";
            DeliveryDate = DateTime.Now;
            SupplierId = 0;
            DepartmentId = 0;
        }

        public ComputerDto(int id, string inventoryNumber, string brand, string cpu, string ram,
                          string hardDrive, string screen, DateTime deliveryDate, int supplierId,
                          string assignedTo, string assignmentType, int departmentId)
        {
            Id = id;
            InventoryNumber = inventoryNumber;
            Brand = brand;
            CPU = cpu;
            RAM = ram;
            HardDrive = hardDrive;
            Screen = screen;
            DeliveryDate = deliveryDate;
            SupplierId = supplierId;
            AssignedTo = assignedTo;
            AssignmentType = assignmentType;
            DepartmentId = departmentId;
        }

        public override string ToString()
        {
            return $@"Id: {Id} InventoryNumber: {InventoryNumber} Brand: {Brand}
                    CPU: {CPU} RAM: {RAM} HardDrive: {HardDrive} Screen: {Screen}
                    DeliveryDate: {DeliveryDate} AssignedTo: {AssignedTo} Type: {AssignmentType}";
        }
    }
}