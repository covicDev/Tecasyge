using System.Collections.Generic;
using UnityEngine;

namespace _cov._FieldHand
{
    public class _FieldHandSlotModerator : MonoBehaviour, _IFieldHandSlotModerator
    {
        public _IFieldHandBase _FieldHandBase => this.transform.GetComponent<_FieldHandBase>();

        private List<GameObject> _fieldSlotList = new List<GameObject>();

        private float _currentXPosition;
        private int _currentAmountOfCardOnHand;

        #region --- Public method ---
        public Transform _GetNextFreeFieldHandSlotAddonTranform()
        {
            foreach (var item in _fieldSlotList)
            {
                if (item.transform.GetComponent<_FieldHandSlotController>().__IsThereFieldHandSlotFree() == true)
                {
                    return item.transform.Find(_SFieldHandName._SlotAddonName).transform;
                }
            }
            throw new System.Exception("0x0002 Out of boundaries.");
        }

        public bool __CheckIsThereAnyFieldHandSlotFree()
        {
            foreach (var item in this._fieldSlotList)
            {
                if (item.transform.GetComponent<_FieldHandSlotController>().__IsThereFieldHandSlotFree() == true)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region --- Preparation ---
        public void _PrepareHandSlots()
        {
            var fieldSlotPrefab = this._FieldHandBase._FieldSlotPrefab;
            var fieldSlotParent = this.transform.Find(_SFieldHandName._SlotName);

            _currentXPosition = this._FieldHandBase._FieldHandManager._XStartPostion;
            _currentAmountOfCardOnHand = this._FieldHandBase._FieldHandManager._MaxCurrentCardNumberOnHand;

            for (int i = 0; i < _currentAmountOfCardOnHand; i++)
            {
                var position = new Vector3(this.transform.position.x + _currentXPosition, this.transform.position.y, this.transform.position.z);
                var data = Instantiate(fieldSlotPrefab, position, Quaternion.identity);
                data.transform.SetParent(fieldSlotParent);
                _fieldSlotList.Add(data);
                _currentXPosition += this._FieldHandBase._FieldHandManager._XJump;

            }
        }
        #endregion
    }
    public interface _IFieldHandSlotModerator
    {
        void _PrepareHandSlots();
        Transform _GetNextFreeFieldHandSlotAddonTranform();
        bool __CheckIsThereAnyFieldHandSlotFree();
    }
}
