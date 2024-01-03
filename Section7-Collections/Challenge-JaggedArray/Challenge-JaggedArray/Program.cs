namespace Challenge_JaggedArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[][] friendArray = new string[][]
            {
                new string[] {"Elton", "Jake"},
                new string[] {"Lily", "Aria"},
                new string[] {"Wilson", "Amber"}
            };

            Console.WriteLine("Hello {0}, I'd love to introduce {1} to you.", friendArray[0][0], friendArray[1][0]);
            Console.WriteLine("Hello {0}, I'd love to introduce {1} to you.", friendArray[1][0], friendArray[2][0]);
            Console.WriteLine("Hello {0}, I'd love to introduce {1} to you.", friendArray[2][0], friendArray[0][0]);
        }
    }
}
