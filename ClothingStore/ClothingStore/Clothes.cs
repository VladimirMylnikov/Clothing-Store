using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore
{
    class Clothes : Product
    {


        //Перегружаем конструктор
        public Clothes(string Name, string Group, string Type,
            string Kind, string Color, string Material, int Count,
            double Price, string Brand, string Counrty)
               : base(Name, Group, Type, Kind, Color, Material, Count, Price, Brand, Counrty)      // Наследуем от базового абстрактного класса Product
        {}

        public override object[] Show()
        {
            object[] clothesInfo = {
               Name, Group,
               Type, Kind, Color, Material, Count,
               Price, Brand, Country,};
            return clothesInfo;
        }
    }
}
