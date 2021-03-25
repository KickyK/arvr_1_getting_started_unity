using UnityEngine;

namespace ARVR.ScriptableTypes
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeGameObjectList", menuName = "Scriptable Objects/Collections/List/Game Object")]
    public class RuntimeGameObjectList : RuntimeList<GameObject>
    {
    }
}