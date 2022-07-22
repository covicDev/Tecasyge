using UnityEngine;

using _cov._Table;
using _cov._CardMinion._CardMinionMaker;

namespace _cov._CardMinion
{
    public class _CardMinionManager : MonoBehaviour, _ICardMinionManager
    {
        public Camera _CameraMain => Camera.main;
        public _TableSpriteNumber _TableOfMinionSprites => GameObject.Find("GameManager").transform.GetComponentInChildren<_TableSpriteNumber>();
        public _ICardMinionStatsMaker _CardMinionStatsMaker => GameObject.Find("GameManager").transform.GetComponentInChildren<_CardMinionStatsMaker>();
    }
    public interface _ICardMinionManager
    {
        Camera _CameraMain { get; }
        _TableSpriteNumber _TableOfMinionSprites { get; }
        _ICardMinionStatsMaker _CardMinionStatsMaker { get; }
    }
}
