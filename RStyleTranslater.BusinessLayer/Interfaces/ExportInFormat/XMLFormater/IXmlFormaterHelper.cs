using System.Xml;
using RStyleTranslater.BusinessLayer.Models.ExportInFormat;

namespace RStyleTranslater.BusinessLayer.Interfaces.ExportInFormat.XMLFormater
{
    public interface IXmlFormaterHelper
    {
        XmlDocument Document { get; set; }
        XmlElement CreateCodeValueElement(Text text, string type);
        XmlElement CreateNowDateTimeElement();
    }
}
