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
        public static Contact_Repo _contactRepo = new Contact_Repo();

        public void Run()
        {
            SeedThis();
            MenuOps.Menu();
        }

        public static void GetAllContacts()
        {
            List<Contact> contactList = _contactRepo.ReadAllContacts();
            string status = "";
            string client = "";
            int timeActive = 0;
            Console.WriteLine(String.Format("{0,-12} {1,-25} {2} {3}", "Date active", "Status", "Name",""));
            foreach (var member in contactList)
            {
                if(member.DateActive == null) {
                    status = "Contact: Not a client";
                } else
                {
                timeActive = (int)((TimeSpan)(DateTime.Now - member.DateActive)).Days;
                    if (member.Status == 'A' && timeActive > 90)
                    {
                        status = "Past customer";
                        client = "Past Customer";
                    }
                    else { status = "Current customer"; }
                }

                Console.WriteLine(String.Format("{0,-12:d} {1,-25} {2}, {3}", member.DateActive, status, member.LastName, member.FirstName));
                Console.WriteLine(String.Format("{0,-13}{1}\n"," ", member.EmailBody));
                    
            }
            Console.ReadKey();
        }

        public void UpdateContact()
        {

            Contact newContact = new Contact();

            Console.Write("Enter contact ID number : >");
            
            string verifyInput = (Console.ReadLine());
            if (ushort.TryParse(verifyInput, out ushort getId))
            {
                var itemToUpdate = _contactRepo.GetContactById(getId);
                if (itemToUpdate == null)
                { Console.WriteLine("ERROR: Check the ID number and try again.\n\n"); MenuOps.Menu(); }

                Console.WriteLine($"\nSelected contact {itemToUpdate.LastName}, {itemToUpdate.FirstName}\n");
            }
            else
            { Console.WriteLine("ERROR: Check the ID number and try again.\n\n"); MenuOps.Menu(); }



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

        public void AddNewContact()
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

        public void DeleteContact()
        {
            List<Contact> contactList = _contactRepo.ReadAllContacts();
            //Console.Write("Enter last name of contact you want to remove > ");
           // string toRemove = Console.ReadLine();
            //int i = 0;
            //int s = 1;
            //foreach (var name in contactList)
            //{

            //    if (name.LastName.ToLower() == toRemove.ToLower()) 
            //    { Console.WriteLine($"ID : {name.Id} \t{name.LastName}, {name.FirstName} \n"); s++; }
            //    i++;
            //}
            Console.Write("Enter ID of person to delete > ");
            //ushort selected = Convert.ToUInt16(Console.ReadLine());
            string verifyInput = (Console.ReadLine());
            if (ushort.TryParse(verifyInput, out ushort selected))
            {
                var itemToRemove = _contactRepo.GetContactById(selected);
                if (itemToRemove == null)
                { Console.WriteLine("ERROR: Check the ID number and try again.\n\n"); MenuOps.Menu(); }

                Console.WriteLine($"\nSelected contact {itemToRemove.LastName}, {itemToRemove.FirstName}\n");
            }
            else
            { Console.WriteLine("ERROR: Check the ID number and try again.\n\n"); MenuOps.Menu(); }

            Console.Write("Is this the contact you wish to remove? > ");
            string response = Console.ReadLine();
            if (response == "y")
            { _contactRepo.DeleteContact(selected); Console.WriteLine("\nContact Removed"); }
            else { Console.WriteLine("Invalid Response. Return to the menu"); }

            Console.WriteLine() ;
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

