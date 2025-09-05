namespace FinOps.Modules.Inventory.Tests
{
    internal class Calculator
    {
        public int Add(int a, int b) => a + b;

        public int Subtract(int a, int b) => a - b;

        public int Multiply(int a, int b) => a * b;

        public double Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero");

            return (double)a / b;
        }

        public bool IsEven(int number) => number % 2 == 0;
    }
}
