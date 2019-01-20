using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wetr.Domainclasses
{
    public class Provinces
    {
        public Provinces()
        {
            
        }
        public Provinces(string province)
        {
            Province = province;
        }

        public string Province { get; set; }
    }
}
