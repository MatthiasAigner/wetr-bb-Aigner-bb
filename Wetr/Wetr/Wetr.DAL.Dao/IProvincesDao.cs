﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetr.Domainclasses;

namespace Wetr.DAL.Dao
{
    public interface IProvincesDao
    {
        IEnumerable<Provinces> FindAllProvinces();        
    }
} 
