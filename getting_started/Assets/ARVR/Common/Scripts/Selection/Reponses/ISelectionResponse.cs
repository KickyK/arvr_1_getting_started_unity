using UnityEngine;

namespace ARVR.Selection
{
    public interface ISelectionResponse
    {
        void OnSelect(Transform transform);
        void OnDeselect(Transform transform);
    }
}
