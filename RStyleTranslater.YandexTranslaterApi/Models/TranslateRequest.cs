namespace RStyleTranslater.YandexTranslaterApi.Models
{
    public class TranslateRequest
    {
        public string Lang { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return $"lang={Lang}&text={Text}";
        }
    }
}