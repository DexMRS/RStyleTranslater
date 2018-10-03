using System;

namespace RStyleTranslater.YandexTranslaterApi.Exceptions
{
    public class TextCannotBeTranslatedException : Exception
    {
        public TextCannotBeTranslatedException() : base("Текст не может быть переведен") { }
    }
}
