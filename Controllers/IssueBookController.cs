using LibraryManagement.Database.Service;
using LibraryManagement.Dtos.IssueBook;
using LibraryManagement.Exceptions;
using Microsoft.AspNetCore.Mvc;
using RedLockNet;

namespace LibraryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssueBookController : ControllerBase
    {
        private readonly IIssueBookService issuerBookService;
        private readonly IDistributedLockFactory distributedLockFactory;

        public IssueBookController(IIssueBookService issuerBookService, IDistributedLockFactory distributedLockFactory)
        {
            this.issuerBookService = issuerBookService;
            this.distributedLockFactory = distributedLockFactory;
        }


        [HttpPost("Issue")]
        [ProducesErrorResponseType(typeof(OutOfStockException))]
        public async Task<IActionResult> IssueBook([FromBody] CreateIssueBookDto createIssueBookDtos)
        {
            try
            {
                await using var _lock = await distributedLockFactory.CreateLockAsync(
                nameof(IssueBook), TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(0), TimeSpan.FromMilliseconds(10));

                if (_lock.IsAcquired)
                {
                    var bookIssue = await issuerBookService.IssueBookAsync(createIssueBookDtos);
                    return Ok(bookIssue);
                }

                throw new InvalidOperationException("Cannot aquire lock");
            }
            catch (OutOfStockException ex)
            {
                return Problem(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
