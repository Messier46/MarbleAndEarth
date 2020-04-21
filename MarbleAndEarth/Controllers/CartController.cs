using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarbleAndEarth.Models;

namespace MarbleAndEarth.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Buy(int id)
        {
            using (MEContext context = new MEContext())
            {
                if(Session["cart"] == null)
                {
                    List<Item> cart = new List<Item>();
                    cart.Add(new Item { Product = context.Products.Find(id), Quanity = 1 });
                    Session["cart"] = cart;
                }
                else
                {
                    List<Item> cart = (List<Item>)Session["cart"];
                    int index = isExist(id);
                    if(index != -1)
                    {
                        cart[index].Quanity++;
                    }
                    else
                    {
                        cart.Add(new Item { Product = context.Products.Find(id), Quanity = 1 });
                    }
                    Session["cart"] = cart;
                }

                var toChange = context.Products.Find(id);
                toChange.Qty -= 1;

                context.Entry(toChange).State = EntityState.Modified;
                context.SaveChanges();


            }
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            int removedQty = cart[index].Quanity;
            cart.RemoveAt(index);
            if(cart.Count == 0)
            {
                cart = null;
            }
            Session["cart"] = cart;
            using(MEContext context = new MEContext())
            {
                var toChange = context.Products.Find(id);
                toChange.Qty += removedQty;

                context.Entry(toChange).State = EntityState.Modified;
                context.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for(int i = 0; i < cart.Count; i++)
            
                if (cart[i].Product.Id.Equals(id))
                    return i;
            return -1;
        }
    }
}