using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Bestellingplaatsen.Helpers; // Zorg dat je deze namespace toevoegt!

namespace Bestellingplaatsen.Pages
{
    public class WinkelwagenModel : PageModel
    {
        private readonly List<Product> _producten = new()
        {
            new Product { Id = 1, Naam = "Nebuchadnezzar", Prijs = 10000.00m },
            new Product { Id = 2, Naam = "Jack-in Chair", Prijs = 500.50m },
            new Product { Id = 3, Naam = "EMP (Electro-Magnetic Pulse) Device", Prijs = 129.99m }
        };

        public List<WinkelwagenItem> Items { get; set; } = new();
        public decimal TotaalPrijs { get; set; }

        public void OnGet()
        {
            var winkelwagen = HttpContext.Session.GetObject<List<int>>("Winkelwagen") ?? new List<int>();

            Items = winkelwagen
                .GroupBy(id => id)
                .Select(g =>
                {
                    var product = _producten.FirstOrDefault(p => p.Id == g.Key);
                    return new WinkelwagenItem
                    {
                        Product = product,
                        Aantal = g.Count()
                    };
                })
                .ToList();

            TotaalPrijs = Items.Sum(i => i.Product.Prijs * i.Aantal);
        }
    }

    public class WinkelwagenItem
    {
        public Product Product { get; set; }
        public int Aantal { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public decimal Prijs { get; set; }
    }
}
