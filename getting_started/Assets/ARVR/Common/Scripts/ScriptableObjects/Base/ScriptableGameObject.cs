using UnityEngine;

namespace ARVR.ScriptableTypes
{
    public class ScriptableGameObject : ScriptableObject
    {
        [Header("Description (optional)")]
        [ContextMenuItem("Reset Name", "ResetName")]
        public string Name;

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
    }
}