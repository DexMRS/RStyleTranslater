namespace RStyleTranslater.YandexTranslaterApi.Models
{
    public class TranslateResponse
    {
        public int Code { get; set; }
        public string Lang { get; set; }
        public string[] Text { get; set; }
    }
}