using UnityEngine;

namespace _cov._CardCastle
{
    public class _CardCastleController : MonoBehaviour
    {
        public _ICardCastleBase _Base => this.transform.GetComponent<_CardCastleBase>();

        #region --- Serialize fields ---
        [Header("Graphic's sprite objects:")]
        [Space(10)]
        [SerializeField] GameObject _LifeValueSprite;
        [SerializeField] GameObject _ArmorValueSprite;
        [SerializeField] GameObject _GoldValueSprite;

        #endregion

        private void Start()
        {
            // Preparation for stats moderator.
            this._Base._CardCastleStatsModerator._PrepareCardCastleBasisStats();

            // Preparation for graphic adapter.
            _prepareCardCastleGraphicAdapter();

        }

        #region --- Private method ---

        #region --- Preparations ---
        private void _prepareCardCastleGraphicAdapter()
        {
            // Sets references to spite values.
            this._Base._CardCastleGraphicAdapter._SetReferencesToValueSprites(
                _LifeValueSprite,
                _ArmorValueSprite,
                _GoldValueSprite);

            // Sets the start values of castle.
            this._Base._CardCastleGraphicAdapter._SetStartValues(this._Base._CardCastleStatsModerator._GetCurrentStatsStruct());

            // Sets the sprites of numbers.
            var data = this._Base._CardCastleManager._TableOfCardCastleNumber;
            this._Base._CardCastleGraphicAdapter._SetNormalNumber(sprites: data._SpriteNormalNumber);
            this._Base._CardCastleGraphicAdapter._SetUnderNumber(sprites: data._SpriteUnderNumber);
            this._Base._CardCastleGraphicAdapter._SetOverNumber(sprites: data._SpriteOverNumber);
            this._Base._CardCastleGraphicAdapter._SetWrongNumber(sprites: data._SpriteWrongNumber);

            // Start first render
            this._Base._CardCastleGraphicAdapter._FirstRender();


        }
        #endregion

        #endregion
    }
}
