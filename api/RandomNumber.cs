using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Company.Function
{
    public static class RandomNumber
    {
        [FunctionName("RandomNumber")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var random = new Random();
            int randomInt = random.Next(0, 100);

            if (randomInt % 2 == 1)
            {
                return new BadRequestObjectResult("Odd numbers are not allowed.");
            }

            return new OkObjectResult(randomInt);
        }
    }
}
