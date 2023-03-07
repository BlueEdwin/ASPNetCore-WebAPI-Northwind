using AutoMapper;
using Common.Northwind.Dtos;
using Common.Northwind.Entities;
using Repository.Northwind;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Service.Northwind
{
    public class NorthwindService : INorthwindService
    {
        private INorthwindUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public NorthwindService(INorthwindUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            IEnumerable<Product> products = _unitOfWork.Repository<Product>().GetAllAsync().Result;

            IEnumerable<ProductDto> productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

            return productDtos;
        }
        public IEnumerable<EmployeeSalesDto> GetEmployeeSales(QueryEmployeeSalesDto queryParam)
        {
            try
            {
                DateTime orderYear = DateTime.ParseExact(queryParam.Year.ToString(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

                DateTime orderYearEnd = orderYear.AddYears(1);

                IEnumerable<Order> orders = _unitOfWork.Repository<Order>().GetAllAsync().Result.Where(x => x.OrderDate >= orderYear && x.OrderDate <= orderYearEnd);

                IEnumerable<Order_Detail> orderDetails = _unitOfWork.Repository<Order_Detail>().GetAllAsync().Result;

                IEnumerable<Employee> employees = _unitOfWork.Repository<Employee>().GetAllAsync().Result;

                IEnumerable<EmployeeSalesDto> empSales = from o in orders
                                                         join or in orderDetails on o.OrderID equals or.OrderID
                                                         join e in employees on o.EmployeeID equals e.EmployeeID
                                                         select new EmployeeSalesDto
                                                         {
                                                             EmployeeID = e.EmployeeID,
                                                             FirstName = e.FirstName,
                                                             LastName = e.LastName,
                                                             City = e.City,
                                                             OrderNumber = (from o in orders
                                                                            where o.EmployeeID == e.EmployeeID
                                                                            select o).Count()
                                                         };

                return empSales;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
