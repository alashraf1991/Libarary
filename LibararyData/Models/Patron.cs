using System;
using System.Collections.Generic;
using System.Text;

namespace LibararyData.Models
{
    public class Patron
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth{ get; set; }
        public string TelephoneNumber{ get; set; }

        public virtual LibararyCard libararyCard { get; set; }
        public virtual LibararyBranch HomeLibararyBranch { get; set; }

    }
}
