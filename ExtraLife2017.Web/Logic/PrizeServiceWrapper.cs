using System;
using Flurl.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExtraLife2017.Web.Models;
using Newtonsoft.Json;

namespace ExtraLife2017.Web.Logic
{
    public class PrizeServiceWrapper : IPrizeServiceWrapper
    {
        private const string PrizeEndpoint = "api/Prizes";

        private readonly string _baseServiceUri;
        private readonly string _apiKey;

        public PrizeServiceWrapper(string serviceDomain, string apiKey, bool useHttps = true)
        {
            _baseServiceUri = string.Format("{0}{1}/", useHttps ? "https://" : "http://", serviceDomain);
            _apiKey = apiKey;
        }

        public async Task<IEnumerable<Prize>> GetPrizes()
        {
            var serviceUri = _baseServiceUri + PrizeEndpoint;
            serviceUri = AddApiCode(serviceUri);

            var response = (await serviceUri.GetJsonAsync<IEnumerable<Prize>>()).Where(x => x.DisplayDate <= DateTime.Today);

            return response;
        }

        private string AddApiCode(string source)
        {
            return source += "?code=" + _apiKey;
        }
    }
}