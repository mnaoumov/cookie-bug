using System;
using Microsoft.ApplicationServer.Http;

namespace CookieBug
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new HttpServiceHost(typeof(MyService), new Uri("http://localhost:1234"));
            host.Open();

            Console.WriteLine("Browse to http://localhost:1234");
            Console.ReadLine();
        }
    }
}
