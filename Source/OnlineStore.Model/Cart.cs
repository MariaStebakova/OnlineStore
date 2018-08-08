using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Model
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Service service, int quantity)
        {
            CartLine line = lineCollection
                .Where(s => s.Service.ServiceId == service.ServiceId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Service = service,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Service service)
        {
            lineCollection.RemoveAll(l => l.Service.ServiceId == service.ServiceId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Service.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Service Service { get; set; }
        public int Quantity { get; set; }
    }
}
