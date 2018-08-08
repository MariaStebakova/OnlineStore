using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Model
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ServiceType { get; set; }
        public decimal Price { get; set; }

        public Service()
        {
            
        }
        
    }
}
