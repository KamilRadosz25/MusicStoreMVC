using Microsoft.AspNetCore.Mvc;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        public string Index()
        {
            return "Hello from Store.Index()";
        }
        public string Browse()
        {
            return "Hello From Store.Browse()";
        }
        public string Details()
        {
            return "Hello from Store.Details()";
        }

    }
}
