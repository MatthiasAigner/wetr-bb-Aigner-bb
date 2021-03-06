﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetr.Domainclasses;

namespace Wetr.DAL.Dao
{
    public interface ICommunitiesDao
    {
        IEnumerable<Communities> FindAllCommunities();
        IEnumerable<Communities> FindCommunitiesByDistrict(string district);
        Communities FindCommunityByPostalcode(int postalcode);
    } 
}
