using System.Collections.Generic;
using UnityEngine;

//Notice that I made a SPECIFIC/CONCRETE type of RuntimeList for string and that I CAN now create in the context menu
[CreateAssetMenu(fileName = "RuntimeStringList", menuName = "Scriptable Objects/Variables/Runtime String List")]
public class RuntimeStringList : RuntimeList<string>
{
}

//Note - We cannot directly instantiate a GENERIC ScriptableObject from the Context Menu - see RuntimeStringList
public abstract class RuntimeList<T> : ScriptableObject
{
    public List<T> list = new List<T>();

    public void Add(T obj)
    {
        if (!list.Contains(obj))
        {
            list.Add(obj);
        }
    }

    public void Remove(T obj)
    {
        if (list.Contains(obj))
        {
            list.Remove(obj);
        }
    }

    //clear
    public void Clear()
    {
        list.Clear();
    }

    //count
    public int Count()
    {
        return list.Count;
    }
}