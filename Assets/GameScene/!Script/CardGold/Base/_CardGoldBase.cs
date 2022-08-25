using UnityEngine;

using _cov._Enum;

namespace _cov._CardGold
{
    public class _CardGoldBase : MonoBehaviour, _ICardGoldBase
    {
        public Transform _GameManager => GameObject.Find("GameManager").transform;
        public _ICardGoldManager _CardGoldManager => this._GameManager.GetComponentInChildren<_CardGoldManager>();
        public _ICardGoldBackgroundModerator _CardGoldBackgroundModerator => this.transform.GetComponent<_CardGoldBackgroundModerator>();


        private _EField _currentField = _EField.Null;
        public _EField _CurrentField { get => this._currentField; set => this._currentField = value; }


        private _EGameState _currentGameState = _EGameState.Null;
        public _EGameState _CurrentGameState { get => _currentGameState; set => _currentGameState = value; }

    }
    public interface _ICardGoldBase
    {
        Transform _GameManager { get; }
        _ICardGoldBackgroundModerator _CardGoldBackgroundModerator { get; }
        _ICardGoldManager _CardGoldManager { get; }
        _EField _CurrentField { get; set; }
        _EGameState _CurrentGameState { get; set; }
    }
}
