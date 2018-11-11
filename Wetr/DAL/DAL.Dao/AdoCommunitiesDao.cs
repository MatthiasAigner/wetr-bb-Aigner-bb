using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Common;
using DAL.Domain;

namespace DAL.Dao
{
    public class AdoCommunitiesDao : ICommunitiesDao
    {
        
        public static readonly RowMapper<Communities> communityMapper =
            row => new Communities
            {
                Postalcode = (int)row["Postalcode"],
                Community = (string)row["Community"],                
                District = (string)row["District"],
                Province = (string)row["Province"]
            };
        

        private readonly AdoTemplate template;

        public AdoCommunitiesDao(IConnectionFactory connectionFactory)
        {
            this.template = new AdoTemplate(connectionFactory);
        }

        public IEnumerable<Communities> FindAllCommunities()
        {
            return template.Query("select * from Communities", communityMapper);
        }

        public Communities FindCommunityByPostalcode(int postalcode)
        {
            return template.Query("select * from Communities where postalcode=@postalcode",
                communityMapper,
                new[] { new SqlParameter("@postalcode", postalcode) }
                ).SingleOrDefault();
        }

        
    }
}
