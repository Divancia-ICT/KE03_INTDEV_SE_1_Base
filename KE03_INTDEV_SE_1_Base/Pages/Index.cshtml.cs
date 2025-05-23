using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Bestellingplaatsen.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        // Simulatie van klantdata
        public List<Customer> Customers { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Simuleer klantgegevens (normaal komt dit uit een database of DAL)
            Customers = new List<Customer>
            {
                new Customer { Name = "Jansen", Orders = new List<Order> { new Order(), new Order() } },
                new Customer { Name = "Pieters", Orders = new List<Order> { new Order() } }
            };
        }
    }

    // Simpele datamodellen voor demo-doeleinden
    public class Customer
    {
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }

    public class Order { }
}
