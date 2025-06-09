using bank_system.Dtos.BranchDtos;
using bank_system.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bank_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchRepository _BranchRepository;

        public BranchController(IBranchRepository BranchRepository)
        {
            _BranchRepository = BranchRepository;
        }

        [HttpPost]
        public IActionResult AddBranch(CreateBranchWithCustomerDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _BranchRepository.CreateBranch(dto);
            return Ok();
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var Branch = _BranchRepository.getAll();
            if (Branch is null)
            {
                return NotFound();
            }
            return Ok(Branch);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBranch(int id, UpdateBranchWithCustomerIdDto dto)
        {
            var result = _BranchRepository.UpdateBranch(id,dto);
            if (!result.Item1)
                return NotFound(result.Item2);
            return Ok(result.Item2);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBranch(int id)
        {
            var result = _BranchRepository.deleteBranch(id);
            if (!result)
                return NotFound();
            return Ok();
        }

    }
}
