using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wetr.Domainclasses
{
    public class Communities
    {
        public Communities()
        {
        }

        public Communities(int postalcode, string community, string district)
        {
            this.Postalcode = postalcode;
            this.Community = community;            
            this.District = district;
            
        }

        public int Postalcode { get; set; }
        public string Community { get; set; }
        public string District { get; set; }
        
    }
} 