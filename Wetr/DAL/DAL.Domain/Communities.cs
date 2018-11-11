using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Domain
{
    public class Communities
    {
        public Communities()
        {
        }

        public Communities(string community, int postalcode, string district, string procince)
        {
            this.Community = community;
            this.Postalcode = postalcode;
            this.District = district;
            this.Procince = procince;
        }

        public string Community { get; set; }
        public int Postalcode { get; set; }
        public string District { get; set; }
        public string Procince { get; set; }
    }
}