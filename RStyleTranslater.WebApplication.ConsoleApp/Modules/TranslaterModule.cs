using Nancy;
using Nancy.ModelBinding;
using RStyleTranslater.Common.Interfaces;
using RStyleTranslater.YandexTranslaterApi.Models;

namespace RStyleTranslater.WebApplication.ConsoleApp.Modules
{
    public class TranslaterModule : NancyModule
    {
        private ITranslater<TranslateRequest, TranslateResponse> _translaterService;
        public TranslaterModule(ITranslater<TranslateRequest, TranslateResponse> translater) : base("/translate")
        {
            _translaterService = translater;

            Post["/"] = (parameters) =>
            {
                var data = this.Bind<TranslateRequest>();
                if (data.Text == string.Empty)
                    return new TranslateResponse {Text = new string[] { "" } } ;
                var res = _translaterService.Translate(data).Result;

                return res;
            };

            Get["/check"] = _ => ((ApiClientCommon) _translaterService).HealthCheck();
            
        }
    }
}
