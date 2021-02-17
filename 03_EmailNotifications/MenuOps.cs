using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_EmailNotifications
{
    class MenuOps
    {
        public static void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("Email Notification Management \nSelect option 1 - 5:\n\n" +
                        "1. View all contacts\n" +
                        "2. Add new contact\n" +
                        "3. Update a contact\n" +
                        "4. Delete a contact \n" +
                        "5. Exit");

                string menuSelect = (Console.ReadLine());
                MenuSelectionCheck(menuSelect);
            }// \while


        }// Menu()

        public static void MenuProcessing(byte selection)
        {
            var ui = new UI();

            Console.Clear();

            switch (selection)
            {
                //case 1:
                //    ui.GetAllContacts();
                //    ClickToCont();
                //    break;
                //case 2:
                //    ui.AddNewContact();
                //    ClickToCont();
                //    break;
                //case 3:
                //    ui.UpdateContact();
                //    ClickToCont();
                //    break;
                //case 4:
                //    ui.DeleteContact();
                //    ClickToCont();
                //    break;

            }

        }

        public static void MenuSelectionCheck(string menuSelect)
        {
            if (Byte.TryParse(menuSelect, out byte num))
            {
                if (num == 5)
                { Environment.Exit(0); }
                else if (num > 0 && num < 5)
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
            Console.WriteLine("\nPlease enter a number 1 - 5\n");
        }

        public static void ClickToCont()
        {
            Console.WriteLine("\n\n\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
