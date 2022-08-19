using System.Collections.Generic;
using UnityEngine;

namespace _cov._FieldHand
{
    public class _FieldHandSlotModerator : MonoBehaviour, _IFieldHandSlotModerator
    {
        private List<GameObject> _fieldSlotList = new List<GameObject>();

        #region --- Preparation ---
        public void _PrepareHandSlots()
        {

        }
        #endregion
    }
    public interface _IFieldHandSlotModerator
    {
        void _PrepareHandSlots();
    }
}
