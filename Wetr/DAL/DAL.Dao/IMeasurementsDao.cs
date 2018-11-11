using DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dao
{
    public interface IMeasurementsDao
    {
        IEnumerable<Measurements> FindAllMeasurements();
        Measurements FindAllMeasurementsByStation(string station);
        Measurements FindAllMeasurementsById(int id);
        bool InsertMeasurement(Measurements measurement);
        bool DeleteMeasurement(int id);
    }
}
