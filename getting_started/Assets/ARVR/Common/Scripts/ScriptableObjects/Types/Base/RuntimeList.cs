using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains a generic abstract list from which we can extend to create concrete list types
/// </summary>
/// <see cref ="https://www.tutorialsteacher.com/csharp/csharp-exception"/>
namespace ARVR.ScriptableTypes
{
    #region Generic Type

    //Note - We cannot directly instantiate a GENERIC ScriptableObject from the Context Menu - see RuntimeStringList
    [System.Serializable]
    public abstract class RuntimeList<T> : ScriptableGameObject, IEnumerable<T>
    {
        [Header("List Contents")]
        [SerializeField]
        private List<T> list = new List<T>();

        public void ResetList()
        {
            list.Clear();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= list.Count)
                    throw new System.ArgumentException($"Invalid index [{index}] in indexer method");               //https://www.tutorialsteacher.com/csharp/csharp-exception

                return list[index];
            }
            set
            {
                if (index < 0 || index >= list.Count)
                    throw new System.ArgumentException($"Invalid index [{index}] in indexer method");

                list[index] = value;
            }
        }

        public void Push(T obj)
        {
            if (!list.Contains(obj))
            {
                list.Add(obj);
            }
        }

        public T Pop()
        {
            if (IsEmpty())
                return default(T);

            T obj = list[list.Count - 1];
            list.Remove(obj);
            return obj;
        }

        public T Peek()
        {
            if (IsEmpty())
                return default(T);

            return list[list.Count - 1];
        }

        public void Remove(T obj)
        {
            if (list.Contains(obj))
            {
                list.Remove(obj);
            }
        }

        public int RemoveAll(Predicate<T> predicate)
        {
            return list.RemoveAll(predicate);
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

        public bool IsEmpty()
        {
            return list.Count == 0;
        }

        public void Sort(IComparer<T> comparer)
        {
            list.Sort(comparer);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)list).GetEnumerator();
        }
    }

    #endregion Generic Type
}