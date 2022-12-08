namespace CarGallery.Model {
    public class Car {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbnailUrl { get; set; }

        public Brand Brand { get; set; }

        public int BrandId { get; set; }
    }
}
