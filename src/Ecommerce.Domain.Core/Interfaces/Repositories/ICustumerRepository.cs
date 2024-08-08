namespace Ecommerce.Domain.Core.Interfaces.Repositories
{
    public interface ICustumerRepository
    {
        void Insert(Custumer custumer);
        void Update(Custumer custumer);
        void Delete(string id);
        IEnumerable<Custumer> Get();
        Custumer Get(string id);
        Custumer? GetByEmail(string email);
    }
}
