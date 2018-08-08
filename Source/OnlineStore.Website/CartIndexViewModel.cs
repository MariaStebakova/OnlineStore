using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineStore.Model;

namespace OnlineStore.Website.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}