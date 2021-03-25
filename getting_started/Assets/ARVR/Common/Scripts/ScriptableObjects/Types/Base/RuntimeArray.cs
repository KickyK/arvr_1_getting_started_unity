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
    public abstract class RuntimeArray<T> : ScriptableGameObject, IEnumerable<T>
    {
        [Header("Array Contents")]
        [SerializeField]
        private T[] array;

        public int Length
        {
            get
            {
                return array.Length;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= array.Length)
                    throw new System.ArgumentException($"Invalid index [{index}] in indexer method");               //https://www.tutorialsteacher.com/csharp/csharp-exception

                return array[index];
            }
            set
            {
                if (index < 0 || index >= array.Length)
                    throw new System.ArgumentException($"Invalid index [{index}] in indexer method");

                array[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)array).GetEnumerator();
        }
    }

    #endregion Generic Type
}