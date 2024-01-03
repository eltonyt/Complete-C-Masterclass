namespace Challenge_SunIsShining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] happiness = {1, 2, 3, 4, 5};
            SunIsShining(happiness);
        }

        static void SunIsShining(int[] arr)
        {
            for(int i = 0; i < arr.GetLength(0); i ++)
            {
                arr[i] *= 2;
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine("The updated value at index {0} is {1}.", i, arr[i]);
            }
        }
    }
}
