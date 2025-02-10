using CsvHelper;
using System.Globalization;
using System;
using LibraryManagement.Models;
using LibraryManagement.Job.Map;
using CsvHelper.Configuration;
using LibraryManagement.Database.Service;
using LibraryManagement.Extensions;

namespace LibraryManagement.Job
{
    public class JobService
    {
        private readonly IBookService bookService;

        public JobService(IBookService bookService)
        {
            this.bookService = bookService;
        }

        /// <summary>
        /// Import from Resource Folder
        /// Supported File CSV
        /// </summary>
        public async Task ImportBooksAsync(string fileDirectoryPath)
        {
            var files = Directory.GetFiles(fileDirectoryPath);
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                BadDataFound =null,
                ReadingExceptionOccurred = re =>
                {
                    return false;
                }
            };

            foreach (var file in files)
            {

                if (bookService.IsBookFileProcessed(file))
                {
                    continue;
                }

                using (var reader = new StreamReader(file))
                using (var csv = new CsvReader(reader, configuration))
                {
                    
                    csv.Context.RegisterClassMap<BookMap>();

                    try
                    {
                        var records = csv.GetRecords<Book>();
                        var batches = records.Batch(50);

                        int batchId = 1;
                        foreach (var batch in batches)
                        {
                            Console.WriteLine($"Processing batch : {batchId}" );
                            await bookService.AddBooksAsync(batch);
                            batchId++;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                await bookService.AddBookFileAsync(file);
                Console.WriteLine("Importing some of the books.");
            }
        }


        /// <summary>
        /// Import from file uploaded
        /// </summary>
        /// <param name="files"></param>
        public void ImportBooks(IEnumerable<FormFile> files)
        {

        }
    }
}
