
using ProductApp.Manager;
using System;

namespace ProductApp.Models
{
   public class Categorie
    {
       static int counter = 0;
       public Categorie()
        {
            this.Id = ++counter;
        }
        public Categorie(string name)
            :this()
        {
            this.Name = name;
        }
       
        
        public int Id { get;private set; }
        public string Name{ get; set; }

        

        
    }
}
