using KitapEvi_DataAccess.DATA;
using KitapEvi_Models.Models;
using KitapEvi_Models.Models.ViewsModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapEvi.Controllers
{
    public class KitapController : Controller
    {
        private readonly KitapEviContext _db;
        public KitapController(KitapEviContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //1.Yol
            //List<Kitap> kList = _db.Kitaplar.ToList();
            //Uygulanır fakat verimli değil! hız olması için explicitloading kullanılır.!!
            //foreach (var item in kList)
            //{
            //    item.Yayinevi = _db.Yayinevleri.FirstOrDefault(x => x.YayinEviID == item.YayinEviID);
            //}
            //1.Yol Son
            //2.Yol
            List<Kitap> kList = _db.Kitaplar.Include(x =>x.Yayinevi).ToList();
            //iligili alanlara innerjoin yaparak  getirir

            return View(kList);
        }

        public IActionResult Update_Insert(int? id)
        {
            KitapVM obj = new KitapVM();
            obj.YayinEviListesi = _db.Yayinevleri.Select(x => new SelectListItem
            {
                Text = x.YayinEviAdi,
                Value = x.YayinEviID.ToString()
            });
            obj.KategoriListesi = _db.Kategoriler.Select(x => new SelectListItem
            {
                Text = x.KategoriAdi,
                Value = x.KategoriID.ToString()
            });
            if (id==null)
            {
                return View(obj);
            }
            obj.Kitap = _db.Kitaplar.FirstOrDefault(x => x.KitapID == id);
            obj.Kategori = _db.Kategoriler.FirstOrDefault(x=>x.KategoriID == obj.Kitap.KategoriID);
            
            if (obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update_Insert(KitapVM obj)
        {
            if (obj.Kitap.KategoriID== 0)
            {
                _db.Kitaplar.Add(obj.Kitap);
            }
            else
            {
                _db.Kitaplar.Update(obj.Kitap);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var obj = _db.Kitaplar.FirstOrDefault(x => x.KitapID == id);
            _db.Kitaplar.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detay(int? id)
        {
            KitapVM obj = new KitapVM();
            if (id==null)
            {
                return View(obj);
            }
            obj.Kitap = _db.Kitaplar.FirstOrDefault(x => x.KitapID == id);
            obj.Kitap.KitapDetay =_db.KitapDetaylar.FirstOrDefault(x=>x.KitapID == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Detay(KitapVM obj)
        {
            if (obj.Kitap.KitapDetay.KitapDetayID == 0)
            {
                var kitapdb = _db.Kitaplar.FirstOrDefault(x => x.KitapID == obj.Kitap.KitapID);
                obj.Kitap.KitapDetay.KitapID = kitapdb.KitapID;                
                obj.Kitap.kitapDetayId = obj.Kitap.KitapDetay.KitapDetayID;
                kitapdb.kitapDetayId = obj.Kitap.KitapDetay.KitapDetayID;
                _db.KitapDetaylar.Add(obj.Kitap.KitapDetay);
                _db.SaveChanges();

            }
            else
            {
                var kitap = _db.Kitaplar.FirstOrDefault(x => x.KitapID == obj.Kitap.KitapID);
                obj.Kitap.KitapDetay.KitapID = kitap.KitapID;
                _db.KitapDetaylar.Update(obj.Kitap.KitapDetay);
                obj.Kitap.kitapDetayId = obj.Kitap.KitapDetay.KitapDetayID;
                kitap.kitapDetayId = obj.Kitap.KitapDetay.KitapDetayID;
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}