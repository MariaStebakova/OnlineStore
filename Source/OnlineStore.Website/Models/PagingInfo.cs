using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Website.Models
{
    public class PagingInfo
    {
        // Кол-во товаров
        public int TotalItems { get; set; }

        // Кол-во товаров на одной странице
        public int ItemsPerPage { get; set; }

        // Номер текущей страницы
        public int CurrentPage { get; set; }

        // Общее кол-во страниц
        public int TotalPages
        {
            get { return ItemsPerPage > 0 ? (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage) : 0; }
        }
    }
}