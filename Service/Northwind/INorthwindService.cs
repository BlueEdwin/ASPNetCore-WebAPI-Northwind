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
    }
}
