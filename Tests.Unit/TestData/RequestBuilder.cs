using System.Net.Http;

namespace Tests.Unit.TestData
{
    public class RequestBuilder
    {
        public HttpRequestMessage Build()
        {
            return new HttpRequestMessage();
        } 
    }
}