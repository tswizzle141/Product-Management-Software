using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QLSP
{
    class ConfigJson
    {
    }
    public class DataProductList_Ninh
    {
        public List<Product> products { get; set; }
        public List<Currency> currency { get; set; }
        public DataProductList_Ninh()
        {
            products = new List<Product>();
            currency = new List<Currency>();
        }
    }
    public class Name_product<T>
    {
        public T[] products { get; set; }

    }

    public class Product
    {
        public String Type { get; set; }
        public String Name { get; set; }
        public String Amount { get; set; }
        public String Prices { get; set; }
        public String USD { get; set; }
        public String VND { get; set; }
        public String EUR { get; set; }
        public String RMB { get; set; }
        public String KRW { get; set; }
        public String Warranty { get; set; }
        public String Availability { get; set; }
    }
    
    public class Bill_GTGT
    {
        public String Date { get; set; }
        public String Name { get; set; }
        public String Company { get; set; }
        public String Address { get; set; }
        public String Account { get; set; }
        public String Pay { get; set; }
        public String Tax { get; set; }


    }
    public class Bill_Thuong
    {
        public String Date { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Account { get; set; }
        public String Pay { get; set; }


    }

    public class Info_bill_add<T>
    {
        public List<T> bill { get; set; }
        
    }
    public class Info_bill_repair<T>
    {
        public T[] bill { get; set; }

    }
    public class Currency
    {
        public String Type { get; set; }
    }

    public class Name_currency<T>
    {
        public T[] currency { get; set; }
    }
}
