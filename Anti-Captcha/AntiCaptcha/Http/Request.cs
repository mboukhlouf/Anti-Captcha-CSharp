using System;
using System.Collections.Generic;
using System.Text;

namespace AntiCaptcha.Http
{
    public class Request
    {
        public String Url { get; set; }
        public String Method { get; set; }
        public String PostData { get; set; }
        public Dictionary<String, String> Headers { get; set; }
        public String ContentType { get; set; }

        public Request()
        {
        }
    }
}
