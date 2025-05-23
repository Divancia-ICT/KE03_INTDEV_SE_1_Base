//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Bestellingplaatsen.Helpers;


//namespace Bestellingplaatsen.Pages
//{
//    public class ProductenModel : PageModel
//    {
//        public void OnGet() { }

//        public IActionResult OnPostAddToCart(int productId)
//        {
//            var product = GetProductById(productId);

//            List<Product> cart = HttpContext.Session.GetObject<List<Product>>("Cart") ?? new List<Product>();
//            cart.Add(product);
//            HttpContext.Session.SetObject("Cart", cart);

//            return RedirectToPage("/Winkelwagen");
//        }

//        private Product GetProductById(int id)
//        {
//            var producten = new List<Product>
//            {
//                new Product { Id = 1, Name = "Nebuchadnezzar", Price = 10000.0 },
//                new Product { Id = 2, Name = "Jack-in Chair", Price = 500.5 },
//                new Product { Id = 3, Name = "EMP (Electro-Magnetic Pulse) Device", Price = 129.99 }
//            };
//            return producten.FirstOrDefault(p => p.Id == id);
//        }

//        public class Product
//        {
//            public int Id { get; set; }
//            public string Name { get; set; }
//            public double Price { get; set; }
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Bestellingplaatsen.Helpers;

namespace Bestellingplaatsen.Pages
{
    public class ProductenModel : PageModel
    {
        // Productenlijst (optioneel, want jij hebt ze hardcoded in de cshtml)
        private readonly List<Product> _producten = new()
        {
            new Product { Id = 1, Naam = "Nebuchadnezzar", Prijs = 10000.00m },
            new Product { Id = 2, Naam = "Jack-in Chair", Prijs = 500.50m },
            new Product { Id = 3, Naam = "EMP (Electro-Magnetic Pulse) Device", Prijs = 129.99m }
        };

        public List<Product> Producten => _producten;

        // Hier voeg je je OnPost toe:
        public IActionResult OnPost(int productId)
        {
            var winkelwagen = HttpContext.Session.GetObject<List<int>>("Winkelwagen") ?? new List<int>();
            winkelwagen.Add(productId);
            HttpContext.Session.SetObject("Winkelwagen", winkelwagen);

            // Redirect naar winkelwagen of naar producten pagina
            return RedirectToPage("Winkelwagen");
        }
    }

    public class Producten
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal PRiJS { get; set; }
    }
}
