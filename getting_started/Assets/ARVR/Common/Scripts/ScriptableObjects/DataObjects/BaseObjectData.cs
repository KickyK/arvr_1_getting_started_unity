using ARVR.ScriptableTypes;
using UnityEngine;

namespace ARVR.ObjectData
{
    /// <see cref="https://www.youtube.com/watch?v=PVOVIxNxxeQ"/>
    public abstract class BaseObjectData : ScriptableGameObject
    {
        [Header("Common")]
        public ItemType type;

        [Tooltip("Prefab used when drawing this object")]
        public GameObject associatedPrefab;

        [Tooltip("Alternate prefab used when drawing this object")]
        public GameObject alternatePrefab;
    }
}