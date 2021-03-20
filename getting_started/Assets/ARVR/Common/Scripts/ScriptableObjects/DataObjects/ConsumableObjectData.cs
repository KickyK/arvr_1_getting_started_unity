using UnityEngine;

namespace ARVR.ObjectData
{
    [CreateAssetMenu(fileName = "ConsumableObjectData", menuName = "Scriptable Objects/Object Data/Consumable")]
    public class ConsumableObjectData : InteractableObjectData
    {
        [Header("Attributes")]
        public AttributeType Attribute;

        [Header("Value & Prefab")]
        public float Value;

        [Tooltip("Prefab used to instanciate an object after consumption")]
        public GameObject PostConsumptionPrefab;
    }
}