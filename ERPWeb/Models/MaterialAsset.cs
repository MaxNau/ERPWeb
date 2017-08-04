namespace ERPWeb.Models
{
    public class MaterialAsset
    {
        public int Id { get; set; }
        public virtual SubjectOfLabor Asset { get; set; }
        public string Number { get; set; }
        public int Code { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}