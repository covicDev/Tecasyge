using UnityEngine;

namespace _cov._FieldHand
{
    public class _FieldHandSlotController : MonoBehaviour
    {
        #region --- Public method ---
        // Get
        public Transform _GetFieldHandSlotAddonReference()
        {
            return this.transform.Find(_SFieldHandName._SlotAddonName).transform;
        }

        // Check
        public bool __IsThereFieldHandSlotFree()
        {
            return _getChildNumber() >= 1 ? false : true;
        }
        #endregion

        #region --- Private method ---
        private int _getChildNumber()
        {
            int value = this.transform.Find(_SFieldHandName._SlotAddonName).childCount;
            return value;
        }
        #endregion
    }
}
