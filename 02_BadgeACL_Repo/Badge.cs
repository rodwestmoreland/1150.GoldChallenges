using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BadgeACL_Repo
{
    public class Badge
    {
        public ushort Id { get; set; }
        public string Door { get; set; }

        public Badge() { }
        public Badge(ushort id, string door)
        {
            Id =    id;
            Door =  door; 
        }
    }
}
