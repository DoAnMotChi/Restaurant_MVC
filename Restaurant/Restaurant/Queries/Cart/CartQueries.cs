using Restaurant.ViewModel.Cart;
using Restaurant.ViewModel.MonAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Queries.Cart
{
    public class CartQueries
    {
        public static void AddToCart(BookedFoodViewModel model,ref CartViewModel  cart)
        {
            var item = cart.Foods.FirstOrDefault(t => t.ID == model.ID);
            if (item!=null)
            {
                cart.Foods[cart.Foods.IndexOf(item)].Quantity += model.Quantity;
            }
            else
            {
                cart.Foods.Add(model);
            }
        }
    }
}