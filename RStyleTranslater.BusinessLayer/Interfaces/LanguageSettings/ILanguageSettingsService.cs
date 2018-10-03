using System.Collections.Generic;
using RStyleTranslater.BusinessLayer.Models.LanguageSettings;

namespace RStyleTranslater.BusinessLayer.Interfaces.LanguageSettings
{
    public interface ILanguageSettingsService
    {
        IEnumerable<Language> GetDestLanguages(Language sourceLanguages);
        IEnumerable<Language> GetSourceLanguages(Language destLanguages);
    }
}
