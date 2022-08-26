using UnityEngine;

using _cov._Common;
using _cov._Table;

namespace _cov._CardCastle
{
    public class _CardCastleManager : MonoBehaviour, _ICardCastleManager
    {
        public _TableSpriteNumber _TableOfCardCastleNumber => _CommonManager._GameManager.GetComponentInChildren<_TableSpriteNumber>();

        #region --- Castle card graphic ---
        [Header("Castle card sprite references.")]

        [SerializeField] private Sprite _cardCastleLevelOneSprite;
        public Sprite _CardCastleLevelOneSprite => _cardCastleLevelOneSprite;

        [SerializeField] private Sprite _cardCastleLevelTwoSprite;
        public Sprite _CardCastleLevelTwoSprite => _cardCastleLevelTwoSprite;

        [SerializeField] private Sprite _cardCastleLevelThreeSprite;
        public Sprite _CardCastleLevelThreeSprite => _cardCastleLevelThreeSprite;

        [SerializeField] private Sprite _cardCastleLevelFourSprite;
        public Sprite _CardCastleLevelFourSprite => _cardCastleLevelFourSprite;

        #endregion

        #region --- Castle basis stats ---
        [Header("Castle basis stats.")]

        [SerializeField] private int _cardCastleLife = 9;
        public int _CardCastleLife => _cardCastleLife;

        [SerializeField] private int _cardCastleArmor = 1;
        public int _CardCastleArmor => _cardCastleArmor;

        #endregion

        #region --- Castle card tier setting ---
        [Header("Gold needed for castle upgrades.")]

        [SerializeField] private int _goldNeedeForLevelTwo = 3;
        public int _GoldNeedeForLevelTwo => _goldNeedeForLevelTwo;

        [SerializeField] private int _goldNeedeForLevelThree = 4;
        public int _GoldNeedeForLevelThree => _goldNeedeForLevelThree;

        [SerializeField] private int _goldNeedeForLevelFour = 6;
        public int _GoldNeedeForLevelFour => _goldNeedeForLevelFour;

        #endregion
    }

    public interface _ICardCastleManager
    {
        Sprite _CardCastleLevelFourSprite { get; }
        Sprite _CardCastleLevelOneSprite { get; }
        Sprite _CardCastleLevelThreeSprite { get; }
        Sprite _CardCastleLevelTwoSprite { get; }

        int _CardCastleLife { get; }
        int _CardCastleArmor { get; }

        int _GoldNeedeForLevelTwo { get; }
        int _GoldNeedeForLevelThree { get; }
        int _GoldNeedeForLevelFour { get; }

        _TableSpriteNumber _TableOfCardCastleNumber { get; }
    }
}
