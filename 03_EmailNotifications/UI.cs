using _03_Email_Repo;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_EmailNotifications
{
    public class UI
    {
        private readonly Contact_Repo _contactRepo = new Contact_Repo();

        public void Run()
        {
            SeedThis();
            Menu();
        }
        public void Menu()
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

        private void GetAllContacts()
        {
            List<Contact> contactList = _contactRepo.ReadAllContacts();

            foreach (var member in contactList)
            {
                Console.WriteLine($"{member.LastName}, {member.FirstName} \t\tStatus {member.Status:10}\n{member.EmailBody}\n");

            }
            Console.ReadKey();
        }

        private void UpdateContact()
        {

            Contact newContact = new Contact();

            Console.Write("Enter contact ID number : >");
                ushort getId = Convert.ToUInt16(Console.ReadLine());
            var contactToUpdate = _contactRepo.GetContactById(getId);
            Console.WriteLine($"\nUpdating {contactToUpdate.FirstName} {contactToUpdate.LastName}\n"  ); 

            Console.Write("Enter first name > ");
                newContact.FirstName = Console.ReadLine();
            Console.Write("Enter last name > ");
                newContact.LastName = Console.ReadLine();
            Console.Write("Select contact type: \n\t 1. Customer \n\t 2. Potential Customer \n\nSelection > ");
                DateProcessing(newContact);

            _contactRepo.UpdateContact(getId, newContact);
        }
        private void AddNewContact()
        {
            Contact newContact = new Contact();
            Console.Write("Enter first name > ");
            newContact.FirstName = Console.ReadLine();
            Console.Write("Enter last name > ");
            newContact.LastName = Console.ReadLine();

            Console.Write("Select contact type: \n\t 1. Customer \n\t 2. Potential Customer \n\nSelection > ");
            DateProcessing(newContact);

            _contactRepo.CreateContact(newContact);
            
        }

        private void DeleteContact()
        {
            List<Contact> contactList = _contactRepo.ReadAllContacts();
            Console.Write("Enter last name of contact you want to remove > ");
            string toRemove = Console.ReadLine();
            int i = 0;
            int s = 1;
            foreach (var name in contactList)
            {

                if (name.LastName.ToLower() == toRemove.ToLower()) 
                { Console.WriteLine($"ID : {name.Id} \t{name.LastName}, {name.FirstName} \n"); s++; }
                i++;
            }
            Console.WriteLine("Enter ID of person to delete");
            ushort selected = Convert.ToUInt16(Console.ReadLine());
            _contactRepo.DeleteContact(selected);
            Console.WriteLine() ;
            GetAllContacts();

            
            Console.ReadKey();
        }

        private static void DateProcessing(Contact newContact)
        {
            DateTime userDateInput;
            if (Console.ReadLine() == "1")
            {
                Console.Write("Enter date customer signed up for service > ");
                if (DateTime.TryParse(Console.ReadLine(), out userDateInput))
                {
                    Console.WriteLine("you entered: " + userDateInput.ToShortDateString());
                    newContact.DateActive = userDateInput;
                }
                else
                { Console.WriteLine("You have entered an incorrect value."); }
            } // \ IF DateTime active check
        }

        public void MenuProcessing(byte selection)
        {
            Console.Clear();

            switch (selection)
            {
                case 1:
                    GetAllContacts();
                    ClickToCont();
                    break;
                case 2:
                    AddNewContact();
                    ClickToCont();
                    break;
                case 3:
                    UpdateContact();
                    ClickToCont();
                    break;
                case 4:
                    DeleteContact();
                    ClickToCont();
                    break;

            }

        }

        private void MenuSelectionCheck(string menuSelect)
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

        private static void InvalidSelection()
        {
            Console.Clear();
            Console.WriteLine("\nPlease enter a number 1 - 5\n");
        }

        private static void ClickToCont()
        {
            Console.WriteLine("\n\n\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
        }


        private void SeedThis()
        {
            var c01 = new Contact(1,"Doo", "Scooby", new DateTime(2021, 01, 01));
            var c02 = new Contact(2,"Rogers", "Shaggy", new DateTime(2020, 01, 01));
            var c03 = new Contact(3,"Waterson", "Gumball", new DateTime(2020, 01, 10));
            var c04 = new Contact(4,"Flintstone", "Wilma", new DateTime(1999, 01, 01));
            var c05 = new Contact(5,"Flintstone", "Fred", new DateTime(1999, 01, 10));
            var c06 = new Contact(6,"Parr", "Bob");
            var c07 = new Contact(7,"Parr", "Helen");

            _contactRepo.CreateContact(c01);
            _contactRepo.CreateContact(c02);
            _contactRepo.CreateContact(c03);
            _contactRepo.CreateContact(c04);
            _contactRepo.CreateContact(c05);
            _contactRepo.CreateContact(c06);
            _contactRepo.CreateContact(c07);

        }// SeedThis

    }// class
}

