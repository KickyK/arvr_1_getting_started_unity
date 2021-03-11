using UnityEngine;

/// <summary>
/// Contains a set of ScriptableObject(SO) data types (float, int, bool) and reference types that can switch between a local variable (e.g float) or reference to a shared variable (e.g. FloatVariable)
/// </summary>
namespace ARVR.ScriptableTypes
{
    #region Generic Type

    [System.Serializable]
    public abstract class ScriptableDataType<T> : ScriptableObject
    {
        [Header("Value")]
        [ContextMenuItem("Reset Score", "ResetValue")]
        public T Value;

        [Header("Description (optional)")]
        [ContextMenuItem("Reset Name", "ResetName")]
        public string Name;

        [TextArea(3, 5)]
        [ContextMenuItem("Reset Description", "ResetDescription")]
        public string Description;

        public virtual void ResetName()
        {
            Name = "";
        }

        public virtual void ResetDescription()
        {
            Description = "";
        }

        public virtual void ResetValue()
        {
            Value = default(T);
        }
    }

    #endregion Generic Type

    #region Concrete Types

    [CreateAssetMenu(fileName = "BoolVariable", menuName = "Scriptable Objects/Variables/Bool", order = 1)]
    public class BoolVariable : ScriptableDataType<bool>
    {
    }

    [CreateAssetMenu(fileName = "FloatVariable", menuName = "Scriptable Objects/Variables/Float", order = 2)]
    public class FloatVariable : ScriptableDataType<float>
    {
    }

    [CreateAssetMenu(fileName = "GameObjectVariable", menuName = "Scriptable Objects/Variables/Game Object", order = 3)]
    public class GameObjectVariable : ScriptableDataType<GameObject>
    {
    }

    [CreateAssetMenu(fileName = "IntVariable", menuName = "Scriptable Objects/Variables/Int", order = 4)]
    public class IntVariable : ScriptableDataType<int>
    {
    }

    [CreateAssetMenu(fileName = "StringVariable", menuName = "Scriptable Objects/Variables/String", order = 5)]
    public class StringVariable : ScriptableDataType<string>
    {
    }

    [CreateAssetMenu(fileName = "TransformVariable", menuName = "Scriptable Objects/Variables/Transform", order = 6)]
    public class TransformVariable : ScriptableDataType<Transform>
    {
    }

    #endregion Concrete Types

    #region Reference Types

    [System.Serializable]
    public class BoolReference
    {
        public bool UseConstant = true;
        public bool ConstantValue;
        public BoolVariable Variable;

        public bool Value
        {
            get
            {
                return UseConstant ? ConstantValue : Variable.Value;
            }
        }
    }

    [System.Serializable]
    public class FloatReference
    {
        public bool UseConstant = true;
        public float ConstantValue;
        public FloatVariable Variable;

        public float Value
        {
            get
            {
                return UseConstant ? ConstantValue : Variable.Value;
            }
        }
    }

    [System.Serializable]
    public class GameObjectReference
    {
        public bool UseConstant = true;
        public GameObject ConstantValue;
        public GameObjectVariable Variable;

        public GameObject Value
        {
            get
            {
                return UseConstant ? ConstantValue : Variable.Value;
            }
        }
    }

    [System.Serializable]
    public class IntReference
    {
        public bool UseConstant = true;
        public int ConstantValue;
        public IntVariable Variable;

        public int Value
        {
            get
            {
                return UseConstant ? ConstantValue : Variable.Value;
            }
        }
    }

    [System.Serializable]
    public class StringReference
    {
        public bool UseConstant = true;
        public string ConstantValue;
        public StringVariable Variable;

        public string Value
        {
            get
            {
                return UseConstant ? ConstantValue : Variable.Value;
            }
        }
    }

    [System.Serializable]
    public class TransformReference
    {
        public bool UseConstant = true;
        public Transform ConstantValue;
        public TransformVariable Variable;

        public Transform Value
        {
            get
            {
                return UseConstant ? ConstantValue : Variable.Value;
            }
        }
    }

    #endregion Reference Types
}