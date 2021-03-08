//C# Example (LookAtPoint.cs)
using UnityEngine;

namespace ARVR.Utilities
{
    [ExecuteInEditMode]
    public class LookAtPoint : MonoBehaviour
    {
        [SerializeField]
        private Vector3 lookAtPoint = Vector3.zero;

        void Update()
        {
            transform.LookAt(lookAtPoint);
            Debug.DrawLine(transform.position, lookAtPoint);
        }
    }
}
