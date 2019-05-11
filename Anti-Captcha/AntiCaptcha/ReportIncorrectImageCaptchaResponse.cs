using System;
using System.Runtime.Serialization;

using AntiCaptcha.Helpers;

namespace AntiCaptcha
{
    [DataContract]
    public class ReportIncorrectImageCaptchaResponse
    {
        [DataMember (Order = 0, Name = "errorId")]
        public Error ErrorId { get; set; }

        [DataMember (Order = 1, Name = "status")]
        public String Status { get; set; }

        public String ToJson()
        {
            return JsonHelper.ToJson<ReportIncorrectImageCaptchaResponse>(this);
        }

        public static ReportIncorrectImageCaptchaResponse ParseFromJson(String Json)
        {
            return JsonHelper.ParseFromJson<ReportIncorrectImageCaptchaResponse>(Json);
        }

        public override String ToString()
        {
            return ToJson();
        }
    }
}
