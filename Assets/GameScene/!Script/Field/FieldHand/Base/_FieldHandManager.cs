using UnityEngine;

using _cov._Enum;

namespace _cov._FieldHand
{
    public class _FieldHandManager : MonoBehaviour, _IFieldHandManager
    {
        [SerializeField] _EField _fieldType = _EField.Pile;
        public _EField _FieldType => this._fieldType;
    }

    public interface _IFieldHandManager
    {
        _EField _FieldType { get; }
    }
}
