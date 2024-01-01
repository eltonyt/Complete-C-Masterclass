- Class - Blue print of an Object
    - Has actions/abilities - methods
    - Has properties - member variables
    - Inheritance possible
    - Call be used as a Datatype - i.e. String
- Create Class from Visual Studio 2022
    
    ![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/b0dd9717-c1cd-4e54-8549-0570db9dc784/11911552-3eff-4cc7-b814-d67759d5a5a2/Untitled.png)
    
- **Private Variables - try to name it with a underscore at front. (i.e. _name = xxx)**
- **Constructor with default values - public Car(string name, int hp = 0, string color = “black”) {}**
- **Properties - Used as setters and getters within the object class**
    
    ```csharp
    // WITHIN CLASS 
    public string Name { 
    	get {return _name;} 
    	set {_name = value;} 
    }
    // CALLING FROM MAIN FUNCTION
    Car myCar = new Car();
    myCar.Name = "Audi";
    Console.WriteLine(myCar.Name);
    ```
    
    - Auto implemented Properties
        - Remove specific content from getter and setter
            
            ```csharp
            public string Name { get; set;}
            ```
            
    - Read-Only Property - **Normally used for Computer Data - Computed by the program and should never be updated by human beings**
        - Remove Set from Property
            
            ```csharp
            public string Name { get;}
            ```
            
    - Write-Only Property - **Sensitive data, but cannot be read by the system (such as Password)**
        - Remove Get from Property
            
            ```csharp
            public string Name { set;}
            ```
            
- Finalizers & Destructors
    - Class Name with a leading “~”
        - Automatically executed when the object is destructed by the application
        
        ```csharp
        ~Car() {
        
        }
        ```