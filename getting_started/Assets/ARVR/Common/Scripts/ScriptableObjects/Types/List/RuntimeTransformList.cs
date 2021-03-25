using UnityEngine;

namespace ARVR.ScriptableTypes
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeTransformList", menuName = "Scriptable Objects/Collections/List/Transform")]
    public class RuntimeTransformList : RuntimeList<Transform>
    {
    }
}