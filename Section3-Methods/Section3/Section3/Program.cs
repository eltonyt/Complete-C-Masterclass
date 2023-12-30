namespace Section3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string friend1 = "Elton";
            string friend2 = "Jake";
            string friend3 = "Lily";
            GreetFriend(friend1);
            GreetFriend(friend2);
            GreetFriend(friend3);
        }

        // CHALLENGE 
        public static void GreetFriend(string friendName)
        {
            Console.WriteLine($"Hi {friendName}, my friend!");
        }
    }
}
