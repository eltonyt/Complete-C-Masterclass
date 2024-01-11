- new - keyword
    - 
    
    ```csharp
    //In child class - this helps calling child class' method when parent class's method has no keyword virtual.
    public new void xxx() {
    	xxx
    }
    ```
    
- Sealed Keyword
    
    ```csharp
    // in middle class - so that it overrides parent class
    // but it doesn't allow other child class to override this method anymore
    public sealed override void Repair() {
    	//xxx
    }
    ```
    
- Has A Relationship - A object that a specific class owns
- Abstract
    
    ```csharp
    abstract class Shape{
    	public string Name {get; set;}
    	public virtual void GetInfo(){
    		Console.WriteLine("xxx")
    	}
    	// Needs to be implemented within deriving class
    	public abstract double Volume();
    }
    ```
    
- as keyword
    
    ```csharp
    Shape shape = new Cube(3);
    Cube iceCube = shape as Cube;
    ```
    
- Read/Write text file
    
    ```csharp
    // Read
    string text = System.IO.File.ReadAllText(Path);
    string[] lines = System.IO.File.ReadAllLines(Path);
    
    // Write
    string[] lines = {"Hello", xxxxx}
    System.IO.File.WriteAllLines(path, lines);
    
    string test = "xxxxxxxxxx";
    System.Io.File.WriteAllText(path, test);
    
    using(StreamWriter file = new StreamWriter(path))
    {
    	foreach (string line in lines) {
    		file.WriteLine(line);	
    	}
    }
    ```