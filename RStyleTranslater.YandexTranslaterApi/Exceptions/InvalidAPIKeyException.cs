using System;

namespace RStyleTranslater.YandexTranslaterApi.Exceptions
{
    public class InvalidApiKeyException : Exception
    {
        public InvalidApiKeyException(): base("Неправильный API-ключ") { }
    }
}
