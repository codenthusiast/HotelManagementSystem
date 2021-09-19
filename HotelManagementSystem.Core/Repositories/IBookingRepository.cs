using HotelManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HotelManagementSystem.Core.Repositories
{
    public interface IBookingRepository
    {
        void Add(Booking entity);
        void AddRange(IEnumerable<Booking> entities);
        bool Delete(string id);
        IEnumerable<Booking> GetAll();
        Booking GetById(string id);
        IEnumerable<Booking> GetByQuery(Expression<Func<Booking, bool>> expression);
        bool Update(Booking entity);
    }
}
