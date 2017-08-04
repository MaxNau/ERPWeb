using System.ComponentModel.DataAnnotations.Schema;

namespace ERPWeb.Models
{
    [Table("Materials")]
    public class Material : SubjectOfLabor
    {
        public decimal Quantity { get; set; }
    }
}