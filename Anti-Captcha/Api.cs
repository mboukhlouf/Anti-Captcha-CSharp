using System;

namespace AntiCaptcha
{
    public class AntiCaptchaApi
    {
        private readonly Http.Client Client;

        public String Host { get; set; }
        public String ClientKey { get; set; }

        public AntiCaptchaApi(String Host, String ClientKey)
        {
            this.Host = Host;   
            this.ClientKey = ClientKey;
            this.Client = new Http.Client();
        }

        public async System.Threading.Tasks.Task<TaskResponse> CreateTaskAsync<TTaskType>(TTaskType taskType)
        {
            String url = $"{Host}/createTask";
            Task<TTaskType> task = new Task<TTaskType>()
            {
                ClientKey = this.ClientKey,
                TaskType = taskType,
                LanguagePool = "en"
            };

            String postData = task.ToJson();

            Http.Request request = new Http.Request()
            {
                Url = url,
                Method = "POST",
                PostData = postData,
                ContentType = "application/json"
            };

            Http.Response response = await Client.ExecuteAsync(request);
            if(response.StatusCode == 200)
            {
                TaskResponse taskResponse = TaskResponse.ParseFromJson(response.Body);
                return taskResponse;
            }
            else
            {
                throw new Exception(response.ToString());
            }
        }

        public async System.Threading.Tasks.Task<TaskResult<SolutionType>> GetTaskResultAsync<SolutionType>(int taskId)
        {
            String url = $"{Host}/getTaskResult";
            String postData = $"{{\"clientKey\":\"{ClientKey}\", \"taskId\": {taskId}}}";

            Http.Request request = new Http.Request()
            {
                Url = url,
                Method = "POST",
                PostData = postData,
                ContentType = "application/json"
            };

            Http.Response response = await Client.ExecuteAsync(request);
            if (response.StatusCode == 200)
            {
                TaskResult<SolutionType> taskResult = TaskResult<SolutionType>.ParseFromJson(response.Body);
                return taskResult;
            }
            else
            {
                throw new Exception(response.ToString());
            }
        }

        public async System.Threading.Tasks.Task<BalanceResponse> GetBalanceAsync()
        {
            String url = $"{Host}/getBalance";
            String postData = $"{{\"clientKey\":\"{ClientKey}\"}}";

            Http.Request request = new Http.Request()
            {
                Url = url,
                Method = "POST",
                PostData = postData,
                ContentType = "application/json"
            };

            Http.Response response = await Client.ExecuteAsync(request);
            if (response.StatusCode == 200)
            {
                BalanceResponse balanceResponse = BalanceResponse.ParseFromJson(response.Body);
                return balanceResponse;
            }
            else
            {
                throw new Exception(response.ToString());
            }
        }

        public async System.Threading.Tasks.Task<QueueStat> GetQueueStats(Queue queueId)
        {
            String url = $"{Host}/getQueueStats ";
            String postData = $"{{\"queueId\":\"{(int)queueId}\"}}";

            Http.Request request = new Http.Request()
            {
                Url = url,
                Method = "POST",
                PostData = postData,
                ContentType = "application/json"
            };

            Http.Response response = await Client.ExecuteAsync(request);
            if (response.StatusCode == 200)
            {
                QueueStat queueStat = QueueStat.ParseFromJson(response.Body);
                return queueStat;
            }
            else
            {
                throw new Exception(response.ToString());
            }
        }

        public async System.Threading.Tasks.Task<ReportIncorrectImageCaptchaResponse> ReportIncorrectImageCaptcha(int taskId)
        {
            String url = $"{Host}/reportIncorrectImageCaptcha ";
            String postData = $"{{\"clientKey\":\"{ClientKey}\", \"taskId\": {taskId}}}";

            Http.Request request = new Http.Request()
            {
                Url = url,
                Method = "POST",
                PostData = postData,
                ContentType = "application/json"
            };

            Http.Response response = await Client.ExecuteAsync(request);
            if (response.StatusCode == 200)
            {
                ReportIncorrectImageCaptchaResponse reportResponse = ReportIncorrectImageCaptchaResponse.ParseFromJson(response.Body);
                return reportResponse;
            }
            else
            {
                throw new Exception(response.ToString());
            }
        }
    }
}
