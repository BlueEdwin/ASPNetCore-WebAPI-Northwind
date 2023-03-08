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
        /// <summary>
        /// 取得所有產品
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetProducts")]
        public JsonResult GetProducts()
        {
            IEnumerable<ProductDto> productDtos = _northwindService.GetProducts();

            IEnumerable<ProductViewModel> productViewModels = _mapper.Map<IEnumerable<ProductViewModel>>(productDtos);

            return Json(productViewModels);
        }
        /// <summary>
        /// 依年度統計當年度業務銷售成績
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetEmployeeSales")]
        public JsonResult GetEmployeeSales([FromBody] QueryEmployeeParameter queryEmpParam)
        {
            QueryEmployeeSalesDto queryParma = _mapper.Map<QueryEmployeeSalesDto>(queryEmpParam);

            IEnumerable<EmployeeSalesDto> employeeSalesDtos = _northwindService.GetEmployeeSales(queryParma);

            IEnumerable<EmployeeSalesViewModel> employeeSalesVM = _mapper.Map<IEnumerable<EmployeeSalesViewModel>>(employeeSalesDtos);

            return Json(employeeSalesVM);
        }
        /// <summary>
        /// 取得訂單包含訂購的顧客所在地，可觀察各地區產品銷售狀況
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetOrderWithCustomerInfo")]
        public JsonResult GetOrderWithCustomerInfo()
        {
            IEnumerable<OrderWithCustomerInfoDto> orderWithCustomerInfoDtos = _northwindService.GetOrdersWithCustomerInfo();

            IEnumerable<OrderWithCustomerInfoViewModel> orderWCusInfoVM = _mapper.Map<IEnumerable<OrderWithCustomerInfoViewModel>>(orderWithCustomerInfoDtos);

            return Json(orderWCusInfoVM);
        }
    }
}
