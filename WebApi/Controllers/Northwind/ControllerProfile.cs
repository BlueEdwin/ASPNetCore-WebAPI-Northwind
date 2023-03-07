using AutoMapper;

namespace WebApi.Controllers.Northwind
{
    public class ControllerProfile : Profile
    {
        //低耦合，藉由繼承 Profile，Automapper 自動取得所有定義 Profile，並將IMapper注入到需要的區塊中，降低程式碼對 Autmapper 的耦合度
        /// <summary>
        /// Initialize a new instance of the <see cref="ServiceProfile"/>
        /// </summary>
        public ControllerProfile()
        {
            //建立 Profile 對照定義
            CreateMap<Common.Northwind.Dtos.ProductDto, WebApi.Controllers.Northwind.ProductViewModel>();
            CreateMap<WebApi.Controllers.Northwind.QueryEmployeeParameter, Common.Northwind.Dtos.QueryEmployeeSalesDto>();
            CreateMap<Common.Northwind.Dtos.EmployeeSalesDto, WebApi.Controllers.Northwind.EmployeeSalesViewModel>();
        }
    }
}
