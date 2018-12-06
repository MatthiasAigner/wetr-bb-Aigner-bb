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
    public class AdoDistrictDao : IDistrictDao
    {
        
        public static readonly RowMapper<Districts> districtMapper =
            row => new Districts
            {
                District = (string)row["District"],
                Province = (string)row["Province"]
            };

        private readonly AdoTemplate template;

        public AdoDistrictDao(IConnectionFactory connectionFactory)
        {
            this.template = new AdoTemplate(connectionFactory);
        }

        

        public IEnumerable<Districts> FindDistrictsByProvince(string province)
        {
            {
                return template.Query("select * from District where Province=@province",
                    districtMapper,
                    new[] { new SqlParameter("@province", province) }
                    );
            }
        }

        
    }
}
