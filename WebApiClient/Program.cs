using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    class Program
    {
        private static HttpClientManager _manager = new HttpClientManager();

        static void Main(string[] args)
        {
            //_manager.SendGetXmlRequest();

            //_manager.SendPostXml();

            _manager.SendAsyncGet2();

            Console.WriteLine("Waiting...");
            
            Console.Read();
        }
    }
}
