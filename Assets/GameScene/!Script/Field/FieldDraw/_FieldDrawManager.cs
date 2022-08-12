using UnityEngine;

using _cov._Enum;

namespace _cov._FieldDraw
{
    public class _FieldDrawManager : MonoBehaviour, _IFieldDrawManager
    {
        [SerializeField] _EField _fieldType = _EField.Pile;
        public _EField _FieldType => this._fieldType;
    }
    public interface _IFieldDrawManager
    {
        _EField _FieldType { get; }
    }
}
