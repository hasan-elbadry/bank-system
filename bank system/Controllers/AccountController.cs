using bank_system.Dtos.AccountDtos;
using bank_system.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bank_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _AccountRepository;

        public AccountController(IAccountRepository AccountRepository)
        {
            _AccountRepository = AccountRepository;
        }

        [HttpPost]
        public IActionResult AddAccount(CreateAccountWithExsitCustomerId dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _AccountRepository.CreateAccount(dto);
            return Ok();
        }
    }
}
