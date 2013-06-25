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

namespace RacingResource.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        [OutputCache(Duration=180)]
        public ActionResult Index()
        {
            List<SyndicationItem> aggregator = new List<SyndicationItem>();
            Rss20FeedFormatter formatter = new Rss20FeedFormatter();

            XmlReader reader = XmlReader.Create(@"http://www.racingpost.com/rss/horse-racing-news.sd");
            formatter.ReadFrom(reader);
            aggregator.AddRange(formatter.Feed.Items);
            reader.Close();
            reader = XmlReader.Create(@"http://www.skysports.com/rss/0,20514,12426,00.xml");
            formatter.ReadFrom(reader);
            aggregator.AddRange(formatter.Feed.Items);
            string xml;
            using (WebClient webClient = new WebClient())
            {
                xml = Encoding.UTF8.GetString(webClient.DownloadData(@"http://www.sportinglife.com/rss/racing.xml"));
            }
            xml = xml.Replace("BST", "+0100");
            byte[] bytes = System.Text.UTF8Encoding.ASCII.GetBytes(xml);
            reader = XmlReader.Create(new MemoryStream(bytes));
            formatter.ReadFrom(reader);
            aggregator.AddRange(formatter.Feed.Items);
            reader.Close();
 
            ViewData["feed"] = aggregator.OrderByDescending(x => x.PublishDate).Take(20).ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

    }
}
