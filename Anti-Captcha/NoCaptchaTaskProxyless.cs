using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

using AntiCaptcha.Helpers;

namespace AntiCaptcha
{
    [KnownType(typeof(NoCaptchaTaskProxyless))]
    [DataContract]
    public class NoCaptchaTaskProxyless
    {
        [DataMember (Order = 0, Name = "type")]
        public String Type { get; private set; } = "NoCaptchaTaskProxyless";

        [DataMember(Order = 1, Name = "websiteURL")]
        public String WebsiteUrl { get; set; }

        [DataMember(Order = 2, Name = "websiteKey")]
        public String WebsiteKey { get; set; }

        [DataMember(Order = 3, Name = "websiteSToken")]
        public String WebsiteSToken { get; set; }

        [DataMember(Order = 4, Name = "isInvisible")]
        public bool Invisible { get; set; }

        public NoCaptchaTaskProxyless()
        {
            this.WebsiteUrl = "";
            this.WebsiteKey = "";
            this.WebsiteSToken = "";
            this.Invisible = false;
        }

        public NoCaptchaTaskProxyless(String WebsiteUrl, String WebsiteKey, String WebsiteSToken = "", bool Invisible = false)
        {
            this.WebsiteUrl = WebsiteUrl;
            this.WebsiteKey = WebsiteKey;
            this.WebsiteSToken = WebsiteSToken;
            this.Invisible = Invisible;
        }

        public String ToJson()
        {
            return JsonHelper.ToJson<NoCaptchaTaskProxyless>(this);
        }

        public static NoCaptchaTaskProxyless ParseFromJson(String Json)
        {
            return JsonHelper.ParseFromJson<NoCaptchaTaskProxyless>(Json);
        }

        public override String ToString()
        {
            return ToJson();
        }
    }
}
