using UnityEngine;

public enum DoorStateType : sbyte
{
    Closed, Opening, Open, Closing
}

[ExecuteAlways]
public class DoorController : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 5)]
    private float displacementSpeed = 0.25f;

    [SerializeField]
    [Range(0.01f, 5)]
    private float maxDisplacement = 1;

    [SerializeField]
    private Vector3 displacementDirection = Vector3.up;

    private float currentDisplacement;
    private bool IsToggleRequest;
    private Vector3 displacedPosition;
    private DoorStateType doorState;

    private void Awake()
    {
        displacedPosition.Normalize();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckMovementRequestedAndAllowed();

        ApplyMovement();

        CheckMovementCompleted();
    }

    public void HandleDoorToggle()
    {
        //can you find a bug in the implementation?
        IsToggleRequest = !IsToggleRequest;
    }

    private void ApplyMovement()
    {
        if (doorState == DoorStateType.Opening && currentDisplacement < maxDisplacement)
        {
            currentDisplacement += displacementSpeed;
            transform.position = displacedPosition + displacementDirection * currentDisplacement;
        }
        else if (doorState == DoorStateType.Closing && currentDisplacement < maxDisplacement)
        {
            currentDisplacement += displacementSpeed;
            transform.position = displacedPosition - displacementDirection * currentDisplacement;
        }
    }

    private void CheckMovementRequestedAndAllowed()
    {
        if (doorState == DoorStateType.Closed && IsToggleRequest)
        {
            doorState = DoorStateType.Opening;
            displacedPosition = transform.position;
        }
        else if (doorState == DoorStateType.Open && IsToggleRequest)
        {
            doorState = DoorStateType.Closing;
            displacedPosition = transform.position;
        }
    }

    private void CheckMovementCompleted()
    {
        if (doorState == DoorStateType.Opening && currentDisplacement >= maxDisplacement)
        {
            IsToggleRequest = false;
            doorState = DoorStateType.Open;
            currentDisplacement = 0;
        }
        else if (doorState == DoorStateType.Closing && currentDisplacement >= maxDisplacement)
        {
            IsToggleRequest = false;
            doorState = DoorStateType.Closed;
            currentDisplacement = 0;
        }
    }
}