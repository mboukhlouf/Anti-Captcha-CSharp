using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AntiCaptcha.Http
{
    public class Client
    {
        private readonly HttpClientHandler HttpClientHandler;
        private readonly HttpClient HttpClient;

        public IWebProxy Proxy
        {
            get
            {
                return HttpClientHandler.Proxy;
            }
            set
            {
                HttpClientHandler.UseProxy = value != null;
                HttpClientHandler.Proxy = value;
            }
        }

        public CookieContainer Cookies
        {
            get
            {
                return HttpClientHandler.CookieContainer;
            }
            set
            {
                HttpClientHandler.CookieContainer = value;
            }
        }

        public Client()
        {
            HttpClientHandler = new HttpClientHandler();
            HttpClient = new HttpClient(HttpClientHandler);

            HttpClientHandler.UseDefaultCredentials = true;
            HttpClientHandler.UseCookies = true;
            HttpClientHandler.CookieContainer = new CookieContainer();
            HttpClientHandler.AllowAutoRedirect = false;
        }

        public async System.Threading.Tasks.Task<Response> ExecuteAsync(Request request)
        {
            var Message = new HttpRequestMessage()
            {
                Method = new HttpMethod(request.Method),
                RequestUri = new Uri(request.Url),
                Content = new StringContent(request.PostData ?? "")
            };

            if (request.Headers != null)
                foreach (KeyValuePair<String, String> header in request.Headers)
                {
                    Message.Headers.Add(header.Key, header.Value);
                }

            if (!String.IsNullOrEmpty(request.ContentType))
                Message.Content.Headers.ContentType = new MediaTypeHeaderValue(request.ContentType);

            using (HttpResponseMessage httpResponse = await HttpClient.SendAsync(Message))
            using (HttpContent content = httpResponse.Content)
            {
                Dictionary<string, string[]> headers = new Dictionary<string, string[]>();

                // Adding response headers
                foreach (var header in httpResponse.Headers)
                {
                    headers.Add(header.Key, (string[])header.Value);
                }

                // Adding content headres
                foreach (var header in content.Headers)
                {
                    foreach (var value in header.Value)
                    {
                        headers.Add(header.Key, (string[])header.Value);
                    }

                }
                Response response = new Response()
                {
                    Version = httpResponse.Version.ToString(),
                    StatusCode = (int)httpResponse.StatusCode,
                    ReasonPhrase = httpResponse.ReasonPhrase,
                    Body = await content.ReadAsStringAsync(),
                    Headers = headers
                };
                return response;
            }
        }

        ~Client()
        {
            HttpClient.Dispose();
            HttpClientHandler.Dispose();
        }
    }
}
