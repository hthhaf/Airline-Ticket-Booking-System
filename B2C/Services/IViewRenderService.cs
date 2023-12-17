using B2C.Data;
using B2C.Model;

using System.Threading.Tasks;

namespace B2C.Services
{
    public interface IViewRenderService
    {
		Task<string> RenderToStringAsync<TModel>(string viewName, TModel model);

	}

}
