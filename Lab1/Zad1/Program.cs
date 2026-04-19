Console.WriteLine();
Console.Write("Wpisz zakres liczb ze spacją (np. 1 10):");
string? input = Console.ReadLine();



if (string.IsNullOrEmpty(input))
{
    Console.WriteLine("NULL");
    return;
}

string[] numbers = input.Split(' ');

int num1 = 0;
int num2 = 0;

bool validInputNum1 = int.TryParse(numbers[0], out num1);
bool validInputNum2 = int.TryParse(numbers[1], out num2);



if (validInputNum1 && validInputNum2)
{
    Console.WriteLine($"Zakres {numbers[0]} - {numbers[1]}");
}
else
{
    Console.WriteLine("Wpisz liczby");
}

int counter = 0;

for (int a = num1; a <= num2; a++)
{
    for (int b = a; b <= num2; b++)
    {
        for (int c = b; c <= num2; c++)
        {
            if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2))
            {
                counter++;
            }
        }
    }
}

Console.WriteLine(counter);