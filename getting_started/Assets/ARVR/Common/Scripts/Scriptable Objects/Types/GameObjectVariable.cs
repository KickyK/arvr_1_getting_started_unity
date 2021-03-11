using UnityEngine;

namespace ARVR.ScriptableTypes
{
    [CreateAssetMenu(fileName = "GameObjectVariable", menuName = "Scriptable Objects/Variables/Game Object", order = 3)]
    public class GameObjectVariable : ScriptableDataType<GameObject>
    {
    }
}