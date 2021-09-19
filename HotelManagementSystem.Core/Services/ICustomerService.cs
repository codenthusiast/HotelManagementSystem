using HotelManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Core.Services
{
    public interface ICustomerService
    {
        bool AddCustomer(CustomerModel customer);
        CustomerModel GetById(string id);
        IEnumerable<CustomerModel> GetAll();

    }
}
