using UnityEngine;

namespace ARVR.ScriptableTypes
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeTransformArray", menuName = "Scriptable Objects/Collections/Array/Transform")]
    public class RuntimeTransformArray : RuntimeArray<Transform>
    {
    }
}