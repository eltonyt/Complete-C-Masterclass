```jsx
// Electric Device - Base Class
namespace InheritanceDemo
{
    internal class ElectricDevice
    {
        public bool isOn { get; set; }
        public string Brand { get; set; }

        public ElectricDevice(bool isOn, string brand)
        {
            this.isOn = isOn;
            this.Brand = brand;
        }

        public void SwitchOn()
        {
            isOn = true;
        }

        public void SwitchOff()
        {
            isOn = false;
        }
    }
}

// Radio Class - Child Class
namespace InheritanceDemo
{
    internal class Radio : ElectricDevice
    {
        public Radio(bool isOn, string brand):base(isOn, brand) {}
        public void ListenRadio()
        {
            if (isOn)
            {
                Console.WriteLine("Listening to the radio");
            }
            else
            {
                Console.WriteLine("Radio is switched off, switch it on first.");
            }
        }
    }
}

// TV Class - Child Class
namespace InheritanceDemo
{
    internal class TV : ElectricDevice
    {
        public TV(bool isOn, string brand):base(isOn, brand) {}
        public void listenRadio()
        {
            if (isOn)
            {
                Console.WriteLine("Watching the TV.");
            }
            else
            {
                Console.WriteLine("TV is switched off, switch it on first.");
            }
        }

    }
}

```

- Can only inherited from one parent class.
- Some keywords
    - Virtual & Override
    - **Override keyword can only be used on the method that’s inheritance from parent’s virtual class**
        
        ```jsx
        // Within Base Class - Allow sub classes to override this method
        public virtual void MakeSound() {
        	Console.WriteLine("LOL!");
        }
        
        // Child Class Method - Override
        public override void MakeSoud() {
        	Console.WriteLine("Lmao!");
        }
        
        // Child Class Method - Calling Base Class Method
        public override void MakeSound() {
        	base.MakeSound();
        }
        ```
        
- Inerfaces
    - keyword - interface
    - Naming - with I leading. For example (IDestroyable.cs)
        
        ```csharp
        // INTERFACE
        interface IDestroyable
        {
        	string DestructionSound {get; set}
        	void Destroy();
        }
        
        // CLASS THAT IMPLEMENTS THE INTERFACE
        class Car : Vehicle, IDestroyable
        {
        	xxxxx
        
        	// implements the method
        	public string DestructionSound {get; set}
        
        	public void Destroy() {
        		xxxxx
        	}
        }
        ```
        
    - Pros
        - Code Readability
        - Code Semantics
        - Code Maintainability
        - Design Patterns
        - **Multi-Inheritance**
- IEnumerator & IEnumerable - Easier to be used within iterations
    - IEnumerable <T> for generic Collections
    - IEnumerable for non generic Collections
        - Example
        
        ```csharp
        using System;
        using System.Collections.Generic;
        using System.Collections;
        
        namespace Coding.Exercise
        {
            // TODO
            class Contact {
                public string Name {get; set;}
                public string PhoneNumber {get; set;}
                public Contact(string name, string phoneNumber)
                {
                    this.Name = name;
                    this.PhoneNumber = phoneNumber;
                }
                public void Call () {
                    Console.WriteLine("Calling to {0}. Phone number is {1}", this.Name, this.PhoneNumber);
                }
            }
            
            class PhoneBook : IEnumerable<Contact> {
                public List<Contact> Contacts;
                public PhoneBook() {
                    Contacts = new List<Contact>{
                        new Contact("Andre", "435797087"),
                        new Contact("Lisa", "435677087"),
                        new Contact("Dine", "3457697087"),
                        new Contact("Sofi", "4367697087")
                    };
                }
                
                IEnumerator<Contact> IEnumerable<Contact>.GetEnumerator(){
                    return Contacts.GetEnumerator();
                }
        
                IEnumerator IEnumerable.GetEnumerator(){
                    throw new NotImplementedException();
                }
            }
            
            public static class Program{
                static public void Main(string[] args){
                    PhoneBook MyPhoneBook = new PhoneBook();
        
                    foreach (Contact contact in MyPhoneBook){
                        contact.Call();
                    }
                } 
            }
        }
        ```