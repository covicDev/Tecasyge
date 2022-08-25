using UnityEngine;

using _cov._Enum;

namespace _cov._FieldDraw
{
    public class _FieldDrawManager : MonoBehaviour, _IFieldDrawManager
    {
        [SerializeField] _EField _fieldType = _EField.Pile;
        public _EField _FieldType => this._fieldType;

        [Header("Position of field piles.")]
        [SerializeField] float _fieldPileXPosition = -150;
        public float _FieldPileXPosition => _fieldPileXPosition;

    }
    public interface _IFieldDrawManager
    {
        _EField _FieldType { get; }
        float _FieldPileXPosition { get; }
    }
}
