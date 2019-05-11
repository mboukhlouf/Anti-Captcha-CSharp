using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

using AntiCaptcha.Helpers;

namespace AntiCaptcha
{
    [DataContract]
    public class TaskResponse
    {
        [DataMember(Order = 0, Name = "errorId", IsRequired = true)]
        public Error ErrorId { get; set; }

        [DataMember(Order = 1, Name = "errorCode", IsRequired = false)]
        public String Errorcode { get; set; }

        [DataMember(Order = 2, Name = "errorDescription", IsRequired = false)]
        public String ErrorDescription { get; set; }

        [DataMember(Order = 3, Name = "taskId", IsRequired = false)]
        public int TaskId { get; set; }

        public TaskResponse()
        {

        }

        public TaskResponse(Error ErrorId, int TaskId)
        {
            this.ErrorId = ErrorId;
            this.TaskId = TaskId;   
        }

        public String ToJson()
        {
            return JsonHelper.ToJson<TaskResponse>(this);
        }

        public static TaskResponse ParseFromJson(String Json)
        {
            return JsonHelper.ParseFromJson<TaskResponse>(Json);
        }

        public override String ToString()
        {
            return ToJson();
        }
    }
}
