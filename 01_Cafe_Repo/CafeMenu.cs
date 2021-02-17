using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Repo
{
    public class CafeMenu
    {
        public byte FoodNumber { get; set; }
        public string FoodName { get; set; }
        public string Description { get; set; }
        public string FoodIngredients { get; set; }

        public decimal Price { get; set; }
        //public string PriceString { get => Price.ToString("N"); }

        //get { return _price == null ? "No price" : string.Format("{0:C}", _price.Value);
        //set { _price = value; }


        public CafeMenu() { }
        public CafeMenu(byte foodnum, string name, string desc, string ingredients, decimal price)
        {
            FoodNumber = foodnum;
            FoodName = name;
            Description = desc;
            FoodIngredients = ingredients;
            Price = price;
        }
    }
}
