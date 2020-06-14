using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yanai.Models
{
    public class Product
    {
        int productId;
        string productName;

        public int ProductId { get => productId; set => productId = value; }
        public string ProductName { get => productName; set => productName = value; }

        public List<Product> GetProducts()
        {
            DBservices dbs = new DBservices();
            return dbs.getProductsList();
        }
    }
}