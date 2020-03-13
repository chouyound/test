using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    [Serializable]
    public class Product
    {
        public Product(int id, string name, double price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}",this.Id,this.Name,this.Price);
        }
    }
}
