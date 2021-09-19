using HotelManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HotelManagementSystem.Core.Repositories
{
    public interface IRoomRepository
    {
        void Add(Room entity);
        void AddRange(IEnumerable<Room> entities);
        bool Delete(string id);
        IEnumerable<Room> GetAll();
        Room GetById(string id);
        IEnumerable<Room> GetByQuery(Expression<Func<Room, bool>> expression);
        bool Update(Room entity);
    }
}
