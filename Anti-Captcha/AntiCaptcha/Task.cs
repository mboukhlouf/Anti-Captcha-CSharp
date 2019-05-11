using AntiCaptcha.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace AntiCaptcha
{
    [DataContract]
    public class Task<TTaskType>
    {
        [DataMember(Order = 0, Name = "clientKey", IsRequired = true)]
        public String ClientKey { get; set; }

        [DataMember(Order = 1, Name = "task", IsRequired = true)]
        public TTaskType TaskType { get; set; }

        [DataMember(Order = 2, Name = "softId", IsRequired = false)]
        public int SoftId { get; set; }

        [DataMember(Order = 3, Name = "languagePool", IsRequired = false)]
        public String LanguagePool { get; set; }

        [DataMember(Order = 4, Name = "callbackUrl", IsRequired = false)]
        public String CallbackUrl { get; set; }

        public Task()
        {
            this.ClientKey = "";
            this.TaskType = default(TTaskType);
            this.SoftId = 0;
            this.LanguagePool = "en";
            this.CallbackUrl = "";
        }

        public Task(String ClientKey, TTaskType TaskType, int SoftId = 0, String LanguagePool = "en", String CallbackUrl = "")
        {
            this.ClientKey = ClientKey;
            this.TaskType = TaskType;
            this.SoftId = SoftId;
            this.LanguagePool = LanguagePool;
            this.CallbackUrl = CallbackUrl;
        }

        public String ToJson()
        {
            return JsonHelper.ToJson<Task<TTaskType>>(this);
        }

        public static Task<TTaskType> ParseFromJson(String Json)
        {
            return JsonHelper.ParseFromJson<Task<TTaskType>>(Json);
        }

        public override String ToString()
        {
            return ToJson();
        }
    }
}
