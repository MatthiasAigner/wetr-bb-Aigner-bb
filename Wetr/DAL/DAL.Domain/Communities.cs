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

        public Communities(int postalcode, string community, string district, string province)
        {
            this.Postalcode = postalcode;
            this.Community = community;            
            this.District = district;
            this.Province = province;
        }
        public int Postalcode { get; set; }
        public string Community { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
    }
}