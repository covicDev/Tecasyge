using UnityEngine;
using UnityEngine.EventSystems;

using _cov._Struct;

namespace _cov._FieldHand
{
    public class _FieldHandInteraction : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public _IFieldHandController _FieldHandController => this.transform.GetComponent<_FieldHandController>();

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData?.pointerDrag == null)
            {
                return;
            }
            // Card minion interaction.
            if (eventData.pointerDrag.CompareTag(_SName._TagCardMinion))
            {
                // Checks if there is any free hand slot.
                if (this._FieldHandController._Base._FieldHandSlotModerator.__CheckIsThereAnyFieldHandSlotFree() == false) return;


                var cardMinion = eventData.pointerDrag.transform.GetComponent<_cov._CardMinion._CardMinionController>();
                if (cardMinion._CheckIfCardMinionCanBeTransferedToThisField(this._FieldHandController._FieldType) == false) return;

                var parent = this._FieldHandController._Base._FieldHandSlotModerator._GetNextFreeFieldHandSlotAddonTranform();
                cardMinion._TransferCardMinionToThisField(parent, parent.position, this._FieldHandController._FieldType);
            }

            // Card gold interaction.
            if (eventData.pointerDrag.CompareTag(_SName._TagCardGold))
            {
                // Checks if there is any free hand slot.
                if (this._FieldHandController._Base._FieldHandSlotModerator.__CheckIsThereAnyFieldHandSlotFree() == false) return;

                var cardGold = eventData.pointerDrag.transform.GetComponent<_cov._CardGold._CardGoldController>();
                if (cardGold._CheckIfCardGoldCanBeTransferedToThisField(this._FieldHandController._FieldType) == false) return;

                var parent = this._FieldHandController._Base._FieldHandSlotModerator._GetNextFreeFieldHandSlotAddonTranform();
                cardGold._TransferCardGoldToThisField(parent, parent.position, this._FieldHandController._FieldType);
                cardGold.transform.GetComponent<Canvas>().overrideSorting = false;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData?.pointerDrag == null)
            {
                Cursor.visible = true;
                return;
            }

            // Card minion interaction.
            if (eventData.pointerDrag.CompareTag(_SName._TagCardMinion))
            {
                // Checks if there is any free hand slot.
                if (this._FieldHandController._Base._FieldHandSlotModerator.__CheckIsThereAnyFieldHandSlotFree() == false)
                {
                    this._FieldHandController._Base._FieldHandBackgroundModerator._SetBackgroundOfFieldHandDenial();
                    return;
                }
                
                // Checks if minion can be transfered to this field.
                var cardMinion = eventData.pointerDrag.transform.GetComponent<_cov._CardMinion._CardMinionController>();

                if (cardMinion._CheckIfCardMinionCanBeTransferedToThisField(this._FieldHandController._FieldType) == true)
                {
                    this._FieldHandController._Base._FieldHandBackgroundModerator._SetBackgroundOfFieldHandApproval();
                    return;
                }
                this._FieldHandController._Base._FieldHandBackgroundModerator._SetBackgroundOfFieldHandDenial();
            }

            // Card gold interaction.
            if (eventData.pointerDrag.CompareTag(_SName._TagCardGold))
            {
                // Checks if there is any free hand slot.
                if (this._FieldHandController._Base._FieldHandSlotModerator.__CheckIsThereAnyFieldHandSlotFree() == false)
                {
                    this._FieldHandController._Base._FieldHandBackgroundModerator._SetBackgroundOfFieldHandDenial();
                    return;
                }

                // Checks if gold card can be transfered to this field.
                var cardGold = eventData.pointerDrag.transform.GetComponent<_cov._CardGold._CardGoldController>();

                if (cardGold._CheckIfCardGoldCanBeTransferedToThisField(this._FieldHandController._FieldType) == true)
                {
                    this._FieldHandController._Base._FieldHandBackgroundModerator._SetBackgroundOfFieldHandApproval();
                    return;
                }
                this._FieldHandController._Base._FieldHandBackgroundModerator._SetBackgroundOfFieldHandDenial();
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            this._FieldHandController._Base._FieldHandBackgroundModerator._SetBackgroundOfFieldHandToOriginal();

            if (eventData?.pointerDrag == null)
            {
                return;
            }

        }
    }
}
