using UnityEngine;

namespace _cov._CardGold
{
    public class _CardGoldBase : MonoBehaviour, _ICardGoldBase
    {
        public Transform _GameManager => GameObject.Find("GameManager").transform;
        public _ICardGoldManager _CardGoldManager => this._GameManager.GetComponentInChildren<_CardGoldManager>();
        public _ICardGoldBackgorundModerator _CardGoldBackgorundModerator => this.transform.GetComponent<_CardGoldBackgorundModerator>();
    }
    public interface _ICardGoldBase
    {
        Transform _GameManager { get; }
        _ICardGoldBackgorundModerator _CardGoldBackgorundModerator { get; }
        _ICardGoldManager _CardGoldManager { get; }
    }
}
