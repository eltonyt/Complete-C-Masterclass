namespace Section2_DataTypesAndVariables
{
    internal class Program
    {

        
        public static void Main(string[] args)
        {
            // Assignment1();
            // String1();
            // String2();
            Challenge();
        }

        // ASSIGNMENT 1 - PARSING
        public static void Assignment1()
        {
            string stringForFloat = "0.85"; // datatype should be float
            string stringForInt = "12345"; // datatype should be int
            float f = float.Parse(stringForFloat);
            int i = Int32.Parse(stringForInt);
            Console.WriteLine(f);
            Console.WriteLine(i);
            Console.Read();
        }

        // Exercise - String 1
        public static void String1()
        {
            string? string1;
            Console.WriteLine("Please enter your name and press enter");
            string1 = Console.ReadLine();
            while (String.IsNullOrEmpty(string1))
            {
                Console.WriteLine("No user input. Please enter your name and press enter");
                string1 = Console.ReadLine();
            }
                
            Console.WriteLine(string1.ToUpper());
            Console.WriteLine(string1.ToLower());
            Console.WriteLine(string1.Trim());
        }

        // Exercise - string2
        public static void String2()
        {
            string? string2;
            Console.WriteLine("Enter a string here: ");
            string2 = Console.ReadLine();
            while (String.IsNullOrEmpty(string2))
            {
                Console.WriteLine("No user input. Please enter your name and press enter");
                string2 = Console.ReadLine();
            }
            string? character;
            Console.WriteLine("Enter the character to search: ");
            character = Console.ReadLine();
            while (String.IsNullOrEmpty(character) || character.Length != 1)
            {
                Console.WriteLine("Illegal input. Please enter the character to search:");
                character = Console.ReadLine();
            }
            if (string2.IndexOf(character) > -1)
            {
                Console.WriteLine(string2.IndexOf(character));
            }
            else
            {
                Console.WriteLine("Character {0} not within the string: {1}.", character, string2);
            }

            string? firstName;
            Console.WriteLine("Please enter your first name: ");
            firstName = Console.ReadLine();
            while (String.IsNullOrEmpty(firstName))
            {
                Console.WriteLine("No user input. Please enter your first name:");
                firstName = Console.ReadLine();
            }
            string? lastName;
            Console.WriteLine("Please enter your last name: ");
            lastName = Console.ReadLine();
            while (String.IsNullOrEmpty(lastName))
            {
                Console.WriteLine("Illegal input. Please enter your last name: ");
                lastName = Console.ReadLine();
            }
            string name = firstName + " " + lastName;
            Console.WriteLine(name);
        }

        public static void Challenge()
        {
            byte byteV = 1;
            sbyte sbyteV = -4;
            short shortV = 5555;
            ushort ushortV = 222;
            int intV = 233;
            uint uintV = 9283;
            long longV = 8912739182;
            ulong ulongV = 99999992;
            float floatV = 233.22f;
            double doubleV = 233.22;
            char c = 'a';
            bool boolV = true;
            object obj = new();
            decimal decimalV = 3;

            string string1 = "I control text";
            string wholeNumberString = "3333";
            int wholeNumber = Int32.Parse(wholeNumberString);
            Console.WriteLine(string1);
            Console.WriteLine(wholeNumberString);
            Console.WriteLine(wholeNumber);
            Console.Read();
        }
    }
}
