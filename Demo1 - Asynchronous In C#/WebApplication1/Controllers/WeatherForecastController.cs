using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly TestContext _context;

        public WeatherForecastController(TestContext context)
        {
            _context = context;
        }

        [HttpGet("1")]
        public IActionResult Get1()
        {
            int availableThreads, maxThreads, minThreads;
            ThreadPool.GetAvailableThreads(out availableThreads, out maxThreads);
            ThreadPool.GetMaxThreads(out maxThreads, out minThreads);

            ThreadPool.SetMinThreads(0, 0);
            ThreadPool.SetMaxThreads(1, 1);


            return Ok(new List<string>
            {
                $"Available Threads: {availableThreads}",
                $"Max Threads: {maxThreads}",
                $"Min Threads: {minThreads}"
            });
        }

        [HttpGet("2")]
        public IActionResult Get2()
        {
            ShowThreadInformation("SSOI");
            var students = new List<Student>();
            for (var i = 0; i < 1_000_000_000; i++)
            {
                students.Add(new Student
                {
                    Id = Guid.NewGuid(),
                    Name = i.ToString(),
                });
            }

            var stus= _context.Students.ToListAsync();

            //
            _context.SaveChanges();
            return Ok();
        }

        private static void ShowThreadInformation(string name)
        {
            var thread = Thread.CurrentThread;
            var msg = $"{name} thread information\n" +
                      $"   Background: {thread.IsBackground}\n" +
                      $"   Thread Pool: {thread.IsThreadPoolThread}\n" +
                      $"   Thread ID: {thread.ManagedThreadId}\n";
            Trace.WriteLine(msg);
        }
    }
}