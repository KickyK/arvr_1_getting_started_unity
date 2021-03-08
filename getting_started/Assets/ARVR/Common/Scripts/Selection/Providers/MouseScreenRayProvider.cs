using UnityEngine;

namespace ARVR.Selection
{
    public class MouseScreenRayProvider : MonoBehaviour, IRayProvider
    {
        [SerializeField]
        [Tooltip("Specify the camera to use to create the ray from camera to mouse")]
        private Camera currentCamera = null;

        [SerializeField]
        [Tooltip("Specify which camera eye (i.e. left, right, mono (non-VR)) to use when creating the ray from camera to mouse")]
        private Camera.MonoOrStereoscopicEye monoOrStereoscopicEye = Camera.MonoOrStereoscopicEye.Mono;
        
        void Awake()
        {
            if(currentCamera == null)
                currentCamera = Camera.main;
        }
        
        public Ray CreateRay()
        {
            return currentCamera.ScreenPointToRay(Input.mousePosition, monoOrStereoscopicEye); //Stereoscopic?
        }

    }
}
