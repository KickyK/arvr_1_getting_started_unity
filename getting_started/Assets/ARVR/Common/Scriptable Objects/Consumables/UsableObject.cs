using UnityEngine;
using UnityEngine.Events;

namespace ARVR.Usable
{
    public enum UsableType : sbyte
    {
        Food, Drink, Tool, Narrative, Quest, Armor, Weapon
    }

    public enum AttributeType : sbyte
    {
        Agility, Strength, Stamina, Speed, Knowledge, Intelligence
    }

    public abstract class UsableObject : ScriptableObject
    {
        #region Fields

        [Header("Descriptive Properties")]
        [SerializeField]
        public string itemName;

        [SerializeField]
        [Multiline(3)]
        public string itemDescription;

        [Header("Usable Item Properties")]
        [SerializeField]
        public UsableType itemType;

        [SerializeField]
        public AttributeType itemAttribute;

        [Header("Visual & Audio Properties")]
        [SerializeField]
        public Sprite itemIcon;

        [SerializeField]
        public GameObject associatedPrefab;

        [SerializeField]
        public GameObject alternatePrefab;

        [SerializeField]
        public AudioClip useAudioClip;

        [Header("Selection Properties")]
        [SerializeField]
        public LayerMask layerMask;

        [SerializeField]
        public string tag;

        #endregion Fields

        public abstract void Use();
    }
}