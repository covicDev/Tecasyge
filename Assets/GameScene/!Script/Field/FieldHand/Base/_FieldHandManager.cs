using UnityEngine;

using _cov._Enum;

namespace _cov._FieldHand
{
    public class _FieldHandManager : MonoBehaviour, _IFieldHandManager
    {
        [SerializeField] _EField _fieldType = _EField.Pile;
        public _EField _FieldType => this._fieldType;

        [Header("Amount of max card that could be on hand.")]
        [SerializeField] int _maxCardNumberOnHand = 10;
        public int _MaxCardNumberOnHand => this._maxCardNumberOnHand;

        [Header("Amount of start card that could be on hand.")]
        [SerializeField] int _maxCurrentCardNumberOnHand = 5;
        public int _MaxCurrentCardNumberOnHand => this._maxCurrentCardNumberOnHand;

        #region --- Coordinates of hand slots ---
        [Header("Position of card hand slots.")]
        [SerializeField] float _xStartPostion = 0;
        public float _XStartPostion => this._xStartPostion;
        [SerializeField] float _xJump = 0;
        public float _XJump => this._xJump;

        #endregion
    }

    public interface _IFieldHandManager
    {
        _EField _FieldType { get; }
        int _MaxCardNumberOnHand { get; }
        int _MaxCurrentCardNumberOnHand { get; }

        float _XStartPostion { get; }
        float _XJump { get; }

    }
}
