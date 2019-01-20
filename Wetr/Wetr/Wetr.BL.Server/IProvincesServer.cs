using System.Collections.Generic;
using Wetr.Domainclasses;

namespace Wetr.BL.Server
{
    public interface IProvincesServer
    {
        IEnumerable<Provinces> FindAllProvinces();
    }
} 
