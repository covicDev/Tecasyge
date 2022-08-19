using UnityEngine;
using UnityEngine.EventSystems;

using _cov._Enum;

namespace _cov._CardMinion
{
    //[RequireComponent(typeof(_CardMinionController))]
    public class _CardMinionMovement : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        public _ICardMinionController _cardMinionController => this.transform.GetComponent<_CardMinionController>();

        #region --- Variable ---
        private Camera _camera => this._cardMinionController._Base._CardMinionManager._CameraMain;
        private CanvasGroup _canvasGroup => this.transform.GetComponent<CanvasGroup>();

        private _EField _fieldBeforeBeginDrag = _EField.Null;
        #endregion

        #region --- Mouse events ---
        public void OnBeginDrag(PointerEventData eventData)
        {
            // Cursor.visible = false;
            this._canvasGroup.blocksRaycasts = false;

            // Drag only when left mouse is used.
            if (Input.GetMouseButton(0))
            {
                this._fieldBeforeBeginDrag = this._cardMinionController._Base._CardMinionFieldModerator._GetCurrentField();
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            // If it is not an object.
            if (eventData.pointerDrag == null) return;

            // Drag only when left mouse is used.
            if (Input.GetMouseButton(0))
            {
                if (_onDragCardMinion) return;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            // Cursor.visible = true;
            this._canvasGroup.blocksRaycasts = true;

            if(this._fieldBeforeBeginDrag == this._cardMinionController._Base._CardMinionFieldModerator._GetCurrentField())
            {
                this.transform.position = this.transform.parent.position;
            }
        }

        #endregion

        #region --- Private method ---

        #region --- Card minion method ---
        private bool _onBeginDragCardMinion
        {
            get
            {
                return true;
            }
        }

        private bool _onDragCardMinion
        {
            get
            {
                // if card minion on field battle -> return.
                if (this._cardMinionController._Base._CardMinionFieldModerator.__IsCardMinionOnFieldBattle()) return true;

                var data = this._camera.ScreenToWorldPoint(Input.mousePosition);
                data.z = 0f;
                this.transform.position = data;
                
                return true;
            }
        }

        private bool _onEndDragCardMinion
        {
            get
            {
                return true;
            }
        }

        #endregion

        #endregion

    }
}
