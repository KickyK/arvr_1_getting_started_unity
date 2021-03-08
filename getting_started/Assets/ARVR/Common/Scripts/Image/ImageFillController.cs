using ARVR.ScriptableTypes;
using UnityEngine;
using UnityEngine.UI;

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