using Ecommerce.Domain.Core.Interfaces.Sevices;
using Ecommerce.Domain.Models;
using System.Net.Mail;

namespace Ecommerce.Domain.Services
{
    public class CustumerService : ICustumerService
    {
        private readonly ICustumerService _custumerService;

        public CustumerService(ICustumerService custumerService)
        {
            _custumerService = custumerService;
        }

        public void SaveCustumer(Custumer custumer)
        {
            throw new NotImplementedException();
        }

        private void ValidateEmail(string email)
        {

        }

        private bool IsEmailValid(string email)
        {
            if(string.IsNullOrEmpty(email))
                return false;

            try
            {
                var emailAddress = new MailAddress(email);

                if (emailAddress.Address != null)
                    return false;

                return CheckDomain(email);
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }

        private bool CheckDomain(string email)
        {
            var domain = email.Split('@')[1];
            var domainParts = domain.Split('.');
            if(domainParts.Length < 2)
                return false;

            return true;
        }
    }
}
