using Medicine_Entry.Data;
using Medicine_Entry.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medicine_Entry.Controllers
{
    public class infoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public infoController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<info> objinfoList = _db.infos;
            return View(objinfoList);
        }

        //Get
        public IActionResult Create()
        {
            
            return View();
        }

        //POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(info obj)
        {
            if (ModelState.IsValid) {
                _db.infos.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }


        //Get
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var infoFromDb = _db.infos.Find(id);
            if(infoFromDb == null)
            {
                return NotFound();
            }
            return View(infoFromDb);
        }

        //POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(info obj)
        {
            if (ModelState.IsValid)
            {
                _db.infos.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var infoFromDb = _db.infos.Find(id);
            if (infoFromDb == null)
            {
                return NotFound();
            }
            return View(infoFromDb);
        }

        //POST

        [HttpPost,ActionName("DeleteInfo")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteInfo(int? id)
        {
            var inf = _db.infos.Find(id);
            if (inf == null)
            {
                return NotFound();
            }
            _db.infos.Remove(inf);
            _db.SaveChanges();
            return RedirectToAction("Index");
             

        }
    }
}
