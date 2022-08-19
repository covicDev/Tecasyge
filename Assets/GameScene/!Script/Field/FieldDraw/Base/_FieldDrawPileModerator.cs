using System.Collections.Generic;
using UnityEngine;

namespace _cov._FieldDraw
{
    public class _FieldDrawPileModerator : MonoBehaviour, _IFieldDrawPileModerator
    {
        public _IFieldDrawBase _FieldDrawBase => this.transform.GetComponent<_FieldDrawBase>();

        #region --- Public variable ---
        public bool __CheckIsAnyFieldPileFree => this._checkIsAnyFieldPileFree();

        #endregion

        #region --- Private variable ---
        private List<GameObject> _fieldPileList = new List<GameObject>();

        #endregion

        // ---

        #region --- Public method ---
        public Transform _GetNextFreeFieldPileAddonTranform()
        {
            foreach (var item in _fieldPileList)
            {
                if (item.transform.GetComponent<_FieldPileController>().__IsFieldPileFree() == true)
                {
                    return item.transform.Find(_SFieldDrawName._PileAddonName).transform;
                }
            }
            throw new System.Exception("0x0002 Out of boundaries.");
        }

        

        #endregion

        #region --- Preparation ---
        public void _PrepareFieldPileSlots()
        {
            var fieldPilePrefab = this._FieldDrawBase._FieldPilePrefab;
            var fieldPileParent = this.transform.Find(_SFieldDrawName._SlotName);

            // <todo> Better placing algorithm.
            var position = new Vector3(this.transform.position.x - 2, this.transform.position.y, this.transform.position.z);

            var data = Instantiate(fieldPilePrefab, position, Quaternion.identity);
            data.transform.SetParent(fieldPileParent);
            _fieldPileList.Add(data);
        }
        #endregion

        #region --- Private method ---

        // check
        public bool _checkIsAnyFieldPileFree()
        {
            foreach (var item in _fieldPileList)
            {
                if (item.transform.GetComponent<_FieldPileController>().__IsFieldPileFree() == true)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

    }
    public interface _IFieldDrawPileModerator
    {
        _IFieldDrawBase _FieldDrawBase { get; }
        bool __CheckIsAnyFieldPileFree { get; }
        Transform _GetNextFreeFieldPileAddonTranform();
        void _PrepareFieldPileSlots();
        
    }
}
