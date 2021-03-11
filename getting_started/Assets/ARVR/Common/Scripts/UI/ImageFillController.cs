using ARVR.ScriptableTypes;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Set the fill on a UI image using this controller. For example, attach to a UI health bar and set its fill state using a shared FloatReference set by the player's health
/// </summary>
namespace ARVR.UI
{
    public class ImageFillController : MonoBehaviour
    {
        public FloatReference Variable;
        public FloatReference Max;
        public Image Image;

        private void Update()
        {
            Image.fillAmount = Mathf.Clamp01(Variable.Value / Max.Value);
        }
    }
}