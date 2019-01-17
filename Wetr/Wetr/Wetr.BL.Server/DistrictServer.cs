using System.Collections.Generic;
using Wetr.DAL.Common;
using Wetr.DAL.Dao;
using Wetr.Domainclasses;

namespace Wetr.BL.Server
{
    public class DistrictServer : IDistrictServer        
    {
        private static readonly IConnectionFactory connectionFactory = new DefaultConnectionFactory();
        private IDistrictDao districtDao = new AdoDistrictDao(connectionFactory);

        public IEnumerable<Districts> FindAllDistricts()
        {
            return districtDao.FindAllDistricts();
        }

        public IEnumerable<Districts> FindDistrictsByProvince(string province)
        {
            return districtDao.FindDistrictsByProvince(province);
        }
    }
}
