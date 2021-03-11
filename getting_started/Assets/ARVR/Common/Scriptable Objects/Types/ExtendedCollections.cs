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
    public abstract class RuntimeList<T> : ScriptableObject, IEnumerable<T>
    {
        [Header("List Contents")]
        [SerializeField]
        private List<T> list = new List<T>();

        [Header("Descriptive Information (optional)")]
        [ContextMenuItem("Reset Name", "ResetName")]
        public string Name;

        [TextArea(3, 5)]
        [ContextMenuItem("Reset Description", "ResetDescription")]
        public string Description;

        public void ResetName()
        {
            Name = "";
        }

        public void ResetDescription()
        {
            Description = "";
        }

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

    #region Concrete Types

    //Notice that I made a SPECIFIC/CONCRETE type of RuntimeList for string and that I CAN now create in the context menu
    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeIntList", menuName = "Scriptable Objects/Collections/List/Int", order = 1)]
    public class RuntimeIntList : RuntimeList<string>
    {
    }

    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeFloatList", menuName = "Scriptable Objects/Collections/List/Float", order = 2)]
    public class RuntimeFloatList : RuntimeList<string>
    {
    }

    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeStringList", menuName = "Scriptable Objects/Collections/List/String", order = 3)]
    public class RuntimeStringList : RuntimeList<string>
    {
    }

    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeGameObjectList", menuName = "Scriptable Objects/Collections/List/Game Object", order = 4)]
    public class RuntimeGameObjectList : RuntimeList<GameObject>
    {
    }

    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeTransformList", menuName = "Scriptable Objects/Collections/List/Transform", order = 5)]
    public class RuntimeTransformList : RuntimeList<Transform>
    {
    }

    #endregion Concrete Types
}