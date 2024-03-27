using System;
using System.Threading.Tasks;

namespace Lab4Web.Services.Lambda
{
    public class LambdaService : ILambdaService
    {
        public Tuple<int, int, int> Test1(int value)
        {
            // Expresie Lambda pentru extragerea cifrelor individuale dintr-un număr
            var lambdaExp = (int num) => new Tuple<int, int, int>(num % 10, (num / 10) % 10, (num / 100) % 10);
            return lambdaExp(value);
        }

        public bool Test2(string value)
        {
            // Expresie Lambda pentru a verifica dacă șirul este un număr
            var lambdaExp = (string v) => int.TryParse(v, out _);
            return lambdaExp(value);
        }

        public async Task<string> Test3Async(string value)
        {
            // Expresie Lambda folosită într-un context asincron
            var lambdaExp = async (string v) =>
            {
                await Delay();
                return v.ToLower();
            };

            return await lambdaExp(value);
        }

        public Task Delay()
        {
            return Task.Delay(1000); // Delay simulat pentru scopul demonstrativ
        }

        public int TestWithUnusedParams()
        {
            // Expresie Lambda cu parametri neutilizați
            var lambdaExp = () => 42; // Exemplu simplu
            return lambdaExp();
        }
    }
}
