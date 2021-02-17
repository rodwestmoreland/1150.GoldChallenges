using _01_Cafe_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Repo
{
    public class UI
    {
        private static Cafe_Repo _cafeRepo = new Cafe_Repo();
        public static List<CafeMenu> _menuList = new List<CafeMenu>();

        public void Run()
        {
            SeedThis();
            MenuOps.MenuSelections();
        }// \Run

        public static void MenuList()
        {
            List<CafeMenu> _list = _cafeRepo.GetMenu();

            Console.WriteLine("Menu List\n");
            foreach (var item in _list)
            {
                Console.WriteLine($"Item # {item.FoodNumber}:  ${item.Price}  {item.FoodName} ");
                Console.WriteLine($"Description: {item.Description}");
                Console.WriteLine($"-- Ingredients: {item.FoodIngredients} \n");
            }
        }

        public void AddMenuItem()
        {
            List<CafeMenu>  _list   = _cafeRepo.GetMenu();
            CafeMenu        newItem = new CafeMenu();
            byte foodNum =0;
            bool numberFound = false;
            bool numberCheck = true;
            do
            {
                
                Console.Write("Enter Menu Item Number > ");
                foodNum = Convert.ToByte(Console.ReadLine());

                foreach (var item in _list)
                {
                    if (item.FoodNumber == foodNum)
                    {
                        numberFound = true;
                    }

                }//foreach
                if (numberFound)
                {
                    Console.WriteLine("pick another number");
                    numberFound = false;
                }
                else { numberFound = false; numberCheck = false; }

            } while (numberCheck);
            
            Console.Write("Enter Menu Item Name > ");
            string foodName = (Console.ReadLine());
            
            Console.Write("Enter Menu Item Description > ");
            string  foodDesc = (Console.ReadLine());
            
            Console.Write("Enter Menu Item Ingredients > ");
            string foodIngredients = (Console.ReadLine());

            Console.Write("Enter Item Price > ");
            decimal foodPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Confirm: Would you like to enter this as a new menu item (y/n)?\n");
            Console.WriteLine($"Item # {foodNum}:  ${foodPrice}  {foodName} ");
            Console.WriteLine($"Description: {foodDesc} ");
            Console.WriteLine($"-- Ingredients: {foodIngredients} \n");
            char response = Convert.ToChar(Console.ReadLine().ToLower());
            if (response == 'y') 
            {
                newItem.FoodNumber =        foodNum;
                newItem.FoodName =          foodName;    
                newItem.Description =       foodDesc;
                newItem.FoodIngredients =   foodIngredients;
                newItem.Price =             foodPrice;
                _cafeRepo.AddMenuItem(newItem);
            }
        }

        public void DeleteMenuItem()
        {
            Console.Write("Enter item number that you would like to delete > ");
            byte itemToDelete = Convert.ToByte(Console.ReadLine());
            var confirmItem = _cafeRepo.GetItemByNumber(itemToDelete);
            Console.Write($"Delete {confirmItem.FoodName} (y/n)? >");
            char confirmDelete = Convert.ToChar( Console.ReadLine());
            if (confirmDelete == 'y')
            {
                _cafeRepo.DeleteMenuItem( itemToDelete);
                Console.WriteLine($"\n{confirmItem.FoodName} deleted.");
            }
            else { Console.WriteLine($"\n{confirmItem.FoodName} was not deleted."); }
        }

        private void SeedThis()
        {
            // Populate data:
            CafeMenu menuItem1 = new CafeMenu(1, "Chicken Parmesean",
                                                    "Baked Chicken over pasta with creamy marinara sauce",
                                                    "chicken (.5lbs), pasta (.25 box), house marinara (1 cup), Parm/Herb blend",
                                                    15.75m);
            CafeMenu menuItem2 = new CafeMenu(2, "Taco Pie",
                                                    "Full pie ground beef taco pie with a flaky crust and sour cream icing",
                                                    "pie crust, pie topper, three cheeses (.5 cup), refried beans (12 oz), cilantro (1 cup), tomatos (.5 cup), sourcream (.25 cup)",
                                                    13.80m);

            _cafeRepo.AddMenuItem(menuItem1);
            _cafeRepo.AddMenuItem(menuItem2);
   
        }

    }// \class
}