﻿using UnityEngine;

namespace _cov._CardMinion
{
    public class _CardMinionStatsModerator : MonoBehaviour, _ICardMinionStatsModerator
    {
        #region --- Variable ---
        public _ICardMinionBase _CardMinionBase => this.transform.GetComponent<_CardMinionBase>();

        // Store in struct card minion stats.
        private _SCardMinionStruct _baseStats;
        private _SCardMinionStruct _currentStats;
        public _SCardMinionStruct _GetCurrentStatsStruct() => _currentStats;

        //Boolean checking the states of minion. 
        // Checks if minion is on battle field, it means check if minion can be attacked
        private bool __onBattlefield = false;
        // Checks if minion is attacking right now
        private bool __onAttackMode = false;
        // Checks if minion handle the condition to attack other cards
        private bool __canAttackOthers = false;
        // Checks if minion handle the condition to be attacked by others
        private bool __canBeTargetOfAttack = false;

        #endregion

        #region --- Public method ---

        public void _UpdateCardMinionStats()
        {

            this._updateCardGoldAmount();
            this._updateCardMinionAttackPossibility();

        }
        
        #region --- Check ---
        public bool _CheckIfGoldCardCanBeGivenToThisMinion()
        {
            // Checks if it Place turn.
            if (this._CardMinionBase._GameCurrentState != _Enum._EGameState.Place) return false;

            // Checks if minion card is on battlefield.
            if (this._CardMinionBase._CardMinionFieldModerator._GetCurrentField() != _Enum._EField.Battlefield) return false;

            // Check if minion can get more gold card.
            if (this._checkIfCardMinionCanGetMoreCardGold() != true) return false;

            return true;
        }

        public bool _CheckIfMinionCanAttackOthers()
        {
            return this.__canAttackOthers;
        }

        #region --- Get ---
        public int _GetCardGoldAmount()
        {
            return this._currentStats._Gold;
        }
        #endregion

        #endregion

        #region --- Basic sets ---
        /// <summary>
        /// Method takes and prepare basic stats for minion card.
        /// </summary>
        public void _PrepareCardMinionBasisStats()
        {
            var maker = _CardMinionBase._CardMinionManager._CardMinionStatsMaker;
            _SCardMinionStruct data = maker._MakeMinion(1);
            this._baseStats = new _SCardMinionStruct()
            {
                _Image = data._Image,
                _Attack = data._Attack,
                _Life = data._Life,
                _Armor = data._Armor,
                _Gold = data._Gold,
            };
            this._currentStats = this._baseStats;
        }
        #endregion

        #endregion

        #region --- Private method ---
        // Method updates gold amount.
        private void _updateCardGoldAmount()
        {
            this._currentStats._Gold = this._CardMinionBase._CardGoldParent.childCount;
            this._currentStats._Gold = Mathf.Clamp(this._currentStats._Gold, 0, 9);
        }

        // Method updates card minion attack possibility.
        private void _updateCardMinionAttackPossibility()
        {
            if (this._CardMinionBase._CardMinionFieldModerator.__IsCardMinionOnFieldBattle())
            {
                this.__onBattlefield = true;
                this.__canBeTargetOfAttack = true;
                if (this._currentStats._Gold >= this._baseStats._Gold)
                {
                    this.__canAttackOthers = true;
                }
            }
        }

        private bool _checkIfCardMinionCanGetMoreCardGold()
        {
            if (this._currentStats._Gold < this._baseStats._Gold) return true;
            return false;
        }
        #endregion

    }
    public interface _ICardMinionStatsModerator
    {
        _SCardMinionStruct _GetCurrentStatsStruct();
        void _PrepareCardMinionBasisStats();
        bool _CheckIfGoldCardCanBeGivenToThisMinion();
        bool _CheckIfMinionCanAttackOthers();
        void _UpdateCardMinionStats();
        int _GetCardGoldAmount();
    }
}
