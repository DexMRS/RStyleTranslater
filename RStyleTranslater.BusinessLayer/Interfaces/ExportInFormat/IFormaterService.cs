using System.IO;

namespace RStyleTranslater.BusinessLayer.Interfaces.ExportInFormat
{
    public interface IFormaterService<in TInputModel, TOutputFormat>
    {
        TOutputFormat Format(TInputModel model);
        Stream ToStream(TOutputFormat document);
    }
}
