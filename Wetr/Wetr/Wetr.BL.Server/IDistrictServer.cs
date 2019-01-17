using System.Collections.Generic;
using Wetr.Domainclasses;

namespace Wetr.BL.Server
{
    public interface IDistrictServer
    {
        IEnumerable<Districts> FindDistrictsByProvince(string province);
        IEnumerable<Districts> FindAllDistricts();
    }
} 
