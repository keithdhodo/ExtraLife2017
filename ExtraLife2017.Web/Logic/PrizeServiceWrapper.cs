using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExtraLife2017.Web.Models;

namespace ExtraLife2017.Web.Logic
{
    public class PrizeServiceWrapper : IPrizeServiceWrapper
    {
        private const string PrizeEndpoint = "";

        private readonly string _baseServiceUri;

        public PrizeServiceWrapper(string serviceDomain, bool useHttps = true)
        {
            _baseServiceUri = string.Format("{0}{1}/", useHttps ? "https://" : "http://", serviceDomain);
        }

        public async Task<IEnumerable<Prize>> GetPrizes()
        {
            var serviceUri = _baseServiceUri + PrizeEndpoint;
            var response = await serviceUri.GetJsonAsync<IEnumerable<Prize>>();

            return response;
        }
    }
}