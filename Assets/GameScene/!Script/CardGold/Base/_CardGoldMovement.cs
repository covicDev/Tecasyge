using UnityEngine;
using UnityEngine.EventSystems;

using _cov._Enum;

namespace _cov._CardGold
{
    public class _CardGoldMovement : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        public _ICardGoldBase _Base => this.transform.GetComponent<_CardGoldBase>();

        #region --- Variable ---
        private Camera _camera => this._Base._CardGoldManager._CameraMain;
        private CanvasGroup _canvasGroup => this.transform.GetComponent<CanvasGroup>();
        private _EField _fieldBeforeBeginDrag = _EField.Null;

        #endregion

        public void OnBeginDrag(PointerEventData eventData)
        {
            this._canvasGroup.blocksRaycasts = false;

            // Get current gold card field.
            this._fieldBeforeBeginDrag = this._Base._CurrentField;
        }

        public void OnDrag(PointerEventData eventData)
        {
            // If it is not an object.
            if (eventData?.pointerDrag == null) return;

            // Drag only when left mouse is used.
            if (Input.GetMouseButton(0))
            {
                if (_onDragCardGoldToField) return;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            this._canvasGroup.blocksRaycasts = true;
    
            // If field type doesn't change then move gold card to it's parent position.
            if(this._fieldBeforeBeginDrag == this._Base._CurrentField)
            {
                this.transform.position = this.transform.parent.position;
            }
        }

        #region --- Private method ---
        private bool _onDragCardGold
        {
            get
            {
                if (this._Base._CurrentGameState != _EGameState.Draw || this._Base._CurrentGameState != _EGameState.Place) return false;

                var data = this._camera.ScreenToWorldPoint(Input.mousePosition);
                data.z = 0f;
                this.transform.position = data;
                return true;
            }
        }

        private bool _onDragCardGoldToField
        {
            get
            {
                if (this._Base._CurrentGameState != _EGameState.Draw && this._Base._CurrentGameState != _EGameState.Place) return false;

                var data = this._camera.ScreenToWorldPoint(Input.mousePosition);
                data.z = 0f;
                this.transform.position = data;

                return true;
            }
        }
        #endregion
    }
}

