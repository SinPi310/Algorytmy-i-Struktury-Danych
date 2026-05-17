using System;
using System.Collections;
using System.Collections.Generic;

public class PriorityList<T> : IEnumerable<T> where T : IComparable<T>
{
    private List<T> _elements;
    
    private IComparer<T> _comparer;

    public PriorityList()
    {
        _elements = new List<T>();
        _comparer = Comparer<T>.Default;
    }

    public PriorityList(IComparer<T> comparer)
    {
        _elements = new List<T>();
        _comparer = comparer;
    }

    public PriorityList(IEnumerable<T> collection, IComparer<T> comparer)
    {
        _comparer = comparer;
        _elements = new List<T>(collection);
        _elements.Sort(_comparer);
    }

    public void push(T item)
    {
        int index = _elements.BinarySearch(item, _comparer);
        
        if (index < 0)
        {
            index = ~index;
        }
        
        _elements.Insert(index, item);
    }

    public T pop()
    {
        if (_elements.Count == 0)
        {
            return default(T);
        }

        T firstElement = _elements[0];
        _elements.RemoveAt(0);
        
        return firstElement;
    }

    public int size()
    {
        return _elements.Count;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _elements.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
public class Program
{
    public static void Main()
    {
        {
            Console.WriteLine("");
            Console.WriteLine("-- Test 1 --");
            PriorityList<double> list = new PriorityList<double>();
            list.push(5.0);
            list.push(4.0);
            list.push(3.0);
            while(list.size() > 0)
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
        }

        {
            Console.WriteLine("");
            Console.WriteLine("-- Test 2 --");
            PriorityList<double> list = new PriorityList<double>();
            list.push(5.0); list.push(4.0); list.push(3.0);
            foreach(var s in list) 
              Console.WriteLine (s);
            foreach (var s in list)
              Console.WriteLine (s);

            PriorityList<string> ls = new PriorityList<string> (StringComparer.OrdinalIgnoreCase);
            ls.push ("CCC");
            ls.push ("ADA");
            ls.push ("aBA");
            ls.push ("AaA");
            
            IEnumerator<string> i = ls.GetEnumerator ();
            while (i.MoveNext()) 
            {
              Console.WriteLine (" >> {0}", i.Current);
            }
        }

        {
            Console.WriteLine("");
            Console.WriteLine("-- Test 3 --");
            List<string> ll = new List<string>();
            ll.Add("BB"); ll.Add("AA");
            PriorityList<string> lista = new PriorityList<string> (ll, StringComparer.Ordinal);
            foreach(var s in lista) 
                Console.WriteLine (s);
        }
    }
}