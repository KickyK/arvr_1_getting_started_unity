using UnityEngine;

namespace ARVR.ScriptableTypes
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeVector3Array", menuName = "Scriptable Objects/Collections/Array/Vector3")]
    public class RuntimeVector3Array : RuntimeArray<Vector3>
    {
    }
}