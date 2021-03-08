using UnityEngine;

namespace ARVR.Usable
{
    [CreateAssetMenu(fileName = "StoryObject", menuName = "Scriptable Objects/Usables/Story", order = 2)]
    public class StoryObject : UsableObject
    {
        [SerializeField]
        private int requiredLevel;

        public override void Use()
        {
            throw new System.NotImplementedException();
        }
    }
}