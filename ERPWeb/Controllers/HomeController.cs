using ERPWeb.Models;
using ERPWeb.ViewModels;
using System.Web.Mvc;

namespace ERPWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {    
            return View(new ProductionViewModel());
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        public ActionResult AddProductPartial()
        {
            return PartialView("AddProductPartial");
        }

        public ActionResult ViewCatalogs()
        {
            return PartialView("CatalogsPartial");
        }

        public ActionResult ProductsAndMaterialsCatalog()
        {
            return PartialView("ProductsAndMaterialsCatalogPartial");
        }

        public ActionResult ProductsCatalog()
        {
            return PartialView("ProductsCatalogPartial");
        }

        public ActionResult AddProductOrMaterial()
        {
            return PartialView("AddProductOrMaterialPartial", new AddProductOrMaterialViewModel());
        }

        public ActionResult OperationsCatalog()
        {
            return PartialView("OperationsCatalogPartial");
        }

        public ActionResult MaterialsCatalog()
        {
            return PartialView("MaterialsCatalogPartial");
        }

        [HttpPost]
        public ActionResult AddProductOrMaterial(AddProductOrMaterialViewModel viewModel)
        {
            SubjectOfLabor sol;
            if (viewModel.SelectedItem == "Product")
                sol = new Product();
            else
                sol = new Material();

            sol.Name = viewModel.Name;

            using (ProductsContext context = new ProductsContext())
            {
                context.SubjectsOfLabor.Add(sol);
                context.SaveChanges();
            }
            return RedirectToAction("index", "home", new { id = "productsandmaterialscatalog" });
        }
    }
}