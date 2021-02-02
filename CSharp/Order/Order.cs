using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Orderns
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<string> items { get; set; } = new List<string> { };
        public Double price { get; set; }

        public string ItemListToString()
        {
            string l = "\n    {";
           
            foreach (string item in this.items)
                l += "\n      "+item+",";
            
            return l += "\n    }";
        }
    }
}
