### Hello World

- Workflow
    - Visual Studio 2022 → New Project → Console App Template → Run the code
- Project Structure
    - .cs file - c# source file
    - .csproj - project configuration file

### New & Old Format of the templates

- New - ≥ Net6.0
- Old - Do not use Top-Level statements
    - Looks similar to Java Main Function
    - Internal keyword - Meaning this file can only be accessed within this project workspace
    - namespace - project
        
        ```csharp
        namespace OldStyleApp
        {
            internal class Program
            {
                static void Main(string[] args)
                {
                    Console.WriteLine("Hello, World!");
        						Console.Beep();
                }
            }
        }
        ```