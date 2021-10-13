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
        public static void GetCategory(Categorie cat)
        {
            Console.WriteLine($"{cat.Id}: ADI:{cat.Name}");

        }
        public static void AddCategory(this string name,AppManager manager)
        {
            Categorie categorie = new Categorie(name);

            manager.Categories.Add(categorie);
        }
        public static  void RemoveCategory(this int Id, AppManager manager)
        {
            Categorie cat = manager.Categories.FirstOrDefault(a => a.Id == Id);
            if (cat != null)
            {
                manager.Categories.Remove(cat);
            }
        }
        public static Categorie GetCategoryById(this int id, AppManager manager)
        {

            Categorie cat = manager.Categories.FirstOrDefault(a => a.Id == id);

            return cat;
        }
        public static  void ReadAllCategories(AppManager manager)
        {

            foreach (var item in manager.Categories)
            {
                Console.WriteLine($"{item.Id} {item.Name}");
            }
        }
        public static void SearchCategoryByName(this string name, AppManager manager)
        {
            Categorie category = manager.Categories.FirstOrDefault(b => b.Name == name);
            if (category != null)
            {
                Console.WriteLine($"{category.Id}: ADI:{category.Name} ");
            }
            else
            {
                Console.WriteLine("Bu adda məhsul tapılmadı");
            }

        }

    }
}

