using UnityEngine;
using UnityEngine.UI;

namespace _cov._CardCastle
{
    public class _CardCastleGraphicAdapter : MonoBehaviour, _ICardCastleGraphicAdapter
    {
        #region --- Variable ---
        private GameObject _LifeValueSprite;
        private GameObject _ArmorValueSprite;
        private GameObject _GoldValueSprite;

        private Sprite[] _normalNumber;
        private Sprite[] _underNumber;
        private Sprite[] _overNumber;
        private Sprite[] _wrongNumber;

        private _SCardCastleStruct _cardCastleBasisStats;
        private _SCardCastleStruct _cardCastleCurrentStats;

        #endregion

        public void _FirstRender()
        {
            this._LifeValueSprite.GetComponent<Image>().sprite = this._normalNumber[this._cardCastleBasisStats._Life];
            this._ArmorValueSprite.GetComponent<Image>().sprite = this._normalNumber[this._cardCastleBasisStats._Armor];
            this._GoldValueSprite.GetComponent<Image>().sprite = this._normalNumber[this._cardCastleBasisStats._Gold];
        }

        #region --- Basic sets ---

        public void _SetStartValues(_SCardCastleStruct _struct)
        {
            this._cardCastleBasisStats = _struct;
            this._cardCastleCurrentStats = _struct;
        }

        public void _SetReferencesToValueSprites(
             in GameObject LifeValueSprite,
             in GameObject ArmorValueSprite,
             in GameObject GoldValueSprite)
        {
            this._LifeValueSprite = LifeValueSprite;
            this._ArmorValueSprite = ArmorValueSprite;
            this._GoldValueSprite = GoldValueSprite;
        }
        public void _SetNormalNumber(in Sprite[] sprites)
        {
            this._normalNumber = sprites;
        }
        public void _SetUnderNumber(in Sprite[] sprites)
        {
            this._underNumber = sprites;
        }
        public void _SetOverNumber(in Sprite[] sprites)
        {
            this._overNumber = sprites;
        }
        public void _SetWrongNumber(in Sprite[] sprites)
        {
            this._wrongNumber = sprites;
        }

        #endregion
    }
    public interface _ICardCastleGraphicAdapter
    {
        void _FirstRender();

        // Basic sets.
        void _SetStartValues(_SCardCastleStruct _struct);
        void _SetReferencesToValueSprites(
            in GameObject LifeValueSprite,
            in GameObject ArmorValueSprite,
            in GameObject GoldValueSprite);
        void _SetNormalNumber(in Sprite[] sprites);
        void _SetUnderNumber(in Sprite[] sprites);
        void _SetOverNumber(in Sprite[] sprites);
        void _SetWrongNumber(in Sprite[] sprites);
    }
}
