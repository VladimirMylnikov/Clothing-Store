using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore
{
    class Shoes : Product
    {
        //Перегружаем конструктор
        public Shoes(string Name, string Group, string Type,
            string Kind, string Color,
            string Material, int Count, double Price,
            string Brand, string Counrty,
            string SoleMaterial, int SoleHeight)
           : base(Name, Group, Type, Kind, Color, Material, Count, Price, Brand, Counrty)      // Наследуем от базового абстрактного класса Product
        {
            this.SoleHeight = SoleHeight;
            this.SoleMaterial = SoleMaterial;
        }

        //Материал подошвы
        public string SoleMaterial { get; set; }

        //Высота подошвы
        public int SoleHeight { get; set; }

        public override object[] Show()
        {
            object[] shoesInfo = { Name, Group,
               Type, Kind, Color, Material, Count,
               Price, Brand, Country,
                SoleMaterial, SoleHeight };
            return shoesInfo;
        }
    }
}
