using System;

using AntiCaptcha;

namespace Anti_Captcha
{
    class Program
    {
        static void Main(string[] args)
        {
            AntiCaptchaApi AntiCaptchaApi = new AntiCaptchaApi("https://api.anti-captcha.com", "Client Key");
            NoCaptchaTaskProxyless captchaTask = new NoCaptchaTaskProxyless("Website Url", "Website Key");

            System.Threading.Tasks.Task.Run(async () =>
            {
                // Get balance
                BalanceResponse balanceResponse = await AntiCaptchaApi.GetBalanceAsync();
                float balance = balanceResponse.Balance;

                // Make a task
                TaskResponse response = await AntiCaptchaApi.CreateTaskAsync(captchaTask);
                int taskId = response.TaskId;

                // Get the task result
                TaskResult<NoCaptchaSolution> taskResult = null;
                do
                {
                    try
                    {
                        taskResult = await AntiCaptchaApi.GetTaskResultAsync<NoCaptchaSolution>(taskId);
                        // Wait 0.5 seconds before requesting again
                        System.Threading.Tasks.Task.Delay(500).Wait();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                while (taskResult != null && taskResult.Status != "ready");
            });

            Console.Read();
        }
    }
}