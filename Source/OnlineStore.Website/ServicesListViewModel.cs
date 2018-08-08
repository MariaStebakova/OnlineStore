using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineStore.Model;

namespace OnlineStore.Website.Models
{
    public class ServicesListViewModel
    {
        public IEnumerable<Service> Services { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }

    }
}