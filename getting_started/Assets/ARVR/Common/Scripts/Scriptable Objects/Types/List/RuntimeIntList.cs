using UnityEngine;

namespace ARVR.ScriptableTypes
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeIntList", menuName = "Scriptable Objects/Collections/List/Int", order = 1)]
    public class RuntimeIntList : RuntimeList<string>
    {
    }
}