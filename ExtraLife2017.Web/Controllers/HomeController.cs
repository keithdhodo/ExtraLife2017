﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            _prizeService = new PrizeServiceWrapper(appSettings.Value.PrizeServiceUri);
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
        [Route("Prizes_Read")]
        public async Task<IActionResult> GetPrizes(int tier)
        {
            IEnumerable<Prize> prizes;
            JsonResult json;

            try
            {
                var key = string.Format("{0}-{1}", CacheRegion, "GetPrizes");
                _cache.TryGetValue(key, out prizes);

                if (prizes == null)
                {
                    prizes = await _prizeService.GetPrizes();
                    _cache.Set(key, prizes, _cacheRefresh);
                }

                // sort the tier out
                json = Json(new
                {
                    Result = "OK",
                    Records = prizes
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