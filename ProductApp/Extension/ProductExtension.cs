using ProductApp.Manager;
using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Extention
{
     static public partial class Extension
    {
        public static void GetProduct(Product prod)
        {
            Console.WriteLine($"{prod.Id}: ADI:{prod.Name} QİYMƏTİ:  {prod.Price} man  SAYI: {prod.Count}  KATEQORİYASI: {prod.Category.Name}");

        }
        public static Categorie AddProduct(this Categorie category, Product product, AppManager manager)
        {
            product.Category = category;

            manager.Products.Add(product);

            return category;
        }
        public static Product ReadAllProduct(this AppManager manager)
        {
            Product product = new Product();
            manager.Products.ForEach(prod =>
            {
                Console.WriteLine($"{prod.Id}: ADI:{prod.Name} QİYMƏTİ:  {prod.Price} man  SAYI: {prod.Count}  KATEQORİYASI: {prod.Category.Name}");


            });

            return product;


        }
        public static void RemoveProduct(this int id, AppManager manager)
        {
            Product product = manager.Products.FirstOrDefault(b => b.Id == id);
            if (product != null)
            {
                manager.Products.Remove(product);
            }
        }
        public static void SearchProductByName(this string name, AppManager manager)
        {
            Product product = manager.Products.FirstOrDefault(b => b.Name == name);
            if (product != null)
            {
                Console.WriteLine($"{product.Id}: ADI:{product.Name} QİYMƏTİ:  {product.Price} man  SAYI: {product.Count}  KATEQORİYASI: {product.Category.Name}");

            }
            else
            {
                Console.WriteLine("Bu adda məhsul tapılmadı");
            }

        }
        public static void ChangeProductbyId(this int id ,Product product, Categorie _newcategory, AppManager manager)
        {
            
            Product prnew = manager.Products.FirstOrDefault((Product x) => x.Id ==id) ;
            if (prnew != null)
            {
                manager.Products.Remove(prnew);

                AddProduct(_newcategory, product,manager);
            }
            else { Console.WriteLine("Bele mal yoxdur"); }
        }
        public static void ChangeProductName(this int _Id, string _name ,AppManager manager)
        {
            Product product = manager.Products.Find(pr => pr.Id == _Id);
            if (product != null)
                product.Name = _name;

        }
        public static void ChangeProductPrice(this int Id, decimal _price, AppManager manager)
        {
            Product product = manager.Products.Find(pr => pr.Id == Id);
            if (product != null)
                product.Price = _price;

        }
        public static void ChangeProductCount(this int Id, int _count,AppManager manager)
        {
            Product product = manager.Products.Find(pr => pr.Id == Id);
            if (product != null)
                product.Count = _count;

        }
        public static void ChangeProductCategory(this int id, Categorie categorie,AppManager manager)
        {
            Product product = manager.Products.Find(p => p.Id == id);
            if (product != null)
                product.Category = categorie;


        }

       
    }
}

