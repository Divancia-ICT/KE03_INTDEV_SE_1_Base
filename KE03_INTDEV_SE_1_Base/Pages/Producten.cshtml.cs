using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bestellingplaatsen.Helpers;


namespace Bestellingplaatsen.Pages
{
    public class ProductenModel : PageModel
    {
        public void OnGet() { }

        public IActionResult OnPostAddToCart(int productId)
        {
            var product = GetProductById(productId);

            List<Product> cart = HttpContext.Session.GetObject<List<Product>>("Cart") ?? new List<Product>();
            cart.Add(product);
            HttpContext.Session.SetObject("Cart", cart);

            return RedirectToPage("/Winkelwagen");
        }

        private Product GetProductById(int id)
        {
            var producten = new List<Product>
            {
                new Product { Id = 1, Name = "Nebuchadnezzar", Price = 10000.0 },
                new Product { Id = 2, Name = "Jack-in Chair", Price = 500.5 },
                new Product { Id = 3, Name = "EMP (Electro-Magnetic Pulse) Device", Price = 129.99 }
            };
            return producten.FirstOrDefault(p => p.Id == id);
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
        }
    }
}
