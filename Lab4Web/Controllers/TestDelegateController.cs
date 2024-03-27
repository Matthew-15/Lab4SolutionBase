using Lab4Web.Services.Delegate;
using Microsoft.AspNetCore.Mvc;

namespace Lab4Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestDelegateController : ControllerBase
    {
        private readonly IDelegateService _delegateService;

        public TestDelegateController(IDelegateService delegateService)
        {
            _delegateService = delegateService;
        }

        [HttpGet("test-1")]
        public string Test1(string name)
        {
            // Cerința a: Folosiți un Delegate pentru a insera apelarea unei metode într-o alta metodă
            var callback = new Func<string, string, string>(_delegateService.Hello);

            return _delegateService.Introduction(name, callback);
        }

        [HttpGet("test-2")]
        public string Test2(string name, bool welcome)
        {
            // Cerința b: Folosiți una sau mai multe metode Delegate și demonstrați execuția uneia dintre ele în funcție de o condiție impusă
            Func<string, string, string> callback1 = _delegateService.Hello;
            Func<string, string, string> callback2 = (firstname, lastname) => $"Bye, {firstname} {lastname}";

            // Cerința d: Inițializare a Delegate cu Named method și lambda expression
            Func<string, string, string> callback = welcome ? callback1 : callback2;

            return _delegateService.Introduction(name, callback);
        }

        [HttpGet("test-3")]
        public string Test3(string name)
        {
            // Cerința c: Folosiți Delegate pentru a apela mai multe metode consecutive la finalul unei metode create de voi
            Func<string, string, string> callback1 = _delegateService.Hello;
            Func<string, string, string> callback2 = (firstname, lastname) => $"Goodbye, {firstname} {lastname}";

            // Inițializare cu lambda expressions
            Func<string, string, string> combinedCallback = (firstname, lastname) =>
            {
                var result1 = callback1(firstname, lastname);
                var result2 = callback2(firstname, lastname);
                return $"{result1}. {result2}";
            };

            return _delegateService.Introduction(name, combinedCallback);
        }
    }
}
