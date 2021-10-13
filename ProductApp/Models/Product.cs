

using System;

namespace ProductApp.Models
{
  public  class Product
    {
        static int counter = 0;
        public Product()
        {
            this.Id = ++counter;
        }
        public Product(string name)
            : this()
        {
            this.Name = name;
        }
        public Product(string name,decimal price,int count)
           : this(name)
        {
            this.Price = price;
            this.Count = count;
        }
        public Product(string name, decimal price, int count, Categorie categorie)
           : this(name, price, count)
        {
            this.Category = categorie;
        }
        public int Id { get; private set; }
        public string Name { get; set; }
        public decimal Price{ get; set; }
        public int Count { get; set; }
        public Categorie Category{ get; set; }


    }
}
