using Dependecy_injection.Repositories.Interfaces;

namespace Dependecy_injection.Repositories.Implementations
{
    public class CalculatorRepository: ICalculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}
