using UnityEngine;

namespace ARVR.ScriptableTypes
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeStringList", menuName = "Scriptable Objects/Collections/List/String")]
    public class RuntimeStringList : RuntimeList<string>
    {
    }
}