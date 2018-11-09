using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Domain
{
    public class Communities
    {
        public string Community { get; set; }
        public int Postalcode { get; set; }
        public string District { get; set; }
        public string Procince { get; set; }

        public ICollection<Stations> Stations { get; set; }
    }
}