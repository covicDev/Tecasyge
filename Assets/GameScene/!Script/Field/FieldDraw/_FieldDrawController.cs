using UnityEngine;

using _cov._Enum;
using _cov._GameState;

namespace _cov._FieldDraw
{
    public class _FieldDrawController : MonoBehaviour, _IFieldDrawController, _IGameStateHandler
    {
        public _IFieldDrawBase _Base => this.transform.GetComponent<_FieldDrawBase>();

        private _IGameStateController _gameStateController => this._Base._GameManager.GetComponentInChildren<_GameStateController>();

        private void Start()
        {
            // Attach as a Game state handler.
            this._gameStateController._Attach(this);

            // Preps for field pile slots.
            this._Base._FieldDrawPileModerator._PrepareFieldPileSlots();
        }

        #region --- Preparations ---
        #endregion

        #region --- Public method ---
        public void _GetNextCard()
        {
            // Checks if it's a Draw turn, if not -> return;
            if (this._gameStateController._GameCurrentState != _EGameState.Draw) return;

            // Checks is any pile field is free.
            if(this._Base._FieldDrawPileModerator.__CheckIsAnyFieldPileFree == false)
            {
                this._Base._FieldDrawBackgroundModerator._SetBackgroundOfFieldDrawDenial();
                return;
            }

            this._Base._FieldDrawBackgroundModerator._SetBackgroundOfFieldDrawApproval();

            // Draw new card.
            int randNumber = Random.Range(0, 2);

            // Get free pile field.
            var pileFieldAddon = this._Base._FieldDrawPileModerator._GetNextFreeFieldPileAddonTranform();

            // Draw card
            if (randNumber == 0)
            {
                var minionCard = Instantiate(this._Base._CardMinionPrefab, pileFieldAddon.position, Quaternion.identity);
                var minionScript = minionCard.transform.GetComponent<_CardMinion._CardMinionController>();
                minionScript._TransferCardMinionToThisField(pileFieldAddon, pileFieldAddon.position, this._Base._FieldType);
            }
            else
            {
                var goldCard = Instantiate(this._Base._CardGoldPrefab, pileFieldAddon.position, Quaternion.identity);
                goldCard.transform.SetParent(pileFieldAddon);

                goldCard.GetComponent<Canvas>().overrideSorting = true;
                var goldScript = goldCard.transform.GetComponent<_CardGold._CardGoldController>();
                goldScript._TransferCardGoldToThisField(pileFieldAddon, pileFieldAddon.position, this._Base._FieldType);
            } 
        }

        // As game state Handler.
        public void _UpdateGameStatus(_EGameState currentGameState)
        {
            // Checks if is not a Draw turn.
            if (this._gameStateController._GameCurrentState != _EGameState.Draw)
            {
                this._Base._FieldDrawBackgroundModerator._SetBackgroundOfFieldDrawToGrey();
                this.transform.GetComponent<_FieldDrawInteraction>().enabled = false;

                // Remove all remaining cards of Pile field.
                this._Base._FieldDrawPileModerator._RemoveRemainedCardsOnPileAddon();

                return;
            }

            // Actions for Draw turn.
            this._Base._FieldDrawBackgroundModerator._SetBackgroundOfFieldDrawToOriginal();
            // Disable interaction of Draw field.
            this.transform.GetComponent<_FieldDrawInteraction>().enabled = true;
        }
        #endregion
    }
    public interface _IFieldDrawController
    {
        _IFieldDrawBase _Base { get; }
        void _GetNextCard();
    }
}
