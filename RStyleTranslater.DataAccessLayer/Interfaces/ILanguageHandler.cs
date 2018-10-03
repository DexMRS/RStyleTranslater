using System.Collections.Generic;
using RStyleTranslater.DataAccessLayer.Models;

namespace RStyleTranslater.DataAccessLayer.Interfaces
{
    public interface ILanguageHandler
    {
        IEnumerable<Language> GetDestLanguages(Language sourceLanguage);
        IEnumerable<Language> GetSourceLanguages(Language destLanguage);
    }
}
