using AutoMapper;
using Common.Northwind.Dtos;
using Microsoft.AspNetCore.Mvc;
using Service.Northwind;

namespace WebApi.Controllers.Northwind
{
    public class NorthwindController : Controller
    {
        private INorthwindService _northwindService;
        private IMapper _mapper;

        public NorthwindController(INorthwindService northwindService, IMapper mapper) 
        {
            _northwindService = northwindService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("GetProducts")]
        public JsonResult GetProducts()
        {
            IEnumerable<ProductDto> productDtos = _northwindService.GetProducts();

            IEnumerable<ProductViewModel> productViewModels = _mapper.Map<IEnumerable<ProductViewModel>>(productDtos);

            return Json(productViewModels);
        }
    }
}
