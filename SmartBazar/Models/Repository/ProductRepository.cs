using SmartBazar.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartBazar.Models.Repository
{
    public class ProductRepository : IProduct
    {
        EcommerceEntities db = new EcommerceEntities();
        public void EditProduct(Product cat)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            tbl_product item = db.tbl_product.Where(x => x.pro_id == id).SingleOrDefault();
            Product c = new Product();
            if (item != null)
            {
                c.pro_id = item.pro_id;
                c.pro_name = item.pro_name;
                c.pro_price = item.pro_price;
                c.pro_image1 = item.pro_image1;
                c.pro_image2 = item.pro_image2;
                c.pro_image3 = item.pro_image3;
                c.pro_desc = item.pro_desc;
                c.pro_fk_cat_id = item.pro_fk_cat_id;
                
            }

            return c;
        }

        public void InsertProduct(Product cat)
        {
            throw new NotImplementedException();
        }

        public List<Product> ViewProduct()
        {
            List<Product> li = new List<Product>();
            List<tbl_product> cat = db.tbl_product.ToList();
            foreach (var item in cat)
            {
                Product c = new Product();
                c.pro_id = item.pro_id;
                c.pro_name = item.pro_name;
                c.pro_price = item.pro_price;
                c.pro_image1 = item.pro_image1;
                c.pro_image2 = item.pro_image2;
                c.pro_image3 = item.pro_image3;
                c.pro_desc = item.pro_desc;
                c.pro_fk_cat_id = item.pro_fk_cat_id;
                li.Add(c);
            }
            return li;
        }
    }
}