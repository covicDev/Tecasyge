using UnityEngine;
using UnityEngine.UI;

namespace _cov._CardMinion
{
    public class _CardMinionGraphicAdapter : MonoBehaviour, _ICardMinionGraphicAdapter
    {
        public _ICardMinionBase _CardMinionBase => this.transform.GetComponent<_CardMinionBase>();

        #region --- Variable ---
        private GameObject _AttackValueSprite;
        private GameObject _LifeValueSprite;
        private GameObject _ArmorValueSprite;
        private GameObject _GoldValueSprite;
        private GameObject _PortraitSprite;

        private Sprite[] _normalNumber;
        private Sprite[] _underNumber;
        private Sprite[] _overNumber;
        private Sprite[] _wrongNumber;

        private _SCardMinionStruct _cardMinionBasisStats;
        private _SCardMinionStruct _cardMinionCurrentStats;
        #endregion

        #region --- Public method ---
        /// <summary>
        /// Method runs only once for the first render of card.
        /// It should be run by card minion controller.
        /// </summary>
        public void _FirstRender()
        {
            this._AttackValueSprite.GetComponent<Image>().sprite = this._normalNumber[this._cardMinionBasisStats._Attack];
            this._LifeValueSprite.GetComponent<Image>().sprite = this._normalNumber[this._cardMinionBasisStats._Life];
            this._ArmorValueSprite.GetComponent<Image>().sprite = this._normalNumber[this._cardMinionBasisStats._Armor];
            this._GoldValueSprite.GetComponent<Image>().sprite = this._normalNumber[this._cardMinionBasisStats._Gold];
            this._PortraitSprite.GetComponent<Image>().sprite = this._cardMinionBasisStats._Image;
        }

        /// <summary>
        /// Method runs every time card stat changes.
        /// It render graphic field of card according to the stats of card.
        /// </summary>
        public void _Render()
        {
            // Takes current card minion stats.
            this._cardMinionCurrentStats = this._CardMinionBase._CardMinionStatsModerator._GetCurrentStatsStruct();

            // done only for Gold and Life amount.
            this._updateGoldAmount();
        }

        /// <summary>
        /// Method updates current stats of the card.
        /// </summary>
        public void _UpdateStats(_SCardMinionStruct currentStats)
        {
            this._cardMinionCurrentStats = currentStats;
        }

        #region --- Basic sets ---
        public void _SetStartValues(_SCardMinionStruct _struct)
        {
            this._cardMinionBasisStats = _struct;
            this._cardMinionCurrentStats = _struct;
        }

        /// <summary>
        /// Sets references for sprites field of the card:
        /// image, life, armor, gold.
        /// </summary>
        /// <param name="AttackValueSprite"></param>
        /// <param name="LifeValueSprite"></param>
        /// <param name="ArmorValueSprite"></param>
        /// <param name="GoldValueSprite"></param>
        /// <param name="PortraitSprite"></param>
        public void _SetReferencesToValueSprites(
            in GameObject AttackValueSprite,
            in GameObject LifeValueSprite,
            in GameObject ArmorValueSprite,
            in GameObject GoldValueSprite,
            in GameObject PortraitSprite
            )
        {
            this._AttackValueSprite = AttackValueSprite;
            this._LifeValueSprite = LifeValueSprite;
            this._ArmorValueSprite = ArmorValueSprite;
            this._GoldValueSprite = GoldValueSprite;
            this._PortraitSprite = PortraitSprite;
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

        #endregion

        #region --- Private method ----
        private void _updateGoldAmount()
        {
            int baseGold = this._cardMinionBasisStats._Gold;
            int currentGold = this._cardMinionCurrentStats._Gold;

            if (currentGold == baseGold)
            {
                this._GoldValueSprite.GetComponent<Image>().sprite = this._normalNumber[currentGold];
                return;
            }

            if (currentGold < baseGold)
            {
                this._GoldValueSprite.GetComponent<Image>().sprite = this._underNumber[currentGold];
                return;
            }

            if(currentGold > baseGold)
            {
                this._GoldValueSprite.GetComponent<Image>().sprite = this._overNumber[currentGold];
                return;
            }
        }

        #endregion
    }

    public interface _ICardMinionGraphicAdapter
    {
        void _FirstRender();
        void _Render();
        void _UpdateStats(_SCardMinionStruct currentStats);

        void _SetStartValues(_SCardMinionStruct _struct);
        void _SetNormalNumber(in Sprite[] sprites);
        void _SetUnderNumber(in Sprite[] sprites);
        void _SetOverNumber(in Sprite[] sprites);
        void _SetWrongNumber(in Sprite[] sprites);


        void _SetReferencesToValueSprites(
            in GameObject AttackValueSprite,
            in GameObject LifeValueSprite,
            in GameObject ArmorValueSprite,
            in GameObject GoldValueSprite,
            in GameObject PortraitSprite
            );

    }
}
