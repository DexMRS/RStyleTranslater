using Nancy;
using Nancy.ModelBinding;
using RStyleTranslater.BusinessLayer.Interfaces.LanguageSettings;
using RStyleTranslater.BusinessLayer.Models.LanguageSettings;

namespace RStyleTranslater.WebApplication.ConsoleApp.Modules
{
    public class LanguageModule : NancyModule
    {
        private readonly ILanguageSettingsService _languageSettingsService;

        public LanguageModule(ILanguageSettingsService languageSettingsService) : base("/Languages")
        {
            _languageSettingsService = languageSettingsService;

            Post["/getsourcelanguages"] = (parameters) =>
            {
                var destlanguages = this.Bind<Language>();

                return _languageSettingsService.GetSourceLanguages(destlanguages);
            };

            Post["/getdestlanguages"] = (parameters) =>
            {
                var sourceLanguages = this.Bind<Language>();

                return _languageSettingsService.GetDestLanguages(sourceLanguages);
            };
        }
    }
}
