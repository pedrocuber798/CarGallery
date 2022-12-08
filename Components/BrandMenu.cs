using CarGallery.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarGallery.Components {
    public class BrandMenu : ViewComponent{
        public CarGalleryDbContext Context { get; set; }

        public BrandMenu(CarGalleryDbContext context) { 
            this.Context = context;
        }
        public IViewComponentResult Invoke() {
            var brands = Context.Brands.OrderBy(x => x.Name).ToList();
            return View(brands);
        }
    }
}
