using UnityEngine;

namespace ARVR.ScriptableTypes
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeFloatList", menuName = "Scriptable Objects/Collections/List/Float", order = 2)]
    public class RuntimeFloatList : RuntimeList<string>
    {
    }
}