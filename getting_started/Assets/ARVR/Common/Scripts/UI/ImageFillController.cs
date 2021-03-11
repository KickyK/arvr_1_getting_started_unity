using ARVR.ScriptableTypes;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Set the fill on a UI image using this controller. For example, attach to a UI health bar and set its fill state using a shared FloatReference set by the player's health
/// </summary>
/// <see cref="https://www.youtube.com/watch?v=J1ng1zA3-Pk"/>
/// <seealso cref="https://www.youtube.com/watch?v=PVOVIxNxxeQ"/>
namespace ARVR.UI
{
    [ExecuteAlways]
    public class ImageFillController : MonoBehaviour
    {
        [Tooltip("Image apon which the controller will be applied")]
        public Image Image;

        [Header("Fill Value & Min/Max Range")]
        [Tooltip("Max value of the fill from either a constant value or a scriptable object")]
        public FloatReference Maximum;

        [Tooltip("Min value of the fill from either a constant value or a scriptable object")]
        public FloatReference Minimum;

        [Tooltip("Current value of the fill from either a constant value or a scriptable object")]
        public FloatReference Current;

        [Header("Fill Type & Color")]
        [Tooltip("Specify whether to use color or gradient fill")]
        public ColorFillType ColorFillType;

        public Gradient ColorGradientFill;
        public Color ColorSolidFill;

        private void Awake()
        {
            //prevent execution unless Max > Min
            if (Maximum.Value <= Minimum.Value)
                throw new System.ArgumentException("Maximum cannot be lower than Minimum - Check FloatReference values attached to this controller!");

            if (Current.Value < Minimum.Value || Current.Value > Maximum.Value)
                throw new System.ArgumentException("Current value must be between Maximum and Minimum - Check FloatReference values attached to this controller!");
        }

        private void Update()
        {
            float fill = (Current.Value - Minimum.Value) / (Maximum.Value - Minimum.Value);

            //set color from gradient or solid based on choice
            Image.color = (ColorFillType == ColorFillType.Solid) ? ColorSolidFill : ColorGradientFill.Evaluate(fill);
            // Image.color = ColorSolidFill;

            //set fill
            Image.fillAmount = Mathf.Clamp01(fill);
        }
    }
}