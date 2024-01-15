using System.Text.RegularExpressions;

namespace Assignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string content = System.IO.File.ReadAllText(@"E:\github_project\2023\C#\Section11-AdvancedTopic\input2.txt");
            string[] texts = content.Split(" ");
            var pattern = "[0-9]{2,3}";
            foreach (string text in texts)
            {
                if (Regex.IsMatch(text, pattern))
                {
                    string resultString = Regex.Match(text, @"\d+").Value;
                    int stringInt = Int32.Parse(resultString);
                    char c = (char)stringInt;
                    Console.WriteLine(c);
                }
            }
        }
    }
}
