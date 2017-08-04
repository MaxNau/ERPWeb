using System.Collections.Generic;

namespace ERPWeb.ViewModels
{
    public class AddProductOrMaterialViewModel
    {
        public string Name { get; set; }
        public string SelectedItem { get; set; }
        public List<string> Items { get; set; }

        public AddProductOrMaterialViewModel()
        {
            Items = new List<string>();
            Items.Add("Material");
            Items.Add("Product");
        }
    }
}