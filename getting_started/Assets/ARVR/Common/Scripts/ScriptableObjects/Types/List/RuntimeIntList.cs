using UnityEngine;

namespace ARVR.ScriptableTypes
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeIntList", menuName = "Scriptable Objects/Collections/List/Int")]
    public class RuntimeIntList : RuntimeList<string>
    {
    }
}