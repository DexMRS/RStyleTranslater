using System;

namespace RStyleTranslater.YandexTranslaterApi.Exceptions
{
    public class ExceededMaximumTextSizeException : Exception
    {
        public ExceededMaximumTextSizeException() : base("Превышен максимально допустимый размер текста") { }
    }
}
