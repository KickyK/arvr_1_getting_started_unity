using ARVR.Enums;
using ARVR.Events;
using ARVR.ScriptableTypes;
using UnityEngine;

/// <summary>
/// Simple move player via WASD using FLoatReference and demoing GameEvent
/// </summary>
/// <see cref="https://www.youtube.com/watch?v=tNtOcDryKv4"/>
/// <seealso cref="https://www.youtube.com/watch?v=_QajrabyTJc&t=546s"/>
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //why cant we use this in the editor?
    //public VariableReference<float, FloatVariable> rotationSpeed;

    public FloatReference moveSpeed;
    public FloatReference rotationSpeed;

    public GameEvent OnDoorToggle;

    private CharacterController characterController;
    private Vector3 movementDirection;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movementDirection.Normalize();
    }

    private void FixedUpdate()
    {
        //  transform.position +=

        characterController.Move(moveSpeed.Value * new Vector3(movementDirection.z, 0, movementDirection.x) * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed.Value * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagType.Door.ToString()))
        {
            OnDoorToggle?.Raise();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(TagType.Door.ToString()))
        {
            OnDoorToggle?.Raise();
        }
    }
}