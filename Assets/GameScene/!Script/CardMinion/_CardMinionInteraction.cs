using UnityEngine;
using UnityEngine.EventSystems;

using _cov._Struct;

namespace _cov._CardMinion
{
   // [RequireComponent(typeof(_CardMinionController))]
    public class _CardMinionInteraction : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public _ICardMinionController _CardMinionController => this.transform.GetComponent<_CardMinionController>();

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData?.pointerDrag == null) return;

            // Gold card interaction.
            if (eventData.pointerDrag.CompareTag(_SName._TagCardGold))
            {
                if (this._cardGoldInteraction())
                {
                    var cardGold = eventData.pointerDrag.transform;
                    this._CardMinionController._Base._CardMinionTransferModerator._TransferCardGoldToThisMinion(cardGold);
                    this._CardMinionController._Base._CardMinionBackgroundModerator._SetBackgroundOfCardMinionToOriginal();
                }
            }

        }

        #region --- Mouse over action ---
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData?.pointerDrag == null)
            {
                this._CardMinionController._Base._CardMinionBackgroundModerator._ShowCardMinionShadow();
                return;
            }

            // Gold card interaction.
            if (eventData.pointerDrag.CompareTag(_SName._TagCardGold))
            {
                if (this._cardGoldInteraction())
                {
                    this._CardMinionController._Base._CardMinionBackgroundModerator._SetBackgroundOfCardMinionApproval();
                }
                else
                {
                    this._CardMinionController._Base._CardMinionBackgroundModerator._SetBackgroundOfCardMinionDenial();
                }
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            this._CardMinionController._Base._CardMinionBackgroundModerator._HideCardMinionShadow();
            this._CardMinionController._Base._CardMinionBackgroundModerator._SetBackgroundOfCardMinionToOriginal();
        }

        #endregion

        #region --- Private method ---
        private bool _cardGoldInteraction()
        {
            return this._CardMinionController._Base._CardMinionStatsModerator._CheckIfGoldCardCanBeGivenToThisMinion();
        }

        #endregion

    }
}
