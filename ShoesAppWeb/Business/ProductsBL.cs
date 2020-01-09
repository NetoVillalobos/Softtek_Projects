using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductsBL
    {
        private static ProductsDAL obj = new ProductsDAL();
        public static List<Products> ProductsList()
        {
            return obj.ProductsList();
        }


        public static void Add(Products prod)
        {
            obj.Add(prod);
        }


        public static Products Details(int id)
        {
            return obj.Details(id);
        }


        public static void Edit(Products prod)
        {
            obj.Edit(prod);
        }


        public static void Delete(int id)
        {
            obj.Delete(id);
        }
    }
}
