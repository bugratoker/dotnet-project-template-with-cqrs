namespace SoftwareLab.Core.Services
{
    public interface IEmailService
    {
        Task SendMail(string email,string message);
    }
}
