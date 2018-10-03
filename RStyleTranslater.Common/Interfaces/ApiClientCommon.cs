using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Polly;

namespace RStyleTranslater.Common.Interfaces
{
    public abstract class ApiClientCommon 
    {
        /// <summary>
        /// Стратегия обработки ошибок
        /// </summary>
        protected static Policy ExponentialRetryPolicy { get; set; } =
            Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(
                3,
                attempt => TimeSpan.FromMilliseconds(100 * Math.Pow(2, attempt)));

        protected static string HostName { get; set; }

        /// <summary>
        /// Проверка доступности внешнего сервиса
        /// </summary>
        /// <returns>true - сервис доступен</returns>
        public virtual bool HealthCheck()
        {
            try
            {
                ThrowOnTransientFailure(Get(HostName).Result);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// POST запрос, обёрнутый retry стратегией
        /// </summary>
        /// <param name="endpoint">конечная точка (api/...)</param>
        /// <param name="data">тело запроса</param>
        /// <returns>результат запроса</returns>
        public virtual async Task<HttpResponseMessage> Post(string endpoint, object data) =>
            await ExponentialRetryPolicy.ExecuteAsync(() => SendPost(endpoint, data));

        /// <summary>
        /// GET запрос, обёрнутый retry стратегией
        /// </summary>
        /// <param name="endpoint">конечная точка (api/...)</param>
        /// <returns></returns>
        public virtual async Task<HttpResponseMessage> Get(string endpoint) =>
            await ExponentialRetryPolicy.ExecuteAsync(() => SendGet(endpoint));

        private static async Task<HttpResponseMessage> SendPost(string endpoint, object data)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri($"https://{HostName}");
                var response = await httpClient.PostAsync(
                    $"/{endpoint}",
                    new StringContent(
                        content: data.ToString(),
                        encoding: Encoding.UTF8,
                        mediaType: "application/x-www-form-urlencoded"));
                ThrowOnTransientFailure(response);

                return response;
            }
        }
        
        private static async Task<HttpResponseMessage> SendGet(string endpoint)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri($"https://{HostName}");
                var response = await httpClient.GetAsync(endpoint);
                ThrowOnTransientFailure(response);

                return response;
            }
        }

        private static void ThrowOnTransientFailure(HttpResponseMessage response)
        {
            if (((int)response.StatusCode) < 200 || ((int)response.StatusCode) > 499)
                throw new Exception(response.StatusCode.ToString());
        }
    }
}
