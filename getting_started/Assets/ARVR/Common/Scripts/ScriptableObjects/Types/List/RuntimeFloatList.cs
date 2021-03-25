using UnityEngine;

namespace ARVR.ScriptableTypes
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeFloatList", menuName = "Scriptable Objects/Collections/List/Float")]
    public class RuntimeFloatList : RuntimeList<string>
    {
    }
}