using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Northwind
{
    public class NorthwindUnitOfWork : UnitOfWork, INorthwindUnitOfWork
    {
        public NorthwindUnitOfWork(INorthwindContext context) : base()
        {
            this.Context = (DbContext)context;
        }
    }
}
