using ERPWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERPWeb.ViewModels
{
    public class ProductsCatalogViewModel
    {
        public List<SubjectOfLabor> ItemsCatalog { get; set; }
        public AddProductOrMaterialViewModel AddProductOrMaterialPartialViewModel { get; set; }

        public ProductsCatalogViewModel()
        {
            ItemsCatalog = new List<SubjectOfLabor>();
            AddProductOrMaterialPartialViewModel = new AddProductOrMaterialViewModel();

            using (ProductsContext context = new ProductsContext())
            {
                ItemsCatalog = (from sol in context.SubjectsOfLabor select sol).ToList();
            }
        }
    }
}