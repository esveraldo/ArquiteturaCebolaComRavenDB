namespace Ecommerce.Domain.Services
{
    public class CustumerService : ICustumerService
    {
        private readonly ICustumerRepository _custumerRepository;

        public CustumerService(ICustumerRepository custumerRepository)
        {
            _custumerRepository = custumerRepository;
        }

        public void SaveCustumer(Custumer custumer)
        {
            ValidateEmail(custumer.Email);
            custumer.IsActive = true;
            custumer.CreatedDate = DateTime.Now;
            custumer.Address.IsActive = true;
            custumer.Address.CreatedDate = DateTime.Now;
            _custumerRepository.Insert(custumer);

        }

        private void ValidateEmail(string email)
        {
            if (!IsEmailValid(email))
                throw new DuplicateEmailException(email);

            var existingEmailCustumer = _custumerRepository.GetByEmail(email);
            if(existingEmailCustumer is not null)
                throw new DuplicateEmailException(email);
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

                return CheckDomainHasMXRecord(emailAddress.Host);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private bool CheckDomainHasMXRecord(string domain)
        {
            try
            {
                var lookup = new LookupClient();
                var result = lookup.Query(domain, QueryType.MX);
                return result.Answers.MxRecords().Any();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }
    }
}
