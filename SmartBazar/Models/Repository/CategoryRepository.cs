using SmartBazar.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;

namespace SmartBazar.Models.Repository
{
    public class CategoryRepository : ICategory
    {
        EcommerceEntities db = new EcommerceEntities();
        public void EditCategory(Category item)
        {
            tbl_Category c = db.tbl_Category.Where(x => x.cat_id == item.cat_id).SingleOrDefault();
            c.cat_id = item.cat_id;
            c.cat_name = item.cat_name;
            c.cat_icon = item.cat_icon;
            c.cat_createdon = DateTime.Now;
            c.cat_fk_Ad_id = item.cat_fk_Ad_id;
            
            db.SaveChanges();

        }

        public Category GetCategoryById(int id)
        {
            tbl_Category item = db.tbl_Category.Where(x => x.cat_id == id).SingleOrDefault();
            Category c = new Category();
            c.cat_id = item.cat_id;
            c.cat_name = item.cat_name;
            c.cat_icon = item.cat_icon;
            c.cat_createdon = item.cat_createdon;
            c.cat_fk_Ad_id = item.cat_fk_Ad_id;
            return c;

        }

        public void InsertCategory(Category item)
        {
            tbl_Category c = new tbl_Category();
            c.cat_id = item.cat_id;
            c.cat_name = item.cat_name;
            c.cat_icon = item.cat_icon;
            c.cat_createdon = DateTime.Now;
            c.cat_fk_Ad_id = item.cat_fk_Ad_id;
            db.tbl_Category.Add(c);
            db.SaveChanges();

        }

        public List<Category> ViewCategory()
        {
            List<Category> li = new List<Category>();
            List<tbl_Category> cat = db.tbl_Category.ToList();
            foreach (var item in cat)
            {
                Category c = new Category();
                c.cat_id = item.cat_id;
                c.cat_name = item.cat_name;
                c.cat_icon = item.cat_icon;
                c.cat_createdon = item.cat_createdon;
                c.cat_fk_Ad_id = item.cat_fk_Ad_id;
                li.Add(c);
            }
            return li;
        }
    }
}