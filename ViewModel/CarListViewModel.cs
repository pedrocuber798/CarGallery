using CarGallery.Model;
using System.Collections.Generic;

namespace CarGallery.ViewModel {
    public class CarListViewModel {

        public string BrandName { get; set; }

        public List<Car> Cars { get; set; }
    }
}
