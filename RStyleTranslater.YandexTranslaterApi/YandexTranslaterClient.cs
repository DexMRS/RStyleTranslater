using Newtonsoft.Json;
using System.Threading.Tasks;
using RStyleTranslater.Common.Interfaces;
using RStyleTranslater.YandexTranslaterApi.Exceptions;
using RStyleTranslater.YandexTranslaterApi.Models;

namespace RStyleTranslater.YandexTranslaterApi
{
    public class YandexTranslaterClient : ApiClientCommon, ITranslater<TranslateRequest, TranslateResponse>
    {
        private const string key = "trnsl.1.1.20180927T024654Z.a4cd2e40bae74fed.d5f46aaac8f6fb4be846fb6c6d1dd88210cfcd0e";
        
        public YandexTranslaterClient()
        {
            HostName = "translate.yandex.net";
        }

        public async Task<TranslateResponse> Translate(TranslateRequest translateRequest)
        {
            var response = await Post($"api/v1.5/tr.json/translate?key={key}", translateRequest);
            var result = JsonConvert.DeserializeObject<TranslateResponse>(await response.Content.ReadAsStringAsync());
            CheckForCurrectResult(result);

            return result;
        }

        private static void CheckForCurrectResult(TranslateResponse response)
        {
            switch (response.Code)
            {
                case 401: throw new InvalidApiKeyException();
                case 402: throw new BlockedApiKeyException();
                case 404: throw new ExceededDailyLimitException();
                case 413: throw new ExceededMaximumTextSizeException();
                case 422: throw new TextCannotBeTranslatedException();
                case 501: throw new SpecifiedTranslationNotSupportedException();

                default: return;
            }
            
        }
    }
}
