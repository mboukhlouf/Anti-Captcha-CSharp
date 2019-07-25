using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AntiCaptcha
{
    [DataContract]
    public class NoCaptchaSolution
    {
        [DataMember(Order = 0, Name = "gRecaptchaResponse", IsRequired = true)]
        public String GRecaptchaResponse { get; set; }

        [DataMember(Order = 1, Name = "gRecaptchaResponseMD5", IsRequired = false)]
        public String GRecaptchaResponseMD5 { get; set; }
    }
}
