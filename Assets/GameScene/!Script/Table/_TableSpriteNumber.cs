using UnityEngine;

namespace _cov._Table
{
    public class _TableSpriteNumber : MonoBehaviour
    {
        [Header("Table of normal number sprites.")]
        [Space(10)]
        [SerializeField] Sprite[] _NormalNumber;

        [Header("Table of under number sprites.")]
        [Space(10)]
        [SerializeField] Sprite[] _UnderNumber;

        [Header("Table of over number sprites.")]
        [Space(10)]
        [SerializeField] Sprite[] _OverNumber;

        [Header("Table of wrong number sprites.")]
        [Space(10)]
        [SerializeField] Sprite[] _WrongNumber;

        public Sprite[] _SpriteNormalNumber => this._NormalNumber;
        public Sprite[] _SpriteUnderNumber => this._UnderNumber;
        public Sprite[] _SpriteOverNumber => this._OverNumber;
        public Sprite[] _SpriteWrongNumber => this._WrongNumber;

        public Sprite _GetNormalSprite(int index) => this._NormalNumber[index];
        public Sprite _GetUnderSprite(int index) => this._UnderNumber[index];
        public Sprite _GetOverSprite(int index) => this._OverNumber[index];
        public Sprite _GetWrongSprite(int index) => this._WrongNumber[index];
    }
}