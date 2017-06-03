using System;
using System.Net.Http;

namespace Tests.Acceptance.Model
{
    public class CallSpec
    {
        public string Verb { get; set; } 
        public string Url { get; set; }

        public HttpMethod Method()
        {
            HttpMethod method;

            switch (Verb.ToUpper())
            {
                case "POST":
                    method = HttpMethod.Post;
                    break;
                case "GET":
                    method = HttpMethod.Get;
                    break;
                case "PUT":
                    method = HttpMethod.Put;
                    break;
                case "DELETE":
                    method = HttpMethod.Delete;
                    break;
                default:
                    throw new Exception($"Unsupported verb '{Verb}' in call specification.");
            }

            return method;
        }
    }
}