using System.Collections.Generic;
using Wetr.DAL.Dao;
using Wetr.Domainclasses;

namespace Wetr.BL.Server
{
    class DistrictServer : IDistrictServer        
    {
        private IDistrictDao districtDao;

        public IEnumerable<Districts> FindDistrictsByProvince(string province)
        {
            return districtDao.FindDistrictsByProvince(province);
        }
    }
}
