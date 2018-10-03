using System.IO;
using System.Xml;
using RStyleTranslater.BusinessLayer.Interfaces.ExportInFormat;
using RStyleTranslater.BusinessLayer.Interfaces.ExportInFormat.XMLFormater;
using RStyleTranslater.BusinessLayer.Models.ExportInFormat.XMLFormater;

namespace RStyleTranslater.BusinessLayer.Services.ExportInFormat.XMLFormater
{
    public class XmlFormater : IFormaterService<Translate, XmlDocument>
    {
        private readonly XmlDocument _document = new XmlDocument();
        private readonly IXmlFormaterHelper _xmlFormaterHelper;

        public XmlFormater(IXmlFormaterHelper xmlFormaterHelper)
        {
            _xmlFormaterHelper = xmlFormaterHelper;
            _xmlFormaterHelper.Document = _document;
        }

        public XmlDocument Format(Translate model)
        {
            var translate = _document.CreateElement("translate");

            var rawText = _xmlFormaterHelper.CreateCodeValueElement(model.SourceText, "rawText");
            var translateText = _xmlFormaterHelper.CreateCodeValueElement(model.DestinationText, "translateText");
            var time = _xmlFormaterHelper.CreateNowDateTimeElement();

            translate.AppendChild(rawText);
            translate.AppendChild(translateText);
            translate.AppendChild(time);
            _document.AppendChild(translate);

            return _document;
        }

        public Stream ToStream(XmlDocument xmlDocument)
        {
            MemoryStream xmlStream = new MemoryStream();
            xmlDocument.Save(xmlStream);

            xmlStream.Flush();
            xmlStream.Position = 0;

            return xmlStream;
        }
    }
}
