using UnityEngine;

using _cov._Enum;

namespace _cov._FieldHand
{
    public class _FieldHandController : MonoBehaviour, _IFieldHandController
    {
        public _IFieldHandBase _Base => this.transform.GetComponent<_FieldHandBase>();

        public _EField _FieldType => this._Base._FieldHandManager._FieldType;

        private void Start()
        {
            // Preparation for hand slots.
            this._Base._FieldHandSlotModerator._PrepareHandSlots();
        }
    }

    public interface _IFieldHandController
    {
        _IFieldHandBase _Base { get; }
        _EField _FieldType { get; }
    }
}
