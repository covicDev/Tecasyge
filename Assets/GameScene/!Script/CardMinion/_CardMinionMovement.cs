using UnityEngine;
using UnityEngine.EventSystems;

using _cov._Enum;
using _cov._Sword;

namespace _cov._CardMinion
{
    public class _CardMinionMovement : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private _ICardMinionController _cardMinionController => this.transform.GetComponent<_ICardMinionController>();

        #region --- Variable ---
        private Camera _camera => this._cardMinionController._Base._CardMinionManager._CameraMain;
        private CanvasGroup _canvasGroup => this.transform.GetComponent<CanvasGroup>();

        private _EField _fieldBeforeBeginDrag = _EField.Null;
        #endregion


        #region --- Mouse events ---
        public void OnBeginDrag(PointerEventData eventData)
        {
            Cursor.visible = true;
            this._canvasGroup.blocksRaycasts = false;

            // Drag only when left mouse is used.
            if (Input.GetMouseButton(0))
            {
                this._fieldBeforeBeginDrag = this._cardMinionController._Base._CardMinionFieldModerator._GetCurrentField();

                if (this._onBeginDragCardMinionToFieldHand) return;
                if (this._onBeginDragCardMinionToFieldBattle) return;
                if (this._onBeginDragCardMinionAttackMode) return;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            // If it is not an object.
            if (eventData.pointerDrag == null) return;

            // Drag only when left mouse is used.
            if (Input.GetMouseButton(0))
            {
                if (_onDragCardMinionToFieldHand) return;
                if (_onDragCardMinionToFieldBattle) return;
                if (_onDragSwordAttack) return;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Cursor.visible = true;
            this._canvasGroup.blocksRaycasts = true;

            if (this._fieldBeforeBeginDrag == this._cardMinionController._Base._CardMinionFieldModerator._GetCurrentField())
            {
                this.transform.position = this.transform.parent.position;
            }

            this._cardMinionController._Base._CardMinionBackgroundModerator._SetBackgroundOfCardMinionToOriginal();
            var swordScript = this._cardMinionController._Base._CardMinionManager._SwordAttackReference.GetComponent<_SwordAttackController>();
            swordScript._HideSwordAttack();
        }

        #endregion

        #region --- Private method ---

        #region --- Card minion method ---
        // On begin drag.
        private bool _onBeginDragCardMinionToFieldHand
        {
            get
            {
                if (this._cardMinionController._Base._GameCurrentState != _EGameState.Draw) return false;
                // 
                return true;
            }
        }
        private bool _onBeginDragCardMinionToFieldBattle
        {
            get
            {
                if (this._cardMinionController._Base._GameCurrentState != _EGameState.Place) return false;
                //
                return true;
            }
        }
        private bool _onBeginDragCardMinionAttackMode
        {
            get
            {
                if (this._cardMinionController._Base._GameCurrentState != _EGameState.Attack) return false;

                // Checks if minion is on battle field and can attack others.
                if (this._cardMinionController._Base._CardMinionFieldModerator._GetCurrentField() == _EField.Battlefield)
                {
                    if (this._cardMinionController._Base._CardMinionStatsModerator._CheckIfMinionCanAttackOthers() == true)
                    {
                        var swordScript = this._cardMinionController._Base._CardMinionManager._SwordAttackReference.GetComponent<_SwordAttackController>();
                        swordScript._ShowSwordAttack();
                        Cursor.visible = false;
                    }
                }
                return true;
            }
        }


        // On drag.
        private bool _onDragCardMinionToFieldHand
        {
            get
            {
                if (this._cardMinionController._Base._GameCurrentState != _EGameState.Draw) return false;
                if (this._cardMinionController._Base._CardMinionFieldModerator.__IsCardMinionOnFieldBattle() == true) return false;

                var data = this._camera.ScreenToWorldPoint(Input.mousePosition);
                data.z = 0f;
                this.transform.position = data;

                return true;
            }
        }

        private bool _onDragCardMinionToFieldBattle
        {
            get
            {
                if (this._cardMinionController._Base._GameCurrentState != _EGameState.Place) return false;
                if (this._cardMinionController._Base._CardMinionFieldModerator.__IsCardMinionOnFieldBattle() == true) return false;

                var data = this._camera.ScreenToWorldPoint(Input.mousePosition);
                data.z = 0f;
                this.transform.position = data;

                return true;
            }
        }

        private bool _onDragSwordAttack
        {
            get
            {
                if (this._cardMinionController._Base._GameCurrentState != _EGameState.Attack) return false;
                if (this._cardMinionController._Base._CardMinionFieldModerator.__IsCardMinionOnFieldBattle() == false) return false;
                if (this._cardMinionController._Base._CardMinionStatsModerator._CheckIfMinionCanAttackOthers() == false) return false;

                var data = this._camera.ScreenToWorldPoint(Input.mousePosition);
                data.z = 0f;
                this._cardMinionController._Base._CardMinionManager._SwordAttackReference.position = data;

                return true;

            }
        }

        // On end drag.
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
