using UnityEngine;

namespace ARVR.Selection
{
    public class SelectionManager : MonoBehaviour
    {
        private IRayProvider rayProvider;                   //creating a ray
        private ISelector selector;                         //determining what the ray intersects
        private ISelectionResponse selectionResponse;       //selects/deselects the object

        private Transform currectSelection;

        private void Awake()
        {
            rayProvider = GetComponent<IRayProvider>();
            selector = GetComponent<ISelector>();
            selectionResponse = GetComponent<ISelectionResponse>();
        }

        // Update is called once per frame
        void Update()
        {
            if (currectSelection != null)
            {
                selectionResponse.OnDeselect(currectSelection);
            }

            selector.Check(rayProvider.CreateRay());
            currectSelection = selector.GetSelection();

            if (currectSelection != null)
            {
                selectionResponse.OnSelect(currectSelection);
            }
        }
    }
}
