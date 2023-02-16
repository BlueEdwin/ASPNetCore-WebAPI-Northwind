using AutoMapper;
using Common.Northwind.Dtos;
using Common.Northwind.Entities;
using Repository.Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
