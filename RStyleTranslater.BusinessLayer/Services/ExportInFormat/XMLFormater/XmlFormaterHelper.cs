using System;
using System.Xml;
using RStyleTranslater.BusinessLayer.Interfaces.ExportInFormat.XMLFormater;
using RStyleTranslater.BusinessLayer.Models.ExportInFormat;

namespace RStyleTranslater.BusinessLayer.Services.ExportInFormat.XMLFormater
{
    public class XmlFormaterHelper : IXmlFormaterHelper
    {
        public XmlDocument Document { get; set; }
        public XmlElement CreateCodeValueElement(Text text, string type)
        {
            var rawTextElement = Document.CreateElement(type);
            var code = CreateAttribute("code", text.Language.Code);
            var value = CreateAttribute("value", text.Content);

            rawTextElement.Attributes.Append(code);
            rawTextElement.Attributes.Append(value);

            return rawTextElement;
        }

        public XmlElement CreateNowDateTimeElement()
        {
            var time = Document.CreateElement("time");
            var timeAttr = CreateAttribute("value", DateTime.Now.ToString("dd.MM.yyyy Thh:mm"));
            time.Attributes.Append(timeAttr);

            return time;
        }

        private XmlAttribute CreateAttribute(string attributeName, string attributeValue)
        {

            var attribute = Document.CreateAttribute(attributeName);
            var value = Document.CreateTextNode(attributeValue);
            attribute.AppendChild(value);

            return attribute;
        }
    }
}
