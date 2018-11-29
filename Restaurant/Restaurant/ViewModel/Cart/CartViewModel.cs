using Restaurant.ViewModel.MonAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.ViewModel.Cart
{
    public class CartViewModel
    {
        public CartViewModel()
        {
            Foods = new List<BookedFoodViewModel>();
            TotalMoney = 0;
        }

        public List<BookedFoodViewModel> Foods { get; set; }

        public decimal TotalMoney { get; set; }
    }

   
}