### Arrays

- Fixed Size
- Sequential
- Elements in Same Type
- Contiguous Memory Location
- Use
    - dataType[] arrayName = new dataType[size of array];
    - arrayName[index] = xxx;
    - **dataType[] arrayName = {xxx, xxx, xxx ….} - A little bit different comparing to Java**
    - **dataType[] arrayName = new dataType[] {xxx, xxx, xxx ….} - Same in Java**
- Multi-Dimension - same Length for each row.
    - Use
        
        ```csharp
        // 2 D
        string[,] matrix;
        // 3 D
        string[,,] matrix;
        
        int [,] array2D = new int[,]
        {
        	{1, 2, 3},
        	{4, 5, 6}
        }
        ```
        
    - **Rank - Helps you understand the dimension of the array**
    - **Total Elements, even multi-dimension - array2D.Length;**
    - **Element Counts at different dimension - array2D.GetLength($dimension);**
    - **Data Access - Different comparing to Java**
        
        ```csharp
        int [,] array2D = new int[,]
        {
        	{1, 2, 3},
        	{4, 5, 6}
        }
        
        int data = array2D[0, 1];
        ```
        
- Jagged Arrays - Array within array - **Inner arrays can have different length**
    
    ```csharp
    int[][] jaggedArray = new int[3][];
    jaggedArray[0] = new int[5];
    jaggedArray[1] = new int[3];
    jaggedArray[2] = new int[2];
    
    // Another way
    string[][] friendArray = new string[][]
    {
        new string[] {"Elton", "Jake"},
        new string[] {"Lily", "Aria"},
        new string[] {"Wilson", "Amber"}
    };
    ```
    
- Foreach Loop - used for looping each element within the array - Little bit different comparing to in Java (need to use **“in”** keyword)
    
    ```csharp
    foreach (int x in arr) {
    	xxx;
    }
    ```
    
- **params** keyword - any number of arguments
    - 
    
    ```csharp
    public static int Sum(params int[] numbers) {
    	int total = 0;
    	foreach (int num in numbers) {
    		total += num;	
    	}
    	return total;
    }
    
    Console.WriteLine(Sum(5, 6, 8));
    ```