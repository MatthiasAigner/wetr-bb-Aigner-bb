using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wetr.BL.Server;
using Wetr.Domainclasses;

namespace Wetr.WebService.Controllers
{
    //[Filters.ValidationActionFilter]
    [RoutePrefix("api")]
    public class WetrController : ApiController
    {


        public IStationsServer stationServer = new StationsServer();
        public IMeasurementsServer measurementsServer = new MeasurementsServer();
        public IUsersServer usersServer = new UsersServer();

        [HttpGet]
        [Route("GetAllStations", Name = "GetAllStations")]
        public IEnumerable<Stations> GetAllStations()
        {
            return stationServer.FindAllStations();
        }

        [HttpGet]
        [Route("GetStationsByPostalcode/{postalcode}")]
        public IEnumerable<Stations> GetStationsByPostalcode(int postalcode)
        {
            return stationServer.FindStationByPostalcode(postalcode);
        }

        [HttpGet]
        [Route("GetStationsByRegion/{longitude}/{lattitude}/{radius}")]
        public IEnumerable<Stations> GetStationsByRegion(double longitude, double lattitude, double radius)
        {
            return stationServer.FindStationByRegion(longitude, lattitude, radius);
        }

        [HttpGet]
        [Route("GetStationsByDistrict/{district}")]
        public IEnumerable<Stations> GetStationsByDistrict(string district)
        {
            return stationServer.FindStationByDistrict(district);
        }

        [HttpGet]
        [Route("GetStationsByProvince/{province}")]
        public IEnumerable<Stations> GetStationsByProvince(string province)
        {
            return stationServer.FindStationByProvince(province);
        }

        [HttpGet]
        [Route("GetStationsById/{id}")]
        public Stations GetStationsById(int id)
        {
            return stationServer.FindStationById(id);
        }

        [HttpPost]
        [Route("InsertStation")]
        public IHttpActionResult InsertStation([FromBody] Stations station)
        {
            try
            {
                stationServer.InsertStation(station);
                return Created("/api/insertstation", station);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("DeleteStation/{station}")]
        public IHttpActionResult DeleteStation(string station)
        {
            try
            {
                stationServer.DeleteStation(station);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("InsertMeasurements")]
        public IHttpActionResult InsertMeasurments([FromBody] List<Measurements> measurments)
        {
            try
            {
                measurementsServer.InsertMeasurements(measurments);
                return Created("/api/InsertMeasurements", measurments);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetAllMeasurementsByStationInTimeInterval/{station}/{begin}/{end}")]
        IEnumerable<Measurements> GetAllMeasurementsByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            return measurementsServer.FindAllMeasurementsByStationInTimeInterval(station, begin, end);
        }

        [HttpGet]
        [Route("GetAllUsers)")]
        IEnumerable<Users> GetAllUsers()
        {
            return usersServer.FindAllUsers();
        }
    }
}
