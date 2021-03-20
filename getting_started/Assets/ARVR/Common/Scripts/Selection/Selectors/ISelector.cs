using UnityEngine;

namespace ARVR.Selection
{
    public interface ISelector
    {
        void Check(Ray ray);

        Transform GetSelection();
    }
}