Zaprogramuj klasę generyczną `PriorityList<T>`, w której elementy typu `T` są uporządkowane.

O typie `T` zakładamy, że implementuje interfejs systemowy `IComparable<T>`.

## Klasa powinna udostępniać metody:

 - konstruktor domyślny – wtedy porównywanie elementów jest względem porządku określonego dla typu `T`,

 - konstruktor, którego argumentem jest obiekt klasy implementującej interfejs IComparer<T>, definiujący porządek w liście,

 - `push` - dodawanie elementu (na odpowiednie 
 miejsce)

 - `pop` – usuwanie pierwszego elementu i zwracanie jego wartości. Jeżeli lista jest pusta to zwracamy wartość domyślną dla danego typu,

 - `size` – zwraca liczbę elementów.


## Przykład kodu wykorzystującego klasę:

``` C#
PriorityList<double> list = new PriorityList<double>();
list.push(5.0);
list.push(4.0);
list.push(3.0);
while(list.size() >0)
{
  System.Console.WriteLine(" > "+ list.pop());
}
PriorityList<string> ls = new PriorityList<string> (StringComparer.OrdinalIgnoreCase);
ls.push ("CCC");
ls.push ("ADA");
ls.push ("aBA");
ls.push ("AaA");
while (ls.size() != 0) 
{
  System.Console.WriteLine ("" + ls.pop ());
}
```

W klasie `PriorityList` zaimplementuj interfejs `IEnumerable` tak, aby możliwy był zapis:

``` C#
PriorityList<double> list = new PriorityList<double>();
list.push(5.0); list.push(4.0); list.push(3.0);
foreach(var s in list) 
  Console.WriteLine (s);
foreach (var s in list)
  Console.WriteLine (s);
IEnumerator<string> i = ls.GetEnumerator ();
while (i.MoveNext()) 
{
  Console.WriteLine (" >> {0}", i.Current);
}
```

Do klasy `PriorityList<T>` dodaj konstruktor przyjmujący dowolną kolekcję standardową C# oraz porządek i tworzący `PriorityList` wypełnioną jego elementami odpowiednio uporządkowanymi.

```C#
List<string> ll = new List<string>();
ll.Add("BB"); ll.Add("AA");
PriorityList<string> lista = new PriorityList<string> (ll, StringComparer.Ordinal);
foreach(var s in lista) 
    Console.WriteLine (s);
```