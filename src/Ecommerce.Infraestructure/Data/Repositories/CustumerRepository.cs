using Ecommerce.Domain.Models;

namespace Ecommerce.Infraestructure.Data.Repositories
{
    public class CustumerRepository : ICustumerRepository
    {
        private readonly IDocumentStore _documentStore;

        public CustumerRepository(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        public void Delete(string id)
        {
            using IDocumentSession documentSession = _documentStore.OpenSession();
            var custumer = documentSession.Load<Custumer>(id);

            if(custumer is not null)
            {
                documentSession.Delete(custumer);
                documentSession.SaveChanges();
            }
        }

        public IEnumerable<Custumer> Get()
        {
            using IDocumentSession documentSession = _documentStore.OpenSession();
            return documentSession.Query<Custumer>().ToList();
        }

        public Custumer Get(string id)
        {
            using IDocumentSession documentSession = _documentStore.OpenSession();
            var custumer = documentSession.Load<Custumer>(id); 
            return custumer;
        }

        public Custumer? GetByEmail(string email)
        {
            using IDocumentSession documentSession = _documentStore.OpenSession();
            var custumerEntity = documentSession.Query<Custumer>().FirstOrDefault(c => c.Email == email);

            return custumerEntity;
        }

        public void Insert(Custumer custumer)
        {
            using IDocumentSession documentSession = _documentStore.OpenSession();
            documentSession.Store(custumer);
            documentSession.SaveChanges();
        }

        public void Update(Custumer custumer)
        {
            using IDocumentSession documentSession = _documentStore.OpenSession();
            var custumerEntity = documentSession.Query<Custumer>().FirstOrDefault(c => c.Name == custumer.Name);

            if(custumerEntity is not null)
            {
                custumerEntity.Name = custumer.Name;
                custumerEntity.LastName = custumer.LastName;
                custumerEntity.Email = custumer.Email;
                custumerEntity.BirthDate = custumer.BirthDate;
                custumerEntity.Address = custumer.Address;
                custumerEntity.Cpf = custumer.Cpf;
                custumerEntity.IsActive = custumer.IsActive;
            }
            
            documentSession.SaveChanges();
        }
    }
}
