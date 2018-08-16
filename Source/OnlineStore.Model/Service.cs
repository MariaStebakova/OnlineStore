using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Model
{
    public class Service
    {
        [HiddenInput(DisplayValue = false)]
        public int ServiceId { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Пожалуйста, введите название товара")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Пожалуйста, введите описание товара")]
        public string Description { get; set; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Пожалуйста, укажите категорию товара (кошки, собаки, грызуны, рыбы, птицы, рептилии)")]
        public string ServiceType { get; set; }

        [Display(Name = "Цена (руб)")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public decimal Price { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }


    }
}
