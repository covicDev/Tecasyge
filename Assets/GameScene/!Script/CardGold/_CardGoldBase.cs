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
        public _EField _CurrentField
        {
            get
            {
                return this._currentField;
            }
            set
            {
                this._currentField = value;
            }
        }

    }
    public interface _ICardGoldBase
    {
        Transform _GameManager { get; }
        _ICardGoldBackgroundModerator _CardGoldBackgroundModerator { get; }
        _ICardGoldManager _CardGoldManager { get; }
        _EField _CurrentField { get; set; }
    }
}
