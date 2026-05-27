using System;
using System.Collections;
using System.Collections.Generic;

public enum HeapOptions { MaxHeap = -1, MinHeap = 1 }

public class Heap<T> : IEnumerable<T> where T : IComparable<T>
{
    private List<T> list;
    public HeapOptions Option { get; }

    public Heap(HeapOptions option = HeapOptions.MinHeap)
    {
        this.Option = option;
        list = new List<T>();
    }

    public Heap(IEnumerable<T> collection, HeapOptions option = HeapOptions.MinHeap)
    {
        this.Option = option;
        list = new List<T>();
        
        foreach (var item in collection)
        {
            Insert(item);
        }
    }

    public int Count => list.Count;

    public void Insert(T x)
    {
        list.Add(x); 
        BubbleUp(list.Count - 1); 
    }

    public T Delete()
    {
        if (list.Count == 0)
            throw new InvalidOperationException("Kopiec jest pusty.");

        T top = list[0]; 

        list[0] = list[list.Count - 1];
        list.RemoveAt(list.Count - 1); 

        if (list.Count > 0)
        {
            BubbleDown(0);
        }

        return top;
    }

    public T Top()
    {
        if (list.Count == 0)
            throw new InvalidOperationException("Kopiec jest pusty.");

        return list[0];
    }

    public void Clear()
    {
        list.Clear();
    }

    public T[] ToArray()
    {
        return list.ToArray();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private int Compare(T a, T b)
    {
        return a.CompareTo(b) * (int)Option;
    }

    private void BubbleUp(int index)
    {
        while (index > 0)
        {
            int parent = (index - 1) / 2; 

            if (Compare(list[index], list[parent]) < 0)
            {
                T temp = list[index];
                list[index] = list[parent];
                list[parent] = temp;
                index = parent; 
            }
            else
            {
                break; 
            }
        }
    }

    private void BubbleDown(int index)
    {
        while (index < list.Count)
        {
            int left = 2 * index + 1;  
            int right = 2 * index + 2; 
            int best = index;          

            if (left < list.Count && Compare(list[left], list[best]) < 0)
                best = left;

            if (right < list.Count && Compare(list[right], list[best]) < 0)
                best = right;

            if (best != index)
            {
                T temp = list[index];
                list[index] = list[best];
                list[best] = temp;
                index = best; 
            }
            else
            {
                break; 
            }
        }
    }
}