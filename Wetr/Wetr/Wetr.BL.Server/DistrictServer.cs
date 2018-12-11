using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
