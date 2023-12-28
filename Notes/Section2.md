Variables - Type, Name, and Data

### Variables and Data Types in C#

- Primitive Data Type
    - whole number
        - sbyte = -128 ~ 127 (-2^7 ~ 2^7 - 1)
        - short = -32767 ~ 32767 (-2^15 ~ 2^15 - 1)
        - int = -2147483648 ~ 2147483647 (-2^31 ~ 2^31 - 1)
            - Cast from string - Int32.Parse(xxx);
        - long = -9223327036854775808 ~ 9223327036854775807 (-2^63 ~ 2^63 - 1)
    - with decimals
        - float = 1.5 * 10^(-4) ~ 3.4 * 10^38
            - end with f
        - double = 15-digit precision (mostly used for real world values)
        - decimal = 28-digit precision (mostly used for **financial applications**)
    - bool - true/false
    - char - single letter
- string - multiple letters and unicodes
    - concatenation - xxx + xxx + xxxxx
    - **string formatting using index**
        
        ```csharp
        Console.WriteLine(”xxxxxxxx{0} xxxxxxxxx{1}”, var1, var2);
        ```
        
    - **string interpolation**
        
        ```csharp
        Console.WriteLine($”xxxxxxxx{var1} xxxxxxxxx{var2}”);
        ```
        
    - **Verbatim strings - show all indents/spaces, etc**
        
        ```csharp
        Console.WriteLine(@”xxxxxxxx{var1} xxxxxxxxx{var2}”);
        Console.WriteLine(@”C:\User\Elton\xxx”);
        ```
        
    - Some string functions
        - SubString(int)
        - ToLower()
        - ToUpper()
        - Trim()
        - IndexOf(string)
        - String.IsNullOrWhiteSpace(string) - static method
        - String.Format(”xxx {index}”, object) - used to inject a string to the string
    - Special Characters - add \ before special characters
- **var Type - type of the variable depends on the type of the value**
    - cannot be assigned to null
- Value type & Reference Types
    - Value Types - store actual data
        - int, float, long, double, char, bool, decimal, struct, enum
        - Typically stored in the stack
        - Nullable versions available (int?, double?, etc.)
        - **Can be stored in heap if part of a reference type**
    - Reference Type - stores the memory location of the actual data
        - string, class, Array, etc.
        - **when copying, copy the address of the memory so that two pointers point to the same spot.**

### Coding Standards

- Reasonable Variable Name
- Proper Method Name
- Comments
    - Single-Line
        - // xxxx
    - Multiline
        - /* xxxx */
    - XML documentation comments
        - ///<summary> //xxxxx ///</summary>
- Naming Conventions - Camel
    - Class Name - 1st Letter Capitalized & Camel
    - **Method Name - 1st Letter Capitalized & Camel (Different than Java)**

### Console Methods

Write(xxx) - output on the same line

WriteLine(xxx) - output in the next line

Read() - Takes a single input of type string and return the ASCII code of it

ReadLine() - Takes a string or integer input and can be used for calculation

ReadKey() - Takes the input of type string and returns the Key info

### Explicit & Implicit Casting

- Explicit Casting
    - Manually, loses some information
    - i.e. float → int (13.1 → 13)
- Implicit Casting
    - Automatically, doesn’t lose any information
    - i.e. int →  float (13 → 13.0)

### Constants - Immutable

```csharp
const [Type] [Name] = [Data];
// Example
const int weeks = 52;
```