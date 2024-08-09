namespace Ecommerce.Application.Services
{
    public class CustumerAppSerivce : ICustumerAppService
    {
        private readonly ICustumerService _custemerService;
        private readonly IMapper<CustumerDto, Custumer> _mapper;

        public CustumerAppSerivce(ICustumerService custemerService, IMapper<CustumerDto, Custumer> mapper)
        {
            _custemerService = custemerService;
            _mapper = mapper;
        }

        public void SaveCustumer(CustumerDto custumerDto)
        {
            var custumer = _mapper.Map(custumerDto);
            _custemerService.SaveCustumer(custumer);
        }
    }
}
