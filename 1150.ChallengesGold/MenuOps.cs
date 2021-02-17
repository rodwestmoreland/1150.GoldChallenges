using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Repo
{
    class MenuOps
    {
        public static void MenuSelections()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("Electric and Hybrid insurance statistics 2017-2019 \nSelect option 1 - 5:\n\n" +
                        "1. View all items on menu\n" +
                        "2. Add new menu item\n" +
                        "3. Delete a menu item by item number\n" +
                        "4. Exit");

                string menuSelect = (Console.ReadLine());
                MenuSelectionCheck(menuSelect);
            }// \while


        }//MenuSelections()

        public static void MenuProcessing(byte selection)
        {
            var ui = new UI();

            Console.Clear();

            switch (selection)
            {
                case 1:
                    UI.MenuList();
                    ClickToCont();
                    break;
                case 2:
                    ui.AddMenuItem();
                    ClickToCont();
                    break;
                case 3:
                    ui.DeleteMenuItem();
                    ClickToCont();
                    break;
                
            }

        }//MenuProcessing()

        private static void MenuSelectionCheck(string menuSelect)
        {
            if (Byte.TryParse(menuSelect, out byte num))
            {
                if (num == 4)
                { Environment.Exit(0); }
                else if (num > 0 && num < 4)
                { MenuProcessing(num); }
                else
                { InvalidSelection(); }
            }
            else
            { InvalidSelection(); }
        }

        public static void InvalidSelection()
        {
            Console.Clear();
            Console.WriteLine("\nPlease enter a number 1 - 4\n");
        }

        private static void ClickToCont()
        {
            Console.WriteLine("\n\n\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
