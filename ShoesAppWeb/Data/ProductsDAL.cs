using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductsDAL
    {
        public List<Products> ProductsList()
        {
            using(DataProductsContext db = new DataProductsContext())
            {
                return db.Products.ToList();
            }
        }


        public void Add(Products prod)
        {
            using(DataProductsContext db = new DataProductsContext())
            {
                db.Products.Add(prod);
                db.SaveChanges();
            }
        }


        public Products Details(int id)
        {
            using(DataProductsContext db = new DataProductsContext())
            {
                //return db.Products.Find(id);
                return db.Products.Where(p => p.Id == id).FirstOrDefault();
            }
        }


        public void Edit(Products prod)
        {
            using(DataProductsContext db = new DataProductsContext())
            {
                var p = db.Products.Find(prod.Id);
                p.CatBrands = prod.CatBrands;
                p.CatCatalogs = prod.CatCatalogs;
                p.CatColors = prod.CatColors;
                p.CatProviders = prod.CatProviders;
                p.CatTypeProduct = prod.CatTypeProduct;
                p.Comments = prod.Comments;
                p.DateUpdate = prod.DateUpdate;
                p.Description = prod.Description;
                p.DetailProduct = prod.DetailProduct;
                p.IdBrand = prod.IdBrand;
                p.IdCatalog = prod.IdCatalog;
                p.IdColor = prod.IdColor;
                p.IdProvider = prod.IdProvider;
                p.IdType = prod.IdType;
                p.ImagesProduct = prod.ImagesProduct;
                p.IsEnabled = prod.IsEnabled;
                p.Keywords = prod.Keywords;
                p.Nombre = prod.Nombre;
                p.Observations = prod.Observations;
                p.PriceClient = prod.PriceClient;
                p.PriceDistributor = prod.PriceDistributor;
                p.PriceMember = prod.PriceMember;
                p.Qualification = prod.Qualification;
                p.SimilarProduct = prod.SimilarProduct;
                p.SizeForProduct = prod.SizeForProduct;
                p.Title = prod.Title;
                db.SaveChanges();
            }
        }


        public void Delete(int id)
        {
            using(DataProductsContext db = new DataProductsContext())
            {
                var prod = db.Products.Find(id);
                db.Products.Remove(prod);
                db.SaveChanges();
            }
        }
    }
}
