using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetr.DAL.Common;
using Wetr.DAL.Dao;
using Wetr.Domainclasses;

namespace Wetr.BL.Server
{
    public class ProvincesServer : IProvincesServer
    {
        private static readonly IConnectionFactory connectionFactory = new DefaultConnectionFactory();
        private IProvincesDao provincesDao = new AdoProvincesDao(connectionFactory);        

        public IEnumerable<Provinces> FindAllProvinces()
        {
            return provincesDao.FindAllProvinces();
        }  
    }
}
