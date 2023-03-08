using Common.Northwind.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Northwind
{
    public interface INorthwindService
    {
        /// <summary>
        /// 取得所有產品
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductDto> GetProducts();
        /// <summary>
        /// 取得員工銷售業績
        /// </summary>
        /// <param name="queryParam"></param>
        /// <returns></returns>
        IEnumerable<EmployeeSalesDto> GetEmployeeSales(QueryEmployeeSalesDto queryParam);
        /// <summary>
        /// 取得訂單包含訂購的顧客資訊
        /// </summary>
        /// <returns></returns>
        IEnumerable<OrderWithCustomerInfoDto> GetOrdersWithCustomerInfo();
    }
}
