using Lab4Web.Services.Lambda;
using Microsoft.AspNetCore.Mvc;

namespace Lab4Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestLambdaController : ControllerBase
    {
        private readonly ILambdaService _lambdaService;

        public TestLambdaController(ILambdaService lambdaService)
        {
            _lambdaService = lambdaService;
        }

        [HttpGet("test-1")]
        public string Get(int value)
        {
            // Folosiți expresii Lambda pentru a obține cifrele individuale din număr
            var tupleValue = _lambdaService.Test1(value);
            return $"{tupleValue.Item1} / {tupleValue.Item2} / {tupleValue.Item3}";
        }

        [HttpGet("test-2")]
        public string Test2(string value)
        {
            // Folosiți o expresie Lambda pentru a verifica dacă șirul este un număr
            return _lambdaService.Test2(value) ? "Number" : "Not number";
        }

        [HttpGet("test-3")]
        public async Task<string> Test3(string value)
        {
            // Folosiți o expresie Lambda într-un context asincron
            var result = await _lambdaService.Test3Async(value);
            return result;
        }

        [HttpGet("test-unused-params")]
        public int TestUnusedParams()
        {
            // Folosiți o expresie Lambda cu parametri neutilizați
            var lambdaExp = () => 42; // Exemplu simplu
            return lambdaExp();
        }
    }
}
