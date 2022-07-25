using UnityEngine;

namespace _cov._CardMinion
{
    public class _CardMinionBase : MonoBehaviour, _ICardMinionBase
    {
        public Transform _GameManager => GameObject.Find("GameManager").transform;

        #region --- References of card minion classes ---
        public _ICardMinionManager _CardMinionManager => GameObject.Find("GameManager").transform.GetComponentInChildren<_CardMinionManager>();
        public _ICardMinionGraphicAdapter _CardMinionGraphicAdapter => this.transform.GetComponent<_CardMinionGraphicAdapter>();
        public _ICardMinionStatsModerator _CardMinionStatsModerator => this.transform.GetComponent<_CardMinionStatsModerator>();
        public _ICardMinionBackgroundModerator _CardMinionBackgroundModerator => this.transform.GetComponent<_CardMinionBackgroundModerator>();
        public _ICardMinionTransferModerator _CardMinionTransferModerator => this.transform.GetComponent<_CardMinionTransferModerator>();
        #endregion
    }

    public interface _ICardMinionBase
    {
        Transform _GameManager { get; }
        _ICardMinionManager _CardMinionManager { get; }
        _ICardMinionGraphicAdapter _CardMinionGraphicAdapter { get; }
        _ICardMinionStatsModerator _CardMinionStatsModerator { get; }
        _ICardMinionBackgroundModerator _CardMinionBackgroundModerator { get; }
        _ICardMinionTransferModerator _CardMinionTransferModerator { get; }
    }
}
