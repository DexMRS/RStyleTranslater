using Nancy.TinyIoc;
using RStyleTranslater.DataAccessLayer.Handlers;
using RStyleTranslater.DataAccessLayer.Interfaces;

namespace RStyleTranslater.BusinessLayer.Infostruct
{
    public static class ServicesDependencies
    {
        public static TinyIoCContainer RegisterServicesDependencies(TinyIoCContainer container)
        {
            container.Register<ILanguageHandler, LanguageHandler>();

            return container;
        }

    }
}
