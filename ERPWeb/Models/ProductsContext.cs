namespace ERPWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class ProductsContext : DbContext
    {
        public virtual DbSet<SubjectOfLabor> SubjectsOfLabor { get; set; }
        public virtual DbSet<MaterialAsset> Assets { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }

        public ProductsContext()
            : base("name=ProductsContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ProductsContext>());

            Database.SetInitializer(new DropCreateDatabaseAlways<ProductsContext>());
        }
    }
}