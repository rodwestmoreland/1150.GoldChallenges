using _01_Cafe_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_Cafe_Tests
{
    [TestClass]
    public class UnitTest1
    {
        Cafe_Repo _cafeRepo = new Cafe_Repo();
        List<CafeMenu> _cafeMenu = new List<CafeMenu>();

        public List<CafeMenu> SeedThis() 
        {
           // List<CafeMenu> _cafeMenu = new List<CafeMenu>();

            CafeMenu menuItem1 = new CafeMenu(1, "Chicken Parmesean",
                                                    "Baked Chicken over pasta with creamy marinara sauce",
                                                    "chicken (.5lbs), pasta (.25 box), house marinara (1 cup), Parm/Herb blend",
                                                    15.75m);
            CafeMenu menuItem2 = new CafeMenu(2, "Taco Pie",
                                                    "Full pie ground beef taco pie with a flaky crust and sour cream icing",
                                                    "pie crust, pie topper, three cheeses (.5 cup), refried beans (12 oz), cilantro (1 cup), tomatos (.5 cup), sourcream (.25 cup)",
                                                    13.80m);
            _cafeMenu.Add(menuItem1);
            _cafeMenu.Add(menuItem2);
            
            return _cafeMenu;
        }

        [TestMethod]
        public void CreatingItems()
        {
            SeedThis();
            foreach (var item in _cafeMenu)
            {
                _cafeRepo.AddMenuItem(item);
            }

            int itemCheck = _cafeRepo.GetMenu().Count;

            CafeMenu menuItem3 = new CafeMenu(3, "test",
                                                    "test desc",
                                                    "test ingredients",
                                                    1.00m);

            bool isAdded = _cafeRepo.AddMenuItem(menuItem3);
            
            Console.WriteLine(itemCheck);

            Assert.IsTrue(isAdded);
            Assert.AreEqual(2, itemCheck);

        }

        [TestMethod]
        public void ReadingItems()
        {
            CreatingItems();

            int i = 0;
            var _list = _cafeRepo.GetMenu();
            
            foreach (var item in _list)
            {
                i++;
            }

            Assert.AreEqual(3, i);
        }

        [TestMethod]  //no requirement for updating items
        public void UpdatingItems()
        {
            
        }

        [TestMethod]
        public void DeletingItems()
        {
            CreatingItems();
            byte getId = _cafeMenu[1].FoodNumber;

            CafeMenu checkObj = _cafeRepo.GetItemByNumber(getId);

            Assert.AreEqual(2, getId);

            bool isDeleted = _cafeRepo.DeleteMenuItem(getId);
            Assert.IsTrue(isDeleted);
            checkObj = _cafeRepo.GetItemByNumber(getId);

            Assert.IsNull(checkObj);
        }

    }
}
