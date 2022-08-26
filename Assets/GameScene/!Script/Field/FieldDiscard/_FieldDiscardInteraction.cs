using UnityEngine;
using UnityEngine.EventSystems;

using _cov._Struct;
namespace _cov._FieldDiscard
{
    public class _FieldDiscardInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
    {
        public _IFieldDiscardController _FieldDiscardController => this.transform.GetComponent<_FieldDiscardController>();

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData?.pointerDrag == null)
            {
                Cursor.visible = true;
                this._FieldDiscardController._Base._FieldDiscardBackgroundModerator._SetBackgroundOfFieldDiscardToOriginal();
                return;
            }

            var data = eventData.pointerDrag;

            #region --- Card minion interaction ---
            if (data.CompareTag(_SName._TagCardMinion))
            {
                var dataScript = data.transform.GetComponent<_CardMinion._CardMinionController>();
                if (dataScript._CheckIfCardMinionCanBeTransferedToThisField(this._FieldDiscardController._Base._FieldType) == false) return;

                if (this._FieldDiscardController._DestroyCardMinion(data))
                {
                    this._FieldDiscardController._Base._FieldDiscardBackgroundModerator._SetBackgroundOfFieldDiscardDenial();
                }
            }
            #endregion

            #region --- Card gold interaction ---
            if (data.CompareTag(_SName._TagCardGold))
            {
                var dataScript = data.transform.GetComponent<_CardGold._CardGoldController>();
                if (dataScript._CheckIfCardGoldCanBeTransferedToThisField(this._FieldDiscardController._Base._FieldType) == false) return;

                if (this._FieldDiscardController._DestroyCardGold(data))
                {
                    this._FieldDiscardController._Base._FieldDiscardBackgroundModerator._SetBackgroundOfFieldDiscardDenial();
                }
            }
            #endregion
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            this._FieldDiscardController._Base._FieldDiscardBackgroundModerator._SetBackgroundOfFieldDiscardToOriginal();
            this._FieldDiscardController._Base._FieldDiscardBackgroundModerator._ShowFieldDiscardShadow();

            if (eventData?.pointerDrag == null) return;

            var data = eventData.pointerDrag;

            #region --- Card minion interaction ---
            if (data.CompareTag(_SName._TagCardMinion))
            {
                var dataScript = data.transform.GetComponent<_CardMinion._CardMinionController>();
                if (dataScript._CheckIfCardMinionCanBeTransferedToThisField(this._FieldDiscardController._Base._FieldType) == false) return;

                dataScript._SetCardMinionBackgroundToGray();
                this._FieldDiscardController._Base._FieldDiscardBackgroundModerator._SetBackgroundOfFieldDiscardApproval();
            }
            #endregion

            #region --- Card gold interaction ---
            if (data.CompareTag(_SName._TagCardGold))
            {
                var dataScript = data.transform.GetComponent<_CardGold._CardGoldController>();
                if (dataScript._CheckIfCardGoldCanBeTransferedToThisField(this._FieldDiscardController._Base._FieldType) == false) return;

                data.transform.GetComponent<_CardGold._CardGoldController>()._SetCardGoldBackgroundToGray();
                this._FieldDiscardController._Base._FieldDiscardBackgroundModerator._SetBackgroundOfFieldDiscardApproval();
            }
            #endregion
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            this._FieldDiscardController._Base._FieldDiscardBackgroundModerator._SetBackgroundOfFieldDiscardToOriginal();
            this._FieldDiscardController._Base._FieldDiscardBackgroundModerator._HideFieldDiscardShadow();

            if (eventData?.pointerDrag == null) return;

            var data = eventData.pointerDrag;

            #region --- Card minion interaction ---
            if (data.CompareTag(_SName._TagCardMinion))
            {
                data.transform.GetComponent<_CardMinion._CardMinionController>()._SetCardMinionBackgroundToOriginal();
            }
            #endregion

            #region --- Card gold interaction ---
            if (data.CompareTag(_SName._TagCardGold))
            {
                data.transform.GetComponent<_CardGold._CardGoldController>()._SetCardGoldBackgroundToOriginal();
            }
            #endregion

        }
    }
}
