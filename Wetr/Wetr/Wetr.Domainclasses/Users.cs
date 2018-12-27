using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wetr.Domainclasses
{
    public class Users
    {
        public Users()
        {
        }

        public Users(string username, string firstname, string lastname, string emailadress, string station)
        {
            this.Username = username;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Emailadress = emailadress;
            this.Station = station;
        }

        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Emailadress { get; set; }
        public string Station { get; set; }   
    }
} 