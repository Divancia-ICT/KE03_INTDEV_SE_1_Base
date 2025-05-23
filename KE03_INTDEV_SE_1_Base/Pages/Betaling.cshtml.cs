using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class BetalingModel : PageModel
    {
        [BindProperty]
        public string Naam { get; set; }

        [BindProperty]
        public string Kaartnummer { get; set; }

        [BindProperty]
        public string Betaalmethode { get; set; }

        public bool BetalingVerwerkt { get; set; } = false;

        public void OnGet()
        {
        }

        public void OnPost()
        {
            // Hier kun je eventueel controleren of de gegevens geldig zijn

            if (!string.IsNullOrWhiteSpace(Naam) &&
                !string.IsNullOrWhiteSpace(Kaartnummer) &&
                !string.IsNullOrWhiteSpace(Betaalmethode))
            {
                BetalingVerwerkt = true;
            }
        }
    }
}
