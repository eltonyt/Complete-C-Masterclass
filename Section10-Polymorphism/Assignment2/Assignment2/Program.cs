namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] fileContent = System.IO.File.ReadAllLines(@"E:\github_project\2023\C#\Section10-Polymorphism\input.txt");
            foreach (string content in fileContent)
            {
                if (content.Contains("split"))
                {
                    string[] innerString = content.Split(" ");
                    string fourthElement = innerString[3];
                    System.IO.File.WriteAllText(@"E:\github_project\2023\C#\Section10-Polymorphism\output.txt", fourthElement);
                }
            }
        }
    }
}
