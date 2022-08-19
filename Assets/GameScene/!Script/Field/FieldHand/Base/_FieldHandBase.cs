using UnityEngine;

namespace _cov._FieldHand
{
    public class _FieldHandBase : MonoBehaviour, _IFieldHandBase
    {
        public Transform _GameManager => GameObject.Find("GameManager").transform;

        public _IFieldHandManager _FieldDrawManager => this._GameManager.transform.GetComponentInChildren<_FieldHandManager>();
        public _IFieldHandSlotModerator _FieldHandSlotModerator => this.transform.GetComponent<_FieldHandSlotModerator>();
    }
    public interface _IFieldHandBase
    {
        _IFieldHandManager _FieldDrawManager { get; }
        Transform _GameManager { get; }
        _IFieldHandSlotModerator _FieldHandSlotModerator { get; }
    }
}