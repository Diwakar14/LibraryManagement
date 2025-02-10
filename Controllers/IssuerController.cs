using LibraryManagement.Database.Service;
using LibraryManagement.Dtos.Issuer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssuerController : ControllerBase
    {
        private readonly IIssuerService issuerService;

        public IssuerController(IIssuerService issuerService)
        {
            this.issuerService = issuerService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var issuers = await issuerService.GetAllAsync();
            return Ok(issuers);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync([Required] int id)
        {
            var issuers = await issuerService.GetByIdAsync(id);
            return Ok(issuers);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> CreateAsync(CreateIssuerDto createIssuerDto)
        {
            try
            {
                if (!ModelState.IsValid) { return BadRequest(ModelState); }
                var result = await issuerService.CreateAsync(createIssuerDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
