using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchPersons.Models
{
    public class PersonInfo
    {
      
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }        
        public DateTime DOB { get; set; }
        public string StateCode { get; set; }
    }
    public class StateInfo
    {
        public int StateId { get; set; }
        public string StateCode { get; set; }
    }

 

}