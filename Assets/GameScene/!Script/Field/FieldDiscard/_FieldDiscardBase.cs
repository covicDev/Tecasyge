using UnityEngine;

using _cov._Enum;
namespace _cov._FieldDiscard
{


    public class _FieldDiscardBase : MonoBehaviour, _IFieldDiscardBase
    {
        public Transform _GameManager => GameObject.Find("GameManager").transform;
        public _IFieldDiscardBackgroundModerator _FieldDiscardBackgroundModerator => this.transform.GetComponent<_FieldDiscardBackgroundModerator>();
        public _EField _FieldType => _EField.Discard;
    }

    public interface _IFieldDiscardBase
    {
        Transform _GameManager { get; }
        _IFieldDiscardBackgroundModerator _FieldDiscardBackgroundModerator { get; }
        _EField _FieldType { get; }
    }
}
