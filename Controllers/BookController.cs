using LibraryManagement.Database.Service;
using LibraryManagement.Dtos;
using LibraryManagement.Dtos.Book;
using LibraryManagement.Redis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IRedisService redisService;

        public BookController(IBookService bookService, IRedisService redisService)
        {
            this.bookService = bookService;
            this.redisService = redisService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllBooksAsync([FromQuery] BookQueryParams queryParams)
        {
            try
            {
                var key = $"BookController:GetAllBooksAsync";
                var cachedData = await redisService.GetKeyAsync<PagedResponseDto<BookDto>>(key);
                PagedResponseDto<BookDto> books = cachedData;

                //if (cachedData == null)
                //{
                    books = await bookService.GetBooksAsync(queryParams);
                    await redisService.SetKeyAsync(key, books, TimeSpan.FromMinutes(10));
                //}
                
                return Ok(books);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetBookByIdAsync(int id)
        {
            try
            {
                var key = $"BookController:GetBookByIdAsync";
                var cachedData = await redisService.GetKeyAsync<BookDto>(key);
                BookDto book = cachedData;
                if (cachedData == null)
                {
                    book = await bookService.GetBookByIdAsync(id);
                    await redisService.SetKeyAsync(key,book, TimeSpan.FromMinutes(10));
                }

                return Ok(book);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddBookAsync([FromBody] CreateBookDto createBookDto)
        {
            try
            {
                if(!ModelState.IsValid) { return BadRequest(ModelState); }
                var books = await bookService.AddBookAsync(createBookDto);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
