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