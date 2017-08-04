
namespace ERPWeb.ViewModels
{
    public class ProductionViewModel
    {
        ProductsCatalogViewModel ProductsCatalogPartialViewModel { get; set; }

        public ProductionViewModel()
        {
            ProductsCatalogPartialViewModel = new ProductsCatalogViewModel();
        }
    }
}