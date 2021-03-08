using UnityEngine;

namespace ARVR.ScriptableTypes
{
    //ARVR/Common/Scriptable Objects/Types/ExtendedTypes.cs
    //bool => BoolReference, BoolVariable

    [CreateAssetMenu]
    public class BoolVariable : ScriptableObject
    {
        public bool Value;
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
                return UseConstant == true ? ConstantValue : Variable.Value;
            }
        }
    }

    [CreateAssetMenu(fileName = "FloatVariable", menuName = "Scriptable Objects/Variables/Float")]
    public class FloatVariable : ScriptableObject
    {
        public float Value;
    }

    [System.Serializable]
    public class FloatReference
    {
        [Tooltip("Use the constant value local to the script?")]
        public bool UseConstant = true;

        [Tooltip("Literal non-shared variable")]
        public float ConstantValue;

        [Tooltip("Reference to a shared variable")]
        public FloatVariable Variable;

        public float Value
        {
            get
            {
                return UseConstant == true ? ConstantValue : Variable.Value;
            }
        }
    }
}