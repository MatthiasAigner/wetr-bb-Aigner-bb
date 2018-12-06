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

        public Users(string username, string station)
        {
            this.Username = username;
            this.Station = station;
        }

        public string Username { get; set; }
        public string Station { get; set; }   
    }
} 