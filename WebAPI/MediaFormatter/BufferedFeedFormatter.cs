using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.ServiceModel.Syndication;
using System.Web;
using System.Xml;
using WebAPI.Models;

namespace WebAPI.MediaFormatter
{
    public class BufferedFeedFormatter: BufferedMediaTypeFormatter
    {
        #region Const

        //Zadeklarowane MIME types.

        private readonly string atom = "application/atom+xml";
        
        private readonly string rss = "application/rss+xml";
        
        #endregion

        #region Constructor

        public BufferedFeedFormatter()
        {
            //Mime types obslugiwane przez formattera
            
            SupportedMediaTypes.Add(new MediaTypeHeaderValue(atom));

            SupportedMediaTypes.Add(new MediaTypeHeaderValue(rss));
        }

        #endregion

        public override bool CanReadType(Type type)
        {
            return SupportedType(type);
        }

        public override bool CanWriteType(Type type)
        {
            return SupportedType(type);
        }

        public override void WriteToStream(Type type, object value, System.IO.Stream writeStream, System.Net.Http.HttpContent content)
        {
            BuildSyndicationFeed(value, writeStream, content.Headers.ContentType.MediaType);
        }

        public override object ReadFromStream(Type type, Stream readStream, System.Net.Http.HttpContent content, IFormatterLogger formatterLogger)
        {
            return base.ReadFromStream(type, readStream, content, formatterLogger);
        }

        #region Helper functions

        /// <summary>
        /// Funkcja sprawdzajaca czy formatter obsluguje wybrany typ.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private bool SupportedType(Type type)
        {
            if (type == typeof(Feed) || type == typeof(IEnumerable<Feed>))
                return true;
           
            return false;
        }


        private void BuildSyndicationFeed(object models, Stream stream, string contenttype)
        {
            List<SyndicationItem> items = new List<SyndicationItem>();
            
            var feed = new SyndicationFeed()
            {
                Title = new TextSyndicationContent("My Feed")
            };

            if (models is IEnumerable<Feed>)
            {
                var enumerator = ((IEnumerable<Feed>)models).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    items.Add(BuildSyndicationItem(enumerator.Current));
                }
            }
            else
            {
                items.Add(BuildSyndicationItem((Feed)models));
            }

            feed.Items = items;

            using (XmlWriter writer = XmlWriter.Create(stream))
            {
                if (string.Equals(contenttype, atom))
                {
                    Atom10FeedFormatter atomformatter = new Atom10FeedFormatter(feed);
                    atomformatter.WriteTo(writer);
                }
                else
                {
                    Rss20FeedFormatter rssformatter = new Rss20FeedFormatter(feed);
                    rssformatter.WriteTo(writer);
                }
            }
        }

        private SyndicationItem BuildSyndicationItem(Feed u)
        {
            var item = new SyndicationItem()
            {
                Title = new TextSyndicationContent(u.Title),
                
                BaseUri = new Uri(u.Address),
                
                LastUpdatedTime = u.CreatedAt,
                
                Content = new TextSyndicationContent(u.Description)
            };

            item.Authors.Add(new SyndicationPerson() { Name = u.CreatedBy });
            
            return item;
        }

        #endregion
    }
}