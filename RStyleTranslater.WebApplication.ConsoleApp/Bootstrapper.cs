using System.Xml;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;
using RStyleTranslater.BusinessLayer.Infostruct;
using RStyleTranslater.BusinessLayer.Interfaces.ExportInFormat;
using RStyleTranslater.BusinessLayer.Interfaces.ExportInFormat.XMLFormater;
using RStyleTranslater.BusinessLayer.Interfaces.LanguageSettings;
using RStyleTranslater.BusinessLayer.Models.ExportInFormat.XMLFormater;
using RStyleTranslater.BusinessLayer.Services.ExportInFormat.XMLFormater;
using RStyleTranslater.BusinessLayer.Services.LanguageSettings;
using RStyleTranslater.Common.Interfaces;
using RStyleTranslater.YandexTranslaterApi;
using RStyleTranslater.YandexTranslaterApi.Models;

namespace RStyleTranslater.WebApplication.ConsoleApp
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("static", @"static"));
            base.ConfigureConventions(nancyConventions);
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            //CORS Enable
            pipelines.AfterRequest.AddItemToEndOfPipeline((ctx) =>
            {
                ctx.Response.WithHeader("Access-Control-Allow-Origin", "*")
                    .WithHeader("Access-Control-Allow-Methods", "POST,GET")
                    .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type");

            });
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            container = ServicesDependencies.RegisterServicesDependencies(container);
            container.Register<ILanguageSettingsService, LanguageSettingsService>();
            container.Register<IXmlFormaterHelper, XmlFormaterHelper>();
            container.Register<IFormaterService<Translate, XmlDocument>, XmlFormater>();
            container.Register<ITranslater<TranslateRequest, TranslateResponse>, YandexTranslaterClient>();
        }
    }

}