### Logical conditions

- If - else if - else
- Tenary Operator
    - {condition} ? var1 : var2;
- switch
    - 
    
    ```csharp
    switch (xxx) 
    {
    	case xxx:
    			xxxxxx;
    			break;
    	default:
    			xxxxx;
    			break;
    }
    ```
    

TryParse() - related to User Entered inputs

```csharp
// The returned boolean is true when parsing is successful
string numberAsString = "128";
int parsedValue;
boolean success = int.TryParse(numberAsString, out parsedValue);
```