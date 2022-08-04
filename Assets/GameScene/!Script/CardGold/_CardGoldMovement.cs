using UnityEngine;
using UnityEngine.EventSystems;

namespace _cov._CardGold
{
    public class _CardGoldMovement : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        public _ICardGoldController _CardGoldController => this.transform.GetComponent<_CardGoldController>();

        #region --- Variable ---
        private Camera _camera => this._CardGoldController._Base._CardGoldManager._CameraMain;
        private CanvasGroup _canvasGroup => this.transform.GetComponent<CanvasGroup>();

        #endregion

        public void OnBeginDrag(PointerEventData eventData)
        {
            this._canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            // If it is not an object.
            if (eventData?.pointerDrag == null) return;

            // Drag only when left mouse is used.
            if (Input.GetMouseButton(0))
            {
                if (_onDragCardGold) return;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            this._canvasGroup.blocksRaycasts = true;
        }

        #region --- Private method ---
        private bool _onDragCardGold
        {
            get
            {
                var data = this._camera.ScreenToWorldPoint(Input.mousePosition);
                data.z = 0f;
                this.transform.position = data;
                return true;
            }
        }
        #endregion
    }
}

