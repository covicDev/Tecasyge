using UnityEngine;

namespace _cov._FieldBattle
{
    public class _FieldBattleBase : MonoBehaviour, _IFieldBattleBase
    {
        public Transform _GameManager => GameObject.Find("GameManager").transform;

        #region --- References of card minion classes ---
        public _IFieldBattleManager _FieldBattleManage => GameObject.Find("GameManager").transform.GetComponentInChildren<_FieldBattleManager>();
        public _IFieldBattleBackgroundModerator _FieldBattleBackgroundModerator => this.transform.GetComponent<_FieldBattleBackgroundModerator>();
        #endregion
    }
    public interface _IFieldBattleBase
    {
        Transform _GameManager { get; }
        _IFieldBattleManager _FieldBattleManage { get; }
        _IFieldBattleBackgroundModerator _FieldBattleBackgroundModerator { get; }
    }
}
