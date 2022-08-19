using System.Collections.Generic;
using UnityEngine;

namespace _cov._FieldDraw
{

    public class _FieldPileController : MonoBehaviour, _IFieldPileController
    {
        #region --- Public method ---
        // Get
        public Transform _GetFieldPileAddonReference()
        {
            return this.transform.Find(_SFieldDrawName._PileAddonName).transform;
        }

        // Check
        public bool __IsFieldPileFree()
        {
            return _getChildNumber() >= 1 ? false : true;
        }
        #endregion

        #region --- Private method ---
        private int _getChildNumber()
        {
            int value = this.transform.Find(_SFieldDrawName._PileAddonName).childCount;
            return value;
        }
        #endregion
    }

    public interface _IFieldPileController
    {
        Transform _GetFieldPileAddonReference();
        bool __IsFieldPileFree();
    }

}
