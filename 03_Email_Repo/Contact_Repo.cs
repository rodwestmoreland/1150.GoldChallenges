using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Email_Repo
{
    public class Contact_Repo
    {
        private readonly List<Contact> _contactRepo = new List<Contact>();

        public Contact_Repo() { }
  
        public void CreateContact(Contact contact)
        {
            ProcessEmailBody(contact);
            _contactRepo.Add(contact);
        }

        public void UpdateContact(ushort id, Contact newContactInfo) 
        {
            var currentContactInfo =        GetContactById(id);
            currentContactInfo.FirstName =  newContactInfo.FirstName;
            currentContactInfo.LastName =   newContactInfo.LastName;
            currentContactInfo.DateActive = newContactInfo.DateActive;
        }

        public void DeleteContact(ushort id)
        {
            var removeContact = _contactRepo.SingleOrDefault(x => x.Id == id);
            _contactRepo.Remove(removeContact);
            
        }

        private static void ProcessEmailBody(Contact contact)
        {
            if (DateTime.TryParse(Convert.ToString(contact.DateActive), out DateTime dateInput))
            {
                TimeSpan dateDiff = (TimeSpan)(DateTime.Now - dateInput);
                int timeActive = (int)(dateDiff.Days);
                if (timeActive > 90)
                {
                    contact.Status = 'A';
                    contact.EmailBody = "Haven't heard from you in a while. Contact us today and receive 20% off on new service";
                }
                else
                {
                    contact.Status = 'A';
                    contact.EmailBody = "Thank you for being a loyal customer!";
                }
            }
            else
            {
                contact.Status = 'I';
                contact.EmailBody = "Click here to see Komodo's new offers to help your business grow";
            }
        }   

        public List<Contact> ReadAllContacts()
        {
            return _contactRepo.OrderBy(x => x.LastName).ToList();
        }

        public Contact GetContactById(ushort id)
        {
            return _contactRepo.SingleOrDefault(x => x.Id == id);
        }
    }
}
