using System.ComponentModel;
using System.Text;

string input = Console.ReadLine();
if(string.IsNullOrEmpty(input)) return;

Stack<char> lewy = new Stack<char>();
Stack<char> prawy = new Stack<char>();

foreach(char znak in input)
{
    switch(znak)
    {
        case '<':
            if(lewy.Count > 0)
            { 
                //Wyjęcie z lewego stosu i dawanie do prawego
                prawy.Push(lewy.Pop());
            }
            break;

        case '>':
            if(prawy.Count > 0)
            {
                lewy.Push(prawy.Pop());
            }
            break;

        case '-':
            if(lewy.Count > 0)
            {
                lewy.Pop();
            }
            break;

        default:
            lewy.Push(znak);
            break;
    }
}

//KROK 2 Łączenie wyników
while(lewy.Count > 0)
{
    prawy.Push(lewy.Pop());
}

StringBuilder haslo = new StringBuilder(prawy.Count);
while(prawy.Count > 0)
{
    haslo.Append(prawy.Pop());
}

Console.WriteLine(haslo.ToString());
