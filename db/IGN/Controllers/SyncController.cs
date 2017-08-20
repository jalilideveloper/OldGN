using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using IGN.Data;
using System.Xml.Linq;

namespace IGN.Controllers
{
    public class SyncController : Controller
    {
        // GET: Sync
        
        public bool GetDataTest()
        {
            try
            {
                using (greenopt_IgNewsEntities db = new greenopt_IgNewsEntities())
                {

                    var qRss = (from i in db.tblMagazines
                                where i.MagazineID == 6
                                select i).ToList();
                  
                        IList<Item> lst = ParseRss("http://www.economist.com/sections/economics/rss.xml");

                        var q = (from i in db.tblNews
                                 where i.MagazineID == 6
                                 select i).FirstOrDefault();

                        if (q != null)
                        {
                            if (q.Title == lst.FirstOrDefault().Title)
                            {

                            }
                        }
                        else if (q == null || q.Title != lst.FirstOrDefault().Title)
                        {
                            foreach (var itemInside in lst)
                            {
                                tblNew n = new tblNew();
                                n.Title = itemInside.Title;
                                n.PubDate = itemInside.PublishDate;
                                n.Descriptions = itemInside.Content;
                                n.MagazineID = 6;
                                n.ViewNumber = 0;
                                n.DateInserted = DateTime.Now.Date;
                                n.LinkUrl = itemInside.Link;
                                db.tblNews.Add(n);
                                db.SaveChanges();

                            }


                        }
                    
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public bool GetData()
        {
            try
            {
                using (greenopt_IgNewsEntities db = new greenopt_IgNewsEntities())
                {

                    var qRss = (from i in db.tblMagazines
                                where i.MagazineID == 3
                             select i).ToList();
                    foreach (var item in qRss)
                    {

                        IList<Item> lst = ParseRss(item.RssUrl);

                        var q = (from i in db.tblNews
                                 where i.MagazineID == item.MagazineID
                                 select i).FirstOrDefault();

                        if (q != null )
                        {
                            if ( q.Title == lst.FirstOrDefault().Title )
                            {
                                break;
                            }
                        }
                        else if(q == null || q.Title != lst.FirstOrDefault().Title)
                        {
                            foreach (var itemInside in lst)
                            {
                                tblNew n = new tblNew();
                                n.Title = itemInside.Title;
                                n.PubDate = itemInside.PublishDate;
                                n.Descriptions = itemInside.Content;
                                n.MagazineID = item.MagazineID;
                                n.ViewNumber = 0;
                                n.DateInserted = DateTime.Now.Date;
                                n.LinkUrl = itemInside.Link;
                                db.tblNews.Add(n);
                                db.SaveChanges();

                            }

                           
                        }
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }




        public string DataTableToJSONWithJSONNet(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }
       
        public virtual IList<Item> ParseRss(string url)
        {
            try
            {
                XDocument doc = XDocument.Load(url);
                // RSS/Channel/item
                var entries = from item in doc.Root.Descendants().First(i => i.Name.LocalName == "channel").Elements().Where(i => i.Name.LocalName == "item")
                              select new Item
                              {
                                  FeedType = FeedType.RSS,
                                  Content = item.Elements().First(i => i.Name.LocalName == "description").Value,
                                  Link = item.Elements().First(i => i.Name.LocalName == "link").Value,
                                  PublishDate = item.Elements().First(i => i.Name.LocalName == "pubDate").Value,
                                  Title = item.Elements().First(i => i.Name.LocalName == "title").Value
                              };
                return entries.ToList();
            }
            catch
            {
                return new List<Item>();
            }
        }
        public class Item
        {
            public string Link { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public string PublishDate { get; set; }
            public FeedType FeedType { get; set; }

            public Item()
            {
                Link = "";
                Title = "";
                Content = "";
                PublishDate = "";
                FeedType = FeedType.RSS;
            }
        }
        public enum FeedType
        {
            /// <summary>
            /// Really Simple Syndication format.
            /// </summary>
            RSS,
            /// <summary>
            /// RDF site summary format.
            /// </summary>
            RDF,
            /// <summary>
            /// Atom Syndication format.
            /// </summary>
            Atom
        }
    }
}