using Restaurant.Constants;
using Restaurant.Queries.Cart;
using Restaurant.ViewModel.Cart;
using Restaurant.ViewModel.MonAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class CartController : Controller
    {
        // GET: GioHang
        public ActionResult AddToCart(BookedFoodViewModel model)
        {
            CartViewModel cart;
            if (Session[ConstantsVariable.CART] != null)
            {
                cart = (CartViewModel)Session[ConstantsVariable.CART];
                CartQueries.AddToCart(model, ref cart);
            }
            else
            {
                cart = new CartViewModel();
                cart.Foods.Add(model);
            }
            Session[ConstantsVariable.CART] = cart;
            return RedirectToAction("Index", "Home");
        }
    }
}