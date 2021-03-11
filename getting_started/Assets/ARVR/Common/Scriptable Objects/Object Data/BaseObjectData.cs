using UnityEngine;

namespace ARVR.ObjectData
{
    /// <see cref="https://www.youtube.com/watch?v=PVOVIxNxxeQ"/>
    public abstract class BaseObjectData : ScriptableObject
    {
        [Header("Common")]
        public ItemType itemType;

        [Tooltip("Prefab used when drawing this object")]
        public GameObject associatedPrefab;

        [Tooltip("Alternate prefab used when drawing this object")]
        public GameObject alternatePrefab;

        [Header("Description (optional)")]
        public string itemName;

        [Tooltip("Description may be used internally (design team) or used when selecting the object (e.g. restores 10 units of health)")]
        public string itemDescription;
    }
}