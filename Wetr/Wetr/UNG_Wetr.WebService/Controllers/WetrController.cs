using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wetr.BL.Server;
using Wetr.Domainclasses;

namespace Wetr.WebService.Controllers
{

    //[Filters.ValidationActionFilter]
    [RoutePrefix("api")]
    public class WetrController : Controller
    {
        public IStationsServer stationServer = new StationsServer();

        //private ICurrencyCalculator Logic { get; } = BLFactory.GetCalculator();

        [HttpGet]
            [Route("GetAllStations", Name = "GetBySymbolRoute")]
            public IEnumerable<Stations> GetAllStations()
            {
            
                List<Stations> res = new List<Stations>();
                res.Add(new Stations ( "dd", "ff", 4.5, 3.4,23));
            return res;
                //return stationServer.FindAllStations();
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
