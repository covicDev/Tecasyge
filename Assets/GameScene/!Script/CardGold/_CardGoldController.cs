using UnityEngine;

using _cov._Enum;
using _cov._GameState;

namespace _cov._CardGold
{
    public class _CardGoldController : MonoBehaviour, _ICardGoldController, _IGameStateHandler
    {
        public _ICardGoldBase _Base => this.transform.GetComponent<_CardGoldBase>();

        private void Start()
        {
            // Attach as a Game state handler.
            var gameStateController = this._Base._GameManager.GetComponentInChildren<_GameStateController>();
            gameStateController._Attach(this);
            this._Base._CurrentGameState = gameStateController._GameCurrentState;
        }

        private void OnDestroy()
        {
            // Detach as a Game state handler.
            GameObject.Find("GameManager").transform.GetComponentInChildren<_GameStateController>()._Detach(this);
        }

        #region --- Public method ---
        public bool _TransferCardGoldToThisField(Transform parent, Vector3 position, _EField field)
        {

            this.transform.SetParent(parent);
            this.transform.position = position;

            this._Base._CurrentField = field;

            return true;
        }

        public bool _CheckIfCardGoldCanBeTransferedToThisField(_EField field)
        {
            // Check if minion card can be move to hand field.
            if (field == _EField.Hand)
            {
                if (this._Base._CurrentGameState != _EGameState.Draw) return false;
                if (this._Base._CurrentField != _EField.Pile) return false;
                return true;
            }

            // Check if minion can be move to discard field.
            if (field == _EField.Discard)
            {
                if (this._Base._CurrentGameState != _EGameState.Draw && this._Base._CurrentGameState != _EGameState.Place) return false;
                if (this._Base._CurrentField != _EField.Hand) return false;
                return true;
            }

            return false;
        }

        public bool _DiscardCardGold()
        {
          //  this._Base._GameManager.GetComponentInChildren<_GameStateController>()._Detach(this);
            Destroy(this.gameObject);
            return true;
        }


        public void _DisableCardGoldMovementAndInteraction()
        {
            this.transform.GetComponent<_CardGoldMovement>().enabled = false;
            this.transform.GetComponent<_CardGoldInteraction>().enabled = false;
        }

        // As a handler.
        public void _UpdateGameStatus(_EGameState currentGameState)
        {
            this._Base._CurrentGameState = currentGameState;
        }

        // Get

        // Set
        public void _SetCardGoldMovementDisable() => this.transform.GetComponent<_CardGoldMovement>().enabled = false;
        public void _SetCardGoldBackgroundToGray() => this._Base._CardGoldBackgroundModerator._SetBackgroundOfCardGoldToGray();
        public void _SetCardGoldBackgroundToOriginal() => this._Base._CardGoldBackgroundModerator._SetBackgroundOfCardGoldToOriginal();



        #endregion

    }

    public interface _ICardGoldController
    {
        _ICardGoldBase _Base { get; }
        bool _TransferCardGoldToThisField(Transform parent, Vector3 position, _EField field);
        bool _DiscardCardGold();
        void _DisableCardGoldMovementAndInteraction();
        // Get

        // Set
        void _SetCardGoldMovementDisable();
        void _SetCardGoldBackgroundToGray();
        void _SetCardGoldBackgroundToOriginal();
    }
}
