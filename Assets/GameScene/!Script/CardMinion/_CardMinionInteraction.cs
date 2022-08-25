using UnityEngine;
using UnityEngine.EventSystems;

using _cov._Struct;

namespace _cov._CardMinion
{
   // [RequireComponent(typeof(_CardMinionController))]
    public class _CardMinionInteraction : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public _ICardMinionController _CardMinionController => this.transform.GetComponent<_CardMinionController>();

        private float _cardGoldXJumpPosition => this._CardMinionController._Base._CardMinionManager._CardGoldXJumpPosition;

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData?.pointerDrag == null) return;

            // Gold card interaction.
            if (eventData.pointerDrag.CompareTag(_SName._TagCardGold))
            {
                if (this._cardGoldInteraction())
                {
                    var goldCardParent = this._CardMinionController._Base._CardGoldParent;

                    // Calculating the gold card offset.     
                    int cardGoldAmount = this._CardMinionController._Base._CardMinionStatsModerator._GetCardGoldAmount();
                    float offset = ((float)(cardGoldAmount) * _cardGoldXJumpPosition) + _cardGoldXJumpPosition;

                    // Change card gold position.
                    var goldCardParentPosition = goldCardParent.transform.position;
                    var position = new Vector3(goldCardParentPosition.x - offset, goldCardParentPosition.y, goldCardParentPosition.z);

                    var cardGold = eventData.pointerDrag.transform;
                    var cardGoldScript = cardGold.GetComponent<_CardGold._CardGoldController>();
                    cardGoldScript._TransferCardGoldToThisField(
                        this._CardMinionController._Base._CardGoldParent,
                        position,
                        this._CardMinionController._Base._CardMinionFieldModerator._GetCurrentField()
                        );

                    // Overriding sorting layer.
                    cardGold.GetComponent<Canvas>().overrideSorting = true;
                    cardGold.GetComponent<Canvas>().sortingOrder -= (int)offset;

                    // Disable card gold movement.
                    cardGoldScript._DisableCardGoldMovementAndInteraction();

                    // Update stats.
                    this._CardMinionController._Base._CardMinionStatsModerator._UpdateCardMinionStats();

                    // Update rendering.
                    this._CardMinionController._Base._CardMinionGraphicAdapter._Render();

                    // Reset card minion background.
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
