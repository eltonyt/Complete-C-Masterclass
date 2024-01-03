namespace Section7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] array2D = new int[,]
            {
                {1, 2},
                {4, 5}
            };
            Console.WriteLine(array2D.Rank);

            Console.WriteLine(array2D.Length);
            Console.WriteLine(array2D.GetLength(0));
            Console.WriteLine(array2D.GetLength(1));
        }


    }
}
