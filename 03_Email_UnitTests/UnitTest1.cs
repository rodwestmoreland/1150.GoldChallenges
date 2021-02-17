using _03_Email_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_Email_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        Contact_Repo _contactRepo = new Contact_Repo();
        List<Contact> _contactList = new List<Contact>();

        public List<Contact> SeedThis()
        {
            var c1 = new Contact(1, "Doo", "Scooby", new DateTime(2021, 01, 01));

            var c2 = new Contact(2, "Rogers", "Shaggy", new DateTime(2020, 01, 01));

            _contactList.Add(c1);
            _contactList.Add(c2);

            return _contactList;
        }

        [TestMethod]
        public void CreatingItems()
        {
            SeedThis();
            foreach (var item in _contactList)
            {
                _contactRepo.CreateContact(item);
            }

            int itemCheck = _contactRepo.ReadAllContacts().Count;

            Assert.AreEqual(2, itemCheck);
            Contact item3 = new Contact(3, "TestLast", "TestFirst", new DateTime(2020, 01, 01));
            _contactRepo.CreateContact(item3);
            
            Assert.AreEqual(2, itemCheck);
            Console.WriteLine(itemCheck);

            itemCheck = _contactRepo.ReadAllContacts().Count;
            
            Assert.AreEqual(3, itemCheck);

        }

        [TestMethod]
        public void ReadingItems()
        {
            CreatingItems();

            int i = 0;
            var _list = _contactRepo.ReadAllContacts();

            foreach (var item in _list)
            {
                i++;
            }

            Assert.AreEqual(3, i);
        }

        [TestMethod]
        public void UpdatingItems()
        {
            CreatingItems();
            var newItem = _contactRepo.GetContactById(1);
            newItem.Id = 1;
            newItem.FirstName = "UpdatedFirst";
            newItem.LastName = "UpdatedLast";
            newItem.DateActive = new DateTime(2020, 01, 01);


            _contactRepo.UpdateContact(1, newItem);

            var checkItem = _contactRepo.GetContactById(1);

            Assert.AreEqual("UpdatedFirst", checkItem.FirstName);
        }

        [TestMethod]
        public void DeletingItems()
        {
            CreatingItems();
            ushort getId = _contactList[1].Id;

            Contact checkObj = _contactRepo.GetContactById(getId);

            Assert.AreEqual(2, getId);

            _contactRepo.DeleteContact(getId);

            checkObj = _contactRepo.GetContactById(getId);

            Assert.IsNull(checkObj);
        }

    }
}
