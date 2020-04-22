using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarbleAndEarth.Models;
using Microsoft.AspNet.Identity;

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
        [Authorize]
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
        [Authorize]
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

        public ActionResult Checkout()
        {
            if (Session["cart"] == null)
            {
                return Redirect("~/Product/Index/");
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Checkout(Purchases obj)
        {
            if (obj == null)
            {
                Response.Redirect("Index");
            }
            List<Item> cart = (List<Item>)Session["cart"];

            List<string> products = new List<string>();
            for (int i = 0; i < cart.Count; i++)
            {
                products.Add(cart[i].Product.Id.ToString());
            }
            string prodIdString = string.Join(",", products.ToArray());
            try
            {
                using (MEContext context = new MEContext())
                {
                    obj.CustomerId = User.Identity.GetUserId();
                    obj.ProductId = prodIdString;
                    obj.PurchaseDate = DateTime.Now;
                    context.Purchases.Add(obj);
                    context.SaveChanges();
                    Session["cart"] = null;
                    return Redirect("~/Home/Index/");
                }
            }
            catch
            {
                return View();
            }

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