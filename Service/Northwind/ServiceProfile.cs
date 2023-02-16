using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Northwind
{
    public class ServiceProfile : Profile
    {
        //低耦合，藉由繼承 Profile，Automapper 自動取得所有定義 Profile，並將IMapper注入到需要的區塊中，降低程式碼對 Autmapper 的耦合度
        /// <summary>
        /// Initialize a new instance of the <see cref="ServiceProfile"/>
        /// </summary>
        public ServiceProfile() 
        {
            //建立 Profile 對照定義
            CreateMap<Common.Northwind.Entities.Product, Common.Northwind.Dtos.ProductDto>();
        }
    }
}
