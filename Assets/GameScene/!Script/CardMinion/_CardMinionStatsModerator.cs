using UnityEngine;

namespace _cov._CardMinion
{
    public class _CardMinionStatsModerator : MonoBehaviour, _ICardMinionStatsModerator
    {
        #region --- Variable ---
        public _ICardMinionController _cardMinionController => this.transform.GetComponent<_CardMinionController>();

        // Store in struct card minion stats.
        private _SCardMinionStruct _baseStats;
        private _SCardMinionStruct _currentStats;
        public _SCardMinionStruct _GetCurrentStatsStruct() => _currentStats;

        #endregion

        #region --- Public method ---

        #region --- Basic sets ---
        /// <summary>
        /// Method takes and prepare basic stats for minion card.
        /// </summary>
        public void _PrepareCardMinionBasisStats()
        {
            var maker = _cardMinionController._Base._CardMinionManager._CardMinionStatsMaker;
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
    }
    public interface _ICardMinionStatsModerator
    {
        _SCardMinionStruct _GetCurrentStatsStruct();
        void _PrepareCardMinionBasisStats();
    }
}
