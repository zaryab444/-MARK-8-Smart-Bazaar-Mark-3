using SmartBazar.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBazar.Models.Repository
{
    interface IProduct
    {
        void InsertProduct(Product cat);
        void EditProduct(Product cat);
        List<Product> ViewProduct();
        Product GetProductById(int id);
    }
}
