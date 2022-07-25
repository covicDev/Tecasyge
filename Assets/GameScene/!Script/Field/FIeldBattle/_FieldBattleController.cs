using UnityEngine;

namespace _cov._FieldBattle
{
    public class _FieldBattleController : MonoBehaviour, _IFieldBattleController
    {
        public _IFieldBattleBase _Base => this.transform.GetComponent<_FieldBattleBase>();
        public _Enum._EField _FieldType => _Enum._EField.Battlefield;
    }

    public interface _IFieldBattleController
    {
        _IFieldBattleBase _Base { get; }
        _Enum._EField _FieldType { get; }
    }
}