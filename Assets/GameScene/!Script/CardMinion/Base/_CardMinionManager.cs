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

        #region --- Card gold setting ---
        [Header("The position of the gold card assigned to the minion.")]
        [SerializeField] float _cardGoldXJumpPosition = 0f;
        public float _CardGoldXJumpPosition => _cardGoldXJumpPosition;
        #endregion

        #region --- Attack sword reference ---
        [Header("Attack Sword reference.")]
        [SerializeField] private Transform _swordAttackReference;
        public Transform _SwordAttackReference => _swordAttackReference;
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
        float _CardGoldXJumpPosition { get; }
        Transform _SwordAttackReference { get; }
    }
}
