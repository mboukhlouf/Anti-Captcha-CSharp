using System;
using System.Runtime.Serialization;

using AntiCaptcha.Helpers;

namespace AntiCaptcha
{
    [DataContract]
    public class QueueStat
    {
        [DataMember(Order = 0, Name = "waiting")]
        public int Waiting { get; set; }

        [DataMember(Order = 1, Name = "load")]
        public float Load { get; set; }

        [DataMember(Order = 2, Name = "bid")]
        public float Bid { get; set; }

        [DataMember(Order = 3, Name = "speed")]
        public float Speed { get; set; }

        [DataMember(Order = 4, Name = "total")]
        public int Total { get; set; }

        public String ToJson()
        {
            return JsonHelper.ToJson<QueueStat>(this);
        }

        public static QueueStat ParseFromJson(String Json)
        {
            return JsonHelper.ParseFromJson<QueueStat>(Json);
        }

        public override String ToString()
        {
            return ToJson();
        }
    }
}
