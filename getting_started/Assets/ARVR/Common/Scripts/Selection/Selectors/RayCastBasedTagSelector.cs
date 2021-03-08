using UnityEngine;

namespace ARVR.Selection
{
    public class RayCastBasedTagSelector : MonoBehaviour, ISelector
    {
        [SerializeField]
        private string selectableTag = "Selectable";

        //[SerializeField]
        //private LayerMask layerMask;

        private Transform selection;

        public Transform GetSelection()
        {
            return selection;
        }

        public void Check(Ray ray)
        {
            //   Physics.Raycast(Vector3.zero, new Vector3(0, 1, 0), out hitInfo, 100, layerMask, QueryTriggerInteraction.Ignore);

            selection = null;
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                var currentSelection = hitInfo.transform;
                if (currentSelection.CompareTag(selectableTag))
                    selection = currentSelection;
            }
        }
    }
}
