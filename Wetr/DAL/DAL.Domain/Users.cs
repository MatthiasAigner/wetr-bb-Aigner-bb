using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Domain
{
    public class Users
    {
        public string Username { get; set; }
        public string Station { get; set; }
       


        public ICollection<Stations> Stations { get; set; }
    }
}