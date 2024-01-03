namespace Challenge1_TikTakToe
{
    internal class Program
    {
        static string[,] board = new string[,]
        {
            {"1", "2", "3" },
            {"4", "5", "6" },
            {"7", "8", "9" }
        };
        static bool player1 = true;
        static bool end = false;
        static int step = 0;
        public static void Main(string[] args)
        {
            while (true)
            {
                while (!end)
                {
                    PrintBoard();
                    string enteredValue;
                    do
                    {
                        Console.WriteLine("Player {0}: Choose your field!", player1 ? "1" : "2");
                        enteredValue = Console.ReadLine();
                    } while (enteredValue == null || !ValidInput(enteredValue));

                    int enteredValueFormatted = int.Parse(enteredValue);
                    int rowIndex = (enteredValueFormatted - 1) / 3;
                    int columnIndex = (enteredValueFormatted - 1) % 3;
                    board[rowIndex, columnIndex] = player1 ? "X" : "O";
                    int personWin = CheckWin();
                    if (personWin != -1)
                    {
                        Console.WriteLine("Player {0} wins. Press any key to restart!", personWin);
                        string x = Console.ReadLine();
                        break;
                    }
                    player1 = !player1;
                    step++;
                    if (step == 9)
                    {
                        Console.WriteLine("Draw! Press any key to restart!");
                        string x = Console.ReadLine();
                        break;
                    }
                }
                Reset();
            }
        }

        public static int CheckWin()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, 0].Equals(board[i, 1]) && board[i, 1].Equals(board[i, 2]))
                {
                    if (board[i, 0].Equals("X"))
                        return 1;
                    else
                        return 2;
                }
                // VERTICAL
                if (board[0, i].Equals(board[1, i]) && board[1, i].Equals(board[2, i]))
                    if (board[0, i].Equals("X"))
                        return 1;
                    else
                        return 2;
            }
            if (board[0, 0].Equals(board[1, 1]) && board[1, 1].Equals(board[2, 2]))
                if (board[0, 0].Equals("X"))
                    return 1;
                else
                    return 2;
            if (board[2, 0].Equals(board[1, 1]) && board[1, 1].Equals(board[0, 2]))
                if (board[2, 0].Equals("X"))
                    return 1;
                else
                    return 2;
            return -1;
        }

        public static void Reset()
        {
            board = new string[,]
            {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" }
            };
            player1 = true;
            end = false;
        }

        public static void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine("       |       |       ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", board[0, 0], board[0, 1], board[0, 2]);
            Console.WriteLine("       |       |       ");
            Console.WriteLine("_______|_______|_______");
            Console.WriteLine("       |       |       ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("       |       |       ");
            Console.WriteLine("_______|_______|_______");
            Console.WriteLine("       |       |       ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", board[2, 0], board[2, 1], board[2, 2]);
            Console.WriteLine("       |       |       ");
            Console.WriteLine("_______|_______|_______");
        }

        public static bool ValidInput(string val)
        {
            if (!val.Equals("1") && !val.Equals("2") && !val.Equals("3") && !val.Equals("4") && !val.Equals("5") && !val.Equals("6") && !val.Equals("7") && !val.Equals("8") && !val.Equals("9"))
            {
                Console.WriteLine("Please enter a number!");
                return false;
            }
            else
            {
                int enteredValueFormatted = int.Parse(val);
                int rowIndex = (enteredValueFormatted - 1) / 3;
                int columnIndex = (enteredValueFormatted - 1) % 3;
                if (board[rowIndex, columnIndex].Equals("O") || board[rowIndex, columnIndex].Equals("X"))
                {
                    Console.WriteLine("Incorrect Input! Please use another field!");
                    return false;
                }
                return true;
            }
        }
    }
}
