using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetr.DAL.Common;
using Wetr.Domainclasses;

namespace Wetr.DAL.Dao
{
    public class AdoProvincesDao : IProvincesDao
    {        
        public static readonly RowMapper<Provinces> provincesMapper =
            row => new Provinces
            {
                Province = (string)row["Province"]
            };

        private readonly AdoTemplate template;

        public AdoProvincesDao(IConnectionFactory connectionFactory)
        {
            this.template = new AdoTemplate(connectionFactory);
        }

        public IEnumerable<Provinces> FindAllProvinces()
        {
            return template.Query("select * from Province", provincesMapper);
        }
    }
}
