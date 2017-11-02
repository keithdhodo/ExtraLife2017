using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ExtraLife2017.Web.Logic;
using Microsoft.AspNetCore.Mvc;
using ExtraLife2017.Web.Models;
using ExtraLife2017.Web.Utilities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace ExtraLife2017.Web.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private const string CacheRegion = "HOME";
        private TimeSpan _cacheRefresh = TimeSpan.FromMinutes(30);

        private readonly IMemoryCache _cache;
        private readonly AppSettings _config;
        private readonly IPrizeServiceWrapper _prizeService;

        public HomeController(IOptions<AppSettings> appSettings, IMemoryCache cache)
        {
            _cache = cache;
            _config = appSettings.Value;
            _prizeService = new PrizeServiceWrapper(appSettings.Value.PrizeServiceUri, appSettings.Value.PrizeServiceApiKey);
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("sitemap")]
        public IActionResult Sitemap()
        {
            var baseUrl = string.Format("https://{0}", _config.Domain);
            var siteMapBuilder = new SiteMapBuilder.SitemapBuilder();

            siteMapBuilder.AddUrl(baseUrl, modified: DateTime.UtcNow, changeFrequency: ChangeFrequency.Always, priority: 1);

            var xml = siteMapBuilder.ToString();
            return Content(xml, "text/xml");
        }

        [HttpPost]
        [Route("Prizes_Read/{tier}")]
        public async Task<IActionResult> GetPrizes(int tier, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            IEnumerable<Prize> prizes;
            JsonResult json;

            const string prizeName = "prizeName";
            const string notes = "notes";
            const string restriction = "restriction";
            const string donor = "donor";
            const string wonBy = "wonBy";

            try
            {
                var key = string.Format("{0}-{1}", CacheRegion, "GetPrizes");
                _cache.TryGetValue(key, out prizes);

                if (prizes == null)
                {
                    prizes = await _prizeService.GetPrizes();
                    _cache.Set(key, prizes, _cacheRefresh);
                }

                var selectedPrizes = prizes.Where(x => (x.Tier == tier));

                if (!string.IsNullOrEmpty(jtSorting))
                {
                    var splitSort = jtSorting.Split(' ');

                    if (splitSort.Length == 2)
                    {
                        var isAsc = splitSort[1].Equals("ASC");
                        var isDesc = splitSort[1].Equals("DESC");

                        switch (splitSort[0])
                        {
                            case prizeName:
                                if (isAsc)
                                {
                                    selectedPrizes = selectedPrizes.OrderBy(x => x.PrizeName);
                                }
                                else if (isDesc)
                                {
                                    selectedPrizes = selectedPrizes.OrderByDescending(x => x.PrizeName);
                                }
                                break;
                            case notes:
                                if (isAsc)
                                {
                                    selectedPrizes = selectedPrizes.OrderBy(x => x.Notes);
                                }
                                else if (isDesc)
                                {
                                    selectedPrizes = selectedPrizes.OrderByDescending(x => x.Notes);
                                }
                                break;
                            case restriction:
                                if (isAsc)
                                {
                                    selectedPrizes = selectedPrizes.OrderBy(x => x.Restriction);
                                }
                                else if (isDesc)
                                {
                                    selectedPrizes = selectedPrizes.OrderByDescending(x => x.Restriction);
                                }
                                break;
                            case donor:
                                if (isAsc)
                                {
                                    selectedPrizes = selectedPrizes.OrderBy(x => x.Donor);
                                }
                                else if (isDesc)
                                {
                                    selectedPrizes = selectedPrizes.OrderByDescending(x => x.Donor);
                                }
                                break;
                            case wonBy:
                                if (isAsc)
                                {
                                    selectedPrizes = selectedPrizes.OrderBy(x => x.WonBy);
                                }
                                else if (isDesc)
                                {
                                    selectedPrizes = selectedPrizes.OrderByDescending(x => x.WonBy);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }

                // sort the tier out
                json = Json(new
                {
                    Result = "OK",
                    Records = selectedPrizes.Skip(jtStartIndex - 1).Take(jtPageSize),
                    TotalRecordCount = selectedPrizes.Count()
                });
            }
            catch (Exception e)
            {
                json = Json(new
                {
                    Result = "ERROR",
                    Message = e.Message
                });
            }

            return json;
        }
    }
}