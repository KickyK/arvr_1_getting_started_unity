using ARVR.ScriptableTypes;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    // public FloatScriptableObject rotation;
    // public BoolReference direction;

    public FloatReference rotation;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(rotation.Value * Vector3.up);
    }
}