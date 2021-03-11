using UnityEngine;

namespace ARVR.ObjectData
{
    [CreateAssetMenu(fileName = "ConsumableObjectData", menuName = "Scriptable Objects/Object Data/Consumable")]
    public class ConsumableObjectData : InteractableObjectData
    {
        [Header("Attributes")]
        public AttributeType itemAttribute;

        [Header("Value & Prefab")]
        public float value;

        [Tooltip("Prefab used to instanciate an object after consumption")]
        public GameObject postConsumptionPrefab;
    }
}