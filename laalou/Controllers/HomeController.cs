using laalou.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace laalou.Controllers
{

    public class HomeController : Controller
    {
        private readonly LaalouContext _db;
        public HomeController(LaalouContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var cats = _db.Produits.ToList();
            return View(cats);
        }

        public IActionResult Privacy(int id)
        {
          
            var product = _db.Produits.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Category()
        {
            var cats= _db.Categories.ToList();
            return View(cats);
        }
        public IActionResult Cart()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cart(int productId, int quantity)
        {
            // Implémentez la logique pour ajouter le produit au panier ici
            // Assurez-vous de mettre à jour votre base de données en conséquence

            // Exemple : supposez que vous avez une classe CartService qui gère le panier
            var Cart = new Cart();
            Cart.AddToCart(productId, quantity);

            return Json(new { success = true });
        }

        public IActionResult listeprod()
        {
//LaalouContext db = new LaalouContext();
            var cats = _db.Produits.ToList();
            return View(cats);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
