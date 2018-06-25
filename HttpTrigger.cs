namespace Factorial
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs.Host;

    public class HttpTrigger
    {
        public static IActionResult Run(HttpRequest req, TraceWriter log)
        {
            log.Info("Calculating factorial from number...");
            var number = new long();
            string numberInput = req.Query["number"];
            var isNumber = long.TryParse(numberInput, out number);

            return isNumber
                ? (ActionResult)new OkObjectResult(Factorial(number))
                : new BadRequestObjectResult("That is not a number!");
        }

        public static long Factorial(long number)
        {
            var factorial = 1;
            for (var i = 1; i <= number; i++)
                factorial = i * factorial;

            return factorial;
        }
    }
}