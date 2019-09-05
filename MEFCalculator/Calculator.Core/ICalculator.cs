using System.Threading.Tasks;

namespace Calculator.Core
{
    public interface ICalculator
    {
        string Calculate(string input);

        Task<string> AvailableOperationsAsync();
    }
}