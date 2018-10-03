using System.Xml;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses;
using RStyleTranslater.BusinessLayer.Interfaces.ExportInFormat;
using RStyleTranslater.BusinessLayer.Models.ExportInFormat.XMLFormater;

namespace RStyleTranslater.WebApplication.ConsoleApp.Modules
{
    public class FormaterModule : NancyModule
    {
        private readonly IFormaterService<Translate, XmlDocument> _formaterService;
        public FormaterModule(IFormaterService<Translate, XmlDocument> formaterService) : base("/formatTo")
        {
            _formaterService = formaterService;

            Post["/xml"] = parametrs =>
            {
                var data = this.Bind<Translate>();
                var doc = _formaterService.Format(data);
                var stream = _formaterService.ToStream(doc);
                var response = new StreamResponse(() => stream, "xml");

                return response;
            };
        }
    }
}
