using UnityEngine;

using _cov._Enum;

namespace _cov._CardMinion
{
    public class _CardMinionTransferModerator : MonoBehaviour, _ICardMinionTransferModerator
    {
        public _ICardMinionBase _CardMinionBase => this.transform.GetComponent<_CardMinionBase>();

        private Transform _goldParent => this._CardMinionBase._CardGoldParent;

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
                this._CardMinionBase._CardMinionFieldModerator._SetCurrentFieldTo(field);
            }

            if( field == _EField.Hand)
            {
                this._CardMinionBase._CardMinionFieldModerator._SetCurrentFieldTo(field);
            }

            // Minion goes to battle field.
            if (field == _EField.Battlefield)
            {
                this._CardMinionBase._CardMinionFieldModerator._SetCurrentFieldTo(field);
                this._CardMinionBase._CardMinionStatsModerator._UpdateCardMinionStats();
                this._CardMinionBase._CardMinionGraphicAdapter._Render();
            }

            this.transform.SetParent(parent);
            this.transform.position = position;

           // this.transform.GetComponent<Canvas>().overrideSorting = true;
            return true;
        }


        /// <summary>
        /// Checks if minion card can be transfered to specified field.
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public bool _CheckIfCardMinionCanBeTransferedToThisField(_EField field)
        {
            // Check if minion card can be move to hand field.
            if (field == _EField.Hand)
            {
                if (this._CardMinionBase._GameCurrentState != _EGameState.Draw) return false;
                if (this._CardMinionBase._CardMinionFieldModerator._GetCurrentField() != _EField.Pile) return false;
                return true;
            }

            // Check if minion can be move to battle field.
            if(field == _EField.Battlefield)
            {
                if (this._CardMinionBase._GameCurrentState != _EGameState.Place) return false;
                if (this._CardMinionBase._CardMinionFieldModerator._GetCurrentField() != _EField.Hand) return false;
                if (this._CardMinionBase._CardMinionFieldModerator.__IsCardMinionOnFieldBattle()) return false;
                return true;
            }

            // Check if minion can be move to discard field.
            if( field == _EField.Discard)
            {
                if (this._CardMinionBase._GameCurrentState != _EGameState.Draw && this._CardMinionBase._GameCurrentState != _EGameState.Place) return false;
                if (this._CardMinionBase._CardMinionFieldModerator._GetCurrentField() != _EField.Hand) return false;
                return true;
            }

            return false;
        }

        #endregion
    }

    public interface _ICardMinionTransferModerator
    {
        _ICardMinionBase _CardMinionBase { get; }
        bool _TransferCardMinionToThisField(Transform parent, Vector3 position, _EField field);
        bool _CheckIfCardMinionCanBeTransferedToThisField(_EField field);
    }
}

