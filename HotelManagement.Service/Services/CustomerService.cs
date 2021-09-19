using HotelManagementSystem.Core.Entities;
using HotelManagementSystem.Core.Models;
using HotelManagementSystem.Core.Repositories;
using HotelManagementSystem.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagement.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public bool AddCustomer(CustomerModel model)
        {
            try
            {
                var customer = new Customer()
                {
                    Address = model.Address,
                    Email = model.Email,
                    Mobile = model.Mobile,
                    Name = model.Name
                };
                _customerRepository.Add(customer);
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IEnumerable<CustomerModel> GetAll()
        {
            var customers = _customerRepository.GetAll();
            return customers.Select(customer => new CustomerModel
            {
                Id = customer.Id,
                Address = customer.Address,
                Email = customer.Email,
                Mobile = customer.Mobile,
                Name = customer.Name
            });
        }

        public CustomerModel GetById(string id)
        {
            var customer = _customerRepository.GetById(id);
            return new CustomerModel
            {
                Id = customer.Id,
                Address = customer.Address,
                Email = customer.Email,
                Mobile = customer.Mobile,
                Name = customer.Name
            };
        }
    }
}
