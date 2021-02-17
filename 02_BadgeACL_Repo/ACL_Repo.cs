using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BadgeACL_Repo
{
    public class ACL_Repo
    {
        private readonly List<Badge> _aclRepo = new List<Badge>();

        public void CreateBadge(Badge badge)
        {      _aclRepo.Add(badge);  }

        public List<Badge> ReadBadges()
        {      return _aclRepo;      }

        public void AddDoor()
        {

        }

        public void DeleteDoor()
        {

        }
    }
}
