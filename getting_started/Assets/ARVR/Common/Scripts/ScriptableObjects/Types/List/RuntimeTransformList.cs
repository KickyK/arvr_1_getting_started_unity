using UnityEngine;

namespace ARVR.ScriptableTypes
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeTransformList", menuName = "Scriptable Objects/Collections/List/Transform", order = 5)]
    public class RuntimeTransformList : RuntimeList<Transform>
    {
    }
}