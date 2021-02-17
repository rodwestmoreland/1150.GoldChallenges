using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Repo
{
    public class Cafe_Repo
    {
        private List<CafeMenu> _menuRepo = new List<CafeMenu>();

        public Cafe_Repo() { }

        public List<CafeMenu> GetMenu()
        {      return _menuRepo;      }
        
        public bool AddMenuItem(CafeMenu menuItem)
        {
            int dirSize = _menuRepo.Count();
            _menuRepo.Add(menuItem);
            bool wasAdded = (dirSize + 1) == _menuRepo.Count();
            return wasAdded;
        }

        public bool DeleteMenuItem(byte itemNum)
        {
            CafeMenu itemToDelete = GetItemByNumber(itemNum);
            return _menuRepo.Remove(itemToDelete);
        }

        public CafeMenu GetItemByNumber(byte itemNum)
        {
            return _menuRepo.SingleOrDefault(x => x.FoodNumber == itemNum);
        }

    }
}
