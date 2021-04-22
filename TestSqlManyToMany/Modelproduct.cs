using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TestSqlManyToMany
{
    class MyContextInitializer : CreateDatabaseIfNotExists<Modelproduct>
    {
        protected override void Seed(Modelproduct db)
        {
            base.Seed(db);

        }
    }

    public class Modelproduct : DbContext
    {
        // Контекст настроен для использования строки подключения "Modelproduct" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "TestSqlManyToMany.Modelproduct" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "Modelproduct" 
        // в файле конфигурации приложения.
        public Modelproduct()
            : base("name=Modelproduct")
        {
            Database.SetInitializer<Modelproduct>(new MyContextInitializer());
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ICollection<Category> Categories { get; set; }
        public Product()
        {
            Categories = new List<Category>();
        }
    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        public Category()
        {
            Products = new List<Product>();
        }
    }
}