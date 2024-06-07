using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore
{
    abstract class Product
    {
        // Перегружаем конструктор абстрактного класса
        public Product(string Name, string Group, string Type, string Kind, string Color,
            string Material, int Count, double Price, string Brand, string Counrty)
        {
            this.Name = Name;
            this.Group = Group;
            this.Type = Type;
            this.Kind = Kind;
            this.Color = Color;
            this.Material = Material;
            this.Count = Count;
            this.Price = Price;
            this.Brand = Brand;
            this.Country = Counrty;
        }

        //Название 
        public string Name { get; set; }

        //Группа(одежда,обувь,аксессуары)
        public string Group { get; set; }

        //Тип(мужская, женская)
        public string Type { get; set; }

        //Семейство
        public string Kind { get; set; }

        //Цвет
        public string Color { get; set; }

        //Материал
        public string Material { get; set; }

        //Количество 
        public int Count { get; set; }

        //Цена
        public double Price { get; set; }

        //Производитель
        public string Brand { get; set; }

        //Страна производитель
        public string Country { get; set; }

        public abstract object[] Show();
    }
}
