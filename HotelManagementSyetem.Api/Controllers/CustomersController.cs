using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagementSystem.Core.Models;
using HotelManagementSystem.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSyetem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET: api/Customers
        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(_customerService.GetAll());
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_customerService.GetById(id));
        }

        // POST: api/Customers
        [HttpPost]
        public IActionResult Post([FromBody] CustomerModel model)
        {
            var customer = _customerService.AddCustomer(model);
            return Ok(customer);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
