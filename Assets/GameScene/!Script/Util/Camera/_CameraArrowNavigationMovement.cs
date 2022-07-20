using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _cov._Util._Camera
{
    public class _CameraArrowNavigationMovement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        #region --- Variable ---
        // Camera controller reference.
        private _CameraController _cameraControllerRef => GameObject.Find("GameManager").transform.GetComponent<_CameraController>();

        private bool __onHover = false;
        #endregion

        #region --- Default method ---
        
        #endregion

        public void OnPointerEnter(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}
