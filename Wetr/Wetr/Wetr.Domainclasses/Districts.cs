using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wetr.Domainclasses
{
    public class Districts
    {
        public Districts()
        {
        }

        public Districts(string district, string province)
        {
            this.District = district;
            this.Province = province;
        }

        public string District { get; set; }
        public string Province { get; set; }   
    }
} 