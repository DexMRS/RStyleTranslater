using System.Threading.Tasks;

namespace RStyleTranslater.Common.Interfaces
{
    public interface ITranslater<in TRequest, TResponse>
    {
        Task<TResponse> Translate(TRequest translateRequest);
    }
}
