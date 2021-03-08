using UnityEngine;

namespace ARVR.Selection
{
    public class SelectionManager_OLD : MonoBehaviour
    {
        [SerializeField]
        private ISelectionResponse selectionResponse;

        [SerializeField]
        private string selectableTag = "Selectable";

        [SerializeField]
        private Color selectedColor = Color.green;

        private Transform selection;
        private Color originalColor;

        void Awake()
        {
            selectableTag = selectableTag.Trim();
        }


        // Update is called once per frame
        void Update()
        {
            selectionResponse.OnDeselect(transform);

            // get new selection
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                var currentSelection = hitInfo.transform;
                if (currentSelection.CompareTag(selectableTag))
                {
                    selection = currentSelection;
                    originalColor = selection.GetComponent<Renderer>().material.color;
                }
            }

            // set color of new selection
            selectionResponse.OnSelect(transform);
        }
    }
}
