using Restaurant.Models;
using Restaurant.Queries.MonAn;
using Restaurant.ViewModel.Cart;
using Restaurant.ViewModel.MonAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Queries.Cart
{
    public class RecommendedFoodQueries
    {
        public static List<BookedFoodViewModel> GetChoosingFoods(CartViewModel cart)
        {
            QUANLYQUANANEntities entities = new QUANLYQUANANEntities();
            var foods = entities.MONANs.Select(t => t.MAMONAN).ToList().OrderBy(t=>t);
            List<BookedFoodViewModel> res = new List<BookedFoodViewModel>();
            BookedFoodViewModel food;

            if (cart == null)
            {
                foreach (var item in foods)
                {
                    food = new BookedFoodViewModel() { ID = item, Quantity = 0 };
                    res.Add(food);
                }
            }
            else
            {
                foreach (var item in foods)
                {
                    var choosenFood = cart.Foods.FirstOrDefault(t => t.ID == item);
                    if (choosenFood != null)
                    {
                        food = new BookedFoodViewModel() { ID = item, Quantity = choosenFood.Quantity };
                    }
                    else
                    {
                        food = new BookedFoodViewModel() { ID = item, Quantity = 0 };
                    }
                    res.Add(food);
                }

            }
            return res;
        }

        public static List<string> FindListHoaDon(string idFood)
        {
            QUANLYQUANANEntities entity = new QUANLYQUANANEntities();
            try
            {
                var result = (from ct in entity.CHITIETHOADONs
                              where ct.MAMONAN == idFood
                              group new { ct } by new { ct.MAHD } into grp
                              select grp.Key.MAHD
                              );
                return result.ToList();
            }
            catch (Exception)
            {
                entity.Dispose();
                return null;
            }
        }

        public static List<BookedFoodViewModel> GetBookedFoods(string idFood)
        {
            QUANLYQUANANEntities entities = new QUANLYQUANANEntities();
            List<BookedFoodViewModel> lst = new List<BookedFoodViewModel>();
            var result = entities.InHoaDon(idFood).ToList();
            if (result.Count > 0)
            {
                foreach (var item in result)
                {
                    lst.Add(new BookedFoodViewModel()
                    {
                        ID = item.MAMONAN,
                        Quantity = item.SoLuongDat
                    });
                }
            }
            return lst;
        }

        protected static List<BookedFoodViewModel> FindTheBestCollaborator(List<BookedFoodViewModel> choosingFoods,
                                                                                                     List<string> hoaDonLst)
        {
            Dictionary<string, List<BookedFoodViewModel>> matrix =
                                               new Dictionary<string, List<BookedFoodViewModel>>();
            foreach (var item in hoaDonLst)
            {
                matrix.Add(item, GetBookedFoods(item));
            }
            Dictionary<string, double> lst_R = new Dictionary<string, double>();
            foreach (var item in matrix)
            {
                lst_R.Add(item.Key, Tinh_Sim_CollaborativeFiltering(choosingFoods, item.Value));
            }
            /*--------------------------------------------------------------*/
            double max_R = lst_R.Values.ToList().Max();
            string bestHD = lst_R.FirstOrDefault(t => t.Value == max_R).Key;
            var result = matrix.FirstOrDefault(t => t.Key == bestHD).Value;
            return result;
        }

        protected static double Tinh_Sim_CollaborativeFiltering(List<BookedFoodViewModel> choosingFoods,
                                       List<BookedFoodViewModel> collabrator)
        {
            double average_Main = choosingFoods.Where(t => t.Quantity > 0).Sum(t => t.Quantity) * 1.0 / choosingFoods.Count;
            double average_Temp = collabrator.Where(t => t.Quantity > 0).Sum(t => t.Quantity) * 1.0 / collabrator.Count;
            double tuSo = 0;
            double mauSo = 0;
            double thuaSo1 = 0;
            double thuaSo2 = 0;
            int length = choosingFoods.Count;
            for (int i = 0; i < length; i++)
            {
                tuSo += (choosingFoods[i].Quantity - average_Main) * (collabrator[i].Quantity - average_Temp);
                thuaSo1 += Math.Pow(choosingFoods[i].Quantity - average_Main, 2);
                thuaSo2 += Math.Pow(collabrator[i].Quantity - average_Temp, 2);
            }
            mauSo = Math.Sqrt(thuaSo1) * Math.Sqrt(thuaSo2);
            if (mauSo != 0)
            {
                return tuSo / mauSo;
            }
            return 0;
        }

        public static List<MonAnViewModel> Loc_CollaborativeFiltering(CartViewModel cart, string idChoosenFood, int quantity_Recommended)
        {
            var dsDatKHChinh = GetChoosingFoods(cart);
            var bestCustomer = FindTheBestCollaborator(dsDatKHChinh, FindListHoaDon(idChoosenFood));
            //Lay Ds rate bang duc lo
            Dictionary<string, double> R_result = new Dictionary<string, double>();
            foreach (var item in dsDatKHChinh)
            {
                double sim;
                if (item.Quantity == 0)
                {
                    sim = bestCustomer.FirstOrDefault(t => t.ID == item.ID).Quantity;
                }
                else
                {
                    sim = item.Quantity;
                }
                R_result.Add(item.ID, sim);
            }
            //------------------------
            var res = R_result.OrderByDescending(t => t.Value).Select(t => t.Key).ToList();
            int indexChoosenFood = res.FindIndex(t => t == idChoosenFood);
            res.RemoveAt(indexChoosenFood);
            var collection = res.Take(quantity_Recommended).ToList();
            List<MonAnViewModel> recommendedResult = new List<MonAnViewModel>();
            if (collection.Count > 0)
            {
                foreach (var item in collection)
                {
                    recommendedResult.Add(MonAnQueries.FindFood(item));
                }
            }
            return recommendedResult;
        }


    }
}