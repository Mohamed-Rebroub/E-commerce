using laalou.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace laalou.Controllers
{
    public class AdmController : Controller
    {
        // GET: AdmController
      

        private readonly LaalouContext _db;
        public AdmController(LaalouContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            
            var cats = _db.Produits.ToList();
            return View(cats);

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Produit obj)
        {
            if (ModelState.IsValid)
            {
                _db.Produits.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Produits = _db.Produits.Find(id);
            if (Produits == null)
            {
                return NotFound();
            }
            return View(Produits);
        }

        [HttpPost]
        public IActionResult Edit(Produit obj)
        {
            if (ModelState.IsValid)
            {
                var OldCategory = _db.Produits.Find(obj.Id);
                if (OldCategory == null)
                {
                    return NotFound();
                }
                OldCategory.Nom = obj.Nom;
                OldCategory.Prix = obj.Prix;
                OldCategory.Photo = obj.Photo;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        public IActionResult Delete(int id)
        {
            var Produit = _db.Produits.Find(id);
            if (Produit == null)
            {
                return NotFound();
            }
            _db.Produits.Remove(Produit);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }














        // GET: AdmController/Details/5


    }
}
