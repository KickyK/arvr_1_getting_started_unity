using ARVR.Enums;
using ARVR.Events;
using UnityEngine;

public class AnimatedCharacterController : MonoBehaviour
{
    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private Transform[] groundChecks;

    [SerializeField]
    private float speed = 1.25f;

    private CharacterController characterController;
    private Animator animator;
    private bool IsGrounded;
    private Vector3 movement;
    //   public GameEvent OnDoorToggle;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        if (movement.magnitude > 0)
        {
            movement.Normalize();
            movement *= speed * Time.deltaTime;
            characterController.Move(movement);
        }

        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 0.01f * Time.deltaTime);
        }

        animator.SetFloat("VelocityX", Vector3.Dot(movement.normalized, transform.right), 0.1f, Time.deltaTime);
        animator.SetFloat("VelocityZ", Vector3.Dot(movement.normalized, transform.forward), 0.1f, Time.deltaTime);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag(TagType.Door.ToString()))
    //    {
    //        OnDoorToggle?.Raise();
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag(TagType.Door.ToString()))
    //    {
    //        OnDoorToggle?.Raise();
    //    }
    //}
}