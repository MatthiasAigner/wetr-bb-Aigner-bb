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
    public class AdoUsersDao : IUsersDao
    {
        
        public static readonly RowMapper<Users> userMapper =
            row => new Users
            {
                Username = (string)row["Username"],
                Station = (string)row["Station"]
            };

        private readonly AdoTemplate template;

        public AdoUsersDao(IConnectionFactory connectionFactory)
        {
            this.template = new AdoTemplate(connectionFactory);
        }

        

        public IEnumerable<Users> FindAllUsers()
        {
            return template.Query("select * from Users", userMapper);
        }

        public Users FindUserByUsername(string username)
        {
            return template.Query("select * from Users where username=@username",
                userMapper,
                new[] { new SqlParameter("@username", username) }
                ).SingleOrDefault();
        }

        public bool InsertUser(Users user)
        {
            return template.Execute(
                "insert into Users values (@username, @station)",
                new[]
                {
                    new SqlParameter("@username", user.Username),
                    new SqlParameter("@station", user.Station)

                }) == 1;

        } 

        public bool DeleteUser(string username)
        {
            return template.Execute(
                "delete from Users where Username=@username",
                new[]
                {
                    new SqlParameter("@username", username)
                }) == 1;
        }
    }
}
