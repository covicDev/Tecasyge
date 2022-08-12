using UnityEngine;

using _cov._Enum;

namespace _cov._CardMinion
{
    public class _CardMinionTransferModerator : MonoBehaviour, _ICardMinionTransferModerator
    {
        public _ICardMinionController _CardMinionController => this.transform.GetComponent<_CardMinionController>();

        private Transform _goldParent => this._CardMinionController._Base._CardGoldParent;

        #region --- Public method ---
        /// <summary>
        /// Transfers minion card to specified field.
        /// </summary>
        /// <param name="parent">Parent for minion card.</param>
        /// <param name="position">New position of minion card.</param>
        /// <param name="field">New field of minion card.</param>
        /// <returns></returns>
        public bool _TransferCardMinionToThisField(Transform parent, Vector3 position, _EField field)
        {
            if (field == _EField.Pile)
            {
                this._CardMinionController._Base._CardMinionFieldModerator._SetCurrentFieldTo(field);
            }

            if (field == _EField.Battlefield)
            {
                this._CardMinionController._Base._CardMinionFieldModerator._SetCurrentFieldTo(field);
            }

            this.transform.SetParent(parent);
            this.transform.position = position;

            this.transform.GetComponent<Canvas>().overrideSorting = true;
            return true;
        }

        public bool _TransferCardGoldToThisMinion(Transform goldCard)
        {
            goldCard.transform.SetParent(this._CardMinionController._Base._CardGoldParent);

            // Overriding sorting layer.
            goldCard.GetComponent<Canvas>().overrideSorting = true;
            goldCard.GetComponent<Canvas>().sortingOrder -= 1; //goldAmount;

            // Calculating the gold card offset. <todo> better calculated offset value.
            float offset = ((float)(1) * .3f); //goldAmount+1

            // Change card gold position.
            var position = this._goldParent.transform.position;
            goldCard.transform.position = new Vector3(position.x - offset, position.y, position.z);

            goldCard.transform.GetComponent<_CardGold._CardGoldController>()._Base._CurrentField = _EField.Battlefield;

            // Disable gold card.
            goldCard.transform.GetComponent<_CardGold._CardGoldMovement>().enabled = false;

            return true;
        }


        /// <summary>
        /// Checks if minion card can be transfered to specified field.
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public bool _CheckIfCardMinionCanBeTransferedToThisField(_EField field)
        {
            return true;
        }

        #endregion
    }

    public interface _ICardMinionTransferModerator
    {
        _ICardMinionController _CardMinionController { get; }
        bool _TransferCardMinionToThisField(Transform parent, Vector3 position, _EField field);
        bool _CheckIfCardMinionCanBeTransferedToThisField(_EField field);
        bool _TransferCardGoldToThisMinion(Transform goldCard);
    }
}

