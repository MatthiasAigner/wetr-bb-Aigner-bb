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

            // private ICurrencyCalculator Logic { get; } = BLFactory.GetCalculator();

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
                return Created("http://localhost:5000/api/insertstation", station);
            }catch(Exception)
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





        /*
            [HttpGet]
            [Route("currencies")]
            public IEnumerable<CurrencyData> GetAll()
            {
                return Logic.GetCurrencies().Select(symbol => Logic.GetCurrencyData(symbol));
            }

            [HttpGet]
            [Route("currencies/{srcSymbol}/rates/{targSymbol}")]
            public double RateOfExchange(string srcSymbol, string targSymbol)
            {
                if (!Logic.CurrencyExists(srcSymbol) || !Logic.CurrencyExists(targSymbol))
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                return Logic.RateOfExchange(srcSymbol, targSymbol);
            }

            [HttpPut]
            [Route("currencies")]
            public void Update([FromBody] CurrencyData data)
            {
                if (!Logic.CurrencyExists(data.Symbol))
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                Logic.Update(data);
            }

            [HttpPost]
            [Route("currencies")]
            public HttpResponseMessage Insert([FromBody] CurrencyData data)
            {
                if (Logic.CurrencyExists(data.Symbol))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, $"currency {data.Symbol} already exists");
                }
                Logic.Insert(data);
                var response = Request.CreateResponse(HttpStatusCode.Created);
                string uri = Url.Link("GetBySymbolRoute", new { symbol = data.Symbol });
                response.Headers.Location = new Uri(uri);

                return response;
            }*/
    }
    }
