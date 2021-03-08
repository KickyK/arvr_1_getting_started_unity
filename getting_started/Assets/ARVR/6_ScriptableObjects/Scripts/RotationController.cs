using ARVR.ScriptableTypes;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    // public FloatScriptableObject rotation;
    public FloatReference rotation;

    public BoolReference direction;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(rotation.Value * Vector3.up);
    }
}