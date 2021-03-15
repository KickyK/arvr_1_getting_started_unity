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

        animator.SetFloat("VelocityX", Vector3.Dot(movement.normalized, transform.right), 0.1f, Time.deltaTime);
        animator.SetFloat("VelocityZ", Vector3.Dot(movement.normalized, transform.forward), 0.1f, Time.deltaTime);

        //IsGrounded = false;
        //foreach (var groundCheck in groundChecks)
        //{
        //    if (Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer, QueryTriggerInteraction.Ignore))
        //    {
        //        IsGrounded = true;
        //        break;
        //    }
        //}
    }
}