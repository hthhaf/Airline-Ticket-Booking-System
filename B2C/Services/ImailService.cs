using B2C.Data;
using B2C.Model;

namespace B2C.Services
{
    public interface IMailService
    {
        Task<bool> SendHTMLMail(HTMLMailData htmlMailData, string html);
    }
}