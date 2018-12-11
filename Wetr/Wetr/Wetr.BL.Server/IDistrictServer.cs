
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetr.Domainclasses;

namespace Wetr.BL.Server
{
    public interface IDistrictServer
    {
        IEnumerable<Districts> FindDistrictsByProvince(string province);
        
    }
} 
