### Delegates - a type that can hold a reference to a method

Delegates are used to pass methods as arguments to other methods.

```csharp
private delegate void OnClickDelegate();

public OnClickDeligate OnClick;
```

Example

```csharp
List<string> names = new List<string> () {"A", "B"};
names.RemoveAll(Filter);

static bool Filter(string s) {
	return s.Contains("i");
}
```

Example 2

```csharp
// TODO
public delegate float OperationDelegate(float a, float b);

public static float ApplyOperation(float a, float b, OperationDelegate calculation) {
    return calculation(a, b);
}

public static float Add(float a, float b) {
    return a + b;
}

public static float Subtract(float a, float b) {
    return a - b;
}

public static float Multiply(float a, float b) {
    return a * b;
}

public static float Divide(float a, float b) {
    return a / b;
}

public void static main(string[] args) {
	float a = 3.14f;
	float b = 2.33f;
	Console.WriteLine(ApplyOperation(a, b, Add));
}
```

### Anonymous Method

```csharp
FilterDelegate filter = delegate (Person p)
{
	return p.Age >= 20 && p.Age <= 30;
};
DisplayPeople("Kids", people, filter);

// Updated Version
DisplayPeople("Kids", people delegate (Person p) {
	return p.Age >= 20 && p.Age <= 30;
});
```

### Lambda Declaration

```csharp
// Updated Version
string searchKeyword = "A";
DisplayPeople("age > 20 with search keyword:" + searchKeyword, people, (p) => 
{
	if (p.Name.Contains(SearchKeyword) && p.Age > 20)
		return true;
	return false;
});
```

- Store Lambda as a variable
    
    ```csharp
    Func<int, int> PlusOne = (a) => a+1;
    # this function gets an int argument and returns another int
    # You can have a return or not. And you can have no argument or have multiple. 
     
    # it is the way you can call this function
    int res = PlusOne(3);
    # res = 4
    ```
    

### Events and Multi Delegates

- Events vs Delegates
    - Events are forced to behave like a list
        - += / -=
    - Delegate allows a direct assignment
        - myDelegate = myMethod
    - Events cannot be triggered from outside the class that defines them.