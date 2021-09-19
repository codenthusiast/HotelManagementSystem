using HotelManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HotelManagementSystem.Core.Repositories
{
    public interface ICustomerRepository
    {
            void Add(Customer entity);
            void AddRange(IEnumerable<Customer> entities);
            bool Delete(string id);
            IEnumerable<Customer> GetAll();
            Customer GetById(string id);
            IEnumerable<Customer> GetByQuery(Expression<Func<Customer, bool>> expression);
            bool Update(Customer entity);
    }
}
