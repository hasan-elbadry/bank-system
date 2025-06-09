using bank_system.Dtos.CustomerDtos;
using bank_system.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bank_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpPost]
        public IActionResult AddCustomer(CreateCustomerWithBranchesWithAccountsWithBankCardDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _customerRepository.createCustomer(dto);
            return Ok();
        }


        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var customer = _customerRepository.getById(id);
            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
    }
}
