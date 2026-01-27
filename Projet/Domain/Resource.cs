namespace WebApplication1.Domain
{
    // Classe de domaine pour les ressources matérielles
    public abstract class Resource
    {
        public string InventoryNumber { get; set; }
        public string Brand { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? SupplierId { get; set; }
        public string AssignedTo { get; set; }
        public string AssignmentType { get; set; }
        public int? DepartmentId { get; set; }

        protected Resource()
        {
            InventoryNumber = string.Empty;
            Brand = string.Empty;
            AssignedTo = string.Empty;
            AssignmentType = "Department";
        }

        public abstract string GetResourceType();
    }
}