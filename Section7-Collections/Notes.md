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
    

### Collections

- Definition
    - collection of objects
    - **no limited to one type of objects**
    - No size constraints
- Types
    - **Non-Generic - Any type of objects - Remember: since the element within the arrayList can be different, use object as the type when loop through the arr**
        
        ```csharp
        int num1 = 5;
        float num2 = 3.14f;
        ArrayList arr = new ArrayList();
        arr.Add(num1);
        arr.Add(num2);
        
        foreach (object element in arr) 
        {
        	xxxxx;
        }
        ```
        
    - Generic - one type of objects
- ArrayList
    
    ```csharp
    // Option 1
    ArrayList arr = new ArrayList();
    // Option 2 - with defined number of objects
    ArrayList arr2 = new ArrayList(100);
    
    // Method - Add
    arr.Add(1);
    
    // Method - Remove - specific value from the list (ALl of the element with the save value within the arraylist will be removed.)
    arr.Remove(1);
    
    // Method - RemoveAt - specific value at an index
    arr.RemoveAt(0);
    
    // Method - RemoveRange
    
    // Method - Count
    Console.WriteLine(arr.Count);
    
    ```
    
- Lists
    
    ```csharp
    var numbers = new List<int>();
    numbers.add(7);
    
    int value = numbers[0];
    
    numbers.RemoveAt(0);
    
    numbers.Clear(); // Remove all elements from the list 
    
    numbers.Count; // Count of elements within the List
    ```
    
- Hashtable
    
    ```csharp
    Hashtable table = new Hashtable();
    // ADD
    table.Add(key, value);
    
    // GET VALUE
    value = table[key];
    
    // ITERATION
    foreach (DictionaryEntry entry in table) {
    	value = entry.value;
    }
    
    // ITERATION
    foreach (var value in table.value) {
    	Console.WriteLine(value);
    }
    ```
    
- Dictionaries - generic collections - not that flexible (Type needs to be defined.)
    
    ```csharp
    Dictionary<int, string> dic = new Dictionary<int, string>()
    {
    	{1, "one"},
    	{2, "two"},
    	{3, "three"}
    };
    
    // Add
    dic.Add(4 "four");
    
    // CONTAINS
    if (dict.ContainsKey(key))
    {
    	xxxx
    }
    
    // ACCESS VALUE
    Console.WriteLine(dict[key]);
    
    string result;
    // TRY GET VALUE
    if (dict.TryGetValue("1", out result)) {
    	XXX
    }
    else {
    	// NO KEY 1
    }
    
    // COUNT
    dict.Count
    
    // ITERATION
    for (int i = 0; i < dict.Count; i ++) {
    	KeyValuePair<int, string> keyValuePair = dict.ElementAt(i);
    	string value = keyValuePair.Value;
    	int key = keyValuePair.Key;
    }
    
    // UPDATE THE KEY
    if (dict.ContainsKey(key)) {
    	dict[key] = $newValue;
    }
    
    // REMOVE
    if (dict.Remove(key)) {
    	Console.WriteLine(key + " is removed.")
    }
    ```
    
- Stacks
    - Push(x)
    - Pop()
    - Peek()
    - Count - returns the length of the stack
- Queues
    - Enqueue(Object obj)
    - Dequeue()
    - Peek()
    - Count - returns the length of the Queue