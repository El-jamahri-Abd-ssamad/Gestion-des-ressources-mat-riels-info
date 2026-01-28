using System;

namespace Projet.Entities
{
    public class Resource
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string InventoryNumber { get; set; }
        public string Barcode { get; set; }
        public string Type { get; set; } // e.g. "Computer", "Printer"
        public int AssignedTo { get; set; } // User.Id

        public Resource()
        {
            Id = 0;
            Label = InventoryNumber = Barcode = Type = "";
            AssignedTo = 0;
        }

        public Resource(int id, string label, string inventoryNumber, string barcode, string type, int assignedTo)
        {
            Id = id;
            Label = label;
            InventoryNumber = inventoryNumber;
            Barcode = barcode;
            Type = type;
            AssignedTo = assignedTo;
        }

        public override string ToString()
        {
            return $@"Id {Id} Label {Label} Type {Type} Inventory {InventoryNumber} Barcode {Barcode} AssignedTo {AssignedTo}";
        }
    }
}