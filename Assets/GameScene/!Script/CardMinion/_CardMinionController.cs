using UnityEngine;

namespace _cov._CardMinion
{
    public class _CardMinionController : MonoBehaviour, _ICardMinionController
    {
        public _ICardMinionBase _Base => this.transform.GetComponent<_CardMinionBase>();

        #region --- Serialize fields ---
        [Tooltip("It needs references to sprite object which contains following sprites.")]
        [Header("Graphic's sprite objects:")]
        [Space(10)]
        [SerializeField] GameObject _PortraitSprite;
        [SerializeField] GameObject _AttackValueSprite;
        [SerializeField] GameObject _LifeValueSprite;
        [SerializeField] GameObject _ArmorValueSprite;
        [SerializeField] GameObject _GoldValueSprite;

        #endregion

        private void Start()
        {
            // Preparation for stats moderator.
            _Base._CardMinionStatsModerator._PrepareCardMinionBasisStats();

            // Preparation for graphic adapter.
            _prepareCardGraphicAdapter();
        }

        #region --- Private method ---

        #region --- Preparations ---

        /// <summary>
        /// Method prepares basis stats for graphic adapter.
        /// </summary>
        private void _prepareCardGraphicAdapter()
        {
            // Sets references to spite values.
            this._Base._CardMinionGraphicAdapter._SetReferencesToValueSprites(
            _AttackValueSprite,
            _LifeValueSprite,
            _ArmorValueSprite,
            _GoldValueSprite,
            _PortraitSprite
                );

            // Sets the start values of minion.
             this._Base._CardMinionGraphicAdapter._SetStartValues(this._Base._CardMinionStatsModerator._GetCurrentStatsStruct());

            // Sets the sprites of numbers.
            var data = this._Base._CardMinionManager._TableOfMinionSprites;
            this._Base._CardMinionGraphicAdapter._SetNormalNumber(sprites: data._SpriteNormalNumber);
            this._Base._CardMinionGraphicAdapter._SetUnderNumber(sprites: data._SpriteUnderNumber);
            this._Base._CardMinionGraphicAdapter._SetOverNumber(sprites: data._SpriteOverNumber);
            this._Base._CardMinionGraphicAdapter._SetWrongNumber(sprites: data._SpriteWrongNumber);

            // Start first render
            this._Base._CardMinionGraphicAdapter._FirstRender();
        }
        #endregion

        #endregion

        #region --- Public method ---

        #endregion

    }
    public interface _ICardMinionController
    {
        _ICardMinionBase _Base { get; }
    }
}
