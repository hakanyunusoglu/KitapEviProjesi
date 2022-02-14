using KitapEvi_DataAccess.DATA;
using KitapEvi_Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapEvi.Controllers
{
    public class YayinEviController : Controller
    {
        private readonly KitapEviContext _db ;
        public YayinEviController(KitapEviContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Yayinevi> objlist = _db.Yayinevleri.ToList();
            return View(objlist);
        }
        public IActionResult Update_Insert(int? id)
        {
            Yayinevi obj = new Yayinevi();
            if (id == null)
            {
                return View(obj);
            }
            obj = _db.Yayinevleri.FirstOrDefault(x => x.YayinEviID == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//Güvenlik amacıyla atılan isteklerin gerçek kişiler tarafından gelenlere cevap vermesini sağlar
        public IActionResult Update_Insert(Yayinevi obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.YayinEviID == 0)
                {
                    //create işlemi
                    _db.Yayinevleri.Add(obj);
                }
                else
                {
                    //update
                    _db.Yayinevleri.Update(obj);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            var obj = _db.Yayinevleri.FirstOrDefault(x => x.YayinEviID == id);
            _db.Yayinevleri.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}