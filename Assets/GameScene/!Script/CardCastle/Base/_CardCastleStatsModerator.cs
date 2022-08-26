using UnityEngine;

namespace _cov._CardCastle
{

    public class _CardCastleStatsModerator : MonoBehaviour, _ICardCastleStatsModerator
    {
        public _ICardCastleBase _CardCastleBase => this.transform.GetComponent<_CardCastleBase>();
        public _SCardCastleStruct _GetCurrentStatsStruct() => _currentStats;

        #region --- Variable ---

        // Store in struct card minion stats.
        private _SCardCastleStruct _baseStats;
        private _SCardCastleStruct _currentStats;

        #endregion

        #region --- Basic sets ---
        public void _PrepareCardCastleBasisStats()
        {
            var data = this._CardCastleBase._CardCastleManager;

            this._baseStats = new _SCardCastleStruct()
            {
                _Life = data._CardCastleLife,
                _Armor = data._CardCastleArmor,
                _Gold = data._GoldNeedeForLevelTwo,
                _Tier = 1
            };

            // Struct are not passed by reference.
            this._currentStats = this._baseStats;
        }
        #endregion
    }
    public interface _ICardCastleStatsModerator
    {
        _ICardCastleBase _CardCastleBase { get; }
        _SCardCastleStruct _GetCurrentStatsStruct();
        void _PrepareCardCastleBasisStats();
    }
}
