using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSqlManyToMany
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Modelproduct db = new Modelproduct())
            {
                // создание и добавление моделей
                Product p1 = new Product { Name = "Шоколад", Price = 31 };
                Product p2 = new Product { Name = "Кофе", Price = 280 };
                Product p3 = new Product { Name = "Халва", Price = 74 };
                Product p4 = new Product { Name = "Рыба", Price = 220 };
                db.Products.AddRange(new List<Product> { p1, p2, p3, p4 });
                db.SaveChanges();

                Category c1 = new Category { Name = "Десерт" };
                c1.Products.Add(p1);
                c1.Products.Add(p3);
                c1.Products.Add(p2);

                Category c2 = new Category { Name = "Напиток" };
                c2.Products.Add(p2);


                db.Categories.Add(c1);
                db.Categories.Add(c2);

                db.SaveChanges();
                /*
                foreach (Team t in db.Teams.Include(t => t.Players))
                {
                    Console.WriteLine("Команда: {0}", t.Name);
                    foreach (Player pl in t.Players)
                    {
                        Console.WriteLine("{0} - {1}", pl.Name, pl.Position);
                    }
                    Console.WriteLine();
                }
                */
            }
        }
    }
}
