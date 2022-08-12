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

        #region --- Card minion canvas alpha ---
        [SerializeField] float _cardMinionCanvasAlphaDown = 0.5f;
        public float _CardMinionCanvasAlphaDown => _cardMinionCanvasAlphaDown;
        #endregion

        private void OnValidate()
        {
            this._cardMinionCanvasAlphaDown = Mathf.Clamp(this._cardMinionCanvasAlphaDown, 0f, 1f);
        }

    }
    public interface _ICardMinionManager
    {
        Camera _CameraMain { get; }
        _TableSpriteNumber _TableOfMinionSprites { get; }
        _ICardMinionStatsMaker _CardMinionStatsMaker { get; }
        float _CardMinionCanvasAlphaDown { get; }
    }
}
