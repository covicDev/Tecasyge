using UnityEngine;

namespace _cov._CardGold
{
    public class _CardGoldBase : MonoBehaviour, _ICardGoldBase
    {
        public Transform _GameManager => GameObject.Find("GameManager").transform;
        public _ICardGoldManager _CardGoldManager => this._GameManager.GetComponentInChildren<_CardGoldManager>();
        public _ICardGoldBackgroundModerator _CardGoldBackgroundModerator => this.transform.GetComponent<_CardGoldBackgroundModerator>();

    }
    public interface _ICardGoldBase
    {
        Transform _GameManager { get; }
        _ICardGoldBackgroundModerator _CardGoldBackgroundModerator { get; }
        _ICardGoldManager _CardGoldManager { get; }

    }
}
