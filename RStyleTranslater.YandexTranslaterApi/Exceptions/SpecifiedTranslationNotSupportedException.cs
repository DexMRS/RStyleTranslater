using System;

namespace RStyleTranslater.YandexTranslaterApi.Exceptions
{
    public class SpecifiedTranslationNotSupportedException : Exception
    {
        public SpecifiedTranslationNotSupportedException() : base("Заданное направление перевода не поддерживается") { }
    }
}
