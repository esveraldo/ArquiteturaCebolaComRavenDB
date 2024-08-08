using Ecommerce.Application.Dtos;
using Ecommerce.Application.Mappers.Interfaces;
using Ecommerce.Domain.Models;

namespace Ecommerce.Application.Mappers
{
    public class CustumerMapper : IMapper<Custumer, CustumerDto>, IMapper<CustumerDto, Custumer>
    {
        public CustumerDto Map(Custumer source)
        {
            return new CustumerDto
            {
                Name = source.Name,
                LastName = source.LastName,
                Email = source.Email,
                BirthDate = source.BirthDate,
                Address = new AddressDto
                {
                    Street = source.Address.Street,
                    Number = source.Address.Number,
                    Complement = source.Address.Complement,
                    City = source.Address.City,
                    State = source.Address.State,
                    PostalCode = source.Address.PostalCode,
                },
                Cpf = source.Cpf
            };
        }

        public Custumer Map(CustumerDto source)
        {
            return new Custumer
            {
                Name = source.Name,
                LastName = source.LastName,
                Email = source.Email,
                BirthDate = source.BirthDate,
                Address = new Address
                {
                    Street = source.Address.Street,
                    Number = source.Address.Number,
                    Complement = source.Address.Complement,
                    City = source.Address.City,
                    State = source.Address.State,
                    PostalCode = source.Address.PostalCode,
                },
                Cpf = source.Cpf
            };
        }

        public IEnumerable<CustumerDto> Map(IEnumerable<Custumer> source)
        {
            foreach (var item in source)
            {
                yield return Map(item);
            }
        }

        public IEnumerable<Custumer> Map(IEnumerable<CustumerDto> source)
        {
            foreach (var item in source)
            {
                yield return Map(item);
            }
        }
    }
}
