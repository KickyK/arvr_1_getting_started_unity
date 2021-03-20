using UnityEngine;

namespace ARVR.Selection
{
    public class RayCastSelector : MonoBehaviour, ISelector
    {
        [SerializeField]
        private string selectableTag = "Selectable";

        [SerializeField]
        private LayerMask layerMask;

        [SerializeField]
        [Range(0, 1000)]
        private float maxDistance = 100;

        private Transform selection;

        public Transform GetSelection()
        {
            return selection;
        }

        public void Check(Ray ray)
        {
            selection = null;
            if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance, layerMask.value))
            {
                var currentSelection = hitInfo.transform;
                if (currentSelection.CompareTag(selectableTag))
                    selection = currentSelection;
            }
        }
    }
}