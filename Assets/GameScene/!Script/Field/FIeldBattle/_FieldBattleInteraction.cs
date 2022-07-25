using UnityEngine;
using UnityEngine.EventSystems;

using _cov._Struct;

namespace _cov._FieldBattle
{
    [RequireComponent(typeof(_FieldBattleController))]
    public class _FieldBattleInteraction : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public _IFieldBattleController _fieldBattleController => this.transform.GetComponent<_FieldBattleController>();

        private Transform _parentForCard => this.transform.Find(_SFieldBattleName._AddonName).transform;

        #region --- Drop action ---
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData?.pointerDrag == null) return;

            // if field is bought

            // Card minion action.
            if (eventData.pointerDrag.CompareTag(_SName._TagCardMinion))
            {
                var cardMinion = eventData.pointerDrag.transform.GetComponent<_cov._CardMinion._CardMinionController>();

                // Check if card can be transferred?
                if (cardMinion._CheckIfCardMinionCanBeTransferedToThisField(this._fieldBattleController._FieldType) == false) return;

                // Transfer minion card.
                if (cardMinion._TransferCardMinionToThisField(this._parentForCard, this.transform.position, this._fieldBattleController._FieldType))
                {
                    // Disable this script.
                    this.enabled = false;
                }
            }
        }

        #endregion

        #region --- Mouse over action ---
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData?.pointerDrag == null)
            {
                _fieldBattleController._Base._FieldBattleBackgorundModerator._ShowFieldBattleShadow();
                return;
            }

            // if field is bought

            // Card minion action.
            if (eventData.pointerDrag.CompareTag(_SName._TagCardMinion))
            {
                var cardMinion = eventData.pointerDrag.transform.GetComponent<_cov._CardMinion._CardMinionController>();
                if (cardMinion._CheckIfCardMinionCanBeTransferedToThisField(this._fieldBattleController._FieldType))
                {
                    this._fieldBattleController._Base._FieldBattleBackgorundModerator._SetBackgroundOfFieldBattleApproval();
                }
            }

        }

        public void OnPointerExit(PointerEventData eventData)
        {

            _fieldBattleController._Base._FieldBattleBackgorundModerator._HideFieldBattleShadow();
            _fieldBattleController._Base._FieldBattleBackgorundModerator._SetBackgroundOfFieldBattleToOriginal();
        }

        #endregion

        #region --- Private method ---

        #endregion
    }
}
