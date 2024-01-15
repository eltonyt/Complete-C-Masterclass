namespace Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float a = 3.14f;
            float b = 2.33f;
            Console.WriteLine(ApplyOperation(a, b, Add));
        }

        public delegate float OperationDelegate(float a, float b);

        public static float ApplyOperation(float a, float b, OperationDelegate calculation)
        {
            return calculation(a, b);
        }

        public static float Add(float a, float b)
        {
            return a + b;
        }

        public static float Subtract(float a, float b)
        {
            return a - b;
        }

        public static float Multiply(float a, float b)
        {
            return a * b;
        }

        public static float Divide(float a, float b)
        {
            return a / b;
        }
    }
}
