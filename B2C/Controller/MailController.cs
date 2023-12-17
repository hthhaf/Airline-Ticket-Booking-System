using B2C.Data;
using B2C.Model;
using B2C.Services;
using Microsoft.AspNetCore.Mvc;


namespace B2C.Controller
{
    public class MailController
    {

        private readonly IMailService _mailService;
        //injecting the IMailService into the constructor
        public MailController(IMailService _MailService)
        {
            _mailService = _MailService;
        }

        [HttpPost]
        [Route("SendMail")]
        public Task<bool> SendHTMLMail(HTMLMailData htmlMailData, string html)
        {
            return _mailService.SendHTMLMail(htmlMailData, html);
        }


    }
}
