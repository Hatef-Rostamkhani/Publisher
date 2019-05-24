using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("Test")]
        public string Test()
        {
            return "salam";
        }
        [Route("Publish")]
        [HttpPost]
        public async Task<string> Publish(string project)
        {
            var pass = new SecureString();
            pass.AppendChar('d');
            pass.AppendChar('p');
            pass.AppendChar('D');
            pass.AppendChar('a');
            pass.AppendChar('t');
            pass.AppendChar('i');
            pass.AppendChar('s');
            pass.AppendChar('1');
            pass.AppendChar('3');
            pass.AppendChar('9');
            pass.AppendChar('7');
            var path = Path.Combine(_hostingEnvironment.WebRootPath, $"{project}.bat");
            var start = new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = false,
                RedirectStandardOutput = true,
//                UserName = "Administrator",
//                Password = pass,
//                Domain = "WIN-33OKMHMA2PG",
//                Verb = "runas"
            };
            // Specify exe name.
            string result;
            //
            // Start the process.
            //
            using (Process process = Process.Start(start))
            {
                //
                // Read in all the text from the process with the StreamReader.
                //
                using (StreamReader reader = process.StandardOutput)
                {
                    result = await reader.ReadToEndAsync();
                    Console.Write(result);
                }
            }

            return result;
        }
    }
}