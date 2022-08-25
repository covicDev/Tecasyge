using System.Collections.Generic;
using UnityEngine;

namespace _cov._FieldDraw
{
    public class _FieldDrawPileModerator : MonoBehaviour, _IFieldDrawPileModerator
    {
        public _IFieldDrawBase _Base => this.transform.GetComponent<_FieldDrawBase>();

        #region --- Public variable ---
        public bool __CheckIsAnyFieldPileFree => this._checkIsAnyFieldPileFree();

        #endregion

        #region --- Private variable ---
        private List<GameObject> _fieldPileList = new List<GameObject>();

        private float _fieldPileXPostion;
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
        public void _RemoveRemainedCardsOnPileAddon()
        {
            foreach (var item in _fieldPileList)
            {
                if (item.transform.GetComponent<_FieldPileController>().__IsFieldPileFree() != true)
                {
                    var comp = item.transform.Find(_SFieldDrawName._PileAddonName).transform.GetComponentsInChildren<Component>();
                    foreach (var card in comp)
                    {
                        if ((card is Transform) == false)
                        {
                            Destroy(card.gameObject);
                        }
                    }
                }
            }
        }

        #endregion

        #region --- Preparation ---
        public void _PrepareFieldPileSlots()
        {
            var fieldPilePrefab = this._Base._FieldPilePrefab;
            var fieldPileParent = this.transform.Find(_SFieldDrawName._SlotName);

            var _fieldPileXPostion = this._Base._FieldDrawManager._FieldPileXPosition;
            var position = new Vector3(this.transform.position.x + _fieldPileXPostion, this.transform.position.y, this.transform.position.z);

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
        _IFieldDrawBase _Base { get; }
        bool __CheckIsAnyFieldPileFree { get; }
        Transform _GetNextFreeFieldPileAddonTranform();
        void _PrepareFieldPileSlots();
        void _RemoveRemainedCardsOnPileAddon();

    }
}
