using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceModel.Web;

namespace CookieBug
{
    class MyService
    {
        [WebGet(UriTemplate = "/")]
        public HttpResponseMessage GetSiteRoot(HttpRequestMessage originalMessage)
        {
            var message = new HttpResponseMessage();
            HttpResponseHeaders headers = message.Headers;
            headers.Add("Set-Cookie", "a=b;Path=/;");
            headers.Add("Set-Cookie", "c=d;Path=/;");

            message.Content = new StringContent("<html><body>Expected to see <b>a=b;c=d</b><script type='text/javascript'>alert(document.cookie)</script></body></html>") { Headers = { ContentType = MediaTypeHeaderValue.Parse("text/html") } };

            return message;
        }
    }
}