using UnityEngine;

namespace ARVR.ScriptableTypes
{
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
                return UseConstant ? ConstantValue : Variable.Value;
            }
        }
    }
}