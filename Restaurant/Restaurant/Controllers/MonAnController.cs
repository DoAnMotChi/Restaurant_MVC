using Restaurant.Constants;
using Restaurant.Models;
using Restaurant.Queries.Cart;
using Restaurant.Queries.MonAn;
using Restaurant.ViewModel.Cart;
using Restaurant.ViewModel.MonAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class MonAnController : Controller
    {
        // GET: MonAn
        public ActionResult ChiTietMonAn(string id)
        {
            var model = MonAnQueries.FindFood(id);
            CartViewModel cart = (CartViewModel)Session[ConstantsVariable.CART];
            List<MonAnViewModel> recommendedFoods = RecommendedFoodQueries.Loc_CollaborativeFiltering(cart, id, 4);
            ViewBag.RecommendedFoods = recommendedFoods;
            return View(model);
        }
    }
}