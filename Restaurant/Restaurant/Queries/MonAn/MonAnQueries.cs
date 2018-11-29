using Restaurant.Models;
using Restaurant.ViewModel.MonAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Queries.MonAn
{
    public class MonAnQueries
    {
        public static List<MonAnViewModel> LoadMonAn()
        {
            QUANLYQUANANEntities entities = new QUANLYQUANANEntities();
            try
            {
                var res = (from m in entities.MONANs
                           select new MonAnViewModel()
                           {
                               Ma = m.MAMONAN,
                               Anh = m.HINHANH,
                               Ten = m.TENMONAN,
                           }).ToList();
                return res;
            }
            catch (Exception)
            {
                entities.Dispose();
                return null;
            }
        }

        public static MonAnViewModel FindFood(string maMonAn)
        {
            QUANLYQUANANEntities entities = new QUANLYQUANANEntities();
            var res = entities.MONANs.FirstOrDefault(t => t.MAMONAN==maMonAn);
            if (res != null)
            {
                return new MonAnViewModel()
                {
                    Anh = res.HINHANH,
                    Ten = res.TENMONAN,
                    MoTa = res.MOTA,
                    Ma=res.MAMONAN
                };
            }
            return null;
        }
    }
}