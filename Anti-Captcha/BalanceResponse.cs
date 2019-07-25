using AntiCaptcha.Helpers;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AntiCaptcha
{
    [DataContract]
    public class BalanceResponse
    {
        [DataMember(Order = 0, Name = "errorId", IsRequired = true)]
        public Error ErrorId { get; set; }

        [DataMember(Order = 1, Name = "errorCode", IsRequired = false)]
        public String Errorcode { get; set; }

        [DataMember(Order = 2, Name = "errorDescription", IsRequired = false)]
        public String ErrorDescription { get; set; }

        [DataMember(Order = 3, Name = "balance", IsRequired = false)]
        public float Balance { get; set; }

        public String ToJson()
        {
            return JsonHelper.ToJson<BalanceResponse>(this);
        }

        public static BalanceResponse ParseFromJson(String Json)
        {
            return JsonHelper.ParseFromJson<BalanceResponse>(Json);
        }

        public override String ToString()
        {
            return ToJson();
        }
    }
}
