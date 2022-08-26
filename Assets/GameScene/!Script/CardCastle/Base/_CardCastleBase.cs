using UnityEngine;

using _cov._Common;

namespace _cov._CardCastle
{
    public class _CardCastleBase : MonoBehaviour, _ICardCastleBase
    {
        public Transform _GameManager => _CommonManager._GameManager;
        public _ICardCastleManager _CardCastleManager => this._GameManager.GetComponentInChildren<_CardCastleManager>();

        public _ICardCastleGraphicAdapter _CardCastleGraphicAdapter => this.transform.GetComponent<_CardCastleGraphicAdapter>();
        public _ICardCastleStatsModerator _CardCastleStatsModerator => this.transform.GetComponent<_CardCastleStatsModerator>();
    }

    public interface _ICardCastleBase
    {
        Transform _GameManager { get; }
        _ICardCastleManager _CardCastleManager { get; }
        _ICardCastleGraphicAdapter _CardCastleGraphicAdapter { get; }
        _ICardCastleStatsModerator _CardCastleStatsModerator { get; }

    }
}
