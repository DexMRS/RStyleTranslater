using System.Collections.Generic;
using System.Linq;
using RStyleTranslater.BusinessLayer.Interfaces.LanguageSettings;
using RStyleTranslater.BusinessLayer.Models.LanguageSettings;
using RStyleTranslater.DataAccessLayer.Interfaces;

namespace RStyleTranslater.BusinessLayer.Services.LanguageSettings
{
    public class LanguageSettingsService : ILanguageSettingsService
    {
        private readonly ILanguageHandler _languageHandler;

        public LanguageSettingsService(ILanguageHandler handler)
        {
            _languageHandler = handler;
        }

        public IEnumerable<Language> GetDestLanguages(Language sourceLanguages)
        {
            var tmpResult = _languageHandler.GetDestLanguages(new DataAccessLayer.Models.Language() {Code =  sourceLanguages.Code, LanguageName = sourceLanguages.LanguageName} )
                .Select(x => new Language() {Code = x.Code, LanguageName = x.LanguageName});

            return CheckForUnavailableFeatures(tmpResult, sourceLanguages);
        }

        public IEnumerable<Language> GetSourceLanguages(Language destLanguages)
        {
            var tmpResult = _languageHandler.GetSourceLanguages(new DataAccessLayer.Models.Language() { Code = destLanguages.Code, LanguageName = destLanguages.LanguageName })
                .Select(x => new Language() { Code = x.Code, LanguageName = x.LanguageName });

            return CheckForUnavailableFeatures(tmpResult, destLanguages);
        }

        //Плохо для расширения
        private IEnumerable<Language> CheckForUnavailableFeatures(IEnumerable<Language> languages, Language selectedLanguage)
        {
            switch (selectedLanguage.Code)
            {
                case "en": return languages.Where(lang => lang.Code != "sl");
                case "sl": return languages.Where(lang => lang.Code != "en");
                default: return languages;
            }
        }
    }
}
