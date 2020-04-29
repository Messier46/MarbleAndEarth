using MarbleAndEarth.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarbleAndEarth.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {

            using (MEContext context = new MEContext())
            {
                var list = context.Purchases.OrderBy(x => x.Id).ToList();
                int re = 0;
                foreach (var item in list)
                {
                    var holder = "";
                    string phrase = item.ProductId;
                    string[] idSp = phrase.Split(',');
                    foreach(var x in idSp)
                    {
                        var y = context.Products.Find(int.Parse(x));
                        if(y != null)
                        {
                            holder = holder +  y.Name + ", ";

                        }
                        else
                        {
                            holder = holder + "Removed product, ";
                        }
                    }
                    list[re].ProductId = holder;
                    re++;
                }
                
                return View(list);
            }
            
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Product obj)
        {
            try
            {
                using (MEContext context = new MEContext())
                {
                    context.Products.Add(obj);
                    context.SaveChanges();
                    return Redirect("~/Product/Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            Product result = null;
            using (MEContext context = new MEContext())
            {
                result = context.Products.Find(id);
            }
            return View(result);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                using (MEContext context = new MEContext())
                {
                    var c = context.Products.Find(id);
                    TryUpdateModel(c);
                    context.SaveChanges();
                    return Redirect("~/Product/Index");
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            Product result = null;
            using (MEContext context = new MEContext())
            {
                result = context.Products.Find(id);
            }
            return View(result);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (MEContext context = new MEContext())
                {
                    var c = context.Products.Find(id);
                    context.Products.Remove(c);
                    context.SaveChanges();
                    return Redirect("~/Product/Index");
                }
            }
            catch
            {
                return View();
            }
        }

    }
}
