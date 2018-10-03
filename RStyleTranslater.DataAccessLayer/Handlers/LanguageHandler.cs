using System.Collections.Generic;
using System.Linq;
using RStyleTranslater.DataAccessLayer.Interfaces;
using RStyleTranslater.DataAccessLayer.Models;

namespace RStyleTranslater.DataAccessLayer.Handlers
{
    public class LanguageHandler : ILanguageHandler
    {
        public IEnumerable<Language> GetDestLanguages(Language sourceLanguage = null)
        {
            return sourceLanguage == null 
                ? GetLangs()
                : GetLangs().Where(destLang => destLang.Code != sourceLanguage.Code);
        }

        public IEnumerable<Language> GetSourceLanguages(Language destLanguage = null)
        {
            return destLanguage == null 
                ? GetLangs() 
                : GetLangs().Where(sourceLang => sourceLang.Code != destLanguage.Code);
        }

        private static IEnumerable<Language> GetLangs()
        {
            return new List<Language>
            {
                new Language {Code = "ru", LanguageName = "русский"},
                new Language {Code = "en", LanguageName = "английский"},
                new Language {Code = "sl", LanguageName = "словенский"},
            };
        }
    }
}
