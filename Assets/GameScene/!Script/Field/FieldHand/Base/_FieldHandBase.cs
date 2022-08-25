using UnityEngine;
using _cov._Struct;

namespace _cov._FieldHand
{
    public class _FieldHandBase : MonoBehaviour, _IFieldHandBase
    {
        public Transform _GameManager => GameObject.Find("GameManager").transform;
        public _IFieldHandManager _FieldHandManager => this._GameManager.transform.GetComponentInChildren<_FieldHandManager>();
        public _IFieldHandSlotModerator _FieldHandSlotModerator => this.transform.GetComponent<_FieldHandSlotModerator>();
        public _IFieldHandBackgroundModerator _FieldHandBackgroundModerator => this.transform.GetComponent<_FieldHandBackgroundModerator>();
        public GameObject _FieldSlotPrefab => Resources.Load(_SName._ResourceFieldSlot, typeof(GameObject)) as GameObject;
    }
    public interface _IFieldHandBase
    {
        _IFieldHandManager _FieldHandManager { get; }
        Transform _GameManager { get; }
        _IFieldHandSlotModerator _FieldHandSlotModerator { get; }
        _IFieldHandBackgroundModerator _FieldHandBackgroundModerator { get; }
        GameObject _FieldSlotPrefab { get; }
    }
}