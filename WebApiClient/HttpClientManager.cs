using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebAPI.MediaFormatter;
using WebAPI.Models;

namespace WebApiClient
{
    public class HttpClientManager
    {
        private HttpClient _client;

        private string _address = "http://localhost:9015/";

        public HttpClientManager()
        {
            //client initialization 
            _client = new HttpClient();

            // ustawienie podstawowego adresu, dzialajacego podobnie jak w WCF
            _client.BaseAddress = new Uri(_address);

            // ustawienie akceptowanego content-type !!!!!!!!!!!!!
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
        }

        #region Akcje wykonane synchronicznie

        /// <summary>
        /// Funkcja tworzaca GET synchronicznie. Odczyt danych synchroniczny. Uzywa default xml formattera.
        /// </summary>
        public void SendGetXmlRequest()
        {
            // 
            // wykonanie na koncu .Result powoduje ze akcja zostaje wykonana synchronicznie
            HttpResponseMessage response = _client.GetAsync("api/simple").Result;

            //sprawdzenie statusu odpowiedzi
            if (response.IsSuccessStatusCode)
            {
                // poprzez odpowiednia serializacje dostajemy typ przeslany z serwisu.
                var result = response.Content.ReadAsAsync<Feed>().Result;
            }

        }

        /// <summary>
        /// Funkcja tworzaca GET synchronicznie. Odczyt danych synchroniczny. Podlaczenie reczne roznych formatterow.
        /// </summary>
        public void SendGetRssRequest()
        {
            // 
            // wykonanie na koncu .Result powoduje ze akcja zostaje wykonana synchronicznie
            HttpResponseMessage response = _client.GetAsync("api/simple").Result;

            //sprawdzenie statusu odpowiedzi
            if (response.IsSuccessStatusCode)
            {

                //podlaczenie odpowiednich formatterow. przydatne jezeli uzywamy jakiegos customowego
                var formatters = new List<MediaTypeFormatter>()
                    {
                        new XmlMediaTypeFormatter(),
                        new BufferedFeedFormatter(),
                        new JsonMediaTypeFormatter()
                    };

                var result = response.Content.ReadAsAsync<Feed>(formatters).Result;
            }

        }

        /// <summary>
        /// Funkcja wysylajaca POST do serwisu.
        /// </summary>
        public void SendPostXml()
        {
            Feed f = new Feed() {Title = "Post feed"};


            // wyslanie POST
            var response = _client.PostAsync("api/simple",
                                             new ObjectContent(typeof (Feed), f, new XmlMediaTypeFormatter())).Result;

            //albo 
            response = _client.PostAsync("api/simple", new ObjectContent<Feed>(f, new XmlMediaTypeFormatter())).Result;
        }

        /// <summary>
        /// Funkcja wysylajaca PUT do serwisu.
        /// </summary>
        public void SendPutXml()
        {
            Feed f = new Feed() {Title = "Put feed"};

            _client.PutAsync("api/simple", new ObjectContent<Feed>(f, new XmlMediaTypeFormatter()));
        }

        #endregion

        #region Obsluga bledow

        public void HandlingExceptionsOption1()
        {
            HttpResponseMessage response = _client.GetAsync("api/simple").Result;

            if (response.IsSuccessStatusCode)
            {
                // poprzez odpowiednia serializacje dostajemy typ przeslany z serwisu.
                var result = response.Content.ReadAsAsync<Feed>().Result;
            }
        }

        public void HandlingExceptionsOption2()
        {
            HttpResponseMessage response = _client.GetAsync("api/simple").Result;

            try
            {
                response.EnsureSuccessStatusCode();

                // poprzez odpowiednia serializacje dostajemy typ przeslany z serwisu.
                var result = response.Content.ReadAsAsync<Feed>().Result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        #region Akcje wykonanie asynchronicznie

        /// <summary>
        /// Funkcja wysylajaca asynchronicznie GET. Uzycie frameworka 4.0, brak obslugi slowa await/async
        /// </summary>
        public void SendAsyncGet1()
        {
            _client.GetAsync("api/simple").ContinueWith(
                (requestTask) =>
                    {
                        // Get HTTP response from completed task. 
                        HttpResponseMessage response = requestTask.Result;

                        // Check that response was successful or throw exception 
                        response.EnsureSuccessStatusCode();

                        var item = response.Content.ReadAsAsync<Feed>().Result;
                    });
        }
        
        /// <summary>
        /// Funkcja wysylajaca GET do serwera z wykorzystaniem nowej asynchronicznej skladni dla frameworka 4.5.
        /// Funkcja wykorzystuje TASKs.
        /// </summary>
        public async void SendAsyncGet2()
        {
            // odpalenie metody i przekazanie czynnosci do funkcji SendAsyncGet2
            var task1 = await _client.GetAsync("api/simple");

            //jezeli task1 zostanie zakonczony, wykonywanie metody zostanie wznowione
            //pobranie wynikow synchronicznie
            var result1 = task1.Content.ReadAsAsync<Feed>().Result;

            //utworzenie taska2
            var task2 = _client.GetAsync("api/simple");

            // wykonanie roznych innych czynnosci niezaleznych od zakonczenia task2
            Console.WriteLine("Jakies czynnosci wykonany synchronicznie");
            Console.WriteLine("Jakies czynnosci wykonany synchronicznie");
            Console.WriteLine("Jakies czynnosci wykonany synchronicznie");
            Console.WriteLine("Jakies czynnosci wykonany synchronicznie");

            //tutaj potrzebujemy wynikow taska2
            //jezeli sa one dostepne to akcja zostaje wykonana natychmiast, jezeli nie to funkcja wywoolujaca przejmuje kontrole
            var result2 = await task2;

            //sprawdzenie czy akcja zakonczula sie poprawnie
            if (result2.IsSuccessStatusCode)
            {
                var result = await result2.Content.ReadAsAsync<Feed>();

                if (result != null)
                {
                    Console.WriteLine(result.Title);
                }
            }
            


        }

        /// <summary>
        /// Funkcja wykonujaca asynchronicznie POST. 
        /// </summary>
        public async void SendAsyncPostXml()
        {
            Feed f = new Feed() { Title = "Post feed" };

            var response = await _client.PostAsync("api/simple", new ObjectContent<Feed>(f, new XmlMediaTypeFormatter()));

            if (response.IsSuccessStatusCode)
            {
                
            }
        }

        #endregion

    }

    public abstract class AbsClass
    {
        public abstract void Foo4();
    }

    public class SimpleClass
    {
        public int Property { get; set; }

        public int PropertySet { set; private get; }

        public int PropertyGet { get; private set; }

        public void Foo()
        {

        }

        public virtual void Foo1()
        {

        }
    }

    public class SimpleClass1 : SimpleClass
    {
        public override void Foo1()
        {
            base.Foo1();
        }
    }
}
