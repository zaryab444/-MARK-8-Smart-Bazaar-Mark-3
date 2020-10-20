using SmartBazar.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBazar.Models.Repository
{
    interface ICategory
    {

        void InsertCategory(Category cat);
        void EditCategory(Category cat);
        List<Category> ViewCategory();  //see the list of category
        Category GetCategoryById(int id);
    }
}
