namespace Section4
{
    internal class Program
    {
        static string userName;
        static string password;
        static void Main(string[] args)
        {
            // Choice();


            //while (true)
            //{
            //    Console.WriteLine("Please enter the score.");
            //    double score = double.Parse(Console.ReadLine());
            //    Console.WriteLine("Please enter the player name.");
            //    string playerName = Console.ReadLine();
            //    UpdateHighScore(score, playerName);
            //}

            Ternary();
        }

        // CHALLENGE - IF STATEMENT
        public static void Choice()
        {
            Console.WriteLine("Register('0') or Login('1')?");
            string input = Console.ReadLine();
            if (input == "1")
            {
                if (password == null || userName == null)
                {
                    Console.WriteLine("Not Registered yet. Please register.");
                    Register();
                }
                else
                {
                    Login();
                }
            }
            else if (input == "0")
            {
                if (password != null || userName != null)
                {
                    Console.WriteLine("Already registered. Please login directly.");
                    Login();
                }
                else
                {
                    Register();
                }
            }
            else
            {
                Console.WriteLine("Illegal option. Please try again.");
                Choice();
            }
        }

        public static void Register()
        {
            if (userName != null || password != null)
            {
                Console.WriteLine("Already registered. Please login directly.");
                Login();
            }
            else
            {
                Console.WriteLine("Please enter your username.");
                userName = Console.ReadLine();
                Console.WriteLine("Please enter your password.");
                password = Console.ReadLine();
                Console.WriteLine("Successfully registered.");
                Choice();
            }
        }

        public static void Login()
        {
            Console.WriteLine("Please enter your username.");
            string enteredUserName = Console.ReadLine();
            Console.WriteLine("Please enter your password.");
            string enteredPassword = Console.ReadLine();
            while (!enteredUserName.Equals(userName) || !enteredPassword.Equals(password))
            {
                Console.WriteLine("Wrong Credential. Please try again.");
                Login();
            }
            Console.WriteLine("Successfully login.");
        }


        static double highScore = -1;
        static string highScoreHolder = "";
        // CHALLENGE - IF STATEMENTS 2
        public static void UpdateHighScore(double score, string playerName)
        {
            if (score > highScore)
            {
                Console.WriteLine($"New highscore is {score}");
                Console.WriteLine($"New highscore holder is {playerName}");
                highScore = score;
                highScoreHolder = playerName;
            }
            else
            {
                Console.WriteLine($"The old highscore of {highScore} could not be broken and is still held by {highScoreHolder}.");
            }
        }

        // CHALLENGE - TERNARY OPERATOR
        public static void Ternary()
        {
            Console.WriteLine("Enter the temperature.");
            string input = Console.ReadLine();
            try
            {
                int temperatureFormatted = int.Parse( input );
                Console.WriteLine(temperatureFormatted <= 15 ? "it is too cold here" : (temperatureFormatted >= 16 && temperatureFormatted <= 28 ? "it is ok" : "it is hot here"));
            }
            catch (Exception e)
            {
                Console.WriteLine("Not a valid Temperature.");
            }
        }
    }
}
