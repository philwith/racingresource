using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Web;
using System.Xml;

namespace RacingResource.Utilities
{
    public class RssUtilities
    {

        public static List<SyndicationItem> GetRssFeedItems(string url)
        {
            Rss20FeedFormatter formatter = new Rss20FeedFormatter();
            XmlReader reader;
            try
            {
                 reader = XmlReader.Create(url);
                formatter.ReadFrom(reader);
            }
            catch(XmlException xexp)
            {
                string xml;
                using (WebClient webClient = new WebClient())
                {
                    xml = Encoding.UTF8.GetString(webClient.DownloadData(url));
                }
                xml = xml.Replace("BST", "+0100");
                xml = xml.Replace("GMT", "+0000");
                byte[] bytes = System.Text.UTF8Encoding.ASCII.GetBytes(xml);
                reader = XmlReader.Create(new MemoryStream(bytes));
                formatter.ReadFrom(reader);
            }
            reader.Close();
            return formatter.Feed == null ? null : formatter.Feed.Items.ToList();
        }
    }
}