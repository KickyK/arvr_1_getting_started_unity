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
        [ContextMenuItem("Reset Value", "ResetValue")]
        public T Value;

        [Header("Description (optional)")]
        [ContextMenuItem("Reset Name", "ResetName")]
        public string Name;

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

    #region Reference Types
    //Generic type to replace BoolReference, IntReference etc

    [System.Serializable]
    public class VariableReference<T, V> where V : ScriptableDataType<T>
    {
        public bool UseConstant = true;
        public T ConstantValue;
        public V Variable;

        public T Value
        {
            get
            {
                return UseConstant ? ConstantValue : Variable.Value;
            }
        }
    }

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

    [System.Serializable]
    public class Vector3Reference
    {
        public bool UseConstant = true;
        public Vector3 ConstantValue;
        public Vector3Variable Variable;

        public Vector3 Value
        {
            get
            {
                return UseConstant ? ConstantValue : Variable.Value;
            }
        }
    }

    #endregion Reference Types
}