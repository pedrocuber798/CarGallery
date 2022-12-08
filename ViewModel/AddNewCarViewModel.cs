using CarGallery.Model;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarGallery.ViewModel {
    public class AddNewCarViewModel {

        public List<Brand> brands { get; set; }
        
        [Required(ErrorMessage ="Campo Nome Obrigatório")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Campo Descrição Curta Obrigatório")]
        public string ShortDescription { get; set; }
        
        [Required(ErrorMessage = "Campo Descriçao Longa Obrigatório")]
        public string LongDescription { get; set; }
        
        [Required(ErrorMessage = "Obrigatório a imagem do Carro")]
        public IFormFile Image { get; set; }
        
        [Required(ErrorMessage = "Obrigatório a Thumbnail do Carro")]
        public IFormFile Thumbnail { get; set; }
        
        [Required(ErrorMessage = "Obrigatório a seleção da marca do Carro")]
        public int SelectedBrand { get; set; }
    }
}
