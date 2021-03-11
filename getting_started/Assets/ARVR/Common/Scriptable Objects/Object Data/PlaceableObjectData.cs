using UnityEngine;

namespace ARVR.ObjectData
{
    [CreateAssetMenu(fileName = "PlaceableObjectData", menuName = "Scriptable Objects/Object Data/Placeable")]
    public class PlaceableObjectData : BaseObjectData
    {
        //add game event here - OnDestroy, OnSpawn

        [Header("Units & Buildings")]
        [Tooltip("Type of objects attacked by this object")]
        public AttackTargetType targetType;

        [Tooltip("Attack type used by this object")]
        public AttackType attackType;

        [Tooltip("Damage inflicted by this object with each attack")]
        [Range(0, 1000)]
        public int damagePerAttack;

        [Tooltip("Range over which this unit can attack")]
        [Range(0, 1000)]
        public int attackRange;

        [Tooltip("Rate at which this unit can attack (-1 for random rate in range)")]
        [Range(0, 60000)]
        public int attackRateMs;

        [Tooltip("Audio clipped played when attacking")]
        public AudioClip attackClip;

        [Tooltip("Audio clipped played when dead")]
        public AudioClip dieClip;

        [Header("Movement")]
        [Range(0, 1000)]
        public float moveSpeed;

        [Range(0, 1000)]
        public float strafeSpeed;

        [Range(0, 1000)]
        public float rotateSpeed;
    }
}