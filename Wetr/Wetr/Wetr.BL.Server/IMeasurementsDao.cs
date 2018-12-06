
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetr.Domainclasses;

namespace Wetr.DAL.Dao
{
    public interface IMeasurementsDao
    {
        IEnumerable<Measurements> FindAllMeasurements();
        Measurements FindAllMeasurementsByStation(string station);
        Measurements FindMeasurementById(int id);
        bool InsertMeasurement(Measurements measurement);
        bool DeleteMeasurement(int id);
    }
} 
