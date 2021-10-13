
using ProductApp.Extention;
using ProductApp.Manager;
using ProductApp.Models;
using System;
using System.Text;

namespace ProductApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            AppManager manager = new AppManager();

            Extension.AddCategory("MƏİŞƏT TEXNİKASI",manager);
           Extension.AddCategory("TELEFON VƏ PLANŞETLƏR",manager);
            Extension.AddCategory("KOMPÜTER TEXNİKASI",manager);
            Extension.AddCategory("TV,AUDİO,FOTO-VİDEO",manager);
            Extension.AddCategory("MUSİQİ ALƏTLƏRİ",manager);
            Categorie c1 = Extension.GetCategoryById(1,manager);
            Categorie c2 = Extension.GetCategoryById(2, manager);
            Categorie c3 = Extension.GetCategoryById(3, manager);
            Categorie c4 = Extension.GetCategoryById(4, manager);
            Categorie c5 = Extension.GetCategoryById(5, manager);
            c1.AddProduct(new Product("paltaryuyan", 350, 5), manager);
            c1.AddProduct(new Product("qabyuyan", 550, 2), manager);
            c2.AddProduct(new Product("Mobil telefonlar", 550, 15), manager);
            c2.AddProduct(new Product("Ev telefonlari", 50, 25), manager);
            c3.AddProduct(new Product("pLaptop", 350, 5), manager);
            c3.AddProduct(new Product("Persolan", 550, 2), manager);
            c4.AddProduct(new Product("Canon ", 550, 15), manager);
            c4.AddProduct(new Product("Samsung", 50, 25), manager);
            c5.AddProduct(new Product("Gitara", 550, 15), manager);
            c5.AddProduct(new Product("Pianino", 50, 25), manager);


            Load(manager);










        }
        private static void Load(AppManager manager)
        {

           


            string secim = "";
           
            Console.WriteLine("Dogru secim edin");

            Console.WriteLine("*******************************************Bolluq online marketinə xoş gəlmisiniz*******************************************\n\n\n");
            Console.WriteLine("=============================================");
            Console.WriteLine("== 1.Məhsulların kateqoriyaları üzərində əməliyyat aparmaq. ==");
            Console.WriteLine("== 2.Məhsullar üzərində əməliyyat aparmaq  ==");
            Console.WriteLine("== 3.Sistemden cixmaq.                     ==");
            Console.WriteLine("=============================================");

            Console.WriteLine("Seciminizi daxil edin");
            secim = Console.ReadLine();

           
            switch (secim)
            {
                case "1":
                    Console.WriteLine("1.1.Yeni Kateqoriya əlavə et:");
                    Console.WriteLine("1.2.Kateqoriya üzərində düzəliş et");
                    Console.WriteLine("1.3.Kateqoriyanı sil:");
                    Console.WriteLine("1.4.Bütün kateqoriyaları göstər:");
                    Console.WriteLine("1.5.İd-sinə görə kateqoriyaları göstər");
                    Console.WriteLine("1.6.Kateqoriyalar üzərində ada görə axtarış et:");


                    Console.WriteLine("Seciminizi daxil edin");
                    secim = Console.ReadLine();

                    break;
                case "2":
                    Console.WriteLine("2.1.Yeni məhsul əlavə et:");
                    Console.WriteLine("2.2.Məhsullar üzərində düzəliş et");
                    Console.WriteLine("2.3.Məhsulu sil:");
                    Console.WriteLine("2.4.Bütün məhsulları göstər:");
                    Console.WriteLine("2.5.İd-sinə görə məhsulları göstər");
                    Console.WriteLine("2.6.Məhsullar üzərində ada görə axtarış et:");
                    Console.WriteLine("2.7.Məhsullar üzərində kateqoriyaya görə axtarış et:");
                    Console.WriteLine("2.8.Məhsullar üzərində qiymət aralığına görə axtarış et:");






                    Console.WriteLine("Seciminizi daxil edin");
                    secim = Console.ReadLine();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    {
                        Console.Clear();
                        Console.Beep();
                       
                        Load(null);

                        break;
                    }
            }

            switch (secim)
            {
                case "1.1":
                    {
                        string name;
                        name = Extension.ReadString("Cateqoriyanın adı: ");
                        Extension.AddCategory(name,manager);
                        Console.WriteLine("Yeni  kateqoriya stoka elave edildi");
                        Console.Clear();
                        Load(manager);
                       
                        break;
                    }
                case "1.2":
                    {


                    labelReadCategory:
                        Console.Write("\n Deyismek istediyiniz kateqoriyanin kodunu seçin:");
                        Extension.ReadAllCategories(manager);

                        if (!int.TryParse(Console.ReadLine(), out int catId))
                            goto labelReadCategory;

                        var selected = manager.Categories.Find(a => a.Id == catId);

                        if (selected == null)
                        {
                            Console.WriteLine("bele kateqoriya yoxdur.");
                            goto labelReadCategory;
                        }

                        selected.Name = Extension.ReadString("Yeni ad ");
                        Console.WriteLine("Deyisiklik edildi");
                       
                        Load(manager);
                       
                        break;
                        
                    }
                case "1.3":
                    {
                        int Id;
                        Extension.ReadAllCategories(manager);
                        Id = Extension.ReadInteger("Sileceyiniz kateqoriyanin Id-ni daxil edin: ");
                        Extension.RemoveCategory(Id, manager);
                        Console.WriteLine("Kateqoriya stokdan silindi");
                        Load(manager);
                        break;
                    }
                case "1.4":
                    {
                        Console.WriteLine("Stokda olan bütün kateqoriyalar: \n\n");
                        Extension.ReadAllCategories(manager);
                        Load(manager);
                       
                        break;

                    }
                case ("1.5"):
                    {
                        int id;
                        id = Extension.ReadInteger("Tapmaq istediyiniz kateqoriyanin Id-ni daxil edin");
                        manager.Categories.ForEach(cat =>
                        {
                            if (cat.Id == id)
                            
                                Extension.GetCategory(cat);
                           
                                
                        });
                       
                        Load(manager);

                    }
                    break;
                case ("1.6"):
                    {
                        string name;
                        name = Extension.ReadString("Tapmaq istediyiniz kateqoriyanin adini daxil edin ");
                        Extension.SearchCategoryByName(name, manager);
                        Load(manager);

                    }
                    break;

                default:
                    break;
            }


            switch (secim)
            {

                case "2.1":
                    {
                       
                    labelReadCategory:
                        Console.WriteLine("\n Kateqoriya kodunu seçin:");

                        Extension.ReadAllCategories(manager);

                        if (!int.TryParse(Console.ReadLine(), out int catId))
                                goto labelReadCategory;

                        var selected = manager.Categories.Find((a) => a.Id == catId);

                            if (selected == null)
                            {
                                Console.WriteLine("bele kateqoriya yoxdur.");
                                goto labelReadCategory;
                        }

                            string ProductName = Extension.ReadString("Produktun adı: ");
                            int Count = Extension.ReadInteger("Produktun sayı: ");
                            decimal price = Extension.ReadDecimal("Produktun qiyməti: ");

                            selected.AddProduct(new Product(ProductName, price, Count), manager);
                            Console.WriteLine("Yeni produkt bilgileri stoka elave edildi");
                        

                        Load(manager);
                       
                        break;
                    }
                case "2.2":
                    {

                        Console.WriteLine("2.2.1. Mehsulda umumi deyisiklik aparmaq:");
                        Console.WriteLine("2.2.2. Mehsulun adini deyismek");
                        Console.WriteLine("2.2.3. Mehsulun qiymetini deyismek");
                        Console.WriteLine("2.2.4.Mehsulun sayini deyismek");
                        Console.WriteLine("2.2.5.Mehsulun kateqoriyasini deyismek");
                        Console.WriteLine("Seciminizi daxil edin");
                        secim = Console.ReadLine();
                        break;
                    }

                case "2.3":
                    {
                        int Id;
                        Extension.ReadAllProduct(manager);
                        Id = Extension.ReadInteger("Sileceyiniz produktun Id-ni daxil edin: ");
                        Extension.RemoveProduct(Id, manager);
                        Console.WriteLine("Produkt stokdan silindi");
                        Load(manager);
                        break;
                    }
                case "2.4":
                    {
                        Console.WriteLine("Stokda olan bütün məhsullar: \n\n");
                        Extension.ReadAllProduct(manager);
                        Load(manager);
                        Console.Clear();
                        break;

                    }
                case ("2.5"):
                    {
                        int id;
                        Console.WriteLine("Tapmaq istediyiniz mehsulun Id-ni daxil edin");
                        id = int.Parse(Console.ReadLine());



                        manager.Products.ForEach(prod =>
                        {
                            if (prod.Id == id)
                                Extension.GetProduct(prod);
                        });
                        Console.ReadLine();
                        Load(manager);

                    }
                    break;

                case ("2.6"):
                    {
                        string name;
                        name = Extension.ReadString("Tapmaq istediyiniz mehsulun adini daxil edin ");
                        Extension.SearchProductByName(name, manager);
                        Load(manager);

                    }
                    break;
                case ("2.7"):
                    {
                        Console.WriteLine("Tapmaq istediyiniz kateqoriyani daxil edin");
                        Extension.ReadAllCategories(manager);


                        int Id = Convert.ToInt32(Console.ReadLine());
                        manager.Products.ForEach(prod =>
                        {
                            if (prod.Category.Id == Id)
                                Extension.GetProduct(prod);
                        });
                       

                        Load(manager);


                    }
                    break;
                case ("2.8"):
                    {
                        Console.WriteLine("Hansı aralıqda  qiymetlərdə məhsul axtarırsınız? Qiymətləri daxil edin");
                        decimal FirstPrice= Extension.ReadDecimal("Birinci qiymət  ");
                         decimal SecondPrice=Extension.ReadDecimal("İkinci qiymət  ");

                        manager.Products.ForEach(prod =>
                        {
                            if (prod.Price >= FirstPrice && prod.Price <= SecondPrice)
                                Extension.GetProduct(prod);
                              
                        });
                        Console.ReadLine();
                        Load(manager);
                    }
                    break;

                default:
                    {
                        Console.Clear();
                        Console.Beep();

                        Load(null);

                        break;
                    }

            }

            switch (secim)
            {
                case ("2.2.1"):
                    {
                        int Id;
                        string  name;
                        decimal price;
                        int count;
                        Categorie category;
                        Id = Extension.ReadInteger("Deyismek istediyiniz productun Id-ni daxil edin");
                    labelReadCategory:
                        Console.WriteLine("\n Kateqoriya kodunu seçin:");

                        Extension.ReadAllCategories(manager);

                        if (!int.TryParse(Console.ReadLine(), out int catId))
                            goto labelReadCategory;

                        var selected = manager.Categories.Find((a) => a.Id == catId);

                        if (selected == null)
                        {
                            Console.WriteLine("bele kateqoriya yoxdur.");
                            goto labelReadCategory;
                        }

                        name = Extension.ReadString("Yeni Mal adini daxil edin ");
                       price= Extension.ReadDecimal("Yeni Mal qiymetini daxil edin ");
                       count= Extension.ReadInteger("Yeni Mal sayini daxil edin ");
                      
                        Extension.ChangeProductbyId(Id,new Product( name, price, count),selected,manager);
                        Console.WriteLine("Ugurla deyisdirildi");
                        
                        Load(manager);
                    }
                    break;

                case "2.2.2":
                    {

                        int Id=Extension.ReadInteger("Deyiseceyiniz mehsulun Id-ni daxil edin ");
                        if (manager.Products.Exists(p => p.Id == Id))
                        {
                            string name=Extension.ReadString("Yeni adi daxil edin ");
                            Extension.ChangeProductName(Id, name,manager);
                            Console.WriteLine("Ad deyisildi");
                        }
                        else
                        {
                            Console.WriteLine("Daxil etdiyiniz koda mexsus mehsul yoxdur");
                        }
                        Load(manager);
                    }
                    break;
                case ("2.2.3"):
                    {
                       int Id= Extension.ReadInteger("Deyiseceyiniz mehsulun Id-ni daxil edin ");
                       
                        if (manager.Products.Exists(p => p.Id == Id))
                        {
                            decimal NewPrice=Extension.ReadInteger("Yeni qiymeti daxil edin: ");
                            Extension.ChangeProductPrice(Id, NewPrice, manager);
                            Console.WriteLine("Mehsulun qiymeti deyisildi:");
                        }
                        else
                        {
                            Console.WriteLine("Daxil etdiyiniz koda mexsus mehsul yoxdur");
                        }
                    }
                    Load(manager);
                    break;
                case ("2.2.4"):
                    {
                        int Id = Extension.ReadInteger("Deyiseceyiniz mehsulun Id-ni daxil edin ");
                        if (manager.Products.Exists(p => p.Id == Id))
                        {
                            int NewCount=Extension.ReadInteger("Yeni sayi daxil edin:");
                            Extension.ChangeProductCount(Id, NewCount, manager);
                            Console.WriteLine("Mehsulun sayi deyisildi:");
                        }
                        else
                        {
                            Console.WriteLine("Daxil etdiyiniz koda mexsus mehsul yoxdur");
                        }
                        Load(manager);
                    }
                    break;
                case ("2.2.5"):
                    {
                        int Id = Extension.ReadInteger("Deyiseceyiniz mehsulun Id-ni daxil edin ");
                        if (manager.Products.Exists(p => p.Id == Id))
                        {
                            labelReadCategory:
                            Console.WriteLine("\n Kateqoriya kodunu seçin:");

                            Extension.ReadAllCategories(manager);

                            if (!int.TryParse(Console.ReadLine(), out int catId))
                                goto labelReadCategory;

                            var selected = manager.Categories.Find((a) => a.Id == catId);

                            if (selected == null)
                            {
                                Console.WriteLine("bele kateqoriya yoxdur.");
                                goto labelReadCategory;
                            }

                            Extension.ChangeProductCategory(Id, selected, manager);
                            Console.WriteLine("Mehsulun sayi deyisildi:");
                        }
                        else
                        {
                            Console.WriteLine("Daxil etdiyiniz koda mexsus mehsul yoxdur");
                        }
                        Load(manager);
                    }
                    break;
                default:
                    {
                        Console.Clear();
                        Console.Beep();

                        Load(null);

                        break;
                    }
            }
            }



       
    }
}
