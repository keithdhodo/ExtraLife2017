using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExtraLife2017.Web.Models;
using ExtraLife2017.Web.Utilities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ExtraLife2017.Web.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly AppSettings _config;

        public HomeController(IOptions<AppSettings> appSettings, IMemoryCache cache)
        {
            _cache = cache;
            _config = appSettings.Value;
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
        public IActionResult GetPrizes()
        {
            var prizes = new List<Prize>()
            {
                new Prize()
                {
                    _id = Guid.NewGuid(),
                    Description = "Prize A",
                    Price = 10.25m,
                    PrizeId = 1,
                    ProductCode = "A",
                    ProductName = "Hello",
                    ReleaseDate = DateTime.Today
                },
                new Prize()
                {
                    _id = Guid.NewGuid(),
                    Description = "Prize B",
                    Price = 12.25m,
                    PrizeId = 2,
                    ProductCode = "B",
                    ProductName = "Good Bye",
                    ReleaseDate = DateTime.Today.AddDays(-1)
                },
            };

            return Json(new
            {
                Result = "OK",
                Records = prizes
            });
        }
    }
}