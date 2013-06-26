using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Net;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using RacingResource.Utilities;

namespace RacingResource.Controllers
{
    public class HomeController : AsyncController
    {
        private void GetRacingPostNews()
        {
            List<SyndicationItem> items = RssUtilities.GetRssFeedItems(@"http://www.racingpost.com/rss/horse-racing-news.sd");
            AsyncManager.Parameters.Add("RacingPostNews", items);
            AsyncManager.OutstandingOperations.Decrement();
        }

        private void GetSkySportsNews()
        {
            List<SyndicationItem> items = RssUtilities.GetRssFeedItems(@"http://www.skysports.com/rss/0,20514,12426,00.xml");
            AsyncManager.Parameters.Add("SkySportsNews", items);
            AsyncManager.OutstandingOperations.Decrement();
        }

        private void GetSportingLifeNews()
        {
            List<SyndicationItem> items = RssUtilities.GetRssFeedItems(@"http://www.sportinglife.com/rss/racing.xml");
            AsyncManager.Parameters.Add("SportingLifeNews", items);
            AsyncManager.OutstandingOperations.Decrement();
        }

        private void GetBbcNews()
        {
            List<SyndicationItem> items = RssUtilities.GetRssFeedItems(@"http://feeds.bbci.co.uk/sport/0/horse-racing/rss.xml");
            AsyncManager.Parameters.Add("SportingLifeNews", items);
            AsyncManager.OutstandingOperations.Decrement();
        }

        public void IndexAsync()
        {
            AsyncManager.OutstandingOperations.Increment(3);
            Task.Factory.StartNew(() => GetRacingPostNews());
            Task.Factory.StartNew(() => GetSkySportsNews());
            Task.Factory.StartNew(() => GetSportingLifeNews());
        }

        [OutputCache(Duration=180)]
        public ActionResult IndexCompleted(IEnumerable<SyndicationItem> RacingPostNews, IEnumerable<SyndicationItem> SkySportsNews, IEnumerable<SyndicationItem> SportingLifeNews)
        {
            List<SyndicationItem> aggregator = new List<SyndicationItem>();
            aggregator.AddRange(RacingPostNews);
            aggregator.AddRange(SkySportsNews);
            aggregator.AddRange(SportingLifeNews);
 
            ViewData["feed"] = aggregator.OrderByDescending(x => x.PublishDate).Take(10).ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

    }
}
