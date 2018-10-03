using System;

namespace RStyleTranslater.YandexTranslaterApi.Exceptions
{
    public class BlockedApiKeyException : Exception
    {
        public BlockedApiKeyException() : base("API-ключ заблокирован") { }
    }
}
