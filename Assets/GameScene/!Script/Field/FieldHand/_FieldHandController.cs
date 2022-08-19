using UnityEngine;

namespace _cov._FieldHand
{
    public class _FieldHandController : MonoBehaviour
    {
        public _IFieldHandBase _Base => this.transform.GetComponent<_FieldHandBase>();
        private void Start()
        {
            // Preparation for hand slots.
            this._Base._FieldHandSlotModerator._PrepareHandSlots();
        }
    }
}
