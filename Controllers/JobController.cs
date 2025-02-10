using Hangfire;
using LibraryManagement.Job;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public JobController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("ImportFromSource")]
        public void ImportBookFromSource()
        {
            var dirName = configuration.GetSection("BookResource:DirName").Value;
            var path = Directory.GetCurrentDirectory() + "/Resources/" + dirName;

            if(path != null)
            {
                BackgroundJob.Enqueue<JobService>(a => a.ImportBooksAsync(path));
            }
        }

        [HttpPost]
        [Route("ImportFiles")]
        public void ImportBooks(IEnumerable<FormFile> files)
        {
            var bookSource = configuration.GetSection("BookResource:Path").Value;
            if (bookSource != null)
            {
                BackgroundJob.Enqueue<JobService>(a => a.ImportBooksAsync(bookSource));
            }
        }
    }
}
