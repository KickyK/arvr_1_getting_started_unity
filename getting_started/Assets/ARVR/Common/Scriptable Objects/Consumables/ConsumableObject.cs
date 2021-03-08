using UnityEngine;

namespace ARVR.Usable
{
    [CreateAssetMenu(fileName = "ConsumableObject", menuName = "Scriptable Objects/Usables/Consumable", order = 1)]
    public class ConsumableObject : UsableObject
    {
        #region Fields

        [Header("Health & Lifespan")]
        [SerializeField]
        public float givesHealth;

        [SerializeField]
        public float LivesInMs;

        #endregion Fields

        public override void Use()
        {
            throw new System.NotImplementedException();
        }
    }
}