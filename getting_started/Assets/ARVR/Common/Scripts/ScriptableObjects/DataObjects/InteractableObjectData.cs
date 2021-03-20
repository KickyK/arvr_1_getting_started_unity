using UnityEngine;

namespace ARVR.ObjectData
{
    [CreateAssetMenu(fileName = "InteractableObjectData", menuName = "Scriptable Objects/Object Data/Interactable")]
    public class InteractableObjectData : BaseObjectData
    {
        //add game event here - OnSpawn, OnUse

        [Header("Visual & Audio")]
        [Tooltip("Icon used when interactable is shown in UI (e.g. inventory)")]
        public Sprite UIIcon;

        [Tooltip("Audio clipped played when interactable is picked up")]
        public AudioClip PickupClip;

        [Tooltip("Audio clipped played when interactable is dropped")]
        public AudioClip DropClip;

        [Tooltip("Audio clipped played when interactable is used")]
        public AudioClip UseClip;

        [Header("Life & Respawn")]
        [Tooltip("Amount of time before a visible unused item is removed (-1 = no removal)")]
        public float LivesForMs;

        [Tooltip("Amount of time until respawn following consumption (-1 = respawn never, 0 = respawn immediate)")]
        public float RespawnEveryMs;
    }
}