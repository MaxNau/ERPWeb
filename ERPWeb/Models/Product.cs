using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPWeb.Models
{
    [Table("Products")]
    public class Product : SubjectOfLabor
    {
        public virtual ICollection<Material> RequiredMaterials { get; set; }
        public virtual ICollection<Operation> RequiredOperations { get; set; }
    }
}