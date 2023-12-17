using B2C.Data;
using B2C.Model;
using B2C.Services;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Pkcs;

namespace B2C.Controller
{
    public class ViewRenderController
    {
        private readonly IViewRenderService _IViewRenderService;
        //injecting the IMailService into the constructor
        public ViewRenderController(IViewRenderService IViewRenderService)
        {
            _IViewRenderService = IViewRenderService;
        }

        

        
    }
}
