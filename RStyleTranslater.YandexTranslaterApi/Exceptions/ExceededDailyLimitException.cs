using System;

namespace RStyleTranslater.YandexTranslaterApi.Exceptions
{
    public class ExceededDailyLimitException : Exception
    {
        public ExceededDailyLimitException() : base("Превышено суточное ограничение на объем переведенного текста") { }
    }
}
