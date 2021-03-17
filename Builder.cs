using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP
{
    interface IPCBuilder
    {
        void AddRAM(string ip_str_name, string ip_str_amount);
        void AddMainboard(string ip_strip_str_name, string ip_str_amount);
        void AddSSD(string ip_strip_str_name, string ip_str_amount);
        void AddHDD(string ip_str_name, string ip_str_amount);
        void AddGraphicCard(string ip_str_name, string ip_str_amount);
        void AddCPU(string ip_str_name, string ip_str_amount);
    }

    interface ICurrencyBuilder
    {
        void AddUSD();
        void AddEUR();
        void AddRMB();
        void AddKRW();
    }
    public class ConcretePCBuilder : IPCBuilder
    {
        private List<Product> products = new List<Product>();
        public void Reset()
        {
            products = new List<Product>();
        }
        public void AddRAM(string ip_str_name, string ip_str_amount)
        {
            Add("RAM", ip_str_name, ip_str_amount);
        }
        public void AddMainboard(string ip_str_name, string ip_str_amount)
        {
            Add("Mainboard", ip_str_name, ip_str_amount);
        }
        public void AddSSD(string ip_str_name, string ip_str_amount)
        {
            Add("SSD", ip_str_name, ip_str_amount);
        }
        public void AddHDD(string ip_str_name, string ip_str_amount)
        {
            Add("HDD", ip_str_name, ip_str_amount);
        }
        public void AddGraphicCard(string ip_str_name, string ip_str_amount)
        {
            Add("Graphic Card", ip_str_name, ip_str_amount);
        }
        public void AddCPU(string ip_str_name, string ip_str_amount)
        {
            Add("CPU", ip_str_name, ip_str_amount);
        }
        
        public void Add(string ip_str_type, string ip_str_name, string ip_str_amount)
        {
            Product product = new Product
            {
                Type = ip_str_type,
                Name = ip_str_name,
                Amount = ip_str_amount,
            };
            products.Add(product);
        }
        public void UpdatePriceWarranty(int ip_i_id, string ip_str_price, string ip_str_warranty)
        {
            if (ip_i_id < 0 || ip_i_id >= products.Count) return;
            products[ip_i_id].Prices = ip_str_price;
            products[ip_i_id].Warranty = ip_str_warranty;
        }
        public void UpdateAmount(int ip_i_id, string ip_str_amount)
        {
            if (ip_i_id < 0 || ip_i_id >= products.Count) return;
            products[ip_i_id].Amount = ip_str_amount;
        }
        public void Remove(int _id)
        {
            products.RemoveAt(_id);
        }
        public List<Product> GetProduct()
        {
            return products;
        }
    }
    public class ConcreteCurrencyBuilder : ICurrencyBuilder
    {
        private List<Currency> currencies = new List<Currency>();
        public void Reset()
        {
            currencies = new List<Currency>();
        }
        public void AddUSD()
        {
            currencies.Add(new Currency
            {
                Type = "USD"
            });
        }
        public void AddEUR()
        {
            currencies.Add(new Currency
            {
                Type = "EUR"
            });
        }
        public void AddKRW()
        {
            currencies.Add(new Currency
            {
                Type = "KRW"
            });
        }
        public void AddRMB()
        {
            currencies.Add(new Currency
            {
                Type = "RMB"
            });
        }
        public void Remove(int ip_i_id)
        {
            currencies.RemoveAt(ip_i_id);
        }
        public void Update(int ip_i_id, string ip_str_type)
        {
            currencies[ip_i_id].Type = ip_str_type;
        }
        public List<Currency> GetCurrencies()
        {
            return currencies;
        }
    }
    public class PCDirector
    {
        private ConcretePCBuilder pcBuilder;
        public ConcretePCBuilder PCBuilder
        {
            set { pcBuilder = value; }
        }
        public void BuildBasic()
        {
            pcBuilder.AddCPU("Intel Pentium Gold G5400", "1");
            pcBuilder.AddMainboard("MSI H310M", "1");
            pcBuilder.AddHDD("WD 500GB", "1");
            pcBuilder.AddRAM("Kingston DDR4 4GB", "1");
        }
        public void BuildAdvanced()
        {
            pcBuilder.AddCPU("Intel Core i5-10400", "1");
            pcBuilder.AddMainboard("Asus B460M", "1");
            pcBuilder.AddSSD("Samsung 970 500GB", "1");
            pcBuilder.AddHDD("Corsair 2TB", "1");
            pcBuilder.AddRAM("GSkill DDR4 8GB", "2");
            pcBuilder.AddGraphicCard("Gigabyte GTX 1080", "1");
        }
    }
}
