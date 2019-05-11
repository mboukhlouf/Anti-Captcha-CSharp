using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Runtime.Serialization.Json;

using AntiCaptcha.Helpers;

namespace AntiCaptcha
{
    [DataContract]
    public class TaskResult<TSolution>
    {
        [DataMember(Order = 0, Name = "errorId", IsRequired = true)]
        public Error ErrorId { get; set; }

        [DataMember(Order = 1, Name = "errorCode", IsRequired = false)]
        public String Errorcode { get; set; }

        [DataMember(Order = 2, Name = "errorDescription", IsRequired = false)]
        public String ErrorDescription { get; set; }

        [DataMember (Order = 3, Name = "status")]
        public String Status { get; set; }

        [DataMember (Order = 4, Name = "solution")]
        public TSolution Solution { get; set; }

        [DataMember (Order = 5, Name = "Cost")]
        public double Cost { get; set; }

        [DataMember (Order = 6, Name = "ip")]
        public String Ip { get; set; }

        [DataMember (Order = 7, Name = "createTime")]
        public int CreateTime { get; set; }

        [DataMember(Order = 8, Name = "endTime")]
        public int EndTime { get; set; }

        [DataMember(Order = 9, Name = "solveCount")]
        public int Solvecount { get; set; }

        public TaskResult()
        {

        }

        public String ToJson()
        {
            return JsonHelper.ToJson<TaskResult<TSolution>>(this);
        }

        public static TaskResult<TSolution> ParseFromJson(String Json)
        {
            return JsonHelper.ParseFromJson<TaskResult<TSolution>>(Json);
        }
        
        public override String ToString()
        {
            return ToJson();
        }
    }
}
