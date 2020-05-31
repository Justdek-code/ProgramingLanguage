# SchoolScript 

It is an interpreted and dynamically typed programming language. *Developed By __Denis Vivdenko__*.

## Features that language maintain

* If statement
* While loop
* Print function
* Read functions
* Math operations: +, -, *, /
* Boolean equations: >, <, =
* Variable types: int, string, bool

## Syntax
Syntax of this language is pretty much the same as C/C++ syntax
* #### If statment
   ```
    if (a == b)
    {
      // operations...
    }
    ```
 * #### While loop
    ```
    while (a < 5)
    {
      // operations...
    }
    ```
* #### Variable definiton
    ```
    var a = "Hello World";
    var b = 10;
    var c = b + 5;
    var d = true;
    ```
 * #### Variable assignment
    ```
    a = "Hello World";
    b = 10;
    ```
 * #### Print function
    It can contain infinite number of parameters and each of them will be written on the next line.
    ```
    Print("Hello World", 15, a);
    ```
 * #### Read functions
    It can contain infinite number of parameters and each of them will be read in order through line.
    ```
    ReadInteger(a);
    ReadString(b, c);
    ```
    
## Calculator on SchoolScript
```
var a = 0;
var b = 0;
var isContinue = true;
var operation = " ";
var question = " ";

while (isContinue == true)
{
    Print("Write first value: ");
    ReadInteger(a);

    Print("Write second value: ");
    ReadInteger(b);

    Print("Write operation: ");
    ReadString(operation);

    Print("Result: ");
    if (operation == "+")
    {
        Print(a + b);
    }
    if (operation == "-")
    {
        Print(a - b);
    }
    if (operation == "/")
    {
        Print(a / b);
    }
    if (operation == "*")
    {
        Print(a * b);
    }

    Print("Do you want to continue? (yes/no): ");
    ReadString(question);

    if (question == "yes")
    {
        isContinue = true;
    }
    if (question == "no")
    {
        isContinue = false;
    }
}
```
