using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Email_Repo
{
    public class Contact
    {
        public ushort Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailBody { get; set; }
        public char Status { get; set; }
        public DateTime? DateActive { get; set; }

        public Contact() { }
        public Contact(ushort id, string lname, string fname)
        {
            Id = id;
            FirstName = fname;
            LastName = lname;
        }

        public Contact(ushort id, string lname, string fname, DateTime dateActive)
        {
            Id = id;
            FirstName = fname;
            LastName = lname;
            DateActive = dateActive;
        }

        public Contact(ushort id, string lname, string fname, string emailBody, char status)
        {
            Id = id;
            FirstName = fname;
            LastName = lname;
            EmailBody = emailBody;
            Status = status;
        }
        public Contact(ushort id, string lname, string fname, string emailBody, char status, DateTime dateActive)
        {
            Id = id;
            FirstName = fname;
            LastName = lname;
            EmailBody = emailBody;
            Status = status;
            DateActive = dateActive;
        }
    }
}
