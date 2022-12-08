using Azure.Storage.Blobs;
using CarGallery.Model;
using CarGallery.Repository;
using CarGallery.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarGallery.Controllers {
    public class CarController : Controller {

        public CarGalleryDbContext Context { get; set; }

        public CarController(CarGalleryDbContext context) {
            this.Context = context;
        }

        public ActionResult List(string? brand) {
            List<Car> cars;

            if (string.IsNullOrEmpty(brand)) {
                cars = this.Context.Cars.ToList();
                brand = "Todos os carros";
            }

            else {
                cars = this.Context.Cars.Where(c => c.Brand.Name == brand).ToList();
            }
            return View(new CarListViewModel() {
                BrandName = brand,
                Cars = cars
            });
        }
        public IActionResult Add() {
            AddNewCarViewModel model = CarregarMarcas();
            return View(model);
        }


        [HttpPost]
        public IActionResult Save(AddNewCarViewModel model) {

            if (ModelState.IsValid == false) {
                var addForm = CarregarMarcas();
                return View("Add", addForm);
            }

            var car = new Car();
            car.BrandId = model.SelectedBrand;
            car.Name = model.Name;
            car.LongDescription = model.LongDescription;
            car.ShortDescription = model.ShortDescription;

            

            car.ThumbnailUrl = UploadToAzureBlob(model.Thumbnail);
            car.ImageUrl = UploadToAzureBlob(model.Image);

            Save(car);


            return RedirectToAction("List");
        }

        private string UploadToAzureBlob(IFormFile image) {

            string connectionString = "DefaultEndpointsProtocol=https;AccountName=cargalleryinfnetpc;AccountKey=72Adkm+pGR+6uxpgrvI0QOeT3LaXxAnAUaJaFeq/Uwb3iZdUsnFmVDUsRMtyIK/9xu0SceG4SCtn+ASthTnyIg==;EndpointSuffix=core.windows.net";
            string containerName = "images";
            string fileName = $"{Guid.NewGuid().ToString()}.jpg";

            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

            BlobClient blob = container.GetBlobClient(fileName);

            MemoryStream ms = new MemoryStream();
            image.CopyTo(ms);

            ms.Position = 0;
            blob.Upload(ms);

            return $"https://cargalleryinfnetpc.blob.core.windows.net/images/{fileName}";

        }

        private AddNewCarViewModel CarregarMarcas() {
            var model = new AddNewCarViewModel();
            model.brands = Context.Brands.ToList();
            return model;
        }
        public void Save(Car car) {
            Context.Cars.Add(car);
            Context.SaveChanges();

        }
    }
}
