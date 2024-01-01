namespace Section5
{
    internal class Program
    {
        static float sum = 0;
        static float count = 0;
        // Challenge - Average
        static void Main(string[] args)
        {
            enterValue();
        }

        private static void enterValue() {
            Console.WriteLine(@"Please enter the score. Enter '-1' to Finish");
            string value = Console.ReadLine();
            float valueFormatted = 0;
            if (value == null)
            {
                Console.WriteLine("You have to enter something!");
                enterValue();
            }
            else
            {
                try
                {
                    valueFormatted = float.Parse(value);
                    if (valueFormatted == -1)
                    {
                        if (count == 0)
                            Console.WriteLine("Average score is 0.");
                        else
                        {
                            Console.WriteLine($"Average score is {sum / count}");
                        }
                    }
                    else
                    {
                        count++;
                        sum += valueFormatted;
                        enterValue();
                    }
                }
                catch
                {
                    Console.WriteLine("Entered Value in wrong format");
                    enterValue();
                }
            }
        }
    }
}
